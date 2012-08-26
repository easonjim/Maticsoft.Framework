using System;

namespace Maticsoft.Model.UserExp
{
    /// <summary>
    /// UsersExp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UsersExp
    {
        public UsersExp()
        { }

        #region Model

        private int _userid;
        private string _useravatar;
        private string _singature;
        private DateTime? _birthday;
        private int? _birthdayvisible;
        private bool? _birthdayindexvisible;
        private string _constellation;
        private int? _constellationvisible;
        private bool? _constellationindexvisible;
        private string _nativeplace;
        private int? _nativeplacevisible;
        private bool? _nativeplaceindexvisible;
        private int? _userregionid;
        private string _address;
        private int? _addressvisible;
        private bool? _addressindexvisible;
        private string _bodilyform;
        private int? _bodilyformvisible;
        private bool? _bodilyformindexvisible;
        private string _bloodtype;
        private int? _bloodtypevisible;
        private bool? _bloodtypeindexvisible;
        private string _marriaged;
        private int? _marriagedvisible;
        private bool? _marriagedindexvisible;
        private string _personalstatus;
        private int? _personalstatusvisible;
        private bool? _personalstatusindexvisible;
        private int? _grade;
        private int? _integral = 0;
        private int? _pvcount;
        private DateTime? _lastaccesstime;
        private string _lastaccessip;
        private DateTime? _lastposttime;
        private DateTime? _lastlogintime;
        private string _blong;
        private int? _height;
        private int? _weight;
        private string _image;
        private string _usercareer;
        private string _userhobby;
        private string _teachdescription;
        private decimal? _balance = 0M;
        private string _tags;
        private bool? _recommended;

        /// <summary>
        ///
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string UserAvatar
        {
            set { _useravatar = value; }
            get { return _useravatar; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Singature
        {
            set { _singature = value; }
            get { return _singature; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? BirthdayVisible
        {
            set { _birthdayvisible = value; }
            get { return _birthdayvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? BirthdayIndexVisible
        {
            set { _birthdayindexvisible = value; }
            get { return _birthdayindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Constellation
        {
            set { _constellation = value; }
            get { return _constellation; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? ConstellationVisible
        {
            set { _constellationvisible = value; }
            get { return _constellationvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? ConstellationIndexVisible
        {
            set { _constellationindexvisible = value; }
            get { return _constellationindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string NativePlace
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? NativePlaceVisible
        {
            set { _nativeplacevisible = value; }
            get { return _nativeplacevisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? NativePlaceIndexVisible
        {
            set { _nativeplaceindexvisible = value; }
            get { return _nativeplaceindexvisible; }
        }

        /// <summary>
        /// 省市区
        /// </summary>
        public int? UserRegionID
        {
            set { _userregionid = value; }
            get { return _userregionid; }
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
        ///
        /// </summary>
        public int? AddressVisible
        {
            set { _addressvisible = value; }
            get { return _addressvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? AddressIndexVisible
        {
            set { _addressindexvisible = value; }
            get { return _addressindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BodilyForm
        {
            set { _bodilyform = value; }
            get { return _bodilyform; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? BodilyFormVisible
        {
            set { _bodilyformvisible = value; }
            get { return _bodilyformvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? BodilyFormIndexVisible
        {
            set { _bodilyformindexvisible = value; }
            get { return _bodilyformindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BloodType
        {
            set { _bloodtype = value; }
            get { return _bloodtype; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? BloodTypeVisible
        {
            set { _bloodtypevisible = value; }
            get { return _bloodtypevisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? BloodTypeIndexVisible
        {
            set { _bloodtypeindexvisible = value; }
            get { return _bloodtypeindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Marriaged
        {
            set { _marriaged = value; }
            get { return _marriaged; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? MarriagedVisible
        {
            set { _marriagedvisible = value; }
            get { return _marriagedvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? MarriagedIndexVisible
        {
            set { _marriagedindexvisible = value; }
            get { return _marriagedindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public string PersonalStatus
        {
            set { _personalstatus = value; }
            get { return _personalstatus; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? PersonalStatusVisible
        {
            set { _personalstatusvisible = value; }
            get { return _personalstatusvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool? PersonalStatusIndexVisible
        {
            set { _personalstatusindexvisible = value; }
            get { return _personalstatusindexvisible; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? Integral
        {
            set { _integral = value; }
            get { return _integral; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? PvCount
        {
            set { _pvcount = value; }
            get { return _pvcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? LastAccessTime
        {
            set { _lastaccesstime = value; }
            get { return _lastaccesstime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string LastAccessIP
        {
            set { _lastaccessip = value; }
            get { return _lastaccessip; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? LastPostTime
        {
            set { _lastposttime = value; }
            get { return _lastposttime; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Blong
        {
            set { _blong = value; }
            get { return _blong; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? height
        {
            set { _height = value; }
            get { return _height; }
        }

        /// <summary>
        ///
        /// </summary>
        public int? weight
        {
            set { _weight = value; }
            get { return _weight; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }

        /// <summary>
        /// 用户职业
        /// </summary>
        public string UserCareer
        {
            set { _usercareer = value; }
            get { return _usercareer; }
        }

        /// <summary>
        /// 爱好
        /// </summary>
        public string UserHobby
        {
            set { _userhobby = value; }
            get { return _userhobby; }
        }

        /// <summary>
        /// 教师简介
        /// </summary>
        public string TeachDescription
        {
            set { _teachdescription = value; }
            get { return _teachdescription; }
        }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? Recommended
        {
            set { _recommended = value; }
            get { return _recommended; }
        }

        #endregion Model
    }
}