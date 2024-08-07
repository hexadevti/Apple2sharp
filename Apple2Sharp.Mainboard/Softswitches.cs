using System.Collections;
using System.Threading.Channels;

namespace Apple2Sharp.Mainboard
{
    public class Softswitches
    {
        public bool Graphics_Text { get; set; }
        public bool Page1_Page2 { get; set; }
        public bool DisplayFull_Split { get; set; }
        public bool LoRes_HiRes { get; set; }
        public bool Cols40_80 { get; set; }
        public bool SoundClick { get; set; }

        public bool Cg0 { get; set;}
        public bool Cg1 { get; set;}
        public bool Cg2 { get; set; }
        public bool Cg3 { get; set; }
        public bool CgReset0 { get; set; }
        public bool CgReset1 { get; set; }
        public bool CgReset2 { get; set; }
        public bool CgReset3 { get; set; }

        public bool Pb0 { get; set; }
        public bool Pb1 { get; set; }
        public bool Pb2 { get; set; }

        // Apple IIe

        public bool IntCXRomOn_Off { get; set; }
        public bool SlotC3RomOn_Off { get; set; }
        public bool IntC8RomOn_Off { get; set; }
        public bool AltCharSetOn_Off { get; set; }
        public bool Store80On_Off { get; set; }

        public bool Vertical_blankingOn_Off { get; set;}
        
        public bool IIEMemoryBankBankSelect1_2 { get; set; }
        public bool IIEMemoryBankReadRAM_ROM { get; set; }
        public bool IIEMemoryBankWriteRAM_NoWrite { get; set; }

        public bool RAMReadOn_Off { get; set; }
        public bool RAMWriteOn_Off { get; set;} 
        public bool AltZPOn_Off { get; set; }   

        public bool IOUDisOn_Off { get; set; }

        public bool DHiResOn_Off { get; set; } 

        public int IIeExpansionCardBank { get; set; }


        public void Write(ushort address, byte b, Apple2Board mainBoard)
        {
            ProcessSwitch(address, b, mainBoard, false);
        }

        public byte Read(ushort address, Apple2Board mainBoard)
        {
            return ProcessSwitch(address, 0x00, mainBoard, true);
        }

