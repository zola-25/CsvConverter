using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter.Abstractions
{
    public interface ICommandLineParser
    {
        /// <summary>
        /// Parses the command line arguments.
        /// </summary>
        /// <param name="args">Raw command line arguments</param>
        /// <returns></returns>
        InputOptions GetInputsFromCommandArgs(string[] args);
    }
}
