using NGit.Api;
using NGit.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UpdateDate
{
    class GitHelper
    {
        private static string _dateText = @"ms.date";
        //private static string _debugRepoPath = @"C:\Repos\windows-uwp";
        private static string _currentDirectory;
        private static Git _git;
        private static FileRepository _repository;
        private static ICollection<string> _changedFiles;

        public static void UpdateDates()
        {
            _repository = GetRepository();
            _git = new Git(_repository);
            UpdateDatesInternal();
            _repository.Close();
        }

        private static FileRepository GetRepository()
        {
            FileRepositoryBuilder fileRepositoryBuilder = new FileRepositoryBuilder();
            _currentDirectory = Directory.GetCurrentDirectory();
            //_currentDirectory = _debugRepoPath;
            FileRepository repository = null;

            try
            {
                fileRepositoryBuilder.FindGitDir(_currentDirectory);
                repository = fileRepositoryBuilder.Build();
            }
            catch (System.ArgumentNullException)
            {
                Console.WriteLine("ERROR: Repo not found");
                Environment.Exit(0);
            }

            return repository;
        }

        private static void UpdateDatesInternal()
        {
            Console.WriteLine("Updating dates...");
            StatusCommand statusCommand = _git.Status();
            Status status = statusCommand.Call();
            _changedFiles = status.GetModified();

            if (_changedFiles.Count == 0)
            {
                Console.WriteLine("No files to commit");
                Environment.Exit(0);
            }

            foreach (string filename in _changedFiles)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string filePath = _currentDirectory + @"\" + filename;

                using (StreamReader streamReader = new StreamReader(filePath))
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

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(stringBuilder.ToString());
                }
            }
        }
    }
}