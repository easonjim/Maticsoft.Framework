using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 视频帮助类
    /// </summary>
    public class VideoHelper
    {
        #region 获取视频标题
        /// <summary>
        /// 获取视频标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static String GetTitle(String title)
        {
            String t = title;

            if (t.IndexOf('-') > 0)
            {
                t = getItemFirst(t, '-');
            }

            if (t.IndexOf('_') > 0)
            {
                t = getItemFirst(t, '_');
            }

            return t;
        } 
        #endregion

        #region 获取第一项
        /// <summary>
        /// 获取第一项
        /// </summary>
        /// <param name="t"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private static String getItemFirst(String t, char s)
        {
            String[] arrItem = t.Split(s);
            if (arrItem.Length > 0)
            {
                return arrItem[0].Trim();
            }
            return t;
        }
        #endregion
    }
}
