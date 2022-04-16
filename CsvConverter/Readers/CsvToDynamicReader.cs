using ChoETL;
using CsvConverter.Abstractions;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvConverter
{
    /// <summary>
    /// Read CSV file and convert to an IEnumerable of Dynamic objects
    /// </summary>
    public class CsvToDynamicReader : IReader<DynamicObject>
    {
        private readonly InputOptions _inputOptions;

        public CsvToDynamicReader(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        public IEnumerable<DynamicObject> Read()
        {
            var reader = new ChoCSVReader(_inputOptions.InputFilePath)
                .WithFirstLineHeader()
                .NestedColumnSeparator(_inputOptions.NestingDelimiter.ToCharArray()[0]);
            dynamic rec;
 
            while ((rec = reader.Read()) != null)
            {
                yield return rec;
            }
        }
    }
}
