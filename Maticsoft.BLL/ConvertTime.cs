using System;

namespace Maticsoft.BLL
{
    public class ConvertTime
    {
        /// <summary>
        /// 秒转换成时分秒
        /// </summary>
        public static string SecondToDateTime(int seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, seconds);
            string totalTime = string.Format("{0:00}:{1:00}:{2:00}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
            return totalTime;// (int)ts.TotalHours + ":" + ts.Minutes + ":" + ts.Seconds;
        }

        /// <summary>
        /// 时分秒转换成秒
        /// </summary>
        public static int TimeToSecond(int hour, int minute, int second)
        {
            TimeSpan ts = new TimeSpan(hour, minute, second);
            return (int)ts.TotalSeconds;
        }
    }
}