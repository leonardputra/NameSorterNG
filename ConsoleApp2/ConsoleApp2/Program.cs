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

            Console.WriteLine("Welcome to NameSorter!");
            Console.WriteLine("Input File:");
            string input = fileLoader.ReadFromFile("unsorted name.txt");
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
            List<String> sorted = sorter.sort(swapped);
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
