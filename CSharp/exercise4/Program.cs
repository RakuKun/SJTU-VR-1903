using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BinarySearchTree<T> : IEnumerable<T>
    {
        public enum Mode
        {
            PreOrder,
            InOrder,
            PostOrder
        }
        public class Node<T>
        {
            public T v = default(T);
            public Node<T> p = null;
            public Node<T> left = null;
            public Node<T> right = null;
            public Node(T n)
            {
                v = n;
            }
        }
        private Node<T> root = null;
        public int Count
        {
            get
            {
                int count = 0;
                CountNodes(root, ref count);
                return count;
            }
        }

        public BinarySearchTree(params T[] v)
        {
            if (v.Length != 0)
            {
                foreach (var item in v)
                {
                    Insert(item, this);
                }
            }
        }

        //find Minimum
        public T FindMin()
        {
            T result = default(T);
            //FindMinRecursion(root,ref result);
            result = FindMinIterative(root);
            return result;
        }
        private void FindMinRecursion(Node<T> node, ref T t)
        {
            if (node == null)
                return;
            t = node.v;
            FindMinRecursion(node.left, ref t);
        }
        private T FindMinIterative(Node<T> node)
        {
            Node<T> result = node;
            while (result.left != null)
            {
                result = result.left;
            }
            return result.v;
        }
        private Node<T> FindMinIterativeNode(Node<T> node)
        {
            Node<T> result = node;
            while (result.left != null)
            {
                result = result.left;
            }
            return result;
        }

        //find Maximum
        public T FindMax()
        {
            T result = default(T);
            FindMaxRecursion(root, ref result);
            //result = FindMaxIterative(root);
            return result;
        }
        private void FindMaxRecursion(Node<T> node, ref T t)
        {
            if (node == null)
                return;
            t = node.v;
            FindMaxRecursion(node.right, ref t);
        }
        private T FindMaxIterative(Node<T> node)
        {
            Node<T> result = node;
            while (result.right != null)
            {
                result = result.right;
            }
            return result.v;
        }
        private Node<T> FindMaxIterativeNode(Node<T> node)
        {
            Node<T> result = node;
            while (result.right != null)
            {
                result = result.right;
            }
            return result;
        }

        //tree Insert
        public void Insert(T v, BinarySearchTree<T> tree)
        {
            Node<T> y = null;
            Node<T> x = tree.root;
            Node<T> node = new Node<T>(v);
            dynamic v1 = v;
            while (x != null)
            {
                y = x;
                if (v1 < x.v)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            node.p = y;
            if (y == null)
            {
                tree.root = node;
            }
            else if (v1 < y.v)
            {
                y.left = node;
            }
            else
            {
                y.right = node;
            }
        }

        //delete tree node
        public void Erase(T v)
        {
            DeleteNode(this, Search(v));
        }
        private void DeleteNode(BinarySearchTree<T> tree, Node<T> z)
        {
            if (z.left == null)
                Transplant(tree, z, z.left);
            else if (z.right == null)
                Transplant(tree, z, z.right);
            else
            {
                Node<T> y = FindMinIterativeNode(z.right);
                if (y.p != z)
                {
                    Transplant(tree, y, y.right);
                    y.right = z.right;
                    y.right.p = y;
                }
                Transplant(tree, z, y);
                y.left = z.left;
                y.left.p = y;
            }
        }
        private void Transplant(BinarySearchTree<T> tree, Node<T> u, Node<T> v)
        {
            if (u.p == null)
                tree.root = v;
            else if (u == u.p.left)
                u.p.left = v;
            else
                u.p.right = v;
            if (v != null)
                v.p = u.p;
        }

        //search target
        public Node<T> Search(T v)
        {
            Node<T> result = null;
            //SearchRecursion(root, v,ref result);
            result = SearchIterative(root, v);
            return result;
        }
        private void SearchRecursion(Node<T> node, T v, ref Node<T> result)
        {
            if (node == null)
                return;
            dynamic v1 = node.v;
            if (v1 == v)
            {
                result = node;
            }
            SearchRecursion(node.left, v, ref result);
            SearchRecursion(node.right, v, ref result);
        }
        private Node<T> SearchIterative(Node<T> node, T v)
        {
            dynamic v1 = v;
            while (node != null && v1 != node.v)
            {
                if (v1 < node.v)
                    node = node.left;
                else
                    node = node.right;
            }
            return node;
        }

        //count nodes' amounts
        private void CountNodes(Node<T> node, ref int count)
        {
            if (node == null)
                return;
            else
                count++;
            CountNodes(node.left, ref count);
            CountNodes(node.right, ref count);
        }

        //tree walk
        public List<T> Traversal(Mode mode)
        {
            List<T> result = new List<T>();
            switch (mode)
            {
                case Mode.PreOrder:
                    PreOrder(root, result);
                    break;
                case Mode.InOrder:
                    InOrder(root, result);
                    break;
                case Mode.PostOrder:
                    PostOrder(root, result);
                    break;
            }
            return result;
        }
        private void PreOrder(Node<T> node, List<T> t)
        {
            if (node == null)
                return;
            t.Add(node.v);
            PreOrder(node.left, t);
            PreOrder(node.right, t);
        }


        private void InOrder(Node<T> node, List<T> t)
        {
            if (node == null)
                return;
            InOrder(node.left, t);
            t.Add(node.v);
            InOrder(node.right, t);
        }

        private void PostOrder(Node<T> node, List<T> t)
        {
            if (node == null)
                return;
            PostOrder(node.left, t);
            PostOrder(node.right, t);
            t.Add(node.v);
        }

        //predecessor node
        public T Predecessor(T t)
        {
            return PredecessorNode(Search(t)).v;
        }
        private Node<T> PredecessorNode(Node<T> node)
        {
            if (node.left != null)
                return FindMaxIterativeNode(node.left);
            Node<T> result = node.p;
            while (result != null && result.left == node)
            {
                node = result;
                result = result.p;
            }
            return result;
        }

        //successor
        public T Successor(T t)
        {
            return SuccessorNode(Search(t)).v;
        }
        private Node<T> SuccessorNode(Node<T> node)
        {
            if (node.right != null)
                return FindMinIterativeNode(node.right);
            Node<T> result = node.p;
            while (result != null && result.right == node)
            {
                node = result;
                result = result.p;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Stack<Node<T>> s = new Stack<Node<T>>();
            Node<T> currentNode = root;
            while (currentNode != null || !(s.Count == 0))
            {
                if (currentNode != null)
                {
                    s.Push(currentNode);
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = s.Pop();
                    yield return currentNode.v;
                    currentNode = currentNode.right;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    class Program
    {
        static void Main()
        {
            int[] a = { 6, 5, 2, 8, 7, 9, 10 };
            BinarySearchTree<int> bst = new BinarySearchTree<int>(a);
            Console.Write("List data:");
            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.Write("PreOrder:");
            List<int> result = bst.Traversal(BinarySearchTree<int>.Mode.PreOrder);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.Write("InOrder:");
            result = bst.Traversal(BinarySearchTree<int>.Mode.InOrder);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.Write("PostOrder:");
            result = bst.Traversal(BinarySearchTree<int>.Mode.PostOrder);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine($"search 5 and print parent's value:{bst.Search(5).p.v}");
            Console.WriteLine($"7's predecessor is : {bst.Predecessor(7)}");
            Console.WriteLine($"6's successor is :{bst.Successor(6)}");

            bst.Erase(8);
            Console.Write("After deleting 8,PreOrder:");
            result = bst.Traversal(BinarySearchTree<int>.Mode.PreOrder);
            //foreach (var item in result)
            //{
            //    Console.Write($"{item} ");
            //}

            foreach (var item in bst)
            {
                Console.WriteLine(item);
            }

            while (true)
            {

            }
        }
    }
}
