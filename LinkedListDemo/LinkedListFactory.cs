using System;

namespace LinkedListDemo
{
    /// <summary>
    /// Creates the instance of linked list classes
    /// </summary>
    public class LinkedListFactory
    {
        public static ILinkedList GetLinkedListInstance(LinkedListTypeEnum type)
        {
            CheckValidEnumvalue(typeof(LinkedListTypeEnum), type);

            if(type == LinkedListTypeEnum.SinglyLinkedList)
                return new SinglyLinkedList();

            return new DoublyLinkedList();
        }

        /// <summary>
        /// Check if the enum value is in the range 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private static void CheckValidEnumvalue(Type type, LinkedListTypeEnum value)
        {
            if (!Enum.IsDefined(type, value))
                throw new Exception("Invalid Option Value");
        }
    }
}
