﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Room
    {
        public override int GetHashCode() => Name.GetHashCode();
        public string Name { get; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Room(string name,string description = "")
        {
            Name = name;
            Description = description;
        }

       

        
    }
}
