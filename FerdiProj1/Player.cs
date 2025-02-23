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
        public bool isCrited;
        public bool isHealed;
        public int Manaregenrate { get; set; }
        public List<Skill> Skills { get; set; }


        public Player(string name, int hp, int crt, int defense, int crit, int mana, int manaregenrate)
        {
            Name = name;
            Hp = hp;
            CRT = crt;
            Defense = defense;
            Crit = crit;
            Mana = mana;
            Skills = new List<Skill>();
            Manaregenrate = manaregenrate;
        }
        public void Addskill(Skill skill)
        {
            Skills.Add(skill);
        }
        public void Useskill(Skill skill, Player opponent, Player currentplayer)
        {
            Random ran = new Random();
            int hitchance = ran.Next(1, 101);
            int critchance = ran.Next(1, 101);
            if (hitchance > skill.Accuracy)
            {
                isCrited = false;
                return;
            }

            if (critchance > Crit)
            {
                int damage = (skill.Damage * 2) - opponent.Defense;
                damage = Math.Max(5, damage);
                opponent.Hp -= damage;
                opponent.Hp = Math.Max(0, opponent.Hp);
                isCrited = true;
            }
            else
            {
                int damage = skill.Damage - opponent.Defense;
                damage = Math.Max(5, damage);
                opponent.Hp -= damage;
                opponent.Hp = Math.Max(0, opponent.Hp);
                isCrited = false;
            }
        }
        public void Healskill(int healingval, Player player)
        {
            {
                if (healingval > 0)
                {
                    int healing = player.Hp + healingval;
                    isHealed = true;
                    player.Hp = healing;
                    if (player.Hp >= 101)
                    {
                        player.Hp = 100;
                    }
                }
                else
                {
                    isHealed = false;
                }
            }
        }
        public void Manaregen ( Player player)
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
