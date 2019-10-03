using System;
using static System.Console;

namespace LinkedListDemo
{
    class Program
    {
        private static LinkedList list => LinkedListInstance.GetInstance;

        static void Main(string[] args)
        {
            try
            {
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

        private static void PerformAction(string option)
        {
            (bool success, int optionNumber) = CheckOption(option);
            if (!success)
                return;

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
                    list.DeleteFirstNode();
                    break;

                case 5:
                    list.DeleteLastNode();
                    break;

                case 6:
                    WriteLine("Enter Data To Delete");
                    data = ReadLine();
                    list.DeleteSpecificNode(data);
                    break;
                case 7:
                    list.PrintList();
                    break;

                default:
                    WriteLine("Error Occured While Performing The Operation");
                    break;
            }
        }

        private static (bool, int) CheckOption(string option)
        {
            //int optionNumber = default(int);
            bool success = int.TryParse(option, out int optionNumber);

            if (!success || (optionNumber > 7 || optionNumber < 1))
            {
                WriteLine("Enter Valid Choice");
                return (false, default(int));
            }

            return (success, optionNumber);
        }

        private static void PrintOptions()
        {
            WriteLine("1 - Add Item At First");
            WriteLine("2 - Add Item At Last");
            WriteLine("3 - Add Item After Specific Position");
            WriteLine("4 - Delete First Item");
            WriteLine("5 - Delete Last Item");
            WriteLine("6 - Delete Specific Item");
            WriteLine("7 - Print List");
        }
    }

    public sealed class LinkedListInstance
    {
        private static LinkedList _instance = null;

        private  static object syncLock = new object();

        //Prevent Instantiation from outside
        private LinkedListInstance()
        { }

        //ThreadSafe
        public static LinkedList GetInstance
        {
            get
            {
                if(_instance == null)
                {
                    lock (syncLock)
                    {
                        if(_instance == null)
                        {
                            _instance = new LinkedList();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
