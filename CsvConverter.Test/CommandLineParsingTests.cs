using CsvConverter.Abstractions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvConverter.Test
{
    [TestClass]
    public class CommandLineParsingTests
    {
        [TestMethod]
        public void TestParsing_ShortArgs ()
        {
            var args = new string[] { "-i", "input.csv", "-o", "output.json", "-t", "JSON"};
            var parser = new CommandLineParser();
            var result = parser.GetInputsFromCommandArgs(args);

            result.Should().BeEquivalentTo(new InputOptions()
            {
                InputFilePath = "input.csv",
                OutputFilePath = "output.json",
                OutputType = OutputType.Json,
                NestingDelimiter = "_",
            });
        }

        [TestMethod]
        public void TestParsing_ShortArgs_NoOutputFile ()
        {
            var args = new string[] { "-i", "input.csv", "-t", "JSON"};
            var parser = new CommandLineParser();
            var result = parser.GetInputsFromCommandArgs(args);

            result.Should().BeEquivalentTo(new InputOptions()
            {
                InputFilePath = "input.csv",
                OutputFilePath = null,
                OutputType = OutputType.Json,
                NestingDelimiter = "_",
            });

            result.ConsoleOutput.Should().Be(true);
        }
        
        [TestMethod]
        public void TestParsing_LongArgs ()
        {
            var args = new string[] { "--input", "input.csv", "--output", "output.xml", "--outputType", "XML", "--nestingDelimiter", ";"};
            var parser = new CommandLineParser();
            var result = parser.GetInputsFromCommandArgs(args);

            result.Should().BeEquivalentTo(new InputOptions()
            {
                InputFilePath = "input.csv",
                OutputFilePath = "output.xml",
                OutputType = OutputType.Xml,
                NestingDelimiter = ";",
            });
        }
    }
}
