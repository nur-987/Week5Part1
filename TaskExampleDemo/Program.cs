using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExampleDemo
{
    class Program
    {

        static void Main(string[] args)
        {

            #region intro
            //Action<object> action = doSomething;

            ////declaration  METHOD 1
            //Task t1 = new Task(action, "apple");
            //t1.Start();

            ////can be with or without params, based on the method.
            //Task t2 = new Task(action, "pineapple");
            //t2.Start();

            ////must have a wait. else prog may end before execution finishes
            //t1.Wait();
            //t2.Wait();     

            ////declaration  METHOD 2 
            //Task t3 = Task.Factory.StartNew(action, "honeydew");

            ////task RUN + anonymous function
            //Task t4 = Task.Run(() =>
            //{
            //    Console.WriteLine($"Task ID: {Task.CurrentId}");
            //    //when a task is created => a thread is created too
            //    Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            //});

            #endregion  

            task_Run_ex().Wait(); 
            task_Run_ex();      //run to see the out put difference

            Task_waitAll();

            TaskwithFunc();

            Console.ReadLine();
        }

        public static void doSomething(object myValue)
        {
            Console.WriteLine($"Task ID: {Task.CurrentId}");
            //when a task is created => a thread is created too
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"task execute with value: {myValue}");

        }

        public static async Task task_Run_ex()  //run this prog to see how async await works
        { //task with method
            Console.WriteLine("In task run method");
            await Task.Run(() =>
            {
                for(int i = 0; i<20; i++)
                {
                    Console.WriteLine($"in iteration {i}");
                    Thread.Sleep(2000);
                }
            });
            Console.WriteLine("out of task run method");
        }

        public static void Task_waitAll()
        {
            var tasks = new List<Task>();

            Action<object> action = doSomething;
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(action, i));
                //create a new task every iteration
            }
            Task.WaitAll(tasks.ToArray()); 
            //waitAll => takes an array of tasks and wait for them to complete
        }

        //Task with func => to return a value with Task
        public static void TaskwithFunc()
        {
            Func<object, int> func = (obj) =>
            {
                Console.WriteLine("this is task with func. with parameter obj");
                return ((int)obj* 100); //just random num
            };
            //task with a return type

            var result = Task<int>.Run(() =>
            {
                return func(100);
            });
            Console.WriteLine(result.Result);
            
        }
    }

}
