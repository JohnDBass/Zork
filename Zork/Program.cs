using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        private static Room[,] Rooms;       

        private static (int Row, int Column) Location = (1, 1);

        private static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        private static List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private enum Fields
        {
            Name = 0,
            Description
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            const string defaultRoomsFilename = "Rooms.json";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);
            InitializeRooms(roomsFilename);

            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;

            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);                                            
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
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }

        }


        private static void InitializeRooms(string roomsFilename) =>
            Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));

        private static Commands ToCommand(string commandString) => 
            (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid Direction");

            bool canMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.SOUTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;

                default:
                    canMove = false;
                    break;
            }
            return canMove;
        }
        
    }
}
