﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSorter.Services
{
    public class Sorter:ISorter
    {
        public List<string> sortAscending(List<string> input)
        {
            input.Sort();
            return input;
        }

        public List<string> sortDescending(List<string> input)
        {
            input.Sort();
            input.Reverse();
            return input;
        }
    }
}
