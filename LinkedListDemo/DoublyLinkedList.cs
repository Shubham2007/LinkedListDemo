using System;
using static System.Console;

namespace LinkedListDemo
{
    /// <summary>
    /// Class used to perform common DoublyLinkedList operations
    /// </summary>
    public class DoublyLinkedList : ILinkedList
    {
        #region Fields
        /// <summary>
        /// Always point to first DoublyLinkedListNode of linked list and NULL in case of empty list
        /// </summary>
        private DoublyLinkedListNode head;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize empty list for the first time
        /// </summary>
        public DoublyLinkedList()
        {
            head = null;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Print current doubly linked list for default head
        /// </summary>

        public void PrintList()
        {
            PrintList(head: in head); //Default head
        }

        /// <summary>
        /// Print doubly linked list for given head
        /// </summary>
        public void PrintList(in DoublyLinkedListNode head)
        {
            if (IsEmptyList(in head))
            {
                WriteLine("List is empty");
                return;
            }

            DoublyLinkedListNode curr = head;

            WriteLine("Current List Is: ");
            while (curr != null)
            {
                Write(curr.data + ", ");
                curr = curr.next;
            }
            WriteLine();
        }

        /// <summary>
        /// Add DoublyLinkedListNode at first position in linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAtFirst(object data)
        {
            DoublyLinkedListNode node = InitializeNewNode(data);

            if (IsEmptyList())
            {             
                CreateList(node);
                return;
            }

            node.next = head;
            head = node;
        }

        public void AddNodeAtLast(object data)
        {
            DoublyLinkedListNode node = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(node);
                return;
            }

            DoublyLinkedListNode temp = head;

            while(temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = node;
            node.prev = temp;
        }

        /// <summary>
        /// Add node after specific element in linked list
        /// </summary>
        /// <param name="data"></param>
        /// <param name="insertAfterElement"></param>
        public void AddNodeAfterSpecificElement(object data, object insertAfterElement)
        {
            //Check for empty list
            if (IsEmptyList())
            {
                WriteLine("List is empty");
                return;
            }

            DoublyLinkedListNode curr = head;

            while (curr != null && !insertAfterElement.Equals(curr.data)) 
            {
                curr = curr.next;
            }

            //Data not found
            if(curr == null)
            {
                WriteLine("Data not found");
                return;
            }

            //Insert node after current
            DoublyLinkedListNode temp = InitializeNewNode(data);
            temp.next = curr.next;
            temp.prev = curr;
            temp.next.prev = temp;
            curr.next = temp;
        }

        #endregion

        #region PrivateMethods
        private bool HasOnlyOneNode()
        {
            return head.next == null;
        }

        private static DoublyLinkedListNode InitializeNewNode(object data)
        {
            return new DoublyLinkedListNode(data);
        }

        private void CreateList(DoublyLinkedListNode newNode)
        {
            head = head ?? newNode;
        }

        private bool IsEmptyList() //Check the default head
        {
            return head == null;
        }

        private bool IsEmptyList(in DoublyLinkedListNode head) //Check the given head
        {
            return head == null;
        }

        
        
        #endregion
    }
}
