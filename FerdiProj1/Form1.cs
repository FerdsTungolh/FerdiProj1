namespace FerdiProj1
{
    public partial class Form1 : Form
    {
        public Player Player1;
        public Player Player2;
        private Player currentPlayer;
        private Player opponent;
        private string nameofskill;
        public int PreviousMp;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            //Player Health and Stats
            Player1 = new Player("Naruto", 100, 50, 10, 50, 100 ,5 );
            Player2 = new Player("Sasuke", 100, 50, 5, 50, 100 , 5 );
            //Player 1 Skills Name and Stats
            Player1.Addskill(new Skill("Basic Attack", 7, 95, 0, 0));
            Player1.Addskill(new Skill("Shuriken", 15, 80, 10, 0));
            Player1.Addskill(new Skill("Rasengan", 40, 30, 50, 0));
            Player1.Addskill(new Skill("Rasen Shuriken", 25, 50, 20, 0));
            Player1.Addskill(new Skill("Healing Jutsu", 0, 0, 25, 20));
            //Player 2 Skills Name and Stats
            Player2.Addskill(new Skill("Basic Attack", 9, 95, 0, 0));
            Player2.Addskill(new Skill("Chidori", 20, 80, 10, 0));
            Player2.Addskill(new Skill("Raikiri", 25, 50, 20, 0));
            Player2.Addskill(new Skill("Amaterasu", 40, 30, 50, 0));
            Player2.Addskill(new Skill("Healing Jutsu", 0, 0, 25, 20));

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
                if (Player1.Skills[i].Healing > 0)
                {
                    SkillsDes[i] = $"{Player1.Skills[i].Name} Heal:{Player1.Skills[i].Healing} | Mpcost:{Player1.Skills[i].ManaCost}";
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
                    currentPlayer.Healskill(currentPlayer.Skills[comboBox1.SelectedIndex].Healing, currentPlayer);
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
                        currentPlayer.Healskill(currentPlayer.Skills[p2skill].Healing, currentPlayer);
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

            if (currentPlayer.Hp == previoushp && currentPlayer.isHealed == true)
            {
                label6.ForeColor = Color.Red;
                label6.Text = $"{currentPlayer.Name} is an idiot";
            }
            else if (opponent.Hp == PreviousHp && currentPlayer.isHealed == false)
            {
                label6.ForeColor = Color.Red;
                label6.Text = $"{currentPlayer.Name} has missed the {nameofskill}";
            }
            else if (currentPlayer.isHealed == true)
            {
                label6.ForeColor = Color.SeaGreen;
                label6.Text = $"{currentPlayer.Name} use {nameofskill} and healed {currentPlayer.Hp - previoushp} HP";
            }
            //Attack Landed
            else if (opponent.Hp <= PreviousHp)
            {
                label6.ForeColor = Color.Green;
                // Attack Crited
                if (currentPlayer.isCrited == true)
                {
                    label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} had taken {DamageTaken} critical damage";
                }
                //Attack Does not Crited
                else if (currentPlayer.isCrited == false)
                {
                    label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} has  taken {DamageTaken} damage";
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
    }
}
