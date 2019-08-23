using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Services
{
    public interface ISwapper
    {
        string swap(string input);
        string swapBack(string input);
    }
}
