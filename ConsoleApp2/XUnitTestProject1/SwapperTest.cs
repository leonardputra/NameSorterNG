using System;
using Xunit;
using NameSorter.Services;
using System.Collections.Generic;

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

        [Fact]
        public void SwapList_ListOfString_ReturnSwappedList()
        {
            List<string> mockList = new List<string>();
            mockList.Add("Alpha Bravo");
            mockList.Add("Charlie Delta");
            mockList.Add("Echo Fanta");

            List<string> testResult = service.swapList(mockList, false);

            List<string> expectedResult = new List<string>();
            expectedResult.Add("Bravo Alpha");
            expectedResult.Add("Delta Charlie");
            expectedResult.Add("Fanta Echo");

            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void SwapList_ListOfString_ReturnSwappedBackList()
        {
            List<string> mockList = new List<string>();
            mockList.Add("Alpha 1 Bravo");
            mockList.Add("Charlie 2 Delta");
            mockList.Add("Echo 3 Fanta");

            List<string> testResult = service.swapList(mockList, true);

            List<string> expectedResult = new List<string>();
            expectedResult.Add("1 Bravo Alpha");
            expectedResult.Add("2 Delta Charlie");
            expectedResult.Add("3 Fanta Echo");

            Assert.Equal(testResult, expectedResult);
        }
    }
}
