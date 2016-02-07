using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class Item
    {
        private string name;
        private int value;
        private int weight;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public Item(string name, int value, int weight)
        {
            Name = name;
            Value = value;
            Weight = weight;
        }
    }
}
