using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FerdiProj1
{
    public partial class Form1 : Form
    {
        public Player Player1;
        public Player Player2;
        private Player currentPlayer;
        private Player opponent;
        private string nameofskill;
        private string typeofskill;
        public int PreviousMp;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            //Player Health and Stats
            Player1 = new Player("Naruto", 100, 50, 10, 50, 100, 5);
            Player2 = new Player("Sasuke", 100, 50, 5, 50, 100, 5);
            //Player 1 Skills Name and Stats
            Player1.Addskill(new Skill("Basic Attack", 7, 95, 0, 0, "Attack"));
            Player1.Addskill(new Skill("Shuriken", 15, 80, 10, 0, "Attack"));
            Player1.Addskill(new Skill("Rasengan", 40, 30, 50, 0, "Attack"));
            Player1.Addskill(new Skill("Rasen Shuriken", 25, 50, 20, 10, "Lifesteal"));
            Player1.Addskill(new Skill("Healing Jutsu", 0, 100, 25, 20, "Heal"));
            //Player 2 Skills Name and Stats
            Player2.Addskill(new Skill("Basic Attack", 9, 95, 0, 0, "Attack"));
            Player2.Addskill(new Skill("Chidori", 20, 80, 10, 0, "Attack"));
            Player2.Addskill(new Skill("Raikiri", 25, 50, 20, 0, "Attack"));
            Player2.Addskill(new Skill("Amaterasu", 45, 30, 50, 0, "Attack"));
            Player2.Addskill(new Skill("Healing Jutsu", 0, 100, 25, 20, "Heal"));

            currentPlayer = Player1;
            opponent = Player2;
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Player 1 Skills Description for comboBox selection Automatic 
            string[] SkillsDes = new string[Player1.Skills.Count];

            for (int i = 0; i < SkillsDes.Length; i++)
            {
                if (Player1.Skills[i].Healing > 0 && Player1.Skills[i].Damage <= 0)
                {
                    SkillsDes[i] = $"{Player1.Skills[i].Name} Heal:{Player1.Skills[i].Healing} | Mpcost:{Player1.Skills[i].ManaCost}";
                    comboBox1.Items.Add(SkillsDes[i]);
                }
                else if (Player1.Skills[i].Healing > 0 && Player1.Skills[i].Damage > 0)
                {
                    SkillsDes[i] = $"{Player1.Skills[i].Name} Dmg:{Player1.Skills[i].Damage} | Heal:{Player1.Skills[i].Healing} | Mpcost:{Player1.Skills[i].ManaCost}";
                    comboBox1.Items.Add(SkillsDes[i]);
                }
                else
                {
                    SkillsDes[i] = $"{Player1.Skills[i].Name} Dmg:{Player1.Skills[i].Damage} | Mpcost:{Player1.Skills[i].ManaCost}";
                    comboBox1.Items.Add(SkillsDes[i]);
                }
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Players Skill Initialization to Attack and Conditions
            //Checking if player have skills

            if (currentPlayer.Skills.Count == 0)
            {
                MessageBox.Show($"{currentPlayer.Name} has no skill");
            }
            //Variable for Damage Calculation
            int PreviousHp = opponent.Hp;
            int previoushp = currentPlayer.Hp;
            //Player 1 Skills Conditions and selections
            if (currentPlayer == Player1)
            {
                if (currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost <= currentPlayer.Mana)
                {
                    currentPlayer.Useskill(currentPlayer.Skills[comboBox1.SelectedIndex], opponent, currentPlayer);
                    typeofskill = currentPlayer.Skills[comboBox1.SelectedIndex].SkillType;
                    nameofskill = currentPlayer.Skills[comboBox1.SelectedIndex].Name;
                    currentPlayer.Mana -= currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost;

                }
                else if (currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost > currentPlayer.Mana)
                {
                    MessageBox.Show($"{currentPlayer.Name} doesn't have enough chakra");
                    return;
                }
            }
            //Player 2 Skills Conditions and selections Auto skill selection
            else if (currentPlayer == Player2)
            {
                Random ranskill = new Random();
                while (true)
                {
                inloop:
                    int p2skill = ranskill.Next(currentPlayer.Skills.Count);
                    if (currentPlayer.Skills[p2skill].ManaCost <= currentPlayer.Mana)
                    {
                        currentPlayer.Useskill(currentPlayer.Skills[p2skill], opponent, currentPlayer);
                        typeofskill = currentPlayer.Skills[p2skill].SkillType;
                        nameofskill = currentPlayer.Skills[p2skill].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[p2skill].ManaCost;
                        goto outloop;
                    }
                    else if (currentPlayer.Skills[p2skill].ManaCost > currentPlayer.Mana)
                    {
                        goto inloop;
                    }
                }
            }
        outloop:
            // Damage Calculations
            int DamageTaken = PreviousHp - opponent.Hp;
            // UI for health update
            UpdateUI();
            // Indicators of skills which skill hit and player damage

            //Attack Miss & Healed indicator

            if (typeofskill == "Heal")
            {
                label6.ForeColor = Color.SeaGreen;
                label6.Text = $"{currentPlayer.Name} use {nameofskill} and healed {currentPlayer.Hp - previoushp} HP";
            }
            else if (currentPlayer.isLanded == false)
            {
                label6.ForeColor = Color.Red;
                label6.Text = $"{currentPlayer.Name} has missed the {nameofskill}";
            }
            //Attack Landed
            else if (currentPlayer.isLanded == true && typeofskill == "Attack" || typeofskill == "Lifesteal")
            {
                label6.ForeColor = Color.Green;
                // Attack Crited
                if (currentPlayer.isCrited == true)
                {
                    if (typeofskill == "Lifesteal")
                    {
                        label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} had taken {DamageTaken} critical damage\n{currentPlayer.Name} is healed {currentPlayer.Hp - previoushp} HP";
                    }
                    else
                    {
                        label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} had taken {DamageTaken} critical damage";
                    }
                }
                //Attack Does not Crited
                else if (currentPlayer.isCrited == false)
                {
                    if (typeofskill == "Lifesteal")
                    {
                        label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n{opponent.Name} has  taken {DamageTaken} damage\n{currentPlayer.Name} is healed {currentPlayer.Hp - previoushp} HP";
                    }
                    else
                    {
                        label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} has  taken {DamageTaken} damage";
                    }
                }

            }
            // Checking who win and reseting the game
            if (opponent.Hp == 0)
            {
                MessageBox.Show($"{currentPlayer.Name} Win!", "Game Over");
                label6.Text = $"";
                InitializeGame();
                return;
            }
            // Swaping for turn
            SwapTurn();
        }
        private void SwapTurn()
        {
            opponent.Manaregen(opponent);
            currentPlayer.Manaregen(currentPlayer);
            Player temp = currentPlayer;
            currentPlayer = opponent;
            opponent = temp;
            label3.Text = $"{currentPlayer.Name}'s Turn";
        }
        private void UpdateUI()
        {
            label1.Text = Player1.Name + ": " + Player1.Hp + "HP";
            label2.Text = $"{Player2.Name}: {Player2.Hp} HP";
            chp1.Text = $"Chakra : {Player1.Mana}";
            chp2.Text = $"Chakra : {Player2.Mana}";
            progressBar1.Value = Player1.Hp;
            progressBar2.Value = Player2.Hp;
            progressBar3.Value = Player1.Mana;
            progressBar4.Value = Player2.Mana;
        }

        private void button2_Click(object sender, EventArgs e)
        {
       InitializeGame();
        }
    }
}
