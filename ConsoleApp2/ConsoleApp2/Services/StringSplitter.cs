using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public class StringSplitter:IStringSplitter
    {
        public string[] split(string input)
        {
            if (input != null)
            {
                return input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            }
            return null;
        }
    }
}
