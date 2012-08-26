using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Maticsoft.Common;
using System.Text.RegularExpressions;

namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 土豆网视频
    /// </summary>
    public class TudouSpider : IVideoSpider
    {
        #region 获取土豆网视频信息
        /// <summary>
        /// 获取土豆网视频信息
        /// 不完善，存在Bug
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public VideoInfo GetInfo(String url)
        {
            String vid = StringPlus.TrimStart(url, "http://www.tudou.com/programs/view/").TrimEnd('/');

            String flashUrl = string.Format("http://www.tudou.com/v/{0}/v.swf", vid);

            VideoInfo vi = new VideoInfo();
            vi.PlayUrl = url;
            vi.FlashId = vid;
            vi.FlashUrl = flashUrl;

            try
            {
                String pageBody = PageLoader.Download(url);

                Match mt = Regex.Match(pageBody, "<title>([^<]+?)</title>");
                String title = VideoHelper.GetTitle(mt.Groups[1].Value);

                Match m = Regex.Match(pageBody, "thumbnail[^']+?'([^']+?)'");
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
