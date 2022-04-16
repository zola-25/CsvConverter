# CsvConverter

A console application that converts a csv file to either JSON or XML.

Usage:

| Parameter          | Description                                                                                  |
| ------------------ | -------------------------------------------------------------------------------------------- |
| -i --input         | The input file path (required)
| -o --output        | The output file path. If none is specified, the output will be written to the console
| -t --outputType    | The output type ('JSON' or 'XML'). Defaults to 'JSON'
| --nestingDelimiter | The nesting delimiter for converting column headers into nested json or XML e.g. address_number, address_city into one address object with number and city properties. Defaults to '_'. Hyphens cannot be used.

Example: csvConverter.exe -i input.csv -o output.json -t JSON
