using System;
using Xunit;
using ConsoleApp2.Services;

namespace XUnitTestProject1
{
    public class SwapperTest
    {
        private readonly ISwapper service;
        public SwapperTest()
        {
            this.service = new Swapper();
        }


        [Fact]
        public void Swap_2WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Alpha Bravo");
            string expectedResult = "Bravo Alpha";
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Swap_3WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Alpha Bravo Charlie");
            string expectedResult = "Charlie Alpha Bravo";
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Swap_4WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Alpha Bravo Charlie Delta");
            string expectedResult = "Delta Alpha Bravo Charlie";
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Swapback_2WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Bravo Alpha");
            string expectedResult = "Alpha Bravo";
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Swapback_3WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Bravo Charlie Alpha");
            string expectedResult = "Alpha Bravo Charlie";
            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void Swapback_4WordsName_ReturnSwappedFirstAndLastName()
        {
            string testResult = service.swap("Bravo Charlie Delta Alpha");
            string expectedResult = "Alpha Bravo Charlie Delta";
            Assert.Equal(testResult, expectedResult);
        }
    }
}
