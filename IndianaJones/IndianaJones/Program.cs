using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input1 = new KnapsackInput()
            //{
            //    Capacity = 18,
            //    Items =
            //                         new List<Item>()
            //                             {
            //                                 new Item ("fourth", 12, 4),
            //                                 new Item ("third", 10, 6),
            //                                 new Item ("second", 8, 5),
            //                                 new Item ("cheese", 11, 7),
            //                                 new Item ("first", 14, 3),
            //                                 new Item ("potatos", 7, 1),
            //                                 new Item ("bear", 9, 6)
            //                         }
            //};
            //PrintResults(input1);


            var input2 = new KnapsackInput()
            {
                Capacity = 7,
                Items = ReadInputFromFile()
                                    
            };
            PrintResults(input2);


        }

        public static void PrintResults(KnapsackInput input)
        {
            List<KnapsackSolver> listOfSolvers = new List<KnapsackSolver>()
            {
                new DynamicProgramingSolver(input.Items, input.Capacity),
                new BranchAndBoundSover(input.Items, input.Capacity)
            };


            Console.WriteLine("The maximum value with given capacity of knapsack({0}) is: {1}", input.Capacity, listOfSolvers[0].Solve());
            listOfSolvers[1].Solve();
        }

        public static List<Item> ReadInputFromFile()
        {
            string path = @"C:\Users\IVAN\Desktop\Programming-101-CSharp\IndianaJones\IndianaJones\bin\Debug\fileInput.txt";
            List<Item> inputItems = new List<Item>();

            string[] readFile = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < readFile.Length; i++)
            {
                string[] propertiesOfItem = readFile[i].Split(' ');
                inputItems.Add(new Item(propertiesOfItem[0], Int32.Parse(propertiesOfItem[1]), Int32.Parse(propertiesOfItem[2])));
            }
            return inputItems;
        }
    }
}
