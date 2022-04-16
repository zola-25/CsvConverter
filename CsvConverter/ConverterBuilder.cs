using CsvConverter.Abstractions;
using CsvConverter.Writers;
using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter
{
    public class ConverterBuilder : IConverterBuilder
    {
        public IConverter BuildConverter(InputOptions inputOptions)
        {
            var reader = new CsvToDynamicReader(inputOptions);
            IWriter<DynamicObject> writer;
            switch (inputOptions.OutputType)
            {
                case OutputType.Json:
                    if (inputOptions.ConsoleOutput)
                    {
                        writer = new DynamicToJsonConsoleWriter(inputOptions);
                    } 
                    else
                    {
                        writer = new DynamicToJsonFileWriter(inputOptions);
                    }
                    break;
                case OutputType.Xml:
                    if(inputOptions.ConsoleOutput)
                    {
                        writer = new DynamicToXmlConsoleWriter(inputOptions);
                    }
                    else
                    {
                        writer = new DynamicToXmlFileWriter(inputOptions);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new CsvConverter<DynamicObject>(reader, writer);
        }
    }
}
