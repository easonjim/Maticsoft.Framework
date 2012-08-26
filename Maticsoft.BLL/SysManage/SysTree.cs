using System;
using System.Data;
using Maticsoft.Model.SysManage;
using Maticsoft.Common;
using System.Collections.Generic;
namespace Maticsoft.BLL.SysManage
{
	/// <summary>
	/// SysTree 的摘要说明。
	/// </summary>
	public class SysTree
	{
        private readonly Maticsoft.DAL.SysManage.SysTree dal = new DAL.SysManage.SysTree();


        public int GetPermissionCatalogID(int permissionID)
        {
            return dal.GetPermissionCatalogID(permissionID);
        }
		public SysTree()
		{			
		}
		
		public int AddTreeNode(SysNode node)
		{			
			return dal.AddTreeNode(node);
		}
		public void UpdateNode(SysNode node)
		{			
			dal.UpdateNode(node);
		}
		public void DelTreeNode(int nodeid)
		{			
			dal.DelTreeNode(nodeid);
		}
        public void DelTreeNodes(string nodeidlist)
        {
            dal.DelTreeNodes(nodeidlist);
        }
        public void MoveNodes(string nodeidlist, int ParentID)
        {
            dal.MoveNodes(nodeidlist, ParentID);
        }
        
		public DataSet GetTreeList(string strWhere)
		{			
			return dal.GetTreeList(strWhere);
		}

        public DataSet GetAllTree()
        {
            return dal.GetTreeList("");
        }

        /// <summary>
        /// Get an object list，From the cache
        /// </summary>
        public DataSet GetAllTreeByCache()
        {
            string CacheKey = "GetAllTreeByCache";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetAllTree();
                    if (objModel != null)
                    {
                        int CacheTime = Maticsoft.Common.ConfigHelper.GetConfigInt("CacheTime");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataSet)objModel;
        }


        public DataSet GetTreeSonList(int NodeID, List<int> UserPermissions)
        {
            string strWhere = "";
            if (NodeID > -1)
            {
                strWhere = " parentid=" + NodeID;                
            }
            if (UserPermissions.Count > 0)
            {
                if (strWhere.Length > 1)
                {
                    strWhere += " and ";
                }
                strWhere += " (PermissionID=-1 or PermissionID in (" + StringPlus.GetArrayStr(UserPermissions) + "))";
            }
            return dal.GetTreeList(strWhere);
        }

		public SysNode GetNode(int NodeID)
		{			
			return dal.GetNode(NodeID);
		}

        /// <summary>
        /// Get an object entity，From the cache
        /// </summary>
        public SysNode GetModelByCache(int NodeID)
        {

            string CacheKey = "SysManageModel-" + NodeID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetNode(NodeID);
                    if (objModel != null)
                    {
                        int CacheTime = Maticsoft.Common.ConfigHelper.GetConfigInt("CacheTime");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SysNode)objModel;
        }
		

        #region 日志管理
        public void AddLog(string time,string loginfo,string Particular)
		{			
			dal.AddLog(time,loginfo,Particular);
		}
		public void DelOverdueLog(int days)
		{						
			dal.DelOverdueLog(days);
		}
		public void DeleteLog(string Idlist)
		{			
			string str="";
			if(Idlist.Trim()!="")
			{
				str=" ID in ("+Idlist+")";
			}
			dal.DeleteLog(str);
		}
		public void DeleteLog(string timestart,string timeend)
		{			
			string str=" datetime>'"+timestart+"' and datetime<'"+timeend+"'";
			dal.DeleteLog(str);
		}
		public DataSet GetLogs(string strWhere)
		{			
			return dal.GetLogs(strWhere);
		}
		public DataRow GetLog(string ID)
		{			
			return dal.GetLog(ID);
        }

        #endregion


    }
}
