using System;
using System.Collections.Generic;
using Xunit;
using NameSorter.Services;

namespace XUnitTestProject1
{
    public class SorterTest
    {
        private readonly ISorter service;
        public SorterTest()
        {
            this.service = new Sorter();
        }


        [Fact]
        public void SortAscending_3ArrayOfString_ReturnArrayOfStringSortedAlphabetically()
        {
            List<string> mockNames = new List<string>();
            mockNames.Add("Echo Fanta");
            mockNames.Add("Charlie Delta");
            mockNames.Add("Alpha Bravo");

            List<string> expectedResult = new List<string>();
            expectedResult.Add("Alpha Bravo");
            expectedResult.Add("Charlie Delta");
            expectedResult.Add("Echo Fanta");

            List<string> testResult = service.sortAscending(mockNames);

            Assert.Equal(testResult, expectedResult);
        }

        [Fact]
        public void SortDescending_3ArrayOfString_ReturnArrayOfStringSortedAlphabetically()
        {
            List<string> mockNames = new List<string>();
            mockNames.Add("Alpha Bravo");
            mockNames.Add("Charlie Delta");
            mockNames.Add("Echo Fanta");

            List<string> expectedResult = new List<string>();
            expectedResult.Add("Echo Fanta");
            expectedResult.Add("Charlie Delta");
            expectedResult.Add("Alpha Bravo");

            List<string> testResult = service.sortDescending(mockNames);

            Assert.Equal(testResult, expectedResult);
        }


    }
}
