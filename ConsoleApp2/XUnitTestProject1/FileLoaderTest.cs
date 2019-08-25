using System;
using Xunit;
using ConsoleApp2.Services;

namespace XUnitTestProject1
{
    public class FileLoaderTest
    {
        private readonly IFileLoader service;
        public FileLoaderTest()
        {
            this.service = new FileLoader();
        }


        [Fact]
        public void FileLoader_NullFiles_ShouldReturnNull()
        {
            string testResult = service.ReadFromFile(null);
            Assert.Null(testResult);
        }

        [Fact]
        public void FileLoader_FileNotAvailable_ShouldReturnNull()
        {
            string testResult = service.ReadFromFile("unavailableFile.txt");
            Assert.Null(testResult);
        }

        [Fact]
        public void FileLoader_FileAvailable_ShouldReturnString()
        {
            string testResult = service.ReadFromFile("unsorted name.txt");
            Assert.NotNull(testResult);
        }
    }
}
