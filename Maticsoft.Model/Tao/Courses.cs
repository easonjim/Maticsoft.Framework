using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Courses:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Courses
    {
        public Courses()
        { }

        #region Model

        private int _courseid;
        private string _coursename;
        private string _description;
        private string _shortdescription;
        private int? _categoryid;
        private int? _timeduration;
        private int? _coursespan;
        private DateTime? _expirydate;
        private int? _viewcount;
        private int? _status;
        private string _tags;
        private string _imageurl;
        private int? _type;
        private string _videocontent;
        private DateTime? _createddate;
        private int? _createduserid;
        private bool? _recommended;
        private bool? _latest;
        private bool? _hotsale;
        private bool? _specialoffer;
        private decimal? _price;
        private int? _pv;
        private int? _salesvolume = 0;
        private int? _sequence;
        private string _attachment;
        private int? _modulenum;
        private DateTime? _updateddate;
        private int? _coursetypes;

        /// <summary>
        /// 课程编号
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
        /// 简介
        /// </summary>
        public string ShortDescription
        {
            set { _shortdescription = value; }
            get { return _shortdescription; }
        }

        /// <summary>
        /// 课程类别
        /// </summary>
        public int? CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        /// <summary>
        /// 时长
        /// </summary>
        public int? TimeDuration
        {
            set { _timeduration = value; }
            get { return _timeduration; }
        }

        /// <summary>
        /// 课程时效方式：0 永久 (时间上限制)   1 无限次(次数上限制)
        /// </summary>
        public int? CourseSpan
        {
            set { _coursespan = value; }
            get { return _coursespan; }
        }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? ExpiryDate
        {
            set { _expirydate = value; }
            get { return _expirydate; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }

        /// <summary>
        /// 状态：0:未完成,1:完成待审核,2:审核通过但未上架,3:审核未通过,4:发布上架;
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }

        /// <summary>
        /// 内容类型：0，直接上传；1：视频地址；2 html脚本
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }

        /// <summary>
        /// 视频地址，type是1）
        /// </summary>
        public string VideoContent
        {
            set { _videocontent = value; }
            get { return _videocontent; }
        }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }

        /// <summary>
        /// 发布人
        /// </summary>
        public int? CreatedUserID
        {
            set { _createduserid = value; }
            get { return _createduserid; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? Recommended
        {
            set { _recommended = value; }
            get { return _recommended; }
        }

        /// <summary>
        /// 是否最新
        /// </summary>
        public bool? Latest
        {
            set { _latest = value; }
            get { return _latest; }
        }

        /// <summary>
        /// 是否热卖
        /// </summary>
        public bool? Hotsale
        {
            set { _hotsale = value; }
            get { return _hotsale; }
        }

        /// <summary>
        /// 是否特价
        /// </summary>
        public bool? SpecialOffer
        {
            set { _specialoffer = value; }
            get { return _specialoffer; }
        }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int? PV
        {
            set { _pv = value; }
            get { return _pv; }
        }

        /// <summary>
        /// 销售量
        /// </summary>
        public int? SalesVolume
        {
            set { _salesvolume = value; }
            get { return _salesvolume; }
        }

        /// <summary>
        /// 顺序
        /// </summary>
        public int? Sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
        }

        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment
        {
            set { _attachment = value; }
            get { return _attachment; }
        }

        /// <summary>
        /// 总节数
        /// </summary>
        public int? ModuleNum
        {
            set { _modulenum = value; }
            get { return _modulenum; }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedDate
        {
            set { _updateddate = value; }
            get { return _updateddate; }
        }

        /// <summary>
        /// 课程类型：0 普通课程 1：组织课程
        /// </summary>
        public int? CourseTypes
        {
            set { _coursetypes = value; }
            get { return _coursetypes; }
        }

        #endregion Model
    }
}