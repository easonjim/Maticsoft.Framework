using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common.Video
{
    /// <summary>
    ///  网络视频信息
    /// </summary>
    public class VideoInfo
    {
        #region Model
        /// <summary>
        /// 网络视频播放页面的网址
        /// </summary>
        public String PlayUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 网络视频flash本身的网址
        /// </summary>
        public String FlashUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 网络视频截图的网址
        /// </summary>
        public String PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 网络视频的ID
        /// </summary>
        public String FlashId
        {
            get;
            set;
        }

        /// <summary>
        /// 网络视频标题
        /// </summary>
        public String Title
        {
            get;
            set;
        }
        /// <summary>
        /// 网络视频播放时间
        /// </summary>
        public String Time
        {
            get;
            set;
        }
        #endregion
    }
}