        private byte ProcessSwitch(ushort address, byte b, Apple2Board mainBoard, bool Read_Write = true)
        {
            if (address == 0xc030)
            {
                mainBoard.softswitches.SoundClick = !mainBoard.softswitches.SoundClick;
            }
            else if (address == 0xc000)
            {
                if (Read_Write)
                    return mainBoard.KeyPressedBuffer;
                else
                    mainBoard.softswitches.Store80On_Off = false;

            }
            else if (address == 0xc001)
            {
                if (!Read_Write)
                    mainBoard.softswitches.Store80On_Off = true;
            }
            else if (address == 0xc002)
                mainBoard.softswitches.RAMReadOn_Off = false;
            else if (address == 0xc003)
                mainBoard.softswitches.RAMReadOn_Off = true;
            else if (address == 0xc004)
                mainBoard.softswitches.RAMWriteOn_Off = false;
            else if (address == 0xc005)
                mainBoard.softswitches.RAMWriteOn_Off = true;
            else if (address == 0xc006)
                mainBoard.softswitches.IntCXRomOn_Off = false;
            else if (address == 0xc007)
                mainBoard.softswitches.IntCXRomOn_Off = true;
            else if (address == 0xc008)
                mainBoard.softswitches.AltZPOn_Off = false;
            else if (address == 0xc009)
                mainBoard.softswitches.AltZPOn_Off = true;
            else if (address == 0xc00a)
                mainBoard.softswitches.SlotC3RomOn_Off = false;
            else if (address == 0xc00b)
                mainBoard.softswitches.SlotC3RomOn_Off = true;
            else if (address == 0xc00e)
                mainBoard.softswitches.AltCharSetOn_Off = false;
            else if (address == 0xc00f)
                mainBoard.softswitches.AltCharSetOn_Off = true;
            else if (address == 0xc010)
                mainBoard.KeyPressedBuffer = mainBoard.KeyPressedBuffer < 0x80 ? mainBoard.KeyPressedBuffer : (byte)(mainBoard.KeyPressedBuffer ^ 0b10000000);
            else if (address == 0xc00c)
            {
                if (!Read_Write)
                    mainBoard.softswitches.Cols40_80 = true; // Apple IIc IIe
            }
            else if (address == 0xc00d)
            {
                if (!Read_Write)
                    mainBoard.softswitches.Cols40_80 = false; // Apple IIc IIe
            }
            else if (address == 0xc011)
                return (byte)(mainBoard.softswitches.IIEMemoryBankBankSelect1_2 ? 0x00 : 0xff);
            else if (address == 0xc012)
                return (byte)(mainBoard.softswitches.IIEMemoryBankReadRAM_ROM ? 0xff : 0x00);
            else if (address == 0xc011)
                return (byte)(mainBoard.softswitches.RAMReadOn_Off ? 0xff : 0x00);
            else if (address == 0xc014)
                return (byte)(mainBoard.softswitches.RAMWriteOn_Off ? 0xff : 0x00);
            else if (address == 0xc015)
                return (byte)(mainBoard.softswitches.IntCXRomOn_Off ? 0xff : 0x00);
            else if (address == 0xc016)
                return (byte)(mainBoard.softswitches.AltZPOn_Off ? 0xff : 0x00);
            else if (address == 0xc017)
                return (byte)(mainBoard.softswitches.SlotC3RomOn_Off ? 0xff : 0x00);
            else if (address == 0xc018)
                return (byte)(mainBoard.softswitches.Store80On_Off ? 0xff : 0x00);
            else if (address == 0xc019)
                return (byte)(mainBoard.softswitches.Vertical_blankingOn_Off ? 0xff : 0x00);
            else if (address == 0xc01a)
                return (byte)(mainBoard.softswitches.Graphics_Text ? 0x00 : 0xff);
            else if (address == 0xc01b)
                return (byte)(mainBoard.softswitches.DisplayFull_Split ? 0x00 : 0xff);
            else if (address == 0xc01c)
                return (byte)(mainBoard.softswitches.Page1_Page2 ? 0x00 : 0xff);
            else if (address == 0xc01d)
                return (byte)(mainBoard.softswitches.LoRes_HiRes ? 0x00 : 0xff);
            else if (address == 0xc01e)
                return (byte)(mainBoard.softswitches.AltCharSetOn_Off ? 0xff : 0x00);
            else if (address == 0xc01f)
                return (byte)(mainBoard.softswitches.Cols40_80 ? 0x00 : 0xff);
            else if (address == 0xc050)
                mainBoard.softswitches.Graphics_Text = true;
            else if (address == 0xc051)
                mainBoard.softswitches.Graphics_Text = false;
            else if (address == 0xc052)
                mainBoard.softswitches.DisplayFull_Split = true;
            else if (address == 0xc053)
                mainBoard.softswitches.DisplayFull_Split = false;
            else if (address == 0xc054)
            {
                lock (mainBoard.displayLock)
                {
                    mainBoard.softswitches.Page1_Page2 = true;
                }
            }
            else if (address == 0xc055)
            {
                lock (mainBoard.displayLock)
                {
                    mainBoard.softswitches.Page1_Page2 = false;
                }
            }
            else if (address == 0xc056)
                mainBoard.softswitches.LoRes_HiRes = true;
            else if (address == 0xc057)
                mainBoard.softswitches.LoRes_HiRes = false;
            else if (address == 0xc058)
                mainBoard.softswitches.Cols40_80 = true;
            else if (address == 0xc059)
                mainBoard.softswitches.Cols40_80 = false;
            else if (address == 0xc05e)
            {
                if (mainBoard.softswitches.IOUDisOn_Off)
                    mainBoard.softswitches.DHiResOn_Off = true;
            }
            else if (address == 0xc05f)
            {
                if (mainBoard.softswitches.IOUDisOn_Off)
                    mainBoard.softswitches.DHiResOn_Off = false;
            }
            else if (address == 0xc061)
                return (byte)(mainBoard.softswitches.Pb0 ? 0x80 : 0x00);
            else if (address == 0xc062)
                return (byte)(mainBoard.softswitches.Pb1 ? 0x80 : 0x00);
            else if (address == 0xc063)
                return (byte)(mainBoard.softswitches.Pb2 ? 0x80 : 0x00);
            //else if (address == 0xc063)
            //    return 0x80; // Apple II+ default. For Apple IIe it is defined by shift key pressed
            else if (address == 0xc064)
                return (byte)(mainBoard.softswitches.Cg0 ? 0x80 : 0x00);
            else if (address == 0xc065)
                return (byte)(mainBoard.softswitches.Cg1 ? 0x80 : 0x00);
            else if (address == 0xc066)
                return (byte)(mainBoard.softswitches.Cg2 ? 0x80 : 0x00);
            else if (address == 0xc067)
                return (byte)(mainBoard.softswitches.Cg3 ? 0x80 : 0x00);
            else if (address == 0xc070)
            {
                mainBoard.softswitches.CgReset0 = true;
                mainBoard.softswitches.CgReset1 = true;
                mainBoard.softswitches.CgReset2 = true;
                mainBoard.softswitches.CgReset3 = true;
                mainBoard.softswitches.Cg0 = true;
                mainBoard.softswitches.Cg1 = true;
                mainBoard.softswitches.Cg2 = true;
                mainBoard.softswitches.Cg3 = true;
            }
            else if (address == 0xc071 || address == 0xc073 ||address == 0xc075 ||address == 0xc077)
            {
                if (b < mainBoard.IIEAuxBanks)
                    IIeExpansionCardBank = b;
            }
            else if (address == 0xc07e)
            {
                mainBoard.softswitches.IOUDisOn_Off = true;
            }
            else if (address == 0xc07f)
            {
                if (Read_Write)
                {
                    return (byte)(mainBoard.softswitches.DHiResOn_Off ? 0xff : 0x00);
                }
                else
                    mainBoard.softswitches.IOUDisOn_Off = false;
            }
            else if (address == 0xc07e)
            {   
                if (Read_Write)
                {
                    return (byte)(mainBoard.softswitches.IOUDisOn_Off ? 0x00 : 0xff);
                }
                else
                    mainBoard.softswitches.IOUDisOn_Off = true;
            }
            else if (address >= 0xc070 && address < 0xc080)
            {

            }
            else if (mainBoard.appleIIe)
            {
                if (address >= 0xc080 && address < 0xc090)
                {
                    var last4bits = (address & 0b00001111);
                    BitArray bits = new BitArray(new byte[] { (byte)last4bits });
                    IIEMemoryBankBankSelect1_2 = bits[3];
                    if (bits[1] && bits[0])
                    {
                        IIEMemoryBankReadRAM_ROM = true;
                        IIEMemoryBankWriteRAM_NoWrite = true;
                    }
                    else if (!bits[1] && bits[0])
                    {
                        IIEMemoryBankReadRAM_ROM = false;
                        IIEMemoryBankWriteRAM_NoWrite = true;
                    }
                    else if (bits[1] && !bits[0])
                    {
                        IIEMemoryBankReadRAM_ROM = false;
                        IIEMemoryBankWriteRAM_NoWrite = false;
                    }
                    else if (!bits[1] && !bits[0])
                    {
                        IIEMemoryBankReadRAM_ROM = true;
                        IIEMemoryBankWriteRAM_NoWrite = false;
                    }
                }
            }
            return 0;

        }
    }
}