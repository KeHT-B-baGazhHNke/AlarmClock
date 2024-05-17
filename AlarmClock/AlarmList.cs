using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    static class AlarmList
    {
        public static List<Alarms> alarms = new List<Alarms>();
        public static string hh;
        public static string mm;
        public static string ss;
        public static string text;
        public static bool repeat;
        public static int id;
    }
}
