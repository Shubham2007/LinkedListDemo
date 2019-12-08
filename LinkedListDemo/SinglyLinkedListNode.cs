namespace LinkedListDemo
{
    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode() : this(default(object))
        { }

        public SinglyLinkedListNode(object data)
        {
            this.next = null;
            this.data = data;
        }
        public SinglyLinkedListNode next { get; set; }
        public object data { get; set; }
    }
}
