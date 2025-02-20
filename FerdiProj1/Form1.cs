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
        public int selectedskill;
        public string nameofskill;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Player1 = new Player("Ferds", 100, 50, 10, 50, 100);
            Player2 = new Player("Kurt", 100, 50, 5, 50, 100);

            Player1.Addskill(new Skill("Basic Attack", 7, 100));
            Player1.Addskill(new Skill("Rasengan", 30, 50));
            Player1.Addskill(new Skill("Shuriken", 12, 80));
            Player2.Addskill(new Skill("Basic Attack", 9, 100));
            Player2.Addskill(new Skill("Chidori", 20, 75));
            Player2.Addskill(new Skill("Amaterasu", 50, 10));

            currentPlayer = Player1;
            opponent = Player2;
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add($"Basic Attack Damage: 7");
            comboBox1.Items.Add($"Rasengan Damage: 23");
            comboBox1.Items.Add($"Shuriken: 12");
        }
        private void button1_Click(object sender, EventArgs e)
        {


            /*if (currentPlayer.Skills.Count == 0)
            {
                MessageBox.Show($"{currentPlayer.Name} has no skill");
            }
            */
            if (currentPlayer == Player1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Skill selectedskill = currentPlayer.Skills[0];
                    currentPlayer.Useskill(selectedskill, opponent);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Skill selectedskill = currentPlayer.Skills[1];
                    currentPlayer.Useskill(selectedskill, opponent);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Skill selectedskill = currentPlayer.Skills[2];
                    currentPlayer.Useskill(selectedskill, opponent);
                    label6.Text = $"{currentPlayer.Name} uses {selectedskill}\n {opponent.Name} has  taken {damagetaken} damage";
                }
            }
            else if (currentPlayer == Player2)
            {
                Random ranskill = new Random();
                Skill selectedskill = currentPlayer.Skills[ranskill.Next(currentPlayer.Skills.Count)];
                currentPlayer.Useskill(selectedskill, opponent);
            }
            int PreviousHp = opponent.Hp;
            
            int damagetaken = PreviousHp - opponent.Hp;
            UpdateUI();

            if (opponent.Hp == PreviousHp)
            {
                label4.Text = $"{currentPlayer.Name} miss the {selectedskill} attack";
            }
            label6.Text = $"{currentPlayer.Name} uses {selectedskill}\n {opponent.Name} has  taken {damagetaken} damage";

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
            //Concut
            label1.Text = Player1.Name + ": " + Player1.Hp + "HP";
            //Interpolate
            label2.Text = $"{Player2.Name}: {Player2.Hp} HP";

            progressBar1.Value = Player1.Hp;
            progressBar2.Value = Player2.Hp;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }
    }
}
