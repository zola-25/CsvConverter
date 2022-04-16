using ChoETL;
using CsvConverter.Abstractions;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvConverter.Writers
{
    /// <summary>
    /// Write dynamic objects to the console
    /// </summary>
    public class DynamicToXmlConsoleWriter : IWriter<DynamicObject>
    {
        private readonly InputOptions _inputOptions;

        public DynamicToXmlConsoleWriter(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        public void Write(IEnumerable<DynamicObject> values)
        {
            foreach (var value in values)
            {
                string xmlString = ChoXmlWriter.ToText(value);
                Console.WriteLine(xmlString);
            }
        }
    }
}
