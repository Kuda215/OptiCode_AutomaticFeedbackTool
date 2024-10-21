public class SubmissionResponse
{
    public int Id { get; set; }
    public bool Executing { get; set; }
    public string Date { get; set; }
    public CompilerInfo Compiler { get; set; }
    public ResultInfo Result { get; set; }

    public class CompilerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VersionInfo Version { get; set; }
    }

    public class VersionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ResultInfo
    {
        public StatusInfo Status { get; set; }
        public double Time { get; set; }
        public double Memory { get; set; }
        public int Signal { get; set; }
        public string SignalDesc { get; set; }
        public StreamsInfo Streams { get; set; }
    }

    public class StatusInfo
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class StreamsInfo
    {
        public StreamInfo Source { get; set; }
        public object Input { get; set; }
        public object Output { get; set; }
        public object Error { get; set; }
        public StreamInfo Cmpinfo { get; set; }
    }

    public class StreamInfo
    {
        public int Size { get; set; }
        public string Uri { get; set; }
    }
}