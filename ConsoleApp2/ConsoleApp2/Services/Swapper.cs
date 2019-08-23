using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Services
{
    public class Swapper:ISwapper
    {
        public string swap(string input)
        {
            string[] a = input.Split(' ');
            var result = a.Skip(a.Length - 1)
                .Concat(a.Take(a.Length - 1)).ToArray();
            var newString = string.Join(" ", result);
            return newString;
        }

        public string swapBack(string input)
        {
            string[] a = input.Split(' ');
            var result = a.Skip(1)
                .Concat(a.Take(1)).ToArray();
            var newString = string.Join(" ", result);
            return newString;
        }
    }
}
