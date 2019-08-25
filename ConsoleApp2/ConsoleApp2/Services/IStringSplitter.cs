using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface IStringSplitter
    {
        string[] split(string input);
    }
}
