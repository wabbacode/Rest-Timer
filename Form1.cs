using System.Linq.Expressions;

namespace JJ_Interval
{

    public partial class Form1 : Form

    {
        double totalTime = 90;
        double runningtime;
        bool startStop = false; // "Fast" = the timer is stopped and the Button says "Start"
        bool frmExpand = false;

        string ticktockSoundPath = AppDomain.CurrentDomain.BaseDirectory + "tick.wav";
        string beepSoundPath = AppDomain.CurrentDomain.BaseDirectory + "beep.wav";

        System.Media.SoundPlayer tickTock = new System.Media.SoundPlayer();
        System.Media.SoundPlayer beep = new System.Media.SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (startStop)
            {
                timerStop();
            }
            else
            {
                timerStart();
            }
            
        }

        int f = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            runningtime = runningtime - 0.1;

            f += 1;

            if (f > 9)
            { 
                runningtime = runningtime - 0.0;
                f -= 10;
                //MessageBox.Show(runningtime.ToString(), "aa");
                tickTock.Play();
            }

            if (runningtime <= 1)
            {
                beep.Play();
                if (checkBox3.Checked)
                {
                    timerStop();
                }
            }

            

            // if (runningtime < 0)
            labelTime(runningtime);
        }

        public void labelTime(double time)
        {
            label1.Text = Math.Round(time, 3).ToString().Replace(",", ":");

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        { 
        if (trackBar1.Value == 0)
            {
                totalTime = 90;
            }
        else if (trackBar1.Value == 1)
            {
                totalTime = 60;
            }
        else if (trackBar1.Value == 2)
            {
                totalTime = 30;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                trackBar1.Enabled = false;
            }
            else
            {
                trackBar1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form2 settingsForm = new Form2();
            this.Size = new Size(350, 436);
            //settingsForm.Show();
            if (frmExpand)
            {
                frmExpand = false;
                this.Size = new Size(350, 367);
            }
            else
            {
                frmExpand = true;
                this.Size = new Size(350, 436);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(350, 367);
            // MessageBox.Show(ticktockSoundPath, "test");
            tickTock.SoundLocation = ticktockSoundPath;
            beep.SoundLocation = beepSoundPath;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            totalTime = Convert.ToDouble(textBox1.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.Enabled = false;
            }
            else 
            {
                textBox2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textBox2.Text);
        }

        public void timerStop()
        {
            startStop = false;
            button1.Text = "Start";
            timer1.Stop();
        }

        public void timerStart()
        {
            startStop = true;
            button1.Text = "Stop";
            runningtime = totalTime;
            timer1.Start();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}