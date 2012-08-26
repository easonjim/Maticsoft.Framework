using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Maticsoft.Common.Video
{
    public class TuDouVideoInfo
    {
        #region Model
        /// <summary>
        /// 说明：视频ID
        /// 备注：
        /// </summary>
        public String itemId
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频编码
        /// 备注：11位字符型编码,视频唯一标识 
        /// </summary>
        public String itemCode
        {
            get;
            set;
        }
        /// <summary>
        /// 说明：视频标题
        /// 备注：
        /// </summary>
        public String title
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频标签
        /// 备注：字符串,多个标签之间用逗号','分隔
        /// </summary>
        public String tags
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频描述
        /// 备注：
        /// </summary>
        public String description
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频截图
        /// 备注：
        /// </summary>
        public String picUrl
        {
            get;
            set;
        }


        /// <summary>
        /// 说明：视频备选截图
        /// 备注：URL地址字符串列表
        /// </summary>
        public String picChoiceUrl
        {
            get;
            set;
        }


        /// <summary>
        /// 说明：视频时长
        /// 备注：单位毫秒
        /// </summary>
        public String totalTime
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频发布时间
        /// 备注：指视频审核通过的发布时间,格式(yyyy-mm-dd)
        /// </summary>
        public String pubDate
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：播客id
        /// 备注：上传该视频的用户ID
        /// </summary>
        public String ownerId
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：播客名
        /// 备注：
        /// </summary>
        public String ownerName
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：播客昵称
        /// 备注：
        /// </summary>
        public String ownerNickname
        {
            get;
            set;
        }

        #region 频道信息说明
        // 频道信息  说明
        // 索引值   说明  
        //   1      娱乐  
        //   3      乐活  
        //   5      搞笑  
        //   9      动画  
        //  10      游戏  
        //  14      音乐  
        //  15      体育  
        //  21      科技  
        //  22      电影  
        //  24      财富  
        //  25      教育  
        //  26      汽车  
        //  27      女性  
        //  29      热点  
        //  30      电视剧  
        //  31      综艺  
        //  32      风尚  
        //  99      原创  
        #endregion

        /// <summary>
        /// 说明：所属频道ID
        /// 备注：对应的频道名称可查看:频道信息说明
        /// </summary>
        public String channelId
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：站外播放器URL
        /// 备注：该视频的独立播放地址,可嵌入非土豆网站内容中提供播放
        /// </summary>
        public String outerPlayerUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：媒体类型
        /// 备注："视频"或"音频"
        /// </summary>
        public String mediaType
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频是否加密
        /// 备注：该视频播放时,若被加密,需要密码才能播放
        /// </summary>
        public String secret
        {
            get;
            set;
        }

        /// <summary>
        /// 说明：视频清晰度
        /// 备注：0:256p,1:360p,2:480p,3:720p
        /// </summary>
        public String definition
        {
            get;
            set;
        }

        #endregion
    }
    public class WholeVideoInfo
    {
        public VideoInfoResult multiResult { get; set; }
        public WholeVideoInfo() { }
        /// <summary>
        /// 土豆视频的信息
        /// </summary>
        /// <param name="vr">土豆视频結果列表信息</param>
        public WholeVideoInfo(VideoInfoResult vr)
        {
            this.multiResult = vr;
        }

        /// <summary>
        /// 转JSON格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.None);
            return json;
        }

    }
    public class VideoInfoResult
    {
        public List<TuDouVideoInfo> results { get; set; }
        public VideoInfoResult() { }
        /// <summary>
        /// 土豆视频结果列表信息
        /// </summary>
        /// <param name="videoList">土豆具体每个视频的信息</param>
        public VideoInfoResult(List<TuDouVideoInfo> videoList)
        {
            this.results = videoList;
        }
        /// <summary>
        /// 转JSON格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.None);
            return json;
        }
    }
}
