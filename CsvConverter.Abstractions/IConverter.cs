namespace CsvConverter.Abstractions
{
    public interface IConverter
    {
        /// <summary>
        /// Convert one data source type to another
        /// </summary>
        void Convert();
    }
}