using System;
namespace Maticsoft.Model.SysManage
{
	/// <summary>
	/// SA_Feedback:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SA_Feedback
	{
		public SA_Feedback()
		{}
		#region Model
		private int _feedback_iid;
		private string _feedback_ccontent;
		private string _feedback_cmail;
		private string _feedback_cphone;
		private string _feedback_cusername;
		private string _feedback_ccompany;
		private string _feedback_cuserip;
		private bool _feedback_bsolved=false;
		private DateTime _feedback_datecreate;
        private string _feedback_cResult;

       
		/// 
		/// </summary>
		public int Feedback_iID
		{
			set{ _feedback_iid=value;}
			get{return _feedback_iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cContent
		{
			set{ _feedback_ccontent=value;}
			get{return _feedback_ccontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cMail
		{
			set{ _feedback_cmail=value;}
			get{return _feedback_cmail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cPhone
		{
			set{ _feedback_cphone=value;}
			get{return _feedback_cphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cUserName
		{
			set{ _feedback_cusername=value;}
			get{return _feedback_cusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cCompany
		{
			set{ _feedback_ccompany=value;}
			get{return _feedback_ccompany;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feedback_cUserIP
		{
			set{ _feedback_cuserip=value;}
			get{return _feedback_cuserip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Feedback_bSolved
		{
			set{ _feedback_bsolved=value;}
			get{return _feedback_bsolved;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Feedback_dateCreate
		{
			set{ _feedback_datecreate=value;}
			get{return _feedback_datecreate;}
		}
        /// <summary>
        /// 
        /// </summary>

        public string Feedback_cResult
        {
            get { return _feedback_cResult; }
            set { _feedback_cResult = value; }
        }
		#endregion Model

	}
}

