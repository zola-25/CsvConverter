namespace CsvConverter.Abstractions
{
    public interface IConverterBuilder
    {
        /// <summary>
        /// Build the appropriate ETL converter based on the console input options
        /// </summary>
        /// <param name="inputOptions">Console input options</param>
        /// <returns></returns>
        IConverter BuildConverter(InputOptions inputOptions);
    }
}