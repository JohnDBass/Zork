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

        private int currentRoom;


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            currentRoom = 1;

            while (command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door." +
                            " \n A rubber mat saying 'Welcome to Zork!' lies by the door";                                                
                        break;

                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                        outputString = "The way is shut.";
                        break;

                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}. \n {Rooms[currentRoom]}";
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;
                }

                Console.WriteLine(outputString);
            }

        }

        private static Commands ToCommand(string commandString) => 
            (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        private 
    }
}
