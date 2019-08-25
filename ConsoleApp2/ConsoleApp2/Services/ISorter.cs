using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Services
{
    public interface ISorter
    {
        List<string> sortAscending(List<string> input);
        List<string> sortDescending(List<string> input);
    }
}
