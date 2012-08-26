using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model.SysManage;
namespace Maticsoft.BLL.SysManage
{
	/// <summary>
	/// SA_Feedback
	/// </summary>
	public class SA_Feedback
	{
        private readonly Maticsoft.DAL.SysManage.SA_Feedback dal = new DAL.SysManage.SA_Feedback();
		public SA_Feedback()
		{}
		#region  Method

		
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Maticsoft.Model.SysManage.SA_Feedback model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.SysManage.SA_Feedback model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Feedback_iID)
		{
			
			return dal.Delete(Feedback_iID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string Feedback_iIDlist )
		{
			return dal.DeleteList(Feedback_iIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.SysManage.SA_Feedback GetModel(int Feedback_iID)
		{
			
			return dal.GetModel(Feedback_iID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.SysManage.SA_Feedback GetModelByCache(int Feedback_iID)
		{
			
			string CacheKey = "SA_FeedbackModel-" + Feedback_iID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Feedback_iID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.SysManage.SA_Feedback)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.SysManage.SA_Feedback> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.SysManage.SA_Feedback> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.SysManage.SA_Feedback> modelList = new List<Maticsoft.Model.SysManage.SA_Feedback>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.SysManage.SA_Feedback model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.SysManage.SA_Feedback();
					if(dt.Rows[n]["Feedback_iID"].ToString()!="")
					{
						model.Feedback_iID=int.Parse(dt.Rows[n]["Feedback_iID"].ToString());
					}
					model.Feedback_cContent=dt.Rows[n]["Feedback_cContent"].ToString();
					model.Feedback_cMail=dt.Rows[n]["Feedback_cMail"].ToString();
					model.Feedback_cPhone=dt.Rows[n]["Feedback_cPhone"].ToString();
					model.Feedback_cUserName=dt.Rows[n]["Feedback_cUserName"].ToString();
					model.Feedback_cCompany=dt.Rows[n]["Feedback_cCompany"].ToString();
					model.Feedback_cUserIP=dt.Rows[n]["Feedback_cUserIP"].ToString();
					if(dt.Rows[n]["Feedback_bSolved"].ToString()!="")
					{
						if((dt.Rows[n]["Feedback_bSolved"].ToString()=="1")||(dt.Rows[n]["Feedback_bSolved"].ToString().ToLower()=="true"))
						{
						model.Feedback_bSolved=true;
						}
						else
						{
							model.Feedback_bSolved=false;
						}
					}
					if(dt.Rows[n]["Feedback_dateCreate"].ToString()!="")
					{
						model.Feedback_dateCreate=DateTime.Parse(dt.Rows[n]["Feedback_dateCreate"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

