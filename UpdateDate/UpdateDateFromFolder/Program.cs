using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UpdateDateFromFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            var files = Directory.EnumerateFiles(path);
            string _dateText = @"ms.date";

            foreach (var file in files)
            {
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader streamReader = new StreamReader(file))
                {
                    string currentLine;

                    while (streamReader.Peek() >= 0)
                    {
                        currentLine = streamReader.ReadLine();

                        if (currentLine.Contains(_dateText))
                        {
                            currentLine = _dateText + @": " + DateTime.Today.ToString("d");
                        }

                        stringBuilder.AppendLine(currentLine);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    streamWriter.Write(stringBuilder.ToString());
                }
            }
        }
    }
}
