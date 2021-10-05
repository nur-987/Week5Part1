using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //normal
            Console.WriteLine("Calling the sleepTask method");
            sleepTask();
            

            //async
            Thread thread_name = new Thread(new ThreadStart(sleepTask));
            thread_name.Start();
            thread_name.Join(); //will make this sync. 
                                //once this has finished running then "doSomething" will run.

            //the small task to carry out 
            Console.WriteLine("calling doSomething method");
            doSomething();

            //background task 
            Thread backGround_task = new Thread(new ThreadStart(myTask));
            backGround_task.IsBackground = true;
            //the prog will not wai for this task to be completed before it exists

            Console.WriteLine("calling doSomething method");
            doSomething(); //called again to see prog exit after this is done.
                           //without waiting for backGround to finish.

            
            //passing a delegate in the thread
            Action act = sleepTask;
            CreatNewThread(act);

            //Thread with param
            Thread thParam = new Thread(new ParameterizedThreadStart(sleepTaskParam));
            thParam.Start(10);

            Console.WriteLine("Done with main prog");

            Console.ReadLine();
        }

        //the method to be caried out 
        //normally this would be a big process
        public static void sleepTask()
        {
            Console.WriteLine("in sleep thread, taking a nap");
            Thread.Sleep(2000);
            Console.WriteLine("Doing some work");
            Thread.Sleep(5000);
            Console.WriteLine("im doing work");


        }

        //a very light weight task o run in main and compare with the async
        public static void doSomething()
        {
            Console.WriteLine("perform quick task");
        }

        public static void myTask()
        {
            for (int i = 0; i <1000; i++)
            {
                Console.WriteLine("myTask " + i);
            }
        }


        //thread with Action delegate
        private static void CreatNewThread(Action act)
        {
            Thread th = new Thread(new ThreadStart(act));
        }

        public static void sleepTaskParam(object sleepDuration)
        {
            Console.WriteLine("In background task. Taking a nap");
            Thread.Sleep((int)sleepDuration * 1000);
            Console.WriteLine("done with background");
        }
    }

}
