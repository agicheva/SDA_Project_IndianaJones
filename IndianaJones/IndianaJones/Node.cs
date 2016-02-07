using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class Node
    {
        private int index;
        private int value;
        private int weight;
        private double maxValue;
        private int[] addedItems;               // 0 or 1 showing if the item is taken
        private static List<Item> items;
        private static int capacity;

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public double MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public int[] AddedItems
        {
            get
            {
                return addedItems;
            }

            set
            {
                addedItems = value;
            }
        }        

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        internal static List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }

        public static int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public Node(int index, int value, int weight, int[] addedItems)
        {
            Index = index;
            Value = value;
            Weight = weight;
            AddedItems = addedItems;

            MaxValue = CalculateMaxValue(AddedItems);
        }

        public double CalculateMaxValue(int[] addedItems)
        {
            int i = 0;
            double maxValue = 0;
            double weight = 0;

            while (weight + Items[i].Weight * addedItems[i] <= Capacity)
            {
                weight += Items[i].Weight * addedItems[i];
                maxValue += Items[i].Value * addedItems[i];
                i++;

                if (i == Items.Count) break;
            }

            if (i < Items.Count)
            {
                maxValue += (Capacity - weight) * Items[i].Value / Items[i].Weight;
            }
            return maxValue;
        }

        public override string ToString()
        {
            return "value: " + value + ", weight: " + weight;
        }
    }
}
