using System;

namespace CsvConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 'Pure' Dependency Injection, could use a framework like Autofac for production
            var csvConverter = new CsvConverterProgram(new CommandLineParser(), new ConverterBuilder());
            csvConverter.Run(args);
        }
    }
}
