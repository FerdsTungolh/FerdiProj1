﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerdiProj1
{
    public class Skill
    {
        public string Name { get; }
        public int Damage { get; }
        public int Accuracy { get; }
        public int ManaCost {get; }
        public int Healing { get; }
        public Skill(string name, int damage, int accuracy, int manacost, int heal)
        {
            Name = name;
            Damage = damage;
            Accuracy = accuracy;
            ManaCost = manacost;
            Healing = heal;
        }
    }
}
