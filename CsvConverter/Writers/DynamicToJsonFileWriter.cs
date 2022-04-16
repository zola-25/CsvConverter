using CsvConverter.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace CsvConverter.Writers
{
    /// <summary>
    /// Write dynamic objects to a JSON file
    /// </summary>
    public class DynamicToJsonFileWriter : IWriter<DynamicObject>
    {
        private readonly InputOptions _inputOptions;

        public DynamicToJsonFileWriter(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        public void Write(IEnumerable<DynamicObject> values)
        {
            using (var streamWriter = new StreamWriter(_inputOptions.OutputFilePath))
            {
                streamWriter.WriteLine("[");
                bool first = true;
                foreach (var value in values)
                {
                    if (!first)
                    {
                        streamWriter.WriteLine(",");
                    }
                    first = false;
                    streamWriter.WriteLine(JsonConvert.SerializeObject(value));
                }
                streamWriter.WriteLine("]");

            }
        }
    }
}
