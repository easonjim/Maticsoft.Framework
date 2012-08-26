using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Maticsoft.Common.Video
{
    public class TuDouVideoHelper
    {
        private string apiUrl = "http://api.tudou.com/v3/gw?method=item.info.get&appKey={0}&format=json&itemCodes={1}";
        private string appkey = "7ee7a34f14a4c74b";
        public string Appkey
        {
            get
            {
                if (!string.IsNullOrEmpty(Maticsoft.Common.ConfigHelper.GetConfigString("tudouAppKey")))
                {
                    appkey = Maticsoft.Common.ConfigHelper.GetConfigString("tudouAppKey");
                }
                return appkey;
            }
        }
        
        public string Url 
        { 
            get; 
            set; 
        }

        public TuDouVideoHelper() 
        { 
        }

        public TuDouVideoHelper(string url)
        {
            this.Url = url;
        }

        #region 获取视频编码
        /// <summary>
        /// 获取视频编码
        /// </summary>
        /// <param name="videoUrl">视频地址</param>
        /// <returns></returns>
        public string GetItemCode(string videoUrl)
        {
            //URL格式：http://www.tudou.com/programs/view/XnQ1-NrAFk0/
            string itemCode = null;
            Regex regV = new Regex(@"\/view\/([\w-]+)/?", RegexOptions.IgnoreCase);
            if (regV.IsMatch(videoUrl))//普通视频格式，直接从URL分析
            {
                itemCode = regV.Match(videoUrl).Result("$1");
            }
            else
            {
                //URL格式：http://www.tudou.com/playlist/p/a66633i76946800.html
                Regex regP = new Regex(@"\/p\/[a-z]\d+i(\d+).*\.html", RegexOptions.IgnoreCase);
                if (regP.IsMatch(videoUrl))//土单/剧集视频，直接从URL分析
                {
                    string iid = regP.Match(videoUrl).Result("$1");//列表中的某个视频的iid
                    System.Net.WebClient wclient = new System.Net.WebClient();
                    try
                    {
                        //downLoad土豆视频的网页源代码，分析这一段JSON格式
                        string tudouHtml = Encoding.GetEncoding("GBK").GetString(wclient.DownloadData(videoUrl));
                        Regex regPCode = new Regex("(?is)iid:" + iid + ".*?icode:\"([\\w-]+)\".*?,cid:", RegexOptions.IgnoreCase);
                        if (regPCode.IsMatch(tudouHtml))//从网页原代码分析，主要是获取视频的itemcode
                        {
                            itemCode = regPCode.Match(tudouHtml).Result("$1");
                            return itemCode;//因为用了WebClient,异步，所以要在这里再返回一次
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                    }
                }
                else
                {
                    //URL格式：http://www.tudou.com/playlist/p/a66633.html
                    Regex regPfirst = new Regex(@"\/p\/[a-z]\d+\.html", RegexOptions.IgnoreCase);
                    if (regPfirst.IsMatch(videoUrl))//土单/剧集视频，直接从URL分析
                    {
                        System.Net.WebClient wclient = new System.Net.WebClient();
                        try
                        {
                            //downLoad土豆视频的网页源代码，分析这一段JSON格式
                            string tudouHtml = Encoding.GetEncoding("GBK").GetString(wclient.DownloadData(videoUrl));
                            Regex regPCode = new Regex("(?is)icode:\"([\\w-]+)\".*?,cid:", RegexOptions.IgnoreCase);
                            if (regPCode.IsMatch(tudouHtml))//从网页原代码分析，主要是获取视频的itemcode
                            {
                                itemCode = regPCode.Match(tudouHtml).Result("$1");
                                return itemCode;//因为用了WebClient,异步，所以要在这里再返回一次
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                        }
                    }
                }

            }
            return itemCode;
        } 
        #endregion

        #region 获取土豆Json格式的视频信息
        /// <summary>
        /// 获取土豆Json格式的视频信息
        /// </summary>
        /// <param name="videoUrl">视频URL</param>
        /// <returns></returns>
        public string GetVideoJsonInfo(string videoUrl)
        {
            if (!string.IsNullOrEmpty(videoUrl) && videoUrl.StartsWith("http://"))
            {
                string itemcode = GetItemCode(videoUrl);
                if (itemcode != null)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    wc.Encoding = Encoding.UTF8;
                    string info = wc.DownloadString(string.Format(apiUrl, this.Appkey, itemcode));
                    return info;
                }
            }
            return null;
        } 
        #endregion

        #region 获取土豆的视频信息实体Bug暂时不能使用
        /// <summary>
        /// 获取土豆的视频信息实体Bug暂时不能使用
        /// </summary>
        /// <returns></returns>
        public TuDouVideoInfo GetVideoInfo()
        {
            TuDouVideoInfo video = new TuDouVideoInfo();
            string info = GetVideoJsonInfo(this.Url);
            if (info != null)
            {
                try
                {
                    List<TuDouVideoInfo> videoList = JsonConvert.DeserializeObject<WholeVideoInfo>(info).multiResult.results;
                    if (videoList.Count > 0)
                    {
                        video = videoList[0];
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                }
            }
            return video;
        } 
        #endregion
    }
}
