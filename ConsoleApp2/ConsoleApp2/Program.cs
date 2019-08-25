using System;
using System.Collections.Generic;
using ConsoleApp2;
using ConsoleApp2.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2
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
            Entities.Settings settings = new Entities.Settings();
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

            while (settings.sortByValid() == false)
            {
                Console.Write("Sort By? [F]irst Name / [L]ast Name : ");
                settings.sortBy = Console.ReadLine();
            }

            while (settings.sortModeValid() == false)
            {
                Console.Write("Sort Mode? [A]scending / [D]escending : ");
                settings.sortMode = Console.ReadLine();
            }

            var result = stringSplitter.split(input);
            foreach (string name in result)
            {
                Console.WriteLine(name);
            }

            List<string> swapped = new List<string>();
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Swapped:");
            foreach (string name in result)
            {
                swapped.Add(swapper.swap(name));
                Console.WriteLine(swapped[index]);
                index++;
            }

            Console.WriteLine("");
            Console.WriteLine("Sorted:");
            List<String> sorted = sorter.sortAscending(swapped);
            foreach (string name in sorted)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
            Console.WriteLine("Swapped Again:");
            index = 0;
            swapped = new List<string>();
            foreach (string name in sorted)
            {
                swapped.Add(swapper.swapBack(name));
                Console.WriteLine(swapped[index]);
                index++;
            }
        }
    }
}
