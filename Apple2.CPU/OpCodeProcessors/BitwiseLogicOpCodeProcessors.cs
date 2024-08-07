using Apple2.Mainboard;

namespace Apple2.CPU
{
    internal static class BitwiseLogicOpCodeProcessors
    {
        public static void Process_EOR(State processorState, Apple2Board mainBoard, ushort address)
        {
            var value = mainBoard.ReadByte(address);
            var result = (byte)(value ^ processorState.A);
            WithFlags(processorState, result);
        }

        public static void Process_ORA(State processorState, Apple2Board mainBoard, ushort address)
        {
            var value = mainBoard.ReadByte(address);
            var result = (byte)(value | processorState.A);
            WithFlags(processorState, result);
        }

        public static void Process_AND(State processorState, Apple2Board mainBoard, ushort address)
        {
            var b = mainBoard.ReadByte(address);
            var result = (byte)(b & processorState.A);
            WithFlags(processorState, result);
        }

        private static void WithFlags(State processorState, byte result)
        {
            processorState.A = result;
            processorState.Z = result == 0;
            processorState.N = result.IsNegative();
        }
    }
}