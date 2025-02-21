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
            //Player Health and stats
            Player1 = new Player("Naruto", 100, 50, 10, 50, 100);
            Player2 = new Player("Sasuke", 100, 50, 5, 50, 100);
            //Skills 
            Player1.Addskill(new Skill("Basic Attack", 7, 100, 0));
            Player1.Addskill(new Skill("Rasengan", 30, 40, 40));
            Player1.Addskill(new Skill("Shuriken", 12, 80, 10));
            Player2.Addskill(new Skill("Basic Attack", 9, 100, 0));
            Player2.Addskill(new Skill("Chidori", 20, 75, 20));
            Player2.Addskill(new Skill("Amaterasu", 50, 40, 45));

            currentPlayer = Player1;
            opponent = Player2;
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add($"Basic Attack Damage: 7 | Cost: 0");
            comboBox1.Items.Add($"Rasengan Damage: 23 | Cost: 40");
            comboBox1.Items.Add($"Shuriken: 12 | Cost: 10");
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (currentPlayer.Skills.Count == 0)
            {
                MessageBox.Show($"{currentPlayer.Name} has no skill");
            }
            PreviousHp = opponent.Hp;
            PreviousMp = currentPlayer.Mana;
            if (currentPlayer == Player1)
            {
                if (comboBox1.SelectedIndex == 0 && currentPlayer.Skills[0].ManaCost <= currentPlayer.Mana)
                {

                    currentPlayer.Useskill(currentPlayer.Skills[0], opponent);
                    nameofskill = currentPlayer.Skills[0].Name;
                    currentPlayer.Mana -= currentPlayer.Skills[0].ManaCost;
                }
                else if (comboBox1.SelectedIndex == 0 && currentPlayer.Skills[0].ManaCost >= currentPlayer.Mana)
                {
                    MessageBox.Show($"{currentPlayer.Name} have not enough chakra");
                    return;
                }

                else if (comboBox1.SelectedIndex == 1 && currentPlayer.Skills[1].ManaCost <= currentPlayer.Mana)
                {

                    currentPlayer.Useskill(currentPlayer.Skills[1], opponent);
                    nameofskill = currentPlayer.Skills[1].Name;
                    currentPlayer.Mana -= currentPlayer.Skills[1].ManaCost;

                }
                else if (comboBox1.SelectedIndex == 1 && currentPlayer.Skills[1].ManaCost >= currentPlayer.Mana)
                {
                    MessageBox.Show($"{currentPlayer.Name} have not enough chakra");
                    return;
                }

                else if (comboBox1.SelectedIndex == 2 && currentPlayer.Skills[2].ManaCost <= currentPlayer.Mana)
                {

                    currentPlayer.Useskill(currentPlayer.Skills[2], opponent);
                    nameofskill = currentPlayer.Skills[2].Name;
                    currentPlayer.Mana -= currentPlayer.Skills[2].ManaCost;

                }
                else if (comboBox1.SelectedIndex == 2 && currentPlayer.Skills[2].ManaCost >= currentPlayer.Mana)
                {
                    MessageBox.Show($"{currentPlayer.Name} have not enough chakra");
                    return;
                }

            }
            else if (currentPlayer == Player2)
            {

                Random ranskill = new Random();
                while (true) 
                {
                    inloop:
                    if (ranskill.Next(currentPlayer.Skills.Count) == 0 && currentPlayer.Skills[0].ManaCost <= currentPlayer.Mana)
                    {

                        currentPlayer.Useskill(currentPlayer.Skills[0], opponent);
                        nameofskill = currentPlayer.Skills[0].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[0].ManaCost;
                        goto outloop;
                    }
                    else if (ranskill.Next(currentPlayer.Skills.Count) == 0 && currentPlayer.Skills[0].ManaCost >= currentPlayer.Mana)
                    {
                        goto inloop;
                    }

                    else if (ranskill.Next(currentPlayer.Skills.Count) == 1 && currentPlayer.Skills[1].ManaCost <= currentPlayer.Mana)
                    {

                        currentPlayer.Useskill(currentPlayer.Skills[1], opponent);
                        nameofskill = currentPlayer.Skills[1].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[1].ManaCost;
                        goto outloop;

                    }
                    else if (ranskill.Next(currentPlayer.Skills.Count) == 1 && currentPlayer.Skills[1].ManaCost >= currentPlayer.Mana)
                    {
                        goto inloop;
                    }

                    else if (ranskill.Next(currentPlayer.Skills.Count) == 2 && currentPlayer.Skills[2].ManaCost <= currentPlayer.Mana)
                    {

                        currentPlayer.Useskill(currentPlayer.Skills[2], opponent);
                        nameofskill = currentPlayer.Skills[2].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[2].ManaCost;
                        goto outloop;

                    }
                    else if (ranskill.Next(currentPlayer.Skills.Count) == 2 && currentPlayer.Skills[2].ManaCost >= currentPlayer.Mana)
                    {
                        goto inloop;
                    }
                }
            
           }
        outloop:

            DamageTaken = PreviousHp - opponent.Hp;

            UpdateUI();

            if (opponent.Hp == PreviousHp)
            {
                label4.ForeColor = Color.Red;
                label4.Text = $"{currentPlayer.Name} miss the {nameofskill}";
                DamageTaken = 0;
                PreviousHp = 0;

            }
            else 
            {
                label4.ForeColor = Color.Green;
                label4.Text = $"{currentPlayer.Name} landed {nameofskill} ";
            }
            label6.Text = $"{currentPlayer.Name} uses {nameofskill}\n {opponent.Name} has  taken {DamageTaken} damage";
                DamageTaken = 0;
                PreviousHp = 0;

            if (opponent.Hp == 0)
            {
                MessageBox.Show($"{currentPlayer.Name} Win!", "Game Over");
                InitializeGame();
                return;
            }
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

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }
    }
}
