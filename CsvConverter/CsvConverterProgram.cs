using CsvConverter.Abstractions;

namespace CsvConverter
{
    public class CsvConverterProgram
    {
        private readonly ICommandLineParser _commandLineParser;
        private readonly IConverterBuilder _converterBuilder;

        public CsvConverterProgram(ICommandLineParser commandLineParser, IConverterBuilder converterBuilder)
        {
            _commandLineParser = commandLineParser;
            _converterBuilder = converterBuilder;
        }

        public void Run(string[] args)
        {
            var parsedInputOptions = _commandLineParser.GetInputsFromCommandArgs(args);
            Run(parsedInputOptions);
        }

        public void Run(InputOptions inputOptions)
        {
            var converter = _converterBuilder.BuildConverter(inputOptions);
            converter.Convert();
        }
    }
}
