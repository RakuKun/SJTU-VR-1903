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
			public Node<T> parent {get; set; }
            public Node<T> left { get; set; }
            public Node<T> right { get; set; }

            public Node()
            {
                data = default(T);
				parent = null;
                left = null;
                right = null;
            }

            public Node(T data)
            {
                this.data = data;
				parent = null;
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

        private Node<T> FindMinNode(Node<T> node)
        {
            if (Count == 0)
            {
                return new Node<T>();
            }
            else
            {
                Node<T> minDataNode = node;

                Node<T> leftNode = node.left;
                while (leftNode != null)
                {
                    minDataNode = leftNode;

                    leftNode = leftNode.left;
                }

                return minDataNode;
            }
        }
		
		public T findMin()
		{
			return FindMinNode(root).data;
		}

        private Node<T> FindMaxNode(Node<T> node)
        {
            if (Count == 0)
            {
                return new Node<T>();
            }
            else
            {
                Node<T> maxDataNode = node;

                Node<T> rightNode = node.right;
                while (rightNode != null)
                {
                    maxDataNode = rightNode;

                    rightNode = rightNode.right;
                }

                return maxDataNode;
            }
        }
		
		public T findMax()
		{
			return FindMaxNode(root).data;
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
                    Node<T> leftNode = new Node<T>();
                    leftNode.data = data;
                    node.left = leftNode;
	                leftNode.parent = node;
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
                    Node<T> rightNode = new Node<T>();
                    rightNode.data = data;
                    node.right = rightNode;
	                rightNode.parent = node;
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
		
		private Node<T> searchNode(Node<T> node, T data)
		{
//			if (node == null)
//			{
//				return null;
//			}
//			if (data.CompareTo(node.data) == 0)
//			{
//				return node;
//			}
//
//			if (node.left != null)
//			{
//				searchNode(node.left, data);
//			}
//
//			if (node.right != null)
//			{
//				searchNode(node.right, data);
//			}
//			
//			return null;
			if (node == null)
			{
				return null;
			}

			if (node.data.CompareTo(data) > 0)
			{
				return searchNode(node.left, data);
			}
			else if (node.data.CompareTo(data) < 0)
			{
				return searchNode(node.right, data);
			}
			else
				return node;
		}
        
        public void delete(T data)
        {
			if (Count == 0)
			{
				return;
			}
            Node<T> node = searchNode(root, data);
			if (node == null)
			{
				return;
			}
			
			if (node.left != null && node.right != null)
			{
				Node<T> deleteNode = FindMinNode(node);
				node.data = deleteNode.data;
				
				if (deleteNode.right != null)
				{
					deleteNode.parent.left = deleteNode.right;
					deleteNode.right.parent = deleteNode.parent;
				}
				else
				{
					deleteNode.parent.left = null;
				}
			}
			else if(node.left != null && node.right == null)
			{
				if (node.parent.left == node)
				{
					node.parent.left = node.left;
				}
				else{
					node.parent.right = node.left;
				}
			}
			else if(node.left == null && node.right != null)
			{
				if (node.parent.left == node)
				{
					node.parent.left = node.right;
				}
				else{
					node.parent.right = node.right;
				}
			}
			else
			{
				if (node.parent.left == node)
				{
					node.parent.left = null;
				}
				else{
					node.parent.right = null;
				}
			}
        }
    }
}