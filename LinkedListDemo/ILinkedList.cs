namespace LinkedListDemo
{
    /// <summary>
    /// Interface for linked list operations
    /// </summary>
    public interface ILinkedList
    {
        /// <summary>
        /// Print current linked list for default head
        /// </summary>
        void PrintList();

        /// <summary>
        /// Add LinkedListNode at first position in linked list
        /// </summary>
        /// <param name="data"></param>
        void AddNodeAtFirst(object data);

        /// <summary>
        /// Add LinkedListNode at last position in linked list
        /// </summary>
        /// <param name="data"></param>
        void AddNodeAtLast(object data);

        /// <summary>
        /// Add node after specific element in linked list
        /// </summary>
        /// <param name="data"></param>
        /// <param name="insertAfterElement"></param>
        void AddNodeAfterSpecificElement(object data, object insertAfterElement);

        /// <summary>
        /// Delete first node from linked list
        /// </summary>
        void DeleteFirstNode(string message = null);

        /// <summary>
        /// Delete last node from linked list
        /// </summary>
        void DeleteLastNode(string message = null);

        /// <summary>
        /// Delete specific element from linked list
        /// </summary>
        /// <param name="dataToDelete"></param>
        void DeleteSpecificNode(object dataToDelete);
    }
}
