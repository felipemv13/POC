using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // example 1
            //try
            //{
            //    int x = 1;
            //    int y = 55;
            //    double z = x / y;
            //    Console.WriteLine(z);                
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}
            //finally
            //{
            //    Console.Read();
            //}

            // example 2
            try
            {
                Console.WriteLine("Hello World");
                throw new Exception("Goodby cruel world.");
                Console.WriteLine("Goodbye");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {

            }


        }
    }
}
