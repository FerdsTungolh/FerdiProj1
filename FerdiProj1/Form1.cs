using FerdiProj1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FerdiProj1
{
    public partial class Form1 : Form
    {
        public Player Player1;
        public Player Player2;
        private Player currentPlayer;
        private Player opponent;
        private string nameofskill;
        private int selectedskill;
        private int PreviousHp;
        private int DamageTaken;
        public int PreviousMp;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            //Player Health and Stats
            Player1 = new Player("Naruto", 100, 50, 10, 50, 100,0);
            Player2 = new Player("Sasuke", 100, 50, 5, 50, 100,0);
            //Player 1 Skills Name and Stats
            Player1.Addskill(new Skill("Basic Attack", 7, 100, 0));
            Player1.Addskill(new Skill("Shuriken", 15, 80, 10));
            Player1.Addskill(new Skill("Rasengan", 40, 30, 50));
            Player1.Addskill(new Skill("Rasen Shuriken", 25, 50, 20));
            //Player 2 Skills Name and Stats
            Player2.Addskill(new Skill("Basic Attack", 9, 100, 0));
            Player2.Addskill(new Skill("Chidori", 15, 80, 10));
            Player2.Addskill(new Skill("Raikiri", 25, 50, 20));
            Player2.Addskill(new Skill("Amaterasu", 40, 30, 50));

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
                SkillsDes[i] = $"{Player1.Skills[i].Name} Dmg:{Player1.Skills[i].Damage} | Mpcost:{Player1.Skills[i].ManaCost}";
                comboBox1.Items.Add(SkillsDes[i]);
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
            PreviousHp = opponent.Hp;
            //Player 1 Skills Conditions and selections
            if (currentPlayer == Player1)
            {
                if (currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost <= currentPlayer.Mana)
                {
                    currentPlayer.Useskill(currentPlayer.Skills[comboBox1.SelectedIndex], opponent);
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
                        currentPlayer.Useskill(currentPlayer.Skills[p2skill], opponent);
                        nameofskill = currentPlayer.Skills[p2skill].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[p2skill].ManaCost;
                        goto outloop;
                    }      
                    else if (currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost > currentPlayer.Mana)
                    {
                        goto inloop;
                    }
                }
            }
        outloop:
        // Damage Calculations
            DamageTaken = PreviousHp - opponent.Hp;
        // UI for health update
            UpdateUI();
        // Indicators of skills which skill hit and player damage

            //Attack Miss
            if (opponent.Hp == PreviousHp)
            {
                label6.ForeColor = Color.Red;
                label6.Text = $"{currentPlayer.Name} has missed the {nameofskill}";
            }
            //Attack Landed
            else 
            {
                label6.ForeColor = Color.Green;
               // Attack Crited
                if (currentPlayer.Crited == 2)
                {
                    label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} had taken {DamageTaken} damage successfuly crited";
                }
                //Attack Does not Crited
                else if (currentPlayer.Crited == 1)
                {
                    label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} has  taken {DamageTaken} damage";
                }
            }
            // To reset the global variable back to 0 instead carrying the previous value
                DamageTaken = 0;
                PreviousHp = 0;
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
