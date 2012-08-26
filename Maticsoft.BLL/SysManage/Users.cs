using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model.SysManage;
namespace Maticsoft.BLL.SysManage
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class Users
    {
		Maticsoft.SQLServerDAL.SysManage.Users dal = new Maticsoft.SQLServerDAL.SysManage.Users();
        public Users()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.SysManage.Users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.SysManage.Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.SysManage.Users GetModel(int UserID)
        {

            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.SysManage.Users GetModelByCache(int UserID)
        {

            string CacheKey = "UsersModel-" + UserID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.SysManage.Users)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.Users> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.SysManage.Users> modelList = new List<Maticsoft.Model.SysManage.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SysManage.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.SysManage.Users();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = (byte[])dt.Rows[n]["Password"];
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = dt.Rows[n]["Sex"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["EmployeeID"] != null && dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID = int.Parse(dt.Rows[n]["EmployeeID"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = dt.Rows[n]["DepartmentID"].ToString();
                    }
                    if (dt.Rows[n]["Activity"] != null && dt.Rows[n]["Activity"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Activity"].ToString() == "1") || (dt.Rows[n]["Activity"].ToString().ToLower() == "true"))
                        {
                            model.Activity = true;
                        }
                        else
                        {
                            model.Activity = false;
                        }
                    }
                    if (dt.Rows[n]["UserType"] != null && dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = dt.Rows[n]["UserType"].ToString();
                    }
                    if (dt.Rows[n]["Style"] != null && dt.Rows[n]["Style"].ToString() != "")
                    {
                        model.Style = int.Parse(dt.Rows[n]["Style"].ToString());
                    }
                    if (dt.Rows[n]["User_iCreator"] != null && dt.Rows[n]["User_iCreator"].ToString() != "")
                    {
                        model.User_iCreator = int.Parse(dt.Rows[n]["User_iCreator"].ToString());
                    }
                    if (dt.Rows[n]["User_dateCreate"] != null && dt.Rows[n]["User_dateCreate"].ToString() != "")
                    {
                        model.User_dateCreate = DateTime.Parse(dt.Rows[n]["User_dateCreate"].ToString());
                    }
                    if (dt.Rows[n]["User_dateValid"] != null && dt.Rows[n]["User_dateValid"].ToString() != "")
                    {
                        model.User_dateValid = DateTime.Parse(dt.Rows[n]["User_dateValid"].ToString());
                    }
                    if (dt.Rows[n]["User_dateExpire"] != null && dt.Rows[n]["User_dateExpire"].ToString() != "")
                    {
                        model.User_dateExpire = DateTime.Parse(dt.Rows[n]["User_dateExpire"].ToString());
                    }
                    if (dt.Rows[n]["User_iApprover"] != null && dt.Rows[n]["User_iApprover"].ToString() != "")
                    {
                        model.User_iApprover = int.Parse(dt.Rows[n]["User_iApprover"].ToString());
                    }
                    if (dt.Rows[n]["User_dateApprove"] != null && dt.Rows[n]["User_dateApprove"].ToString() != "")
                    {
                        model.User_dateApprove = DateTime.Parse(dt.Rows[n]["User_dateApprove"].ToString());
                    }
                    if (dt.Rows[n]["User_iApproveState"] != null && dt.Rows[n]["User_iApproveState"].ToString() != "")
                    {
                        model.User_iApproveState = int.Parse(dt.Rows[n]["User_iApproveState"].ToString());
                    }
                    if (dt.Rows[n]["User_cLang"] != null && dt.Rows[n]["User_cLang"].ToString() != "")
                    {
                        model.User_cLang = dt.Rows[n]["User_cLang"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        #region MethodEx
        /// <summary>
        /// 根据DepartmentID删除一条数据
        /// </summary>
        public bool DeleteByDepartmentID(int DepartmentID)
        {
            return dal.DeleteByDepartmentID(DepartmentID);
        }
        /// <summary>
        /// 根据DepartmentID批量删除数据
        /// </summary>
        public bool DeleteListByDepartmentID(string DepartmentIDlist)
        {
            return dal.DeleteListByDepartmentID(DepartmentIDlist);
        }

        public bool ExistByPhone(string Phone)
        {
            return dal.ExistByPhone(Phone);
        }

        /// <summary>
        /// 根据邮箱判断是否存在该记录
        /// </summary>
        public bool ExistsByEmail(string UserEmail)
        {
            return dal.ExistsByEmail(UserEmail);
        }
           /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.SysManage.Users GetModelByEmail(string Email)
        {
            return dal.GetModelByEmail(Email);
        }
         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, string orderby)
        {
            return dal.GetListEx(strWhere, orderby);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.SysManage.Users GetModelEx(int UserID)
        {
            return dal.GetModelEx(UserID);
        }
         /// <summary>
        /// 批量更新用户状态
        /// </summary>
        /// <param name="UserIDlist">用户ID</param>
        /// <param name="Activity">状态</param>
        /// <returns></returns>
        public bool UpdateActivity(string UserIDlist, bool Activity)
        {
            return dal.UpdateActivity(UserIDlist, Activity);
        }
        #endregion

        public DataSet GetList(string type, string keyWord)
        {
            return dal.GetList(type, keyWord);
        }
    }
}

