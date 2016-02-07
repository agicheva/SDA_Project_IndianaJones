using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class DynamicProgramingSolver : KnapsackSolver
    {
        private int[,] resultTable;      //keeps the results
        private List<Item> addedItems;      //shows items taken by Indiana Jones

        public DynamicProgramingSolver(List<Item> items, int capacity) : base(items, capacity)
        {
            
        }

        public override int Solve()
        {
            this.resultTable = new int[this.Items.Count + 1, this.Capacity + 1];
            int[,] keep = new int[this.Items.Count + 1, this.Capacity + 1];       //keep information which item is taken
            addedItems = new List<Item>();

            for (int w = 0; w < this.Capacity; w++)
            {
                resultTable[0, Capacity] = 0;
            }

            for (int i = 1; i <= Items.Count; i++)
            {
                for (int w = 0; w <= Capacity; w++)
                {
                    if (Items[i-1].Weight <= w && (Items[i-1].Value + resultTable[i - 1, w - Items[i-1].Weight] > resultTable[i - 1, w]))
                    {
                        resultTable[i, w] = Math.Max(resultTable[i - 1, w], Items[i-1].Value + resultTable[i - 1, w - Items[i-1].Weight]);
                        keep[i, w] = 1;
                    }
                    else
                    {
                        resultTable[i, w] = resultTable[i - 1, w];
                        keep[i, w] = 0;
                    }
                }
            }

            int col = this.Capacity;
            for (int i = this.Items.Count; i > 1; i--)
            {
                if (keep[i, col] == 1)
                {
                    addedItems.Add(this.Items[i-1]);
                    col -= this.Items[i-1].Weight;
                }

            }

            PrintTable(resultTable);

            return resultTable[Items.Count, Capacity];
        }

        private void PrintTable(int[,] resultTable)
        {
            for (int i = 0; i < this.Items.Count + 1; i++)
            {
                for (int j = 0; j < this.Capacity+1; j++)
                {
                    Console.Write(resultTable[i, j] + string.Format("{0}", resultTable[i, j] < 10 ? "  " : " "));
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            StringBuilder showingAddedItems = new StringBuilder();
            foreach (var item in addedItems)
            {
                showingAddedItems.AppendLine(item.Name);
            }

            return showingAddedItems.ToString();
        }
    }
}
