using System.IO.Abstractions.TestingHelpers;
using Xunit;
 
namespace XUnitTestProject1
{
    public class FileProcessorTestableShould
    {
        [Fact]
        public void ConvertFirstLine()
        {
            var mockFileSystem = new MockFileSystem();
 
            var mockInputFile = new MockFileData("line1\nline2\nline3");
 
            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);
 
            var sut = new FileProcessorTestable(mockFileSystem);
            sut.ConvertFirstLineToUpper(@"C:\temp\in.txt");
 
            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\in.out.txt");
 
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
 
            Assert.Equal("LINE1", outputLines[0]);
            Assert.Equal("line2", outputLines[1]);
            Assert.Equal("line3", outputLines[2]);
        }
    }
}
