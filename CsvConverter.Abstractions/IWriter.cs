using System.Collections.Generic;

namespace CsvConverter.Abstractions
{
    /// <summary>
    /// Write to output objects of type T
    /// </summary>
    /// <typeparam name="T">Type of objects to output. DynamicObject is only used in this code, but where the data structure is known fully defined types could be used, also allowing for validation.</typeparam>
    public interface IWriter<T>
    {
        void Write(IEnumerable<T> values);
    }
}