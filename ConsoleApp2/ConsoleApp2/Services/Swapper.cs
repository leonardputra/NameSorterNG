using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSorter.Services
{
    public class Swapper:ISwapper
    {

        public List<string> swapList(List<string> input, bool swapBackMode) {
            List<string> result = new List<string>();
            if (input.Count != 0)
            {
                if (swapBackMode == false)
                {
                    foreach (string i in input)
                    {
                        result.Add(swap(i));
                    }
                    return result;
                }
                foreach (string i in input)
                {
                    result.Add(swapBack(i));
                }
                return result;
            }
            return null;
        }

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
