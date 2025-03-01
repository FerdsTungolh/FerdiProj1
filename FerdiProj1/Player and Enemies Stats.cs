using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

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
        public string SkillName { get; set; }
        public int SkillDamage { get; set; }
        public int SkillAccuracy { get; set; }
        public int SkillCost { get; set; }
        public int SkillHeal { get; set; }
        public string SkillType { get; set; }
        public string SkillEntity { get; set; }
        public string PlayerImageRight { get; set; }
        public string PlayerImageLeft { get; set; }
        public Player_and_Enemies_Stats(string name, int hp, int crit, int defense, int mana, int manaregenrate, string playerimageright, string playerimageleft)
        {
            Name = name;
            Hp = hp;
            Crit = crit;
            Defense = defense;
            Mana = mana;
            Manaregenrate = manaregenrate;
            PlayerImageRight = playerimageright;
            PlayerImageLeft = playerimageleft;
        }
        public Player_and_Enemies_Stats( string skillname, int skilldamage, int skillaccuracy, int skillcost, int skillheal, string skilltype,string skillentity)
        {
            SkillName = skillname;
            SkillDamage = skilldamage;
            SkillAccuracy = skillaccuracy;
            SkillCost = skillcost;
            SkillHeal = skillheal;
            SkillType = skilltype;
            SkillEntity = skillentity;
        }
        //(Name, Damage, Accuraccy, Manacost, Heal, Skilltype)
        public Player_and_Enemies_Stats()
        {
            //Nothing here
        }
        public List<Player_and_Enemies_Stats> Entity()
        {
            List<Player_and_Enemies_Stats> EntityStats = new List<Player_and_Enemies_Stats>();
            //Player Health and Stats (Name, Hp, Defense, Critrate, Mana, Mana regen)
            EntityStats.Add(new Player_and_Enemies_Stats("Naruto", 100, 10, 50, 100, 5, "C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\Naruto_Movement\\Naruto_Mov_00.png", "C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\Naruto_Movement\\Naruto_Mov_07.png"));
            EntityStats.Add(new Player_and_Enemies_Stats("Sasuke", 100, 5, 50, 100, 5, "C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\SasukeRight.png","C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\SasukeLeft.png"));
            
            return EntityStats;
        }
        public List<Player_and_Enemies_Stats> EntitySkills()
        {
            List<Player_and_Enemies_Stats> EntitySkillStats = new List<Player_and_Enemies_Stats>();
            //Naruto Skills
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Basic Attack", 7, 95, 0, 0, "Attack", Entity()[0].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Shuriken", 15, 80, 10, 0, "Attack", Entity()[0].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Rasengan", 40, 50, 50, 0, "Attack", Entity()[0].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Rasen Shuriken", 25, 50, 20, 10, "Lifesteal", Entity()[0].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Healing Jutsu", 20, 100, 25, 20, "Heal", Entity()[0].Name));
            //Sasuke Skills
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Basic Attack", 9, 95, 0, 0, "Attack", Entity()[1].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Chidori", 20, 80, 10, 0, "Attack", Entity()[1].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Raikiri", 25, 50, 20, 0, "Attack", Entity()[1].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Amaterasu", 45, 30, 50, 0, "Attack", Entity()[1].Name));
            EntitySkillStats.Add(new Player_and_Enemies_Stats("Healing Jutsu", 20, 100, 25, 20, "Heal", Entity()[1].Name));
            return EntitySkillStats;
        }


    }
}