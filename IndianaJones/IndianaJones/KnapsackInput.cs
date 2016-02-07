using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class KnapsackInput
    {
        private List<Item> items;
        private int capacity;

        //List of items Indiana Jones is going to be able to choose of 
        public List<Item> Items
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

        //The capacity of Indiana Jones knapsack
        public int Capacity
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
        
        public KnapsackInput()
        {
            Items = new List<Item>();
        }
    }
}
