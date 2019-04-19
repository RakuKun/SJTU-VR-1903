using System;
using System.Collections.Generic;
using System.Dynamic;

namespace exercise4
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        public enum Mode
        {
                PreOrder,
                MidOrder, 
                PostOrder
        }
        class Node<T>
        {
            public T data { get; set; }
            public Node<T> left { get; set; }
            public Node<T> right { get; set; }

            public Node()
            {
                data = default(T);
                left = null;
                right = null;
            }

            public Node(T data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }
        
        private Node<T> root;
        public int Count { get; set; }

        public BinarySearchTree()
        {
            root = null;
            Count = 0;
        }

        public BinarySearchTree(params T[] dataList)
        {
            foreach (var data in dataList)
            {
                Insert(data);
            }
        }

        public T FindMin()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                T minData = root.data;

                Node<T> leftNode = root.left;
                while (leftNode != null)
                {
                    minData = leftNode.data;

                    leftNode = leftNode.left;
                }

                return minData;
            }
        }

        public T FindMax()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                T maxData = root.data;

                Node<T> rightNode = root.right;
                while (rightNode != null)
                {
                    maxData = rightNode.data;

                    rightNode = rightNode.right;
                }

                return maxData;
            }
        }
        public void Insert(T data)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.data = data;
                Count++;
            }
            else
            {
                Insert(data, root);
                Count++;
            }

        }

        private void Insert(T data, Node<T> node)
        {
            //data == node.data
            //Console.WriteLine(data);
            if (data.CompareTo(node.data) == 0)
            {
                return;
            }
            //data < node.data
            else if (data.CompareTo(node.data) < 0)
            {
                if (node.left == null)
                {
//                    Node<T> leftNode = new Node<T>();
//                    leftNode.data = data;
//                    node.left = leftNode;
                    node.left = new Node<T>(data);
                }
                else
                {
                    Insert(data, node.left);
                }
            }
            //data > node.data
            else if (data.CompareTo(node.data) > 0)
            {
                if (node.right == null)
                {
//                    Node<T> rightNode = new Node<T>();
//                    rightNode.data = data;
//                    node.right = rightNode;
                    node.right = new Node<T>(data);
                }
                else
                {
                    Insert(data, node.right);
                }
            }
        }

        public List<T> Traversal(Mode mode)
        {
            List<T> dataList = new List<T>();

            if (mode == Mode.PreOrder)
            {
                PreOder(root, dataList);
            }
            else if (mode == Mode.MidOrder)
            {
                MidOder(root, dataList);
            }
            else if (mode == Mode.PostOrder)
            {
                PostOrder(root, dataList);
            }

            return dataList;
        }

        /**
         * PreOrder,
           MidOrder, 
           PostOrder
         */
        private void PreOder(Node<T> node, List<T> dataList)
        {
            if (node == null)
            {
                return;
            }
            
            dataList.Add(node.data);
            PreOder(node.left, dataList);
            PreOder(node.right, dataList);
        }

        private void MidOder(Node<T> node, List<T> dataList)
        {
            if (node == null)
            {
                return;
            }
            
            MidOder(node.left, dataList);
            dataList.Add(node.data);
            MidOder(node.right, dataList);
        }
        private void PostOrder(Node<T> node, List<T> dataList)
        {
            if (node == null)
            {
                return;
            }
            
            PostOrder(node.left, dataList);
            PostOrder(node.right, dataList);
            dataList.Add(node.data);
        }
        
        public void deleteNode(T v)
        {
            
        }
    }
}