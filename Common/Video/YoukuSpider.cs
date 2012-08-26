using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
using Maticsoft.Common;

namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 优酷网视频
    /// </summary>
    public class YoukuSpider : IVideoSpider
    {
        #region 获取优酷网视频信息
        /// <summary>
        /// 获取优酷网视频信息
        /// 不完善，存在Bug
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public VideoInfo GetInfo(String url)
        {
            String vid = StringPlus.TrimStart(url, "http://v.youku.com/v_show/id_");
            vid = StringPlus.TrimEnd(vid, ".html");

            String flashUrl = string.Format("http://player.youku.com/player.php/sid/{0}/v.swf", vid);

            VideoInfo vi = new VideoInfo();
            vi.PlayUrl = url;
            vi.FlashUrl = flashUrl;
            vi.FlashId = vid;

            try
            {
                String pageBody = PageLoader.Download(url);

                Match mt = Regex.Match(pageBody, "<title>([^<]+?)</title>");
                String title = VideoHelper.GetTitle(mt.Groups[1].Value);

                Match m = Regex.Match(pageBody, "pic=(http://[^:]+?.ykimg.com.+?)\"");

                String picUrl = m.Groups[1].Value;

                vi.Title = title;
                vi.PicUrl = picUrl;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vi;
        } 
        #endregion
    }
}
