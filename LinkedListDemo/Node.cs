using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListDemo
{
    public class Node
    {
        public Node() : this(default(Object))
        { }

        public Node(Object data)
        {
            this.next = null;
            this.data = data;
        }
        public Node next { get; set; }
        public Object data { get; set; }
    }
}
