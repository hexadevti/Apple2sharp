namespace Runtime.Internal;

internal static class StackFunctions
{
    
    public static byte PullFromStack(State processorState, MainBoard mainBoard)
    {
        processorState.S = (byte)(processorState.S + 1);
        var pulledValue = mainBoard.ReadByte(GetCurrentStackAddress(processorState));
        return (pulledValue);
    }


    public static void PushToStack(State processorState, MainBoard mainBoard, ushort value) 
    {
        BitConverter.GetBytes(value).Reverse().Aggregate(processorState, (current, b) => PushToStack(processorState, mainBoard, b));

    }

    public static State PushToStack(State processorState, MainBoard mainBoard, byte value)
    {
        mainBoard.Write(GetCurrentStackAddress(processorState), value);
        processorState.S = (byte)(processorState.S - 1);
        return processorState;  
    }

    private static ushort GetCurrentStackAddress(State processorState)
    {
        return BitConverter.ToUInt16(new byte []{ processorState.S, 0x01 });
    }
}