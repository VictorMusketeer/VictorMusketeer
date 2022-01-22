using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Algorithms
{
    public partial class GraphUI : Form
    {
        private int[] _coordinates;
        public GraphUI(int[] coodinates)
        {
            InitializeComponent();
            _coordinates = coodinates;
        }

        private void GraphUI_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _coordinates.Length; i++)
            {
                chrGraph.Series["Word"].Points.AddXY(i, _coordinates[i]);
            }
        }
        private void PlaySound(int key)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var currentDirectory = Directory.GetParent(workingDirectory).Parent.FullName + @"\Resources\";
            SoundPlayer sp = new SoundPlayer();
            try
            {
                if (key == 0)
                {
                    sp = new SoundPlayer(currentDirectory + "A.wav");
                    sp.Play();
                }
                else if (key == 1)
                {
                    sp = new SoundPlayer(currentDirectory + "B.wav");
                    sp.Play();
                }
                else if (key == 2)
                {
                    sp = new SoundPlayer(currentDirectory + "Bb.wav");
                    sp.Play();
                }
                else if (key == 3)
                {
                    sp = new SoundPlayer(currentDirectory + "C.wav");
                    sp.Play();
                }
                else if (key == 4)
                {
                    sp = new SoundPlayer(currentDirectory + "C_s.wav");
                    sp.Play();
                }
                else if (key == 5)
                {
                    sp = new SoundPlayer(currentDirectory + "C_s1.wav");
                    sp.Play();
                }
                else if (key == 6)
                {
                    sp = new SoundPlayer(currentDirectory + "C1.wav");
                    sp.Play();
                }
                else if (key == 7)
                {
                    sp = new SoundPlayer(currentDirectory + "D.wav");
                    sp.Play();
                }
                else if (key == 8)
                {
                    sp = new SoundPlayer(currentDirectory + "D_s.wav");
                    sp.Play();
                }
                else if (key == 9)
                {
                    sp = new SoundPlayer(currentDirectory + "D_s1.wav");
                    sp.Play();
                }
                else if (key == 10)
                {
                    sp = new SoundPlayer(currentDirectory + "D1.wav");
                    sp.Play();
                }
                else if (key == 11)
                {
                    sp = new SoundPlayer(currentDirectory + "E.wav");
                    sp.Play();
                }
                else if (key == 12)
                {
                    sp = new SoundPlayer(currentDirectory + "E1.wav");
                    sp.Play();
                }
                else if (key == 13)
                {
                    sp = new SoundPlayer(currentDirectory + "F.wav");
                    sp.Play();
                }
                else if (key == 14)
                {
                    sp = new SoundPlayer(currentDirectory + "F_s.wav");
                    sp.Play();
                }
                else if (key == 15)
                {
                    sp = new SoundPlayer(currentDirectory + "F1.wav");
                    sp.Play();
                }
                else if (key == 16)
                {
                    sp = new SoundPlayer(currentDirectory + "G.wav");
                    sp.Play();
                }
                else if (key == 17)
                {
                    sp = new SoundPlayer(currentDirectory + "G_s.wav");
                    sp.Play();
                }
                else
                {
                    sp = new SoundPlayer(currentDirectory+ "A.wav");
                    sp.Play();
                }
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _coordinates.Length; i++)
            {
                PlaySound(i);
            }
        }
    }
}
