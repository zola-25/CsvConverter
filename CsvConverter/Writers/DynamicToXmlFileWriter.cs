using ChoETL;
using CsvConverter.Abstractions;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvConverter.Writers
{
    /// <summary>
    /// Write dynamic objects to an XML file
    /// </summary>
    public class DynamicToXmlFileWriter : IWriter<DynamicObject>
    {
        private readonly InputOptions _inputOptions;

        public DynamicToXmlFileWriter(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        
        public void Write(IEnumerable<DynamicObject> values)
        {
            using (var xmlWriter = new ChoXmlWriter(_inputOptions.OutputFilePath).WithXPath("documents/document"))
            {
                xmlWriter.Write(values);
            }
        }
    }
}
