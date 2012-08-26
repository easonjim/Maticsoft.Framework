using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 接口层IVideoSpider
    /// </summary>
    public interface IVideoSpider
    {
        #region 成员方法
        /// <summary>
        /// 获取视频信息
        /// </summary>
        /// <param name="playUrl">视频播放页面的网址</param>
        /// <returns>视频信息</returns>
        VideoInfo GetInfo(String playUrl); 
        #endregion
    }
}
