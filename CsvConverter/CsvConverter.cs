using CsvConverter.Abstractions;

namespace CsvConverter
{
    public class CsvConverter<T> : IConverter
    {
        private IReader<T> _reader;
        private IWriter<T> _writer;

        public CsvConverter(IReader<T> reader, IWriter<T> writer)
        {
            _reader = reader;
            _writer = writer;
        }
            
        public void Convert()
        {
            var readValues = _reader.Read();
            _writer.Write(readValues);
        }
    }
}
