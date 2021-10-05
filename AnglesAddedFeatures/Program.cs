using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnglesAddedFeatures
{
    /// <summary>
    /// write a c# program to find out from the given angle 
    /// values whether a geometrical shape can be formed or not . if yes then what type of shape it is. 
    /// Use anonymous method, event and delegate and exception handling
    /// *not implemented Anonymous method
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many angels do you want to enter?");
            int res = Int32.Parse(Console.ReadLine());
            if (res == 3)
            {
                GetAngles(out string[] angel);

                int num1 = Int32.Parse(angel[0]);
                int num2 = Int32.Parse(angel[1]);
                int num3 = Int32.Parse(angel[2]);

                Func<int, int, int, bool> myFunc = CheckTriangle;
                Console.WriteLine(myFunc(num1, num2, num3)); 

                Console.ReadLine();

            }
            if (res == 4)
            {
                GetAngles(out string[] angel);
                int num1 =0, num2 =0, num3 = 0, num4=0;
                try
                {
                    num1 = Int32.Parse(angel[0]);
                    num2 = Int32.Parse(angel[1]);
                    num3 = Int32.Parse(angel[2]);
                    num4 = Int32.Parse(angel[3]);
                }
                catch(ArgumentNullException ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
                Func<int, int, int, int, string> myFunc2 = CheckFourSide;
                Console.WriteLine(myFunc2(num1, num2, num3, num4));

                Console.ReadLine();

            }
            if (res == 5)
            {
                GetAngles(out string[] angel);
                int total = Int32.Parse(angel[0]) + Int32.Parse(angel[1]) + Int32.Parse(angel[2]) +
                            Int32.Parse(angel[3]) + Int32.Parse(angel[4]);

                if (total == 540)
                {
                    Console.WriteLine("The 5 angels make a polygon");
                }
                else
                {
                    Console.WriteLine("The 5 angels do not make a shape");
                }

            }
            else
            {
                Console.WriteLine("Wrong response please try again.");
                Console.ReadLine();
            }
        }

        public static void GetAngles(out string[] angels)
        {
            Console.WriteLine("Please input your angels to check.");
            Console.WriteLine("Separate them with a comma");

            string[] separatedAngel = { "a", "b" };

            try
            {
                string input = Console.ReadLine();
                separatedAngel = input.Split(',');
                
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Error! {ex.Message}" );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }

            angels = separatedAngel;

        }

        public static bool CheckTriangle(int num1, int num2, int num3)
        {
            if(num1+num2+num3 == 180)
            {
                return true;
            }
            return false;
        }
        public static string CheckFourSide(int num1, int num2, int num3, int num4)
        {
            if (num1 + num2 + num3 + num4 == 360)
            {
                return "A four sided shape can be created!";
            }
            return "A four sided shape CANNOT be created!";
        }
    }
}
