namespace BaseLibrary.Interface
{
    public interface IByteParser<out TData>
    {
        int MsgLength { get; set; }

        byte StartByte { get; set; }
        byte EndByte { get; set; }

        TData ParseData(byte[] data);
    }


    public interface IStringParser<out TData>
    {
        int MsgLength { get; set; }

        string StartString { get; set; }
        string EndString { get; set; }
        char[] StringSplitBytes { get; set; }

        TData ParseData(string data);
    }

}