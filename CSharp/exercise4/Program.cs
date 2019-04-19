using System;
using System.Collections.Generic;

namespace exercise4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] datas = {4, 2, 6, 1, 3, 5, 7};
            BinarySearchTree<int> tree = new BinarySearchTree<int>(datas);
            
            List<int> dataList = new List<int>();

            dataList = tree.Traversal(BinarySearchTree<int>.Mode.PreOrder);        
            Console.WriteLine("PreOrder:");
            foreach (var data in dataList)
            {
                Console.Write(data + "");
            }
            Console.WriteLine();
            
            dataList = tree.Traversal(BinarySearchTree<int>.Mode.MidOrder);        
            Console.WriteLine("MidOrder:");
            foreach (var data in dataList)
            {
                Console.Write(data + "");
            }
            Console.WriteLine();
            
            dataList = tree.Traversal(BinarySearchTree<int>.Mode.PostOrder);        
            Console.WriteLine("PostOrder:");
            foreach (var data in dataList)
            {
                Console.Write(data + "");
            }
            Console.WriteLine();
            
            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.FindMin());
            Console.WriteLine(tree.FindMax());
        }
    }
}