using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model.SysManage
{
    /// <summary>
    /// UsersExp
    /// </summary>
    [Serializable]
    public partial class UsersExpModel : Maticsoft.Accounts.Bus.User
    {
        
        #region Model        
        private string _gravatar;
        private string _singature;
        private string _telphone;
        private string _qq;
        private string _msn;
        private string _homepage;
        private DateTime? _birthday;
        private int _birthdayvisible;
        private bool _birthdayindexvisible;
        private string _constellation;
        private int _constellationvisible;
        private bool _constellationindexvisible;
        private string _nativeplace;
        private int _nativeplacevisible;
        private bool _nativeplaceindexvisible;
        private int? _regionid;
        private string _address;
        private int _addressvisible;
        private bool _addressindexvisible;
        private string _bodilyform;
        private int _bodilyformvisible;
        private bool _bodilyformindexvisible;
        private string _bloodtype;
        private int _bloodtypevisible;
        private bool _bloodtypeindexvisible;
        private string _marriaged;
        private int _marriagedvisible;
        private bool _marriagedindexvisible;
        private string _personalstatus;
        private int _personalstatusvisible;
        private bool _personalstatusindexvisible;
        private int? _grade;
        private decimal? _balance = 0M;
        private int? _points = 0;
        private int? _pvcount;
        private DateTime _lastaccesstime;
        private string _lastaccessip;
        private DateTime _lastposttime;
        private DateTime _lastlogintime;
        private string _remark;
        private string _teachdescription;

        ///// <summary>
        ///// 用户编号
        ///// </summary>
        //public override int UserID
        //{
        //    set { base.UserID = value; }
        //    get { return base.UserID; }
        //}

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Gravatar
        {
            set { _gravatar = value; }
            get { return _gravatar; }
        }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string Singature
        {
            set { _singature = value; }
            get { return _singature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomePage
        {
            set { _homepage = value; }
            get { return _homepage; }
        }
        /// <summary>
        /// 用户生日
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 对谁可见
        /// </summary>
        public int BirthdayVisible
        {
            set { _birthdayvisible = value; }
            get { return _birthdayvisible; }
        }
        /// <summary>
        /// 首页是否显示
        /// </summary>
        public bool BirthdayIndexVisible
        {
            set { _birthdayindexvisible = value; }
            get { return _birthdayindexvisible; }
        }
        /// <summary>
        /// 星座
        /// </summary>
        public string Constellation
        {
            set { _constellation = value; }
            get { return _constellation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ConstellationVisible
        {
            set { _constellationvisible = value; }
            get { return _constellationvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ConstellationIndexVisible
        {
            set { _constellationindexvisible = value; }
            get { return _constellationindexvisible; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NativePlaceVisible
        {
            set { _nativeplacevisible = value; }
            get { return _nativeplacevisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool NativePlaceIndexVisible
        {
            set { _nativeplaceindexvisible = value; }
            get { return _nativeplaceindexvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 住址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddressVisible
        {
            set { _addressvisible = value; }
            get { return _addressvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AddressIndexVisible
        {
            set { _addressindexvisible = value; }
            get { return _addressindexvisible; }
        }
        /// <summary>
        /// 体型
        /// </summary>
        public string BodilyForm
        {
            set { _bodilyform = value; }
            get { return _bodilyform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BodilyFormVisible
        {
            set { _bodilyformvisible = value; }
            get { return _bodilyformvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BodilyFormIndexVisible
        {
            set { _bodilyformindexvisible = value; }
            get { return _bodilyformindexvisible; }
        }
        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType
        {
            set { _bloodtype = value; }
            get { return _bloodtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BloodTypeVisible
        {
            set { _bloodtypevisible = value; }
            get { return _bloodtypevisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BloodTypeIndexVisible
        {
            set { _bloodtypeindexvisible = value; }
            get { return _bloodtypeindexvisible; }
        }
        /// <summary>
        /// 婚姻
        /// </summary>
        public string Marriaged
        {
            set { _marriaged = value; }
            get { return _marriaged; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MarriagedVisible
        {
            set { _marriagedvisible = value; }
            get { return _marriagedvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool MarriagedIndexVisible
        {
            set { _marriagedindexvisible = value; }
            get { return _marriagedindexvisible; }
        }
        /// <summary>
        /// 身份
        /// </summary>
        public string PersonalStatus
        {
            set { _personalstatus = value; }
            get { return _personalstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PersonalStatusVisible
        {
            set { _personalstatusvisible = value; }
            get { return _personalstatusvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PersonalStatusIndexVisible
        {
            set { _personalstatusindexvisible = value; }
            get { return _personalstatusindexvisible; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int? Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int? Points
        {
            set { _points = value; }
            get { return _points; }
        }
        /// <summary>
        /// 访问量
        /// </summary>
        public int? PvCount
        {
            set { _pvcount = value; }
            get { return _pvcount; }
        }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime LastAccessTime
        {
            set { _lastaccesstime = value; }
            get { return _lastaccesstime; }
        }
        /// <summary>
        /// 最后访问IP
        /// </summary>
        public string LastAccessIP
        {
            set { _lastaccessip = value; }
            get { return _lastaccessip; }
        }
        /// <summary>
        /// 最后发表时间
        /// </summary>
        public DateTime LastPostTime
        {
            set { _lastposttime = value; }
            get { return _lastposttime; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 教师简介
        /// </summary>
        public string TeachDescription
        {
            set { _teachdescription = value; }
            get { return _teachdescription; }
        }


        #endregion Model

    }



}
