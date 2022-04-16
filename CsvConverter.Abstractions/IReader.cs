using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace CsvConverter.Abstractions
{
    /// <summary>
    /// Read source and output objects of type T
    /// </summary>
    /// <typeparam name="T">Type of objects to output. DynamicObject is only used in this code, but where the data structure is known fully defined types could be used, also allowing for validation.</typeparam>
    public interface IReader<T>
    {
        IEnumerable<T> Read();
    }
}