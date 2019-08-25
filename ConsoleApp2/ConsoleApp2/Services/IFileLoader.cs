using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface IFileLoader
    {
        string ReadFromFile(string FileName);
    }
}
