using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerdiProj1
{
    public partial class Map : Form
    {
        PictureBox player;
        List<string> playerMov = new List<string>();
        int steps = 0;
        int SlowdownFps = 0;
        bool goLeft, goRight, goUp, goDown;
        int playerX;
        int playerY;
        int playerHeight = 88;
        int playerWidth = 88;
        int speed = 20;
        String LastPosition = "Right";
        public Map()
        {
            InitializeComponent();
            BackgroundFx();
            Setup();
        }
        

        
        private void Collision()
        {
             
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }
        private void BackgroundFx()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\tungo\Source\Repos\FerdiProj1\FerdiProj1\Resources\Naruto - Main theme (Flute cover).wav");
            simpleSound.PlayLooping();
        }

        private void Map_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                pictureBox1.Left -= speed;
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                pictureBox1.Left += speed;
                goRight = true;
            }
            if (e.KeyCode == Keys.W)
            {
                pictureBox1.Top -= speed;
                goUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                pictureBox1.Top += speed;
                goDown = true;
            }
           
            Collision();


        }

        private void Map_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
                pictureBox1.Image = Image.FromFile(playerMov[7]);
                LastPosition = "Left";
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
                pictureBox1.Image = Image.FromFile(playerMov[0]);
                LastPosition = "Right";
            }
            if (e.KeyCode == Keys.W)
            {
                goUp = false;
                if (LastPosition == "Right")
                {
                    pictureBox1.Image = Image.FromFile(playerMov[0]);
                }
                else if (LastPosition == "Left")
                {
                    pictureBox1.Image = Image.FromFile(playerMov[7]);
                }


            }
            if (e.KeyCode == Keys.S)
            {
                goDown = false;

                if (LastPosition == "Right")
                {
                    pictureBox1.Image = Image.FromFile(playerMov[0]);
                }
                else if (LastPosition == "Left")
                {
                    pictureBox1.Image = Image.FromFile(playerMov[7]);
                }
            }
      
        }

        private void MapPaintEvent(object sender, PaintEventArgs e)
        {
           
        }

        private void TimeEvent(object sender, EventArgs e)
        {
            if (goUp == true && LastPosition == "Left")
            {
                    AnimatedPlayer(8, 13);
            }
            if (goUp == true && LastPosition == "Right")
            {
                AnimatedPlayer(1, 6);
            }
            if (goDown == true && LastPosition == "Left")
            {
                AnimatedPlayer(8, 13);
            }
            if (goDown == true && LastPosition == "Right")
            {
                AnimatedPlayer(1, 6);
            }
            if (goRight == true)
            {
                AnimatedPlayer(1, 6);
            }
            if (goLeft == true)
            {
                AnimatedPlayer(8,13);
            }
           
            this.Invalidate();
          

        }
        private void Setup() 
        {
          /*  this.BackgroundImage = Image.FromFile("C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\Map.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true; 
          */
            playerMov = Directory.GetFiles("C:\\Users\\tungo\\Source\\Repos\\FerdiProj1\\FerdiProj1\\Resources\\Naruto_Movement\\", "*.png").ToList();
            pictureBox1.Image = Image.FromFile(playerMov[0]);
        }
        private void AnimatedPlayer(int start, int end) 
        {
            SlowdownFps += 1;
            if (SlowdownFps == 5)
            {
                steps++;
                SlowdownFps = 0;
            }
           
            if (steps > end || steps < start)
            {
                steps = start;
            }
            
            pictureBox1.Image = Image.FromFile(playerMov[steps]);
            
        }
    }
    }
    


