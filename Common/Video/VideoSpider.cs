using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 业务逻辑层VideoSpider
    /// </summary>
    public class VideoSpider:IVideoSpider
    {
        #region 获取网络视频信息
        /// <summary>
        /// 获取网络视频信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public VideoInfo GetInfo(String url)
        {
            return getVideoSpider(url).GetInfo(url);
        } 
        #endregion

        #region 根据不同类型的视频网址获取视频信息
        /// <summary>
        /// 根据不同类型的视频网址获取视频信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private IVideoSpider getVideoSpider(String url)
        {
            if (url.IndexOf("youku.com") >= 0) return new YoukuSpider();
            if (url.IndexOf("tudou.com") >= 0) return new TudouSpider();
            if (url.IndexOf("ku6.com") >= 0) return new Ku6Spider();
            return new NullSpider();
        } 
        #endregion

        #region 获取视频url
        /// <summary>
        /// 获取视频url
        /// </summary>
        /// <param name="strHtmlCode"></param>
        /// <returns></returns>
        public string GetVideoUrl(string strHtmlCode)
        {
            string strUrl = string.Empty;
            if (!string.IsNullOrEmpty(strHtmlCode))
            {
                #region YouKu&Ku6
                if (strHtmlCode.ToLower().Contains("youku") || strHtmlCode.ToLower().Contains("ku6") || strHtmlCode.ToLower().Contains("tudou"))
                {
                    string strReg = @"<embed[^>]*src=\""(?<src>[^\""]+)\""[^>]*></embed>";
                    Regex r = new Regex(strReg, RegexOptions.Singleline);
                    MatchCollection mc = r.Matches(strHtmlCode);
                    //是合法的Http 网址
                    if (mc.Count > 0)
                    {
                        foreach (Match match in mc)
                        {
                            strUrl = match.Groups["ScriptSrc"].Value;
                        }
                    }
                    return strUrl;
                }
                #endregion
                #region 163
                else if (strHtmlCode.ToLower().Contains("http://swf.ws.126.net/movieplayer/"))
                {
                    string strReg = @"<object.+?><param\s*name=""movie""\s*value=\""(?<src>[^\""]+)\""[^>]*></param>.+</object>";
                    Regex r = new Regex(strReg, RegexOptions.Singleline);
                    MatchCollection mc = r.Matches(strHtmlCode);
                    //是合法的Http 网址
                    if (mc.Count > 0)
                    {
                        foreach (Match match in mc)
                        {
                            strUrl = match.Groups["src"].Value;
                        }
                    }
                    return strUrl;
                }
                #endregion
                #region Sina
                else if (strHtmlCode.ToLower().Contains("sina"))
                {
                    string strReg = @"<div><object.*?src=\'(?<src>[^\""]+)\'\s*type=.+?</div>";
                    Regex r = new Regex(strReg, RegexOptions.Singleline);
                    MatchCollection mc = r.Matches(strHtmlCode);
                    //是合法的Http 网址
                    if (mc.Count > 0)
                    {
                        foreach (Match match in mc)
                        {
                            strUrl = match.Groups["src"].Value;
                        }
                    }
                    return strUrl;
                }
                else
                {
                    return strUrl;
                }
                #endregion
            }
            return strUrl;
        }
        #endregion
    }
}
