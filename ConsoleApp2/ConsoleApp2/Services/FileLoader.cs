using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.Services
{
    public class FileLoader : IFileLoader
    {
        public string ReadFromFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                return File.ReadAllText(FileName);
            }
            return null;
        }
    }
}
