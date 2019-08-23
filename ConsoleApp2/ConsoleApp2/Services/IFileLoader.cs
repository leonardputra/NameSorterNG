using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Services
{
    public interface IFileLoader
    {
        string ReadFromFile(string FileName);
    }
}
