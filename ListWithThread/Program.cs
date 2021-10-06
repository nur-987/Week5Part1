using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListWithThread
{
    /// <summary>
    /// Write a program which operate on a List and Does addition and Removal. 
    /// It can be any List with any particular type. 
    /// You have to spawn threads depending on user inputs 
    /// which can add and remove from the original List.
    /// </summary>
    class Program
    {
        //not working. NO THREAD function yet

        static void Main(string[] args)
        {
            Items item = new Items();
            bool b = true;
            while (b)
            {
                Console.WriteLine("Press 1) to ADD, 2) to REMOVE");
                int input = Int32.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("Item NAME:");
                    object tempName = Console.ReadLine();

                    Items newItem = new Items();
                    newItem.ItemName = tempName;

                    Thread tdAdd = new Thread(new ParameterizedThreadStart(item.AddItem));
                    tdAdd.Start(newItem);

                }
                else if (input == 2)
                {
                    Console.WriteLine("Name of item to remove: ");
                    object tempName = Console.ReadLine();

                    Items newItem = new Items();
                    newItem.ItemName = tempName;

                    Thread tdRemove = new Thread(new ParameterizedThreadStart(item.Remove));
                    tdRemove.Start(newItem);
                }
                else
                {
                    Console.WriteLine("exiting program");
                    b = false;
                }
            }
            

            Console.ReadLine();
        }

    }

    class Items
    {
        public object ItemName { get; set; }

        public static List<Items> ObjectItems = new List<Items>(); 
        
        public void AddItem(object objName)
        {
            Items newItem = (Items)objName;
            ObjectItems.Add(newItem);
            Console.WriteLine("Number of items in List: " + ObjectItems.Count);

            Console.WriteLine("Items in list now:");
            foreach (Items item in ObjectItems)
            {
                Console.WriteLine(item.ItemName);
            }

        }

        public void Remove(object objName)
        {
            Items itemToRemove = (Items)objName;

            foreach (Items item in ObjectItems)
            {
                if (item.ItemName == itemToRemove)
                {
                    ObjectItems.Remove(item);
                    Console.WriteLine("remove successful");
                }
            }
            Console.WriteLine("Number of items in List: " + ObjectItems.Count);
        }
    }
    
}
