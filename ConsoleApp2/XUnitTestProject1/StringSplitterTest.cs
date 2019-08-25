using System;
using Xunit;
using ConsoleApp2.Services;

namespace XUnitTestProject1
{
    public class StringSplitterTest
    {
        private readonly IStringSplitter service;
        public StringSplitterTest()
        {
            this.service = new StringSplitter();
        }


        [Fact]
        public void Split_2Name_ReturnArrayOfWords()
        {
            string[] testResult = service.split("Alpha Bravo\nCharlie Delta");

            string[] expectedResult = { "Alpha Bravo", "Charlie Delta" };
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Split_Null_ReturnNull()
        {
            string[] testResult = service.split(null);

            string[] expectedResult = null;
            Assert.Equal(testResult, expectedResult);
        }
    }
}
