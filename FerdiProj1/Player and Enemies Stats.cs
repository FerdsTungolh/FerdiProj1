using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerdiProj1
{
    public class Player_and_Enemies_Stats
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Crit { get; set; }
        public int Defense { get; set; }
        public int Mana { get; set; }
        public int Manaregenrate { get; set; }

        public Player_and_Enemies_Stats(string name, int hp, int crit, int defense, int mana, int manaregenrate)
        {
            Name = name;
            Hp = hp;
            Crit = crit;
            Defense = defense;
            Mana = mana;
            Manaregenrate = manaregenrate;
        }
        public Player_and_Enemies_Stats()
        {
            //Nothing here
        }
        public List<Player_and_Enemies_Stats> Entity()
        {
            List<Player_and_Enemies_Stats> EntityStats = new List<Player_and_Enemies_Stats>();
            //Player Health and Stats (Name, Hp, Defense, Critrate, Mana, Mana regen)
            EntityStats.Add(new Player_and_Enemies_Stats("Ferds", 100, 10, 50, 100, 5));
            EntityStats.Add(new Player_and_Enemies_Stats("Kurt", 100, 5, 50, 100, 5));
            return EntityStats;
        }

    }
}