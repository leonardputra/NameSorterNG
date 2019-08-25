using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Entities
{
    public class Settings
    {
        public string inputFile { get; set; }
        public string sortMode { get; set; }
        public string sortBy { get; set; }

        public bool sortByValid()
        {
            if (sortBy != null)
            {
                string[] containsArray = new string[] { "F", "f", "L", "l" };
                foreach (var s in containsArray)
                {

                    if (sortBy.Contains(s))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public bool sortModeValid()
        {
            if (sortMode != null)
            {
                string[] containsArray = new string[] { "A", "a", "D", "d" };
                foreach (var s in containsArray)
                {
                    if (sortMode.Contains(s))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    
}
