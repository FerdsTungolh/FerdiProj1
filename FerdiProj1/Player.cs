﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerdiProj1
{
   public class Player
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int CRT { get; set; }
        public int Defense { get; set; }
        public int Crit { get; set; }
        public int Mana { get; set; }
        public int Crited { get; set; }
        public int Healed { get; set; }
        public List <Skill> Skills { get; set; }


        public Player(string name, int hp ,int crt, int defense, int crit, int mana)
        {
            Name = name;
            Hp = hp;
            CRT = crt;
            Defense = defense;
            Crit = crit;
            Mana = mana;
            Skills = new List<Skill>();
        }
        public void Addskill(Skill skill) 
        {
            Skills.Add(skill) ;
        }
        public void Useskill(Skill skill, Player opponent, Player currentplayer) 
        {
            Random ran = new Random();
            int hitchance = ran.Next(1, 101);
            int critchance = ran.Next(1, 101);
            if (hitchance > skill.Accuracy) 
            {
                Healed = 0;
                Crit = 0;
                return;
            
            }

            if (critchance > Crit)
            {
                int damage = (skill.Damage * 2) - opponent.Defense;
                damage = Math.Max(5, damage);
                opponent.Hp -= damage;
                opponent.Hp = Math.Max(0, opponent.Hp);
                Crited = 2;
                Healed = 0;
            }
            else 
            {
                int damage = skill.Damage - opponent.Defense;
                damage = Math.Max(5, damage);
                opponent.Hp -= damage;
                opponent.Hp = Math.Max(0, opponent.Hp);               
                Crited = 1;
                Healed = 0;
            }
        }
        public void Healskill(int heal, Player player)
        {
            {
                if (heal > 0)
                {
                    int healing = player.Hp + heal;
                    Healed = 1;
                    player.Hp = healing;
                    if (player.Hp >= 101)
                    {
                        player.Hp = 100;
                    }
                }
            }
        }
        public bool isdefeated() 
        {
            return Hp<=0;
        }
   }

}
