using System;
using System.Collections.Generic;
using System.Linq;
using NameSorter;
using NameSorter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NameSorter
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileLoader, FileLoader>()
                .AddSingleton<IStringSplitter, StringSplitter>()
                .AddSingleton<ISwapper, Swapper>()
                .AddSingleton<ISorter, Sorter>()
                .BuildServiceProvider();

            IFileLoader fileLoader = serviceProvider.GetService<IFileLoader>();
            IStringSplitter stringSplitter = serviceProvider.GetService<IStringSplitter>();
            ISwapper swapper = serviceProvider.GetService<ISwapper>();
            ISorter sorter = serviceProvider.GetService<ISorter>();

            screenWriter screenWriter = new screenWriter();
            Entities.Settings settings = new Entities.Settings();
            List<string> swapped = new List<string>();
            string inputFile = null;

            Console.WriteLine(@"
                   _   _                      ____             _              _   _  ____ 
                  | \ | | __ _ _ __ ___   ___/ ___|  ___  _ __| |_ ___ _ __  | \ | |/ ___|
                  |  \| |/ _` | '_ ` _ \ / _ \___ \ / _ \| '__| __/ _ \ '__| |  \| | |  _ 
                  | |\  | (_| | | | | | |  __/___) | (_) | |  | ||  __/ |    | |\  | |_| |
                  |_| \_|\__,_|_| |_| |_|\___|____/ \___/|_|   \__\___|_|    |_| \_|\____| v 2.0
                                                                             
            ");
            while (fileLoader.ReadFromFile(inputFile) == null)
            {
                Console.Write("Input File Name: ");
                inputFile = Console.ReadLine();
            }
            string input = fileLoader.ReadFromFile(inputFile);

            while (!settings.sortByValid())
            {
                Console.Write("Sort By? [F]irst Name / [L]ast Name : ");
                settings.sortBy = Console.ReadLine();
            }

            while (!settings.sortModeValid())
            {
                Console.Write("Sort Mode? [A]scending / [D]escending : ");
                settings.sortMode = Console.ReadLine();
            }

            //split files to string array
            var result = stringSplitter.split(input);
            Console.WriteLine("\nInput file:");
            screenWriter.writeArray(result);

            //swap the names if the sortby is LAST NAME
            if (settings.sortBy == "L" || settings.sortBy == "l")
            {
                Console.WriteLine("\nSwapped:");
                swapped = swapper.swapList(result.ToList(), false);
                screenWriter.writeList(swapped);
            }
            else {
                swapped = result.ToList();
            }

            //sort the names Ascending or Descending
            Console.WriteLine("\nSorted:");
            List<String> sorted = new List<String>();
            if (settings.sortMode == "A" || settings.sortMode == "a") {
                sorted = sorter.sortAscending(swapped);
            }
            else {
                sorted = sorter.sortDescending(swapped);
            }
            screenWriter.writeList(sorted);

            //swap back the names if the sortby is LAST NAME
            if (settings.sortBy == "L" || settings.sortBy == "l")
            {
                Console.WriteLine("\nSwapped Again: ");
                swapped = swapper.swapList(sorted, true);
                screenWriter.writeList(swapped);
            }
        }
    }

    public class screenWriter{
        public void writeArray(string[] input) {
            foreach (string i in input)
            {
                Console.WriteLine(i);
            }
        }

        public void writeList(List<string> input)
        {
            foreach (string i in input)
            {
                Console.WriteLine(i);
            }
        }
    }
}
