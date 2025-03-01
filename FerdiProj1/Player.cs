using System.Numerics;

namespace FerdiProj1
{
    public class Player
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Defense { get; set; }
        public int Crit { get; set; }
        public int Mana { get; set; }

        public bool isCrited;
        public bool isHealed;
        public bool isLanded;
        public int Manaregenrate { get; set; }     
        public List<Skill> Skills { get; set; }


        public Player(string name, int hp, int defense, int crit, int mana, int manaregenrate)
        {
            Name = name;
            Hp = hp;
            Defense = defense;
            Crit = crit;
            Mana = mana;
            Manaregenrate = manaregenrate;
            Skills = new List<Skill>();
        }
        public void Addskill(Skill skill)
        {
            Skills.Add(skill);
        }
        public void Useskill(Skill skill, Player opponent, Player currentplayer)
        {

            if (skill.SkillType == "Attack" || skill.SkillType == "Lifesteal")
            {
             
                Random ran = new Random();
                int hitchance = ran.Next(1, 100);
                if (hitchance > skill.Accuracy)
                {
                    isLanded = false;
                    return;
                }
                else
                {
                    int critchance = ran.Next(1, 100);
                    if (critchance > Crit)
                    {
                        int damage = (skill.Damage * 2) - opponent.Defense;
                        damage = Math.Max(5, damage);
                        opponent.Hp -= damage;
                        opponent.Hp = Math.Max(0, opponent.Hp);
                        isCrited = true;

                    }
                    else if (critchance <= Crit)
                    {
                        int damage = skill.Damage - opponent.Defense;
                        damage = Math.Max(5, damage);
                        opponent.Hp -= damage;
                        opponent.Hp = Math.Max(0, opponent.Hp);
                        isCrited = false;
                    }
                    if (skill.SkillType == "Lifesteal")
                    {
                        HealingSkill(skill, currentplayer);
                    }
                    isLanded = true;
                }
            }
            else if (skill.SkillType == "Heal")
            {
                HealingSkill(skill, currentplayer);
            }

        }
        public void HealingSkill(Skill skill, Player currentplayer)
        {
            if (skill.Healing > 0)
            {
                int healing = currentplayer.Hp + skill.Healing;
                isHealed = true;
                currentplayer.Hp = healing;
                if (currentplayer.Hp >= 100)
                {
                    currentplayer.Hp = 100;
                }
            }
            else
            {
                isHealed = false;
            }
        }

        public void Manaregen(Player player)
        {
            {
                if (player.Mana >= 0)
                {
                    int manaregen = player.Manaregenrate + player.Mana;
                    player.Mana = manaregen;
                    if (player.Mana >= 101)
                    {
                        player.Mana = 100;
                    }
                }
            }
        }
        
    }
}
