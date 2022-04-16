using CsvConverter.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvConverter.Writers
{
    /// <summary>
    /// Write Dynamic Objects to the Console
    /// </summary>
    public class DynamicToJsonConsoleWriter : IWriter<DynamicObject>
    {
        private readonly InputOptions _inputOptions;

        public DynamicToJsonConsoleWriter(InputOptions inputOptions)
        {
            _inputOptions = inputOptions;
        }

        public void Write(IEnumerable<DynamicObject> values)
        {
            Console.WriteLine("[");
            bool first = true;
            foreach (var value in values)
            {
                if (!first)
                {
                    Console.WriteLine(",");
                }
                first = false;
                string jsonObject = JsonConvert.SerializeObject(value);
                Console.WriteLine(jsonObject);
            }
            Console.WriteLine("]");
        }
    }
}
