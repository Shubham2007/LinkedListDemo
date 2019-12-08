using System;
using static System.Console;

namespace LinkedListDemo
{
    class Program
    {
        //private static SinglyLinkedList list => LinkedListInstance.GetInstance;

        private static ILinkedList list { get; set; }

        static void Main(string[] args)
        {
            try
            {
                string linkedListType = string.Empty;

                WriteLine("Choose Linked List Type");
                PrintLinkedListType();
                linkedListType = ReadLine();

                int optionNumber = CheckLinkedListType(linkedListType);

                InitializeLinkedList(optionNumber);

                //Either "Y" Or "N"
                string userChoice, option = string.Empty;

                do
                {
                    PrintOptions();
                    WriteLine("Enter Valid Choice");
                    option = ReadLine();

                    PerformAction(option);

                    WriteLine("Do You Want To Continue...(Y | N)");
                    userChoice = ReadLine();

                } while (userChoice.ToLower() == "y");
            }
            catch(Exception ex)
            {
                WriteLine("Error Occured: " + ex.Message);
            }
        }

        private static void InitializeLinkedList(int listType)
        {
            ILinkedList instance = LinkedListFactory.GetLinkedListInstance((LinkedListTypeEnum)listType);

            if (instance == null)
                throw new Exception("Failed to initialize list");

            SetLinkedListInstance(instance);
            WriteLine("Initialized successfully");
        }

        private static void SetLinkedListInstance(ILinkedList instance)
            => list = instance;

        private static void PerformAction(string option)
        {
            (bool success, int optionNumber) = CheckOption(option);
            if (!success)
                throw new Exception("Invalid option number"); //Generally custom exceptions

            PerformActionOnSuccess(optionNumber);
        }

        private static void PerformActionOnSuccess(int optionNumber)
        {
            //Data to add to linked list
            object data, afterElement = default;

            switch (optionNumber)
            {
                case 1:
                    WriteLine("Enter Data");
                    data = ReadLine();
                    list.AddNodeAtFirst(data);
                    break;

                case 2:
                    WriteLine("Enter Data");
                    data = ReadLine();
                    list.AddNodeAtLast(data);
                    break;

                case 3:
                    WriteLine("Enter Data");
                    data = ReadLine();
                    WriteLine("Enter Element After Which You Want to Insert");
                    afterElement = ReadLine();
                    list.AddNodeAfterSpecificElement(data, afterElement);
                    break;

                case 4:
                    list.PrintList();
                    break;

                //case 5:                    
                //    list.DeleteFirstNode();
                //    break;

                //case 6:
                //    list.DeleteLastNode();
                //    break;

                //case 7:
                //    WriteLine("Enter Data To Delete");
                //    data = ReadLine();
                //    list.DeleteSpecificNode(data);
                //    break;
                
                //case 8:
                //    list.ReverseList();
                //    break;

                //case 9:
                //    list.PrintListInReverse();
                //    break;

                //case 10:
                //    list.CopyLinkedList();
                //    break;

                //case 11:
                //    list.PrintCopiedList();
                //    break;

                //case 12:
                //    list.DetectAndRemoveLoop();
                //    break;

                default:
                    WriteLine("Error Occured While Performing The Operation");
                    break;
            }
        }

        private static int CheckLinkedListType(string choice)
        {
            bool success = int.TryParse(choice, out int optionNumber);

            if (!success || (optionNumber > 2 || optionNumber < 1))
                throw new Exception("Invalid Linked List Type");

            return optionNumber;
        }

        private static (bool, int) CheckOption(string option)
        {
            //int optionNumber = default(int);
            bool success = int.TryParse(option, out int optionNumber);

            if (!success || (optionNumber > 4 || optionNumber < 1))
            {
                return (false, default(int));
            }

            return (success, optionNumber);
        }

        private static void PrintLinkedListType()
        {
            WriteLine("1 - Singly Linked List");
            WriteLine("2 - Doubly Linked List");
        }

        private static void PrintOptions()
        {
            WriteLine("1 - Add Item At First");
            WriteLine("2 - Add Item At Last");
            WriteLine("3 - Add Item After Specific Position");
            WriteLine("4 - Print List");
            //WriteLine("5 - Delete First Item");
            //WriteLine("6 - Delete Last Item");
            //WriteLine("7 - Delete Specific Item");           
            //WriteLine("8 - Reverse List");
            //WriteLine("9 - Print List In Reverse");
            //WriteLine("10 - Copy Linked List");
            //WriteLine("11 - Print Copied List");
            //WriteLine("12 - Detect And Remove Loop");
        }
    }

    //public sealed class LinkedListInstance
    //{
    //    private static SinglyLinkedList _instance = null;

    //    private  static object syncLock = new object();

    //    //Prevent Instantiation from outside
    //    private LinkedListInstance()
    //    { }

    //    //ThreadSafe
    //    public static SinglyLinkedList GetInstance
    //    {
    //        get
    //        {
    //            if(_instance == null)
    //            {
    //                lock (syncLock)
    //                {
    //                    if(_instance == null)
    //                    {
    //                        _instance = new SinglyLinkedList();
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
    //}
}
