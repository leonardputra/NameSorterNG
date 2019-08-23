using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Services
{
    public class Sorter:ISorter
    {
        public List<string> sort(List<string> input)
        {
            input.Sort();
            return input;
        }
    }
}
