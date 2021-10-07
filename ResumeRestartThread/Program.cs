using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResumeRestartThread
{
    /// <summary>
    /// Write a program which can spawn a thread which executes a method. 
    /// The method takes a parameter called Resume or Restart. 
    /// The method displays the numbers in a series. (1,2,3....). 
    /// At any point of time You can spawn more than one thread. 
    /// If the method is passed as Resume it will start the counter from the current counter value 
    /// else it will start from 1 again.
    /// 
    /// NOT COMPLETE => Resume
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            while (b)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Resume - Restart - Exit");
                string input = Console.ReadLine();

                doSomthing(input);

                if (input == "Exit")
                {
                    b = false;
                }
            }


            
          
        }

        public static void Counter()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(5000);

                Resume(i);
            }
        }

        public static void Resume (int x)
        {
            for (int i = x; i < 10000; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(5000);
            }
        }

        public static void doSomthing(string input)
        {
            if (input == "Restart")
            {
                Thread threadRestart = new Thread(new ThreadStart(Counter));
                threadRestart.Start();

            }
            if(input == "Resume")
            {
                Thread threadResume = new Thread(new ThreadStart(Counter));
                threadResume.Start();
            }
        }

    }
   
}
