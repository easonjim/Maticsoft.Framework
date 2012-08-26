/*----------------------------------------------------------------

// Copyright (C) 2012 动软卓越 版权所有。
//
// 文件名：OffLineCourse.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/07/20 11:56:54
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// OffLineCourse:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OffLineCourse
    {
        public OffLineCourse()
        { }

        #region Model

        private int _courseid;
        private string _coursename;
        private string _description;
        private int _categoryid;
        private DateTime _starttime;
        private DateTime _endtime;
        private string _timespan;
        private int _regionid;
        private string _address;
        private decimal _courseprice;
        private string _tags;
        private string _imageurl;
        private int? _limitcount;
        private bool _recommended;
        private bool _latest;
        private bool _hotsale;
        private int _pv = 0;
        private int _attentioncount = 0;
        private int _bookcount = 0;
        private int _createduserid;
        private DateTime _createddate = DateTime.Now;
        private DateTime _updateddate = DateTime.Now;
        private int _status;

        /// <summary>
        ///
        /// </summary>
        public int CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName
        {
            set { _coursename = value; }
            get { return _coursename; }
        }

        /// <summary>
        /// 课程描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 课程分类
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        /// <summary>
        /// 开始日期 如：2012-02-22
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }

        /// <summary>
        /// 结束日期 如：2012-12-12
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }

        /// <summary>
        /// 开课时间点 如：9:30-11:30
        /// </summary>
        public string TimeSpan
        {
            set { _timespan = value; }
            get { return _timespan; }
        }

        /// <summary>
        /// 开课地点
        /// </summary>
        public int RegionID
        {
            set { _regionid = value; }
            get { return _regionid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        /// <summary>
        /// 预计价格
        /// </summary>
        public decimal CoursePrice
        {
            set { _courseprice = value; }
            get { return _courseprice; }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }

        /// <summary>
        /// 课程图片
        /// </summary>
        public string ImageURL
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }

        /// <summary>
        /// 最大报名人数 为空时候为最大
        /// </summary>
        public int? LimitCount
        {
            set { _limitcount = value; }
            get { return _limitcount; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool Recommended
        {
            set { _recommended = value; }
            get { return _recommended; }
        }

        /// <summary>
        /// 是否最新
        /// </summary>
        public bool Latest
        {
            set { _latest = value; }
            get { return _latest; }
        }

        /// <summary>
        /// 是否热卖
        /// </summary>
        public bool Hotsale
        {
            set { _hotsale = value; }
            get { return _hotsale; }
        }

        /// <summary>
        /// 浏览人数
        /// </summary>
        public int PV
        {
            set { _pv = value; }
            get { return _pv; }
        }

        /// <summary>
        /// 关注人数
        /// </summary>
        public int AttentionCount
        {
            set { _attentioncount = value; }
            get { return _attentioncount; }
        }

        /// <summary>
        /// 报名人数
        /// </summary>
        public int BookCount
        {
            set { _bookcount = value; }
            get { return _bookcount; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreatedUserID
        {
            set { _createduserid = value; }
            get { return _createduserid; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime UpdatedDate
        {
            set { _updateddate = value; }
            get { return _updateddate; }
        }

        /// <summary>
        /// 课程状态：0:未完成,1:完成待审核,2:审核通过,3:审核未通过
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        #endregion Model
    }
}