using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Text.RegularExpressions;


namespace Maticsoft.Common.Video
{
    /// <summary>
    /// 酷6网视频
    /// </summary>
    public class Ku6Spider : IVideoSpider
    {
        XmlHelper xml = new XmlHelper();
        #region 获取酷6网视频信息
        /// <summary>
        /// 获取酷6网视频信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public VideoInfo GetInfo(String url)
        {
            VideoInfo vi = new VideoInfo();
            vi.PlayUrl = url;
            try
            {
                String strXml = PageLoader.Download("http://v.ku6.com/repaste.htm?url=" + url);
                if (!string.IsNullOrEmpty(strXml))
                {
                    DataSet ds = xml.xmlToDataSet(strXml);
                    if (null != ds && 0 != ds.Tables[0].Rows.Count && 0 != ds.Tables[0].Columns.Count)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (null != dr["vid"])//视频id
                            {
                                vi.FlashId = dr["vid"].ToString();

                                String strJsonData = PageLoader.Download("http://v.ku6.com/video.htm?t=getVideosByIds&ids=" + vi.FlashId);
                                Match mtt = Regex.Match(strJsonData.ToLower(), "\"videotime\":[^<]+?,");
                                vi.Time = mtt.Groups[0].Value.ToLower().Replace("\"videotime\":", "").Replace(",", "");//视频时间
                            }
                            if (null != dr["title"])//视频标题
                            {
                                vi.Title = dr["title"].ToString();
                            }
                            if (null != dr["coverurl"])//缩略图地址
                            {
                                vi.PicUrl = dr["coverurl"].ToString();
                            }
                            if (null != dr["flash"])//播放器地址
                            {
                                vi.FlashUrl = dr["flash"].ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return vi;
        }
        #endregion
    }
}
