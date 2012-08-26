using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 未实现的视频
    /// </summary>
    public class NullSpider : IVideoSpider
    {
        #region 获取视频信息
        /// <summary>
        /// 获取视频信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public VideoInfo GetInfo(String url)
        {
            return new VideoInfo();
        } 
        #endregion
    }
}
