using Apple2.Mainboard.Enums;

namespace Apple2.CPU.Mos6502
{

    public class OpCodePart
    {
        public int Cycles { get; set; }
        public OpCodeType Operation { get; set; }
        public Addressing? Addressing { get; set; }
        public Register? Register { get; set; }

        public OpCodePart(OpCodeType operation, int cycles, Addressing? addressing = null, Register? register = null)
        {
            Cycles = cycles;
            Operation = operation;
            if (addressing != null)
                Addressing = addressing;
            if (register != null)
                Register = register;
        }
    }


}
