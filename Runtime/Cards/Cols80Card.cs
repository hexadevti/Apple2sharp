
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Runtime.Abstractions;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Runtime.Cards;

public class Cols80Card : ICard
{
    private int _slotNumber = 3;
    private byte[] _c000ROM;
    private byte[] _cc00ROM;
    private Dictionary<byte, bool[,]> _charSet;
    public byte[] extendedSlotsROM = new byte[0x800];
    public int SlotNumber
    {
        get { return _slotNumber; }
        set { _slotNumber = value;}
    }

    public byte[] C000ROM { 
        get { return _c000ROM;}
    }

    public byte[] CC00ROM {
        get { return _cc00ROM;} 
        set { _cc00ROM = value;}
      }

    public Cols80Card(int slotNumber, byte[] c000ROM, byte[] cc00ROM, Dictionary<byte, bool[,]> charSet)
    {
        _slotNumber = slotNumber;
        _c000ROM = c000ROM;
        _cc00ROM = cc00ROM;
        _charSet = charSet;

    }
    public void Write(ushort address, byte b, MainBoard mainBoard)
    {
        ProcessC0xx(address, mainBoard);
    }


    public byte Read(ushort address, MainBoard mainBoard, State state)
    {
        ProcessC0xx(address, mainBoard);
        return 0;
    }

    private void ProcessC0xx(ushort address, MainBoard mainBoard)
    {
        if (address == 0xc080 + _slotNumber * 0x10)
        {
            mainBoard.softswitches.cols80PageSelect = 0;
        }
        else if (address == 0xc084 + _slotNumber * 0x10)
        {
            mainBoard.softswitches.cols80PageSelect = 1;
        }
        else if (address == 0xc088 + _slotNumber * 0x10)
        {
            mainBoard.softswitches.cols80PageSelect = 2;
        }
        else if (address == 0xc08c  + _slotNumber * 0x10)
        {
            mainBoard.softswitches.cols80PageSelect = 3;
        }
    }

    public Bitmap Generate(Runtime.MainBoard mainBoard, int pixelSize)
    {
        int byteid = 0;
        var cursorH = mainBoard.baseRAM[0x57b];
        var cursorV = mainBoard.baseRAM[0x5fb];
        byte[] bmp = new byte[640 * pixelSize * 216 * pixelSize*2];
        int posH = 0;
        byte[] linha = new byte[0x50];

        for (int posV = 0; posV < 24; posV++)
        {
            linha = new byte[0x50];

            for (ushort c = 0; c < 0x50; c++)
            {
                posH = c;
                var chr = mainBoard.cols80RAM[(ushort)((c + (posV * 0x50) + mainBoard.baseRAM[0x6fb] * 0x10) % 0x800)];
                if (posV == cursorV && posH == cursorH)
                {
                    chr = Math.Floor((float)(DateTime.Now.Millisecond / 500)) % 2 == 0 ? (byte)(chr + 0x80) : (byte)(chr);
                }

                linha[c] = chr;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int ps1 = 0; ps1 < pixelSize*2; ps1++)
                {
                    for (int j = 0; j < 0x50; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            bool invert = false;
                            byte rChar = linha[j];
                            if (rChar > 0x80)
                            {
                                invert = true;
                                rChar = (byte)(rChar - 0x80);
                            }
                            
                            object? objout = _charSet[rChar].GetValue(i, k);
                            for (int ps2 = 0; ps2 < pixelSize; ps2++)
                            {
                                if (objout != null)
                                {
                                    if ((bool)objout)
                                        bmp[byteid] = (byte)(invert ? 0x00 : 0xff);
                                    else
                                        bmp[byteid] = (byte)(invert ? 0xff : 0x00);
                                }
                                else
                                    bmp[byteid] = 0x0;
                                byteid++;
                            }
                        }
                    }
                }
            }

        }


        Bitmap bitmap = new Bitmap(640 * pixelSize, 216 * pixelSize * 2, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        ColorPalette pal = bitmap.Palette;
        pal.Entries[0x00] = Color.Black;
        pal.Entries[0xff] = Color.White;

        bitmap.Palette = pal;
        BitmapData bmData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        IntPtr pNative = bmData.Scan0;
        Marshal.Copy(bmp, 0, pNative, 640 * pixelSize * 216 * pixelSize * 2);
        bitmap.UnlockBits(bmData);
        return bitmap;

    }

    
}
