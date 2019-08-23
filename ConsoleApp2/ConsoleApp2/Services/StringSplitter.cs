using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Services
{
    public class StringSplitter:IStringSplitter
    {
        public string[] split(string input)
        {
            return input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }
    }
}
