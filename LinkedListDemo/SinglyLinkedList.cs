using System;

namespace LinkedListDemo
{
    /// <summary>
    /// Class used to perform common LinkedList operations
    /// </summary>
    public class SinglyLinkedList : ILinkedList
    {
        /// <summary>
        /// Always point to first SinglyLinkedListNode of linked list and NULL in case of empty list
        /// </summary>
        private SinglyLinkedListNode head;
        private SinglyLinkedListNode dummyHead; //For copy list

        #region Constructors
        public SinglyLinkedList()
        {
            head = null;
            dummyHead = null;
        }
        #endregion

        /// <summary>
        /// Print current linked list for default head
        /// </summary>

        public void PrintList()
        {
            PrintList(head: in head); //Default head
        }

        /// <summary>
        /// Print linked list for given head
        /// </summary>
        public void PrintList(in SinglyLinkedListNode head)
        {
            if (IsEmptyList(in head))
            {
                Console.WriteLine("List Is Empty");
                return;
            }

            SinglyLinkedListNode current = head;

            Console.WriteLine("Current List Is: ");
            while (current != null)
            {
                Console.Write(current.data + ", ");
                current = current.next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print current linked list but in reverse
        /// </summary>
        public void PrintListInReverse()
        {
            Console.WriteLine("Current List Is: ");
            PrintListInReverse(head);
            Console.WriteLine();
        }      

        /// <summary>
        /// Add SinglyLinkedListNode at first position in linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAtFirst(object data)
        {
            //Create new node
            SinglyLinkedListNode newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            newNode.next = head;
            head = newNode;
        }

        /// <summary>
        /// Add SinglyLinkedListNode at last position in linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAtLast(object data)
        {
            //Create new node
            SinglyLinkedListNode newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            SinglyLinkedListNode current = head;

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
            SinglyLinkedListNode newNode = InitializeNewNode(data);

            if (IsEmptyList())
            {
                CreateList(newNode);
                return;
            }

            SinglyLinkedListNode current = head;

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

            //Insert node
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

            SinglyLinkedListNode current = head;

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

            SinglyLinkedListNode current = head;

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

        /// <summary>
        /// Reveres the current linked list
        /// </summary>
        public void ReverseList()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("List Is Already Empty");
                return;
            }

            if (HasOnlyOneNode())
                return;

            //If list has atleast 2 nodes
            SinglyLinkedListNode prev = null, next = null, current = head;
            while(current != null)
            {
                next = current.next;
                current.next = prev; //Actual reversal
                prev = current;
                current = next;
            }
            head = prev;
        }

        /// <summary>
        /// Copy original linked list to another
        /// </summary>
        public void CopyLinkedList()
        {
            if(IsEmptyList())
            {
                Console.WriteLine("Original list is empty");
                return;
            }

            SinglyLinkedListNode newNode = InitializeNewNode(head.data);
            dummyHead = newNode; //If already copied then resetting

            SinglyLinkedListNode current = head.next, temp = dummyHead;

            while(current != null)
            {
                SinglyLinkedListNode tempNode = InitializeNewNode(current.data);
                temp.next = tempNode;
                current = current.next;
                temp = temp.next;
            }
        }

        /// <summary>
        /// Print out the copied list
        /// </summary>
        public void PrintCopiedList()
        {
            //Never be empty, since we are copying only if original has some items.
            PrintList(dummyHead);
        }

        /// <summary>
        /// Detect the loop in linked list
        /// </summary>
        public void DetectAndRemoveLoop()
        {
            if(IsEmptyList())
            {
                Console.WriteLine("List Is Already Empty");
                return;
            }

            //If list is not empty
            SinglyLinkedListNode slow = head, fast = head;

            while(fast != null && fast.next != null) //If no loop
            {
                slow = slow.next; //Move 1 step
                fast = fast.next.next; //Move 2 steps

                if(ReferenceEquals(slow, fast)) //Loop detect if both meets
                {
                    Console.WriteLine("Loop Detected");
                    int loopLength = GetLoopLength(slow, fast);
                    Console.WriteLine("Length of the loop is : " + loopLength);
                    RemoveLoop(head, slow, fast);
                }
            }
            Console.WriteLine("No Loop Detected");
        }      
        
        

        #region PrivateMethods
        private bool HasOnlyOneNode()
        {
            return head.next == null;
        }

        private static SinglyLinkedListNode InitializeNewNode(object data)
        {
            return new SinglyLinkedListNode(data);
        }

        private void CreateList(SinglyLinkedListNode newNode)
        {
            head = head ?? newNode;
        }

        private bool IsEmptyList() //Check the default head
        {
            return head == null;
        }

        private bool IsEmptyList(in SinglyLinkedListNode head) //Check the given head
        {
            return head == null;
        }

        private void PrintListInReverse(in SinglyLinkedListNode head)
        {
            if (IsEmptyList(head))
                return;

            PrintListInReverse(head.next);

            Console.Write(head.data + ", ");
        }

        private int GetLoopLength(SinglyLinkedListNode slow, SinglyLinkedListNode fast)
        {
            int length = 1;
            slow = fast.next;

            while(!ReferenceEquals(slow, fast))
            {
                slow = slow.next;
                length++;
            }
            return length;
        }

        /// <summary>
        /// Remove loop from the linked list
        /// </summary>
        /// <param name="head"></param>
        /// <param name="slow"></param>
        /// <param name="fast"></param>
        private void RemoveLoop(SinglyLinkedListNode head, SinglyLinkedListNode slow, SinglyLinkedListNode fast)
        {
            SinglyLinkedListNode temp = head;

            while(true)
            {
                while(!ReferenceEquals(slow.next, fast) || !ReferenceEquals(slow.next, temp))
                {
                    slow = slow.next;
                }

                //Last node found
                if (!ReferenceEquals(slow.next, temp)) 
                {
                    //loop removed
                    slow.next = null;
                    Console.WriteLine("Loop removed");
                    break;
                }

                temp = temp.next;
            }
        }
        #endregion
    }
}
