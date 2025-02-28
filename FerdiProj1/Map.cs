using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Map()
        {
            InitializeComponent();
        }

        private int speed = 10;
        private void Collision()
        {
            if (pictureBox1.Bounds.IntersectsWith(panel2.Bounds))
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();

                BackgroundFx();
            }
        }
        private void BackgroundFx()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Ferdinand\Downloads\KingofFightersNeoGeosSoundtrack10thAnniversaryMemorialBoxVol.2-KOF9530secTitle_G711.org_.wav");
            simpleSound.PlayLooping();
        }

        private void Map_KeyDown_1(object sender, KeyEventArgs e)
        {
            {

                switch (e.KeyCode)

                {
                    case Keys.Up:
                    case Keys.W:
                        pictureBox1.Top -= speed;
                        break;

                    case Keys.Down:
                    case Keys.S:
                        pictureBox1.Top += speed;
                        break;


                    case Keys.Left:
                    case Keys.A:
                        pictureBox1.Left -= speed;
                        break;


                    case Keys.Right:
                    case Keys.D:
                        pictureBox1.Left += speed;
                        break;
                }

                Collision();

            }
        }
    }
}


