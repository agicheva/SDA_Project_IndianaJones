using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    abstract class KnapsackSolver
    {
        private List<Item> items;
        private int capacity;

        protected List<Item> Items
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

        protected int Capacity
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

        protected KnapsackSolver(List<Item> items, int capacity)
        {
            Items = items;
            Capacity = capacity;
        }

        public abstract int Solve();
    }
}
