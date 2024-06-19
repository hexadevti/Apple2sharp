using Runtime;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using System.Windows.Input;
using Microsoft.VisualBasic.Devices;
using Runtime.Overlays;
using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Net;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.Diagnostics;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Apple2;

public partial class Form1 : Form
{
    private Memory memory { get; set; }

    private CPU cpu { get; set; }

    Runtime.State state = new Runtime.State();



    bool running = true;

    string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    List<Task> threads = new List<Task>();

    int pixelSize = 2;

    private DirectSoundOut output = null;
    private BlockAlignReductionStream stream = null;

    private bool adjust1mhz = false;

    public Form1()
    {
        InitializeComponent();

        //pictureBox1.Width = (int)(280 * pixelSize * 1.2);
        //pictureBox1.Height = (int)(192 * pixelSize * 1.2);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        if (assemblyPath != null)
            assemblyPath += "/";

        openFileDialog1.FileName = assemblyPath + "roms/Apple Core 525 ProDOS RC2.dsk";
        string[] parts = openFileDialog1.FileName.Split('\\');
        disk1.Text = parts[parts.Length-1];
        openFileDialog2.FileName = "";
        PowerOn();



        this.Shown += Form1_Shown;
    }

    public void PowerOn()
    {


        waveViewer1.SamplesPerPixel = 10;
        waveViewer1.AutoScroll = true;
        waveViewer1.AutoSize = true;

        output = new DirectSoundOut();


        running = true;


        memory = new Memory(state);


        memory.LoadROM(0xf800, File.ReadAllBytes(assemblyPath + "roms/ApplesoftF800.rom"));
        memory.LoadROM(0xf000, File.ReadAllBytes(assemblyPath + "roms/ApplesoftF000.rom"));
        memory.LoadROM(0xe800, File.ReadAllBytes(assemblyPath + "roms/ApplesoftE800.rom"));
        memory.LoadROM(0xe000, File.ReadAllBytes(assemblyPath + "roms/ApplesoftE000.rom"));
        memory.LoadROM(0xd800, File.ReadAllBytes(assemblyPath + "roms/ApplesoftD800.rom"));
        memory.LoadROM(0xd000, File.ReadAllBytes(assemblyPath + "roms/ApplesoftD000.rom"));
        memory.RegisterOverlay(new KeyboardOvl());
        memory.RegisterOverlay(new CpuSoftswitchesOvl());
        memory.RegisterOverlay(new SlotsSoftSwitchesOvl());
        // memory.RegisterOverlay(new EmptySlot1Ovl());
        // memory.RegisterOverlay(new EmptySlot2Ovl());
        // memory.RegisterOverlay(new EmptySlot3Ovl());
        // memory.RegisterOverlay(new EmptySlot4Ovl());
        // memory.RegisterOverlay(new EmptySlot5Ovl());
        memory.RegisterOverlay(new DiskIISlot6Ovl());
        // memory.RegisterOverlay(new EmptySlot7Ovl());


        memory.LoadChars(File.ReadAllBytes(assemblyPath + "roms/CharROM.bin"));


        memory.drive1 = new DiskDrive(openFileDialog1.FileName, memory);
        memory.drive2 = new DiskDrive(openFileDialog2.FileName, memory);



        cpu = new CPU(state, memory, false);
        Keyboard keyboard = new Keyboard(memory, state);


        richTextBox1.KeyDown += keyboard.OnKeyDown;
        richTextBox1.KeyPress += keyboard.OnKeyPress;
        richTextBox1.TextChanged += keyboard.Keyb_TextChanged;

        



        cpu.Reset();

        threads.Add(Task.Run(() =>
        {
            while (running)
            {
                cpu.RunCycle(adjust1mhz);
            }
        }));

        threads.Add(Task.Run(() =>
        {
            while (running)
            {
                lock (memory.displayLock)
                {
                    try
                    {
                        pictureBox1.Image = VideoGenerator.Generate(memory, pixelSize, true);
                    }
                    catch { }
                }
                Thread.Sleep(20);
            }
        }));

        //threads.Add(Task.Run(() =>
        //{
        //    while (running)
        //    {
        //        if (memory.softswitches.SoundClick)
        //        {
        //            tone = new WaveTone(400, 1);
        //            stream = new BlockAlignReductionStream(tone);
        //            waveViewer1.WaveStream = stream;
        //            output.Init(stream);
        //            output.Play();
        //            memory.softswitches.SoundClick = false;
        //        }
        //        Thread.Sleep(5);
        //    }
        //}));
    }

    private void Form1_Shown(object? sender, EventArgs e)
    {
        richTextBox1.Focus();
    }

    private void Form1_Resize(object sender, System.EventArgs e)
    {
    }


    private void button_dsk1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string[] parts = openFileDialog1.FileName.Split('\\');
            disk1.Text = parts[parts.Length-1];
            memory.drive1 = new DiskDrive(openFileDialog1.FileName, memory);
            richTextBox1.Focus();
        }
    }
    private void button_dsk2_Click(object sender, EventArgs e)
    {
        if (openFileDialog2.ShowDialog() == DialogResult.OK)
        {
            string[] parts = openFileDialog2.FileName.Split('\\');
            disk2.Text = parts[parts.Length-1];
            memory.drive2 = new DiskDrive(openFileDialog2.FileName, memory);
            richTextBox1.Focus();
        }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        richTextBox1.Focus();
    }

    private void btn_restart_Click(object sender, EventArgs e)
    {
        running = false;
        foreach (var item in threads)
        {
            if (item != null)
                item.Wait();
        }
        PowerOn();
        richTextBox1.Focus();
    }

    WaveTone tone = new WaveTone(400, 1);


    private void button1_Click(object sender, EventArgs e)
    {
        tone = new WaveTone(100, 1);
        stream = new BlockAlignReductionStream(tone);
        waveViewer1.WaveStream = stream;
        output.Init(stream);
        output.Play();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (output != null) output.Stop();

    }

    private void button3_Click(object sender, EventArgs e)
    {
        tone.frequency = tone.frequency + 200;
        stream = new BlockAlignReductionStream(tone);
        waveViewer1.WaveStream = stream;
    }

    private void btnClockAdjust_Click(object sender, EventArgs e)
    {
        adjust1mhz = !adjust1mhz;
        if (adjust1mhz)
            btnClockAdjust.Text = "Max";
        else
            btnClockAdjust.Text = "1Mhz";
        richTextBox1.Focus();
    }
}

public class WaveTone : WaveStream
{
    public double frequency { get; set; }
    private double amplitude;
    private double time;
    public WaveTone(double f, double a)
    {
        this.time = 0;
        this.frequency = f;
        this.amplitude = a;
    }
    public override WaveFormat WaveFormat
    {
        get
        {
            return new WaveFormat(44100, 8, 1);
        }
    }

    public override long Length 
    {
        get
        {
            return 1;
        }
    }

    public override long Position { get; set; }

    public override int Read(byte[] buffer, int offset, int count)
    {
        int samples = count; // / 2;
        for (int i = 0; i < samples; i++)
        {
            amplitude = amplitude * 0.9992f;
            double sine = amplitude * Math.Sin(Math.PI * 2 * frequency * time);
            time += 1.0 / 44100;
            short truncated = (short)Math.Round(sine * (Math.Pow(2, 7) - 1));
            buffer[i] = (byte)truncated;
            //buffer[i * 2 + 1] = (byte)((truncated & 0xff00) >> 8);
        }

        return count;
    }
}
