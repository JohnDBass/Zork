using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        private static string[] Rooms =
            {"Forest", "West of House", "Behind House", "Clearing", "Canyon View"};

        private static int roomColumn;

        private static List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        static void Main(string[] args)
        {
            roomColumn = 1;
            Console.WriteLine("Welcome to Zork!");
            Commands command = Commands.UNKNOWN;            

            while (command != Commands.QUIT)
            {
                Console.WriteLine(Rooms[roomColumn]);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door." +
                            " \n A rubber mat saying 'Welcome to Zork!' lies by the door");                                                
                        break;

                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:                    
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The Way is shut!");
                        }
                        else
                        {
                            Console.WriteLine("You moved " + (command) );
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }

        }

        private static Commands ToCommand(string commandString) => 
            (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);       

        private static bool Move(Commands command)
        {            
            bool canMove = true;
            switch (command)
            {
                case Commands.NORTH:
                    break;

                case Commands.SOUTH:
                    break;

                case Commands.EAST when roomColumn < Rooms.GetLength(0) - 1:
                    roomColumn++;
                    break;

                case Commands.WEST when roomColumn > 0:
                    roomColumn--;
                    break;

                default:
                    canMove = false;
                    break;
            }
            return canMove;
        }
        
    }
}
