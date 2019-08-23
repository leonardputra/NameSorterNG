using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Services
{
    public interface ISorter
    {
        List<string> sort(List<string> input);
    }
}
