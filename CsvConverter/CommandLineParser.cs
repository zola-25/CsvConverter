using CsvConverter.Abstractions;
using Fclp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter
{
    
    public class CommandLineParser : ICommandLineParser
    {
        private readonly FluentCommandLineParser<InputOptions> _parser;
        public CommandLineParser()
        {
            var parser = new FluentCommandLineParser<InputOptions>();
            parser.Setup(arg => arg.InputFilePath)
                .As('i', "input")
                .WithDescription("The input file path (required)")
                .Required();

            parser.Setup(arg => arg.OutputFilePath)
                .As('o', "output")
                .WithDescription("The output file path. If none is specified, the output will be written to the console")
                .SetDefault(null);

            parser.Setup(arg => arg.NestingDelimiter)
                .As("nestingDelimiter")
                .WithDescription("The nesting delimiter for converting column headers into nested json or XML e.g. address_number, address_city into one address object with number and city properties. Defaults to '_'. Hyphens cannot be used.")
                .SetDefault("_");

            parser.Setup(arg => arg.OutputType)
                .As('t', "outputType")
                .WithDescription("The output type ('JSON' or 'XML'). Defaults to 'JSON'")
                .SetDefault(OutputType.Json);
            
            parser.SetupHelp("?", "help")
                .Callback(text => {
                    Console.WriteLine(text);
                    Console.WriteLine("Example running from Command Line: ./csvConverter.exe -i input.csv -o output.json -t JSON --nestingDelimiter _");
                    Console.ReadLine();
                    Environment.Exit(0);
                });
            
            _parser = parser;
        }
        
        public InputOptions GetInputsFromCommandArgs(string[] args)
        {
            var parseResult = _parser.Parse(args);
            if (parseResult.HasErrors)
            {
                throw new ArgumentException(parseResult.ErrorText);
            }
            return _parser.Object;
        }
    }
}
