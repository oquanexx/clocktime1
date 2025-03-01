using System.Media;

namespace Будильник
{
    public partial class Form1 : Form
    {
      
        System.Windows.Forms.Timer timer01 = new System.Windows.Forms.Timer();
        bool b = false;
        SoundPlayer sp = new SoundPlayer(@"G:\ClockSound.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!b)
            {
                label2.Text = maskedTextBox1.Text;
                timer2.Start();
                maskedTextBox1.Visible = false;
                button1.Text = "Убрать будильник";
                b = true;
            }
            else if (b)
            {
                label2.Text = "00:00";
                timer2.Stop();
                maskedTextBox1.Visible = true;
                button1.Text = "Завести будильник";
                b = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer1_Tick);
            timer01.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(label1.Text == label2.Text + ":00")
            {
                button2.Enabled = true;
                sp.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Stop();
            button2.Enabled = false;
            maskedTextBox1.Visible = false;
            button1.Text = "Завести будильник";
            b = false;
        }
    }
}
