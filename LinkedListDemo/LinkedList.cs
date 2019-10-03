using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListDemo
{
    /// <summary>
    /// Class used to perform common LinkedList operations
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Always point to first Node of linked list and NULL in case of empty list
        /// </summary>
        private Node head;

        #region Constructors
        public LinkedList()
        {
            head = null;
        }
        #endregion

        /// <summary>
        /// Create and return new node for linked list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>       

        public void PrintList()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("List Is Empty");
                return;
            }

            Node current = head;

            Console.WriteLine("Current List Is: ");
            while (current != null)
            {
                Console.Write(current.data + ", ");
                current = current.next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Add Node at first position in linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAtFirst(object data)
        {
            //Create new node
            Node newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            newNode.next = head;
            head = newNode;
        }

        /// <summary>
        /// Add Node at last position in linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAtLast(object data)
        {
            //Create new node
            Node newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            Node current = head;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        /// <summary>
        /// Add node after specific element in linked list
        /// </summary>
        /// <param name="data"></param>
        /// <param name="insertAfterElement"></param>
        public void AddNodeAfterSpecificElement(object data, object insertAfterElement)
        {
            //Create new node
            Node newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            Node current = head;

            while (current != null)
            {
                //Compairing Objects
                if (current.data.Equals(insertAfterElement))
                    break;

                current = current.next;
            }

            if (current == null)
            {
                Console.WriteLine("Data Not Found");
                return;
            }

            newNode.next = current.next;
            current.next = newNode;
        }

        /// <summary>
        /// Delete first node from linked list
        /// </summary>
        public void DeleteFirstNode()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("List Is Already Empty");
                return;
            }

            head = head.next;
        }

        /// <summary>
        /// Delete last node from linked list
        /// </summary>
        public void DeleteLastNode()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("List Is Already Empty");
                return;
            }

            if (HasOnlyOneNode())
            {
                head = null;
            }

            Node current = head;

            while (current.next.next != null)
                current = current.next;

            current.next = null;
        }

        /// <summary>
        /// Delete specific element from linked list
        /// </summary>
        /// <param name="dataToDelete"></param>
        public void DeleteSpecificNode(object dataToDelete)
        {
            if (IsEmptyList())
            {
                Console.WriteLine("List Is Already Empty");
                return;
            }

            if (HasOnlyOneNode())
            {
                if (head.data.Equals(dataToDelete))
                {
                    head = null;
                    return;
                }
                Console.WriteLine("Data Not Found");
                return;
            }

            if(head.data.Equals(dataToDelete))
            {
                head = head.next;
                return;
            }

            Node current = head;

            while (current.next != null)
            {
                if (current.next.data.Equals(dataToDelete))
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
            Console.WriteLine("Data not Found");
        }

        #region PrivateMethods
        private bool HasOnlyOneNode()
        {
            return head.next == null;
        }

        private static Node InitializeNewNode(object data)
        {
            return new Node(data);
        }

        private void CreateList(Node newNode)
        {
            head = head ?? newNode;
        }

        private bool IsEmptyList()
        {
            return head == null;
        }
        #endregion
    }
}
