namespace CsvConverter.Abstractions
{
    public class InputOptions
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public bool ConsoleOutput { get { return OutputFilePath == null; } }
        public OutputType OutputType { get; set; }
        public string NestingDelimiter { get; set;}
    }
}
