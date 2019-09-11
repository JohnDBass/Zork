using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        enum Commands
        {
            QUIT,
            LOOK,
            NORTH,
            SOUTH,
            EAST,
            WEST,
            UNKNOWN
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();

            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door. " +
                    "\nA rubber mat saying 'Welcome to Zork!' lies by the door.");                
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }
        }
    }
}
