using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LongListTracker
{
    class Program
    {

        static char defaultSymbol = '\x1e';

        static void Main(string[] args)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> tasks = new List<string>(System.IO.File.ReadAllLines("longList.txt"));
            bool run = true;
            Console.WriteLine("Welcome to your Simple Scanning task list!");
            while (run)

            {
                autoDeleteItem(tasks);
                Console.ForegroundColor = ConsoleColor.Yellow;


                Console.WriteLine("Would you like to view your list? \nAdd an item to the list? \nComplete an item on the list? \nOr re-enter an item?" +
                    " \nType add, complete, reenter,  view, delete, or to quit, type quit.");
                string userInput = Console.ReadLine();


                if (userInput == "add")
                {
                    addToList(userInput, tasks);
                    Console.Clear();
                }

                else if (userInput == "complete")
                {
                    completeTask(tasks);

                }


                else if (userInput == "reenter")
                {
                    reEnter(tasks);
                }

                else if (userInput == "view")
                {
                    printList(tasks);

                }

                else if (userInput =="delete")
                {
                    deleteItem(tasks);
                }

                else if (userInput == "quit")
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry, I didn't understand. Please choose one of the selections presented to you. They're case sensitive!");
                    Console.ResetColor();

                }

                System.IO.File.WriteAllLines("longList.txt", tasks);


            }



        }
        private static void deleteItem(List<string> tasks)
        {
            try
            {


                foreach (string task in tasks)
                {
                    Console.WriteLine($"{tasks.IndexOf(task)}. {task}");
                }
                Console.WriteLine("Please put the number of the item you would like to delete: ");
                string userInput = Console.ReadLine();
                int input2 = Convert.ToInt32(userInput);

                if (input2 < 0 || input2 > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is wrong. You know it's wrong. Please do the right thing. >:(");

                }
                else if (input2 >= 0 && input2 <= 25)
                {
                    tasks.Remove(tasks[input2]);



                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry, I didn't understand. Please choose one of the selections presented to you. They're case sensitive!");
                Console.ResetColor();
            }
        }

        private static void autoDeleteItem(List<string> tasks)
        {
            bool girlbye = true;
            while (girlbye)
            if (tasks[0].Contains(defaultSymbol))
            {
                tasks.Remove(tasks[0]);

            }
            else
            {
                    girlbye = false;
            }
        }


        private static void completeTask(List<string> tasks) 
        {
            try
            {
                foreach (string task in tasks)
                {
                    Console.WriteLine($"{tasks.IndexOf(task)}. {task}");
                }
                Console.WriteLine("Please put the number of the item you would like to mark as completed: ");
                string userInput = Console.ReadLine();
                int input2 = Convert.ToInt32(userInput);

                if (input2 < 0 || input2 > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is wrong. You know it's wrong. Please do the right thing. >:(");


                }
                else if (input2 >= 0 && input2 <= 25)
                {

                    tasks[input2] += defaultSymbol;


                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry, I didn't understand. Please choose one of the selections presented to you. They're case sensitive!");
                Console.ResetColor();
            }
        }

        private static void reEnter(List<string> tasks)
        {
            try
            {
                foreach (string task in tasks)
                {
                    Console.WriteLine($"{tasks.IndexOf(task)}. {task}");
                }
                Console.WriteLine("Please put the number of the item you would like to reenter: ");
                string userInput = Console.ReadLine();
                int input2 = Convert.ToInt32(userInput);

                if (input2 < 0 || input2 > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is wrong. You know it's wrong. Please do the right thing. >:(");

                }
                else if (input2 >= 0 && input2 <= 25)
                {
                    tasks.Add(tasks[input2]);
                    tasks[input2] += defaultSymbol;


                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry, I didn't understand. Please choose one of the selections presented to you. They're case sensitive!");
                Console.ResetColor();
            }

        }

        
        private static void addToList(string userInput, List<string> tasks)
        {
            bool enter = true;
            while (enter)
            {



                
                    Console.WriteLine("Please add a task or type quit to exit", tasks.Count()+1);
                
                    string usersInput = Console.ReadLine();
                    if (usersInput == "quit")
                    {
                    enter = false;
                    }
                    else
                    {
                        tasks.Add(usersInput);
                    
                    }
                Console.ResetColor();
                
            }
        }



        private static void printList(List<string> tasks)
        {
            Console.Clear();
            foreach (string task in tasks)
            {
                if (task.Contains(defaultSymbol))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{tasks.IndexOf(task)}. {task}");
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{tasks.IndexOf(task)}. {task}");
                }

            }
            Console.WriteLine("Please remember the number of the selection you want to choose, you may find it useful.");

        }
        
    }
}
