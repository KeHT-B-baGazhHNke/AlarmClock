using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH : mm : ss");
            if (AlarmList.alarms.Count >= 1)
            {
                for (int i = 0; i < AlarmList.alarms.Count; i++)
                {
                    if (DateTime.Now.ToString("HH:mm:ss") == AlarmList.alarms[i].hhmmss)
                    {
                        SoundPlayer s1 = new SoundPlayer(@"sigmamusic.wav");
                        s1.Play();
                        if(MessageBox.Show("Alarm!!!", "Alarm!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            s1.Stop();
                        }
                        if (AlarmList.alarms[i].repeat == false)
                        {
                            listView1.Items.RemoveAt(i);
                            AlarmList.alarms.RemoveAt(i);
                        }
                    }
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = AlarmList.alarms.Count();
            AlarmList.hh = "00";
            AlarmList.mm = "00";
            AlarmList.ss = "00";
            AlarmList.text = "";
            AlarmList.repeat = false;
            AlarmList.id = -1;
            AlarmSet alarmSet = new AlarmSet();
            alarmSet.ShowDialog();
            if (AlarmList.alarms.Count > count) {
                listView1.Items.Add(AlarmList.alarms.Last().listViewItem);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int id = listView1.SelectedItems[0].Index;
            AlarmList.hh = AlarmList.alarms[id].hhmmss.Remove(2,6);
            AlarmList.mm = AlarmList.alarms[id].hhmmss.Remove(0, 3).Remove(2,3);
            AlarmList.ss = AlarmList.alarms[id].hhmmss.Remove(0, 6);
            AlarmList.text = AlarmList.alarms[id].Text;
            AlarmList.repeat = AlarmList.alarms[id].repeat;
            AlarmList.id = AlarmList.alarms[id].listViewItem.Index;
            AlarmSet alarmSet = new AlarmSet();
            alarmSet.ShowDialog();
            listView1.Items.RemoveAt(id);
            listView1.Items.Add(AlarmList.alarms.Last().listViewItem);
        }
    }
}
