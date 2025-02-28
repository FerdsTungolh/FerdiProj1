using FerdiProj1.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System.Media;
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
            BackgroundFx();
        }

        private void InitializeGame()
        {
            Player_and_Enemies_Stats stats = new Player_and_Enemies_Stats();
            //Player Health and Stats (Name, Hp, Defense, Critrate, Mana, Mana regen)
            Player_and_Enemies_Stats FirstPlayer = stats.Entity()[0];
            Player_and_Enemies_Stats SecondPlayer = stats.Entity()[1];
            Player1 = new Player(FirstPlayer.Name, FirstPlayer.Hp, FirstPlayer.Defense, FirstPlayer.Crit, FirstPlayer.Mana, FirstPlayer.Manaregenrate);
            Player2 = new(SecondPlayer.Name, SecondPlayer.Hp, SecondPlayer.Defense, SecondPlayer.Crit, SecondPlayer.Mana, SecondPlayer.Manaregenrate);
            
            //Player 1 Skills Name and Stats (Name, Damage, Accuraccy, Manacost, Heal, Skilltype)
            Player1.Addskill(new Skill("Basic Attack", 7, 95, 0, 0, "Attack", 0, 0));
            Player1.Addskill(new Skill("Shuriken", 15, 80, 10, 0, "Attack" , 3, 2));
            Player1.Addskill(new Skill("Rasengan", 40, 50, 50, 0, "Attack", 0, 0));
            Player1.Addskill(new Skill("Rasen Shuriken", 25, 50, 20, 10, "Lifesteal", 0, 0));
            Player1.Addskill(new Skill("Healing Jutsu", 0, 100, 25, 20, "Heal", 0, 0));
            //Player 2 Skills Name and Stats (Name, Damage, Accuraccy, Manacost, Heal, Skilltype)
            Player2.Addskill(new Skill("Basic Attack", 9, 95, 0, 0, "Attack", 0, 0));
            Player2.Addskill(new Skill("Chidori", 20, 80, 10, 0, "Attack", 0, 0));
            Player2.Addskill(new Skill("Raikiri", 25, 50, 20, 0, "Attack", 0, 0));
            Player2.Addskill(new Skill("Amaterasu", 45, 30, 50, 0, "Attack", 2, 3));
            Player2.Addskill(new Skill("Healing Jutsu", 0, 100, 25, 20, "Heal", 0,0));

            currentPlayer = Player1;
            opponent = Player2;
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Player 1 Skills Description for comboBox selection Automatic 
            for (int i = 0; i < Player1.Skills.Count; i++)
            {
                    comboBox1.Items.Add($"{Player1.Skills[i].Name}");
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
                    if (currentPlayer.Skills[4].ManaCost <= currentPlayer.Mana && currentPlayer.Hp <= 30)
                    {
                        currentPlayer.Useskill(currentPlayer.Skills[4], opponent, currentPlayer);
                        typeofskill = currentPlayer.Skills[4].SkillType;
                        nameofskill = currentPlayer.Skills[4].Name;
                        currentPlayer.Mana -= currentPlayer.Skills[4].ManaCost;
                        goto outloop;
                    }
                    else if (currentPlayer.Skills[p2skill].ManaCost <= currentPlayer.Mana)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox1.Items.Add($" Skill Name [{currentPlayer.Skills[comboBox1.SelectedIndex].Name}] Skill Type [{currentPlayer.Skills[comboBox1.SelectedIndex].SkillType}]");
            if (currentPlayer.Skills[comboBox1.SelectedIndex].SkillType == "Attack")
            {
                listBox1.Items.Add($"Damage: {currentPlayer.Skills[comboBox1.SelectedIndex].Damage} | CharkaCost: {currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost} | Accuracy: {currentPlayer.Skills[comboBox1.SelectedIndex].Accuracy}");
            }
            else if (currentPlayer.Skills[comboBox1.SelectedIndex].SkillType == "Lifesteal")
            {
                listBox1.Items.Add($"Damage: {currentPlayer.Skills[comboBox1.SelectedIndex].Damage} | Heal: {currentPlayer.Skills[comboBox1.SelectedIndex].Healing} | ChakraCost: {currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost} | Accuracy {currentPlayer.Skills[comboBox1.SelectedIndex].Accuracy}");
            }
            else if (currentPlayer.Skills[comboBox1.SelectedIndex].SkillType == "Heal")
            {
                listBox1.Items.Add($"Heal: {currentPlayer.Skills[comboBox1.SelectedIndex].Healing} | ChakraCost: {currentPlayer.Skills[comboBox1.SelectedIndex].ManaCost} | Accuracy: {currentPlayer.Skills[comboBox1.SelectedIndex].Accuracy}");
            }
        }
        private void BackgroundFx()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\tungo\Source\Repos\FerdiProj1\FerdiProj1\Resources\screaming-bird.wav");
            simpleSound.PlayLooping();
        }
        
        private void ComboBox1_SizeChanged(object? sender, EventArgs e)
        {
            
        }
    }
    }

