using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlarmClock
{
    public class Alarms
    {
        public string Text;
        public ListViewItem listViewItem;
        public string hhmmss;
        public bool repeat;

        public Alarms(string text, string hhmmss, bool repeat)
        {
            this.repeat = repeat;
            this.hhmmss = hhmmss;
            Text = text;
            ListViewItem _listViewItem = new ListViewItem(new string[] {hhmmss + "  " + Text }, -1, Color.FromArgb(29, 38, 48), Color.Aquamarine, new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204));
            listViewItem = _listViewItem;
        }
    }
}
