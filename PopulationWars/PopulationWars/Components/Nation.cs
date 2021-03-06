﻿using PopulationWars.Components.Governments;
using System;

namespace PopulationWars.Components
{
    [Serializable]
    public class Nation
    {
        public string Name { get; set; }
        public IGovernment Government { get; set; }

        public Nation(string name, IGovernment government)
        {
            Name = name;
            Government = government;
        }

        public override string ToString() => $"{Name} ({Government})";
    }
}