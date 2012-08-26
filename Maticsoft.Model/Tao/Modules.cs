using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// Modules:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Modules
    {
        public Modules()
        { }

        #region Model

        private int _moduleid;
        private string _modulename;
        private string _description;
        private int? _timeduration;
        private int? _status;
        private string _tags;
        private string _imageurl;
        private int? _type;
        private string _videocontent;
        private DateTime? _createddate;
        private int? _createduserid;
        private decimal? _price;
        private int? _pv;
        private int? _sequence;
        private string _attachment;
        private DateTime? _updateddate;

        private string _trueName;

        public string TrueName
        {
            get { return _trueName; }
            set { _trueName = value; }
        }

        private int _isBuy;

        public int IsBuy
        {
            get { return _isBuy; }
            set { _isBuy = value; }
        }

        /// <summary>
        /// 章节编号
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string ModuleName
        {
            set { _modulename = value; }
            get { return _modulename; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
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
        /// 状态：0:未完成,1:完成待审核,2:审核通过但未上架,3:审核未通过,4:发布上架
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
        /// 0本地上传地址 1：网址 2：html脚本
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }

        /// <summary>
        ///
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
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedDate
        {
            set { _updateddate = value; }
            get { return _updateddate; }
        }

        #endregion Model
    }
}