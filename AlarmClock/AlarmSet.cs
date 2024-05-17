using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlarmClock
{
    public partial class AlarmSet : Form
    {
        public AlarmSet()
        {
            InitializeComponent();
        }

        private void AlarmSet_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            toolStripTextBox2.Text = AlarmList.hh;
            toolStripTextBox3.Text = AlarmList.mm;
            toolStripTextBox1.Text = AlarmList.ss;
            richTextBox1.Text = AlarmList.text;
            checkBox1.Checked = AlarmList.repeat;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH : mm : ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AlarmList.id == -1)
            {
                Alarms alarm = new Alarms(richTextBox1.Text, toolStripTextBox2 + ":" + toolStripTextBox3 + ":" + toolStripTextBox1, checkBox1.Checked);
                AlarmList.alarms.Add(alarm);
            }
            else
            {
                Alarms alarm = new Alarms(richTextBox1.Text, toolStripTextBox2 + ":" + toolStripTextBox3 + ":" + toolStripTextBox1, checkBox1.Checked);
                AlarmList.alarms[AlarmList.id] = alarm;
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
