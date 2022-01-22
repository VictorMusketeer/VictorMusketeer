using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace Xinfiniti
{
    public partial class frmXinfiniti : Form
    {
        public frmXinfiniti()
        {
            InitializeComponent();
        }

        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        
        string[]  newFiles, newPaths;
        private List<string> paths = new List<string>(), files = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //sSynth.Pause();
            //System.Threading.Thread.Sleep(1000);
            //sSynth.Resume();

            //sSynth.Speak("Do you wish to use me");
            //System.Threading.Thread.Sleep(500);
            //sSynth.Speak("Click speak X infinity to  use me");
            //System.Threading.Thread.Sleep(500);

            //sRecognize.RecognizeAsyncStop();

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ResetText();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedIndex == i)
                {
                    axWindowsMediaPlayer1.URL = paths[i];
                }
                axWindowsMediaPlayer1.Ctlcontrols.next();
            }
        }

        private void chkXinfiniti_CheckedChanged(object sender, EventArgs e)
        {
            sRecognize.RecognizeAsyncStop();
            chkXinfiniti.Enabled = false;
            checkBox1.Enabled = true;

            if (chkXinfiniti.Checked)
            {

                sSynth.Speak("Welcome to X infinity");
                System.Threading.Thread.Sleep(500);

                Choices sList = new Choices();
                sList.Add(new string[] { "Open", "Play", "Resume", "Pause", "Stop", "Listen", "Hide", "Show", "Close", "Out", "Music" });
                Grammar gr = new Grammar(new GrammarBuilder(sList));
                try
                {
                    sRecognize.RequestRecognizerUpdate();
                    sRecognize.LoadGrammar(gr);
                    sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                    sRecognize.SetInputToDefaultAudioDevice();
                    sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {
                    return;
                }
            }
        }
        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // throw new NotImplementedException();
            if (e.Result.Text == "Open")
            {
                OpenFileDialog df = new OpenFileDialog();
                df.Multiselect = true;

                if (df.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    newFiles = df.SafeFileNames;
                    newPaths = df.FileNames;
                    listBox1.ResetText();
                    for (int i = 0; i < newFiles.Length; i++)
                    { 
                        listBox1.Items.Add(newFiles[i]);
                        files.Append(newFiles[i]);
                        paths.Append(newPaths[i]);
                    }
                }
            }
            else if (e.Result.Text == "Play")
            {
                axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];

            }
            else if (e.Result.Text == "Resume")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else if (e.Result.Text == "Pause")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else if (e.Result.Text == "Stop")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else if (e.Result.Text == "Hide")
            {
                btnOpen.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnResume.Visible = false;
                btnStop.Visible = false;
                pictureBox1.Visible = false;

            }
            else if (e.Result.Text == "Show")
            {
                btnOpen.Visible = true;
                btnPlay.Visible = true;
                btnPause.Visible = true;
                btnResume.Visible = true;
                btnStop.Visible = true;
                pictureBox1.Visible = true;

            }
            else if (e.Result.Text == "Close")
            {
                Application.Exit();
            }
            else if (e.Result.Text == "Listen")
            {
                btnOpen.Visible = false;
                btnPlay.Visible = false;
                btnPause.Visible = false;
                btnResume.Visible = false;
                btnStop.Visible = false;
                pictureBox1.Visible = false;

                sSynth.Speak("How are you");

                System.Threading.Thread.Sleep(500);
                sSynth.Speak("This are the instructions");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("When You say Open");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("The file explorer will pop out allowing you to select music");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("popout allowing you to select music");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("Please either press open or say Open ");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("Or you won't be able to use this music player");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("When you say Play");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("your selected song will be played");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("when you say pause");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("your song will be paused");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("When you say resume");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("your song be will played again");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("When you say stop");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("you will be asked to confirm which to end");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("you can either say out or stop music");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("when you say hide");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("play music buttons will be hidden");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("when you say show");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("play music buttons will be shown");
                System.Threading.Thread.Sleep(500);

                sSynth.Speak("Thanks for listening");
                System.Threading.Thread.Sleep(500);

                btnOpen.Visible = true;
                btnPlay.Visible = true;
                btnPause.Visible = true;
                btnResume.Visible = true;
                btnStop.Visible = true;
                pictureBox1.Visible = true;

                sRecognize.RecognizeAsyncStop();

                chkXinfiniti.Enabled = true;
                checkBox1.Enabled = false;
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            listBox1.Items.Clear();
            files.Clear();
            paths.Clear();
        }

        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            foreach (var path in paths)
            {
                axWindowsMediaPlayer1.URL = path;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sRecognize.RecognizeAsyncStop();
            checkBox1.Enabled = false;
            chkXinfiniti.Enabled = true;
            btnOpen.Visible = true;
            btnPlay.Visible = true;
            btnPause.Visible = true;
            btnResume.Visible = true;
            btnStop.Visible = true;
            pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog df = new OpenFileDialog();
            df.Multiselect = true;

            if (df.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                newFiles = df.SafeFileNames;
                newPaths = df.FileNames;

                for (int i = 0; i < newFiles.Length; i++)
                {
                    listBox1.Items.Add(newFiles[i]);
                    files.Add(newFiles[i]);
                    paths.Add(newPaths[i]);
                }
                listBox1.SelectedIndex = 0;
            }
        }
    }
}
