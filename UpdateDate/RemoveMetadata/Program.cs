using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            var files = Directory.EnumerateFiles(path);
            string prodString = @"ms.prod";
            string techString = @"ms.technology";

            foreach (var file in files)
            {
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader streamReader = new StreamReader(file))
                {
                    string currentLine;

                    while (streamReader.Peek() >= 0)
                    {
                        currentLine = streamReader.ReadLine();

                        if (currentLine.Contains(prodString) || currentLine.Contains(techString))
                        {
                            continue;
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
