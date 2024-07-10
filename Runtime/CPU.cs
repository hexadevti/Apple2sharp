using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Text;
using Runtime.OpCodeProcessors;
using Runtime.Cards;

namespace Runtime
{
    public class CPU
    {
        public State state { get; set; }
        public MainBoard mainBoard { get; set; }
        public ushort lastPC = 0;
        public DateTime last1mhz = DateTime.MinValue;

        public CPU(State state, MainBoard mainBoard)
        {
            this.mainBoard = mainBoard;
            this.state = state;
            last1mhz = DateTime.Now;
        }

        public void WarmStart()
        {

            mainBoard.ClearBaseRAM();
            Thread.Sleep(100);
            Reset();
            Thread.Sleep(100);
        }
        public void Reset()
        {
            lastPC = 0;
            state.PC = mainBoard.ReadAddressLLHH(0xfffc) ?? 0;
        }

        public void IncPC()
        {
            state.PC++;
        }

        public void RunCycle()
        {
            byte instruction = mainBoard.ReadByte(state.PC);
            //lastPC = state.PC;
            OpCodePart? opCodePart = OpCodes.GetOpCode(instruction);
            // Break point with lastPC
            // if (lastPC == 0xc876)
            // {
            //     Thread.Sleep(1);
            // }
            ushort? refAddress = OpCodes.ProcessAddressing(opCodePart, state, mainBoard, this);
            OpCodes.Process(opCodePart, state, mainBoard, refAddress);
            EnqueueCycles(opCodePart);
        }

        public void EnqueueCycles(OpCodePart? opCodePart)
        {
            int cycles = opCodePart != null ? opCodePart.Cycles : 1;
            for (int i = 0; i < cycles; i++)
            {
                if (mainBoard.adjust1Mhz || (!mainBoard.adjust1Mhz && mainBoard.audioJumpInterval != 10))
                    mainBoard.cycleWait.Enqueue(true);
                mainBoard.cpuCycles++;
            }
        
        }

        public void Run(bool running)
        {
            Stopwatch sw3 = Stopwatch.StartNew();
            while (running)
            {
                RunCycle();
                if (mainBoard.cpuCycles >= 1000000)
                {
                    sw3.Stop();
                    mainBoard.clockSpeed = sw3.Elapsed.TotalMilliseconds;
                    mainBoard.cpuCycles = 0;
                    sw3 = Stopwatch.StartNew();
                }
            }
        }

        public void DelayedRun(bool running)
        {
            DateTime countTime = DateTime.Now;
            int soundCycles = 0;
            Stopwatch sw3 = Stopwatch.StartNew();

            int k = 0;
            byte[] bytes = new byte[mainBoard.audioBuffer];

            Thread.Sleep(100);

            double elapsedCycleTime = 600;
            double adjcycle = 100;
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            bool switchJumpInterval = false;
            bool n = false;
            int cpuCycles = 0;
            int cyclesPerMilliseconds = 19500;
            int cyclesPerMillisecondsAdj = cyclesPerMilliseconds;

            while (running)
            {

                if (mainBoard.adjust1Mhz)
                {
                    cpuCycles++;
                    // if (sw.Elapsed.TotalNanoseconds >= elapsedCycleTime)
                    // {
                    if (!mainBoard.cycleWait.TryDequeue(out n))
                    {

                        RunCycle();

                        if (soundCycles > (switchJumpInterval ? 1 : 1))
                        {
                            switchJumpInterval = !switchJumpInterval;

                            if (k < mainBoard.audioBuffer)
                            {
                                bytes[k] = (byte)(mainBoard.softswitches.SoundClick ? 0x80 : 0x00);
                            }
                            else
                            {
                                mainBoard.clickBuffer.Enqueue(bytes);
                                k = 0;
                                bytes = new byte[mainBoard.audioBuffer];
                            }

                            k++;

                            TimeSpan delta2 = DateTime.Now - countTime;
                            if (delta2.TotalMilliseconds >= adjcycle)
                            {
                                mainBoard.screenLog.Enqueue(" Queue buffer: " + mainBoard.clickBuffer.Count()
                                 + " cyclesPerMilliseconds = " + cyclesPerMilliseconds);

                                if (mainBoard.clickBuffer.Count() > 2)
                                {
                                    cyclesPerMilliseconds -= (mainBoard.clickBuffer.Count() - 2) * 10;
                                }
                                else if (mainBoard.clickBuffer.Count() < 2)
                                {
                                    cyclesPerMilliseconds += (2 - mainBoard.clickBuffer.Count()) * 10;
                                }

                                countTime = DateTime.Now;
                            }
                            soundCycles = 0;
                        }
                        else
                        {
                            soundCycles++;
                        }
                    }

                    if (cpuCycles >= cyclesPerMilliseconds)
                    {
                        Thread.Sleep(1);
                        cpuCycles = 0;
                    }
                    // sw = Stopwatch.StartNew();
                    // }
                }
                else
                {
                    if (mainBoard.audioJumpInterval == 10)
                    {
                        RunCycle();
                    }
                    else
                    {
                        cyclesPerMillisecondsAdj = cyclesPerMilliseconds + ((mainBoard.audioJumpInterval) * 3000);
                        cpuCycles++;
                        if (!mainBoard.cycleWait.TryDequeue(out n))
                        {

                            RunCycle();

                            if (soundCycles > (switchJumpInterval ? mainBoard.audioJumpInterval / 2 + 1 : mainBoard.audioJumpInterval / 2 + 1))
                            {
                                switchJumpInterval = !switchJumpInterval;

                                if (k < mainBoard.audioBuffer)
                                {
                                    bytes[k] = (byte)(mainBoard.softswitches.SoundClick ? 0x80 : 0x00);
                                }
                                else
                                {
                                    mainBoard.clickBuffer.Enqueue(bytes);
                                    k = 0;
                                    bytes = new byte[mainBoard.audioBuffer];
                                }

                                k++;

                                TimeSpan delta2 = DateTime.Now - countTime;
                                if (delta2.TotalMilliseconds >= adjcycle)
                                {
                                    mainBoard.screenLog.Enqueue(" Queue buffer: " + mainBoard.clickBuffer.Count()
                                     + " cyclesPerMillisecondsAdj = " + cyclesPerMillisecondsAdj);

                                    if (mainBoard.clickBuffer.Count() > 2)
                                    {
                                        cyclesPerMillisecondsAdj -= (mainBoard.clickBuffer.Count() - 2) * 10;
                                    }
                                    else if (mainBoard.clickBuffer.Count() < 2)
                                    {
                                        cyclesPerMillisecondsAdj += (2 - mainBoard.clickBuffer.Count()) * 10;
                                    }

                                    countTime = DateTime.Now;
                                }
                                soundCycles = 0;
                            }
                            else
                            {
                                soundCycles++;
                            }
                        }

                        if (cpuCycles >= cyclesPerMillisecondsAdj)
                        {
                            Thread.Sleep(1);
                            cpuCycles = 0;
                        }

                    }

                }
                if (mainBoard.cpuCycles >= 1000000)
                {
                    sw3.Stop();
                    mainBoard.clockSpeed = sw3.Elapsed.TotalMilliseconds;
                    mainBoard.cpuCycles = 0;
                    sw3 = Stopwatch.StartNew();
                }

            }
        }
    }

}
