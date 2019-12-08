namespace LinkedListDemo
{
    /// <summary>
    /// Node class for doubly linked list
    /// </summary>
    public class DoublyLinkedListNode
    {
        /// <summary>
        /// Actual data of node
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// Pointer to previous node of list
        /// </summary>
        public DoublyLinkedListNode prev { get; set; }

        /// <summary>
        /// Pointer to next node of list
        /// </summary>
        public DoublyLinkedListNode next { get; set; }
        
        /// <summary>
        /// Constructor to initialize defaut node
        /// </summary>
        public DoublyLinkedListNode() : this(default(object))
        { }

        /// <summary>
        /// Constructor to initialize node with given data
        /// </summary>
        /// <param name="data"></param>
        public DoublyLinkedListNode(object data)
        {
            this.data = data;
            prev = null;
            next = null;
        }
    }
}
