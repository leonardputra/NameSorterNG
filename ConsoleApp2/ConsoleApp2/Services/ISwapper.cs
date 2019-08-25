using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface ISwapper
    {
        List<string> swapList(List<string> input, bool swapBackMode);
        string swap(string input);
        string swapBack(string input);
    }
}
