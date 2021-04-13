using System.IO;
using System.IO.Abstractions;
 
namespace ConsoleApp1
{
    public class FileProcessorTestable
    {
        private readonly IFileSystem _fileSystem;
 
        public FileProcessorTestable() : this (new FileSystem()) {}
 
        public FileProcessorTestable(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }
 
        public void ConvertFirstLineToUpper(string inputFilePath)
        {
            string outputFilePath = Path.ChangeExtension(inputFilePath, ".out.txt");
 
            using (StreamReader inputReader = _fileSystem.File.OpenText(inputFilePath))
            using (StreamWriter outputWriter = _fileSystem.File.CreateText(outputFilePath))
            {
                bool isFirstLine = true;
 
                while (!inputReader.EndOfStream)
                {
                    string line = inputReader.ReadLine();
 
                    if (isFirstLine)
                    {
                        line = line.ToUpperInvariant();
                        isFirstLine = false;
                    }
 
                    outputWriter.WriteLine(line);
                }
            }
        }
    }
}