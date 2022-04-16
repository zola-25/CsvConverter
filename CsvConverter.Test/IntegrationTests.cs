using CsvConverter.Abstractions;
using FluentAssertions;
using FluentAssertions.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml.Linq;

namespace CsvConverter.Test
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        [DataRow("./InputExamples/WebExampleInput.csv", "./OutputExamples/WebExampleExpectedOutput.json")]
        [DataRow("./InputExamples/ComplexExampleInput.csv", "./OutputExamples/ComplexExampleExpectedOutput.json")]
        public void CsvToJson_ToFile(string inputFilePath, string expectedOutputFile)
        {
            var csvConverter = new CsvConverterProgram(new CommandLineParser(), new ConverterBuilder());
            var inputs = new InputOptions()
            {
                InputFilePath = inputFilePath,
                OutputFilePath = "./WebOutputTestResult.json",
                NestingDelimiter = "_",
                OutputType = OutputType.Json,
            };
            csvConverter.Run(inputs);

            Assert.IsTrue(System.IO.File.Exists(inputs.OutputFilePath));

            var outputExpectedText = System.IO.File.ReadAllText(expectedOutputFile);
            var outputResultText = System.IO.File.ReadAllText("./WebOutputTestResult.json");

            JToken actual = JToken.Parse(outputResultText);
            JToken expected = JToken.Parse(outputExpectedText);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow("./InputExamples/WebExampleInput.csv", "./OutputExamples/WebExampleExpectedOutput.xml")]
        [DataRow("./InputExamples/ComplexExampleInput.csv", "./OutputExamples/ComplexExampleExpectedOutput.xml")]
        public void CsvToXml_ToFile(string inputFilePath, string expectedOutputFile)
        {
            var csvConverter = new CsvConverterProgram(new CommandLineParser(), new ConverterBuilder());
            var inputs = new InputOptions()
            {
                InputFilePath = inputFilePath,
                OutputFilePath = "./WebOutputTestResult.xml",
                NestingDelimiter = "_",
                OutputType = OutputType.Xml
            };
            csvConverter.Run(inputs);

            Assert.IsTrue(System.IO.File.Exists(inputs.OutputFilePath));

            var outputExpectedText = System.IO.File.ReadAllText(expectedOutputFile);
            var outputResultText = System.IO.File.ReadAllText("./WebOutputTestResult.xml");

            var actual = XDocument.Parse(outputExpectedText).ToString(); // ToString() is just a hack to make all whitespace (tabs vs spaces etc) normalized for each xml document
            var expected = XDocument.Parse(outputResultText).ToString();
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void CsvToJson_ToConsole()
        {
            var csvConverter = new CsvConverterProgram(new CommandLineParser(), new ConverterBuilder());
            var inputs = new InputOptions()
            {
                InputFilePath = "./InputExamples/WebExampleInput.csv",
                NestingDelimiter = "_",
                OutputType = OutputType.Json
            };
            
            // Copied from https://stackoverflow.com/a/2139303/3910619
            using (StringWriter consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                csvConverter.Run(inputs);
                var outputExpectedText = System.IO.File.ReadAllText("./OutputExamples/WebExampleExpectedOutput.json");
                JToken expected = JToken.Parse(outputExpectedText);
                
                var actualOutputText = consoleWriter.ToString();
                JToken actual = JToken.Parse(actualOutputText);
                actual.Should().BeEquivalentTo(expected);
            }
        }        
    }
}
