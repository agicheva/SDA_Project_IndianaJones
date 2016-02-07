using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaJones
{
    class BranchAndBoundSover : KnapsackSolver
    {
        public int[] addedItems;                
        private List<Node> branchingNodes;      //last nodes in the "tree"
        private Node root;                      //start node
        
        public BranchAndBoundSover(List<Item> items, int capacity) : base(items, capacity)
        {
            Node.Items = Items;
            Node.Capacity = Capacity;

            items.Sort(delegate (Item i1, Item i2) { return (i1.Value / i1.Weight).CompareTo(i2.Value / i2.Weight); });
            items.Reverse();

            addedItems = new int[this.Items.Count];
            for (int i = 0; i < addedItems.Length; i++)
            {
                addedItems[i] = 1;
            }
            root = new Node(0, 0, 0, addedItems);
            branchingNodes = new List<Node>() { root };
        }

        public override int Solve()
        {
            while (true)
            {
                branchingNodes.Sort(delegate (Node node1, Node node2) { return node1.MaxValue.CompareTo(node2.MaxValue); });

                if (branchingNodes.Last().Index == this.Items.Count)
                {
                    Console.WriteLine("The value is: {0} and the items are {1}",
                        branchingNodes.Last().Value, string.Join(", ", branchingNodes.Last().AddedItems));
                    return branchingNodes.Last().Value;

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("branching: " + branchingNodes.Last());
                Console.WriteLine("------------");
                Branch(branchingNodes.Last());

                foreach (Node node_ in branchingNodes)
                {
                    Console.WriteLine(node_);
                }
            }
            return -1;
        }

        private void Branch(Node node)
        {
            branchingNodes.Remove(node);

            Node nodeLeft = new Node(node.Index + 1, node.Value + Items[node.Index].Value, node.Weight + Items[node.Index].Weight, (int[])node.AddedItems.Clone());

            int[] addedItemsClone = (int[])node.AddedItems.Clone();
            addedItemsClone[node.Index] = 0;
            Node nodeRight = new Node(node.Index + 1, node.Value, node.Weight, addedItemsClone);

            if (nodeLeft.Weight <= this.Capacity)
            {
                branchingNodes.Add(nodeLeft);
            }

            if (nodeRight.Weight<=this.Capacity)
            {
                branchingNodes.Add(nodeRight);
            }
        }

    }
}
