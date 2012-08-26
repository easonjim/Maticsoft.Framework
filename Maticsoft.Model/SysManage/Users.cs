using System;
namespace Maticsoft.Model.SysManage
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _userid;
		private string _username;
		private byte[] _password;
		private string _truename;
		private string _sex;
		private string _phone;
		private string _email;
		private int? _employeeid;
		private string _departmentid;
		private bool? _activity;
		private string _usertype;
		private int? _style;
		private int? _user_icreator;
		private DateTime? _user_datecreate;
		private DateTime? _user_datevalid;
		private DateTime? _user_dateexpire;
		private int? _user_iapprover;
		private DateTime? _user_dateapprove;
		private int? _user_iapprovestate;
		private string _user_clang;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Activity
		{
			set{ _activity=value;}
			get{return _activity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Style
		{
			set{ _style=value;}
			get{return _style;}
		}
		/// <summary>
		/// 创建者
		/// </summary>
		public int? User_iCreator
		{
			set{ _user_icreator=value;}
			get{return _user_icreator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? User_dateCreate
		{
			set{ _user_datecreate=value;}
			get{return _user_datecreate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? User_dateValid
		{
			set{ _user_datevalid=value;}
			get{return _user_datevalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? User_dateExpire
		{
			set{ _user_dateexpire=value;}
			get{return _user_dateexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? User_iApprover
		{
			set{ _user_iapprover=value;}
			get{return _user_iapprover;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? User_dateApprove
		{
			set{ _user_dateapprove=value;}
			get{return _user_dateapprove;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? User_iApproveState
		{
			set{ _user_iapprovestate=value;}
			get{return _user_iapprovestate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_cLang
		{
			set{ _user_clang=value;}
			get{return _user_clang;}
		}
		#endregion Model

        #region ModelEx
        private string _personalstatus;

        /// <summary>
        /// 职务
        /// </summary>
        public string PersonalStatus
        {
            get { return _personalstatus; }
            set { _personalstatus = value; }
        }

        private string _telphone;

        /// <summary>
        /// 手机
        /// </summary>
        public string TelPhone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        private string _qq;

        /// <summary>
        /// 腾讯QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _aliwangwang;

        /// <summary>
        /// 淘宝/阿里旺旺
        /// </summary>
        public string Aliwangwang
        {
            get { return _aliwangwang; }
            set { _aliwangwang = value; }
        }

        private string _msn;

        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }

        private DateTime? _birthday;

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _address;

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        #endregion
	}
}

