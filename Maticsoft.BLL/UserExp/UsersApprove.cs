using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.UserExp
{
    /// <summary>
    /// UsersApprove
    /// </summary>
    public partial class UsersApprove
    {
        private readonly Maticsoft.DAL.UserExp.UsersApprove dal = new Maticsoft.DAL.UserExp.UsersApprove();

        public UsersApprove()
        { }

        #region Method

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
        public bool Exists(int UserID, int ApproveType)
        {
            return dal.Exists(UserID, ApproveType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.UserExp.UsersApprove model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.UserExp.UsersApprove model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserExp.UsersApprove GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.UserExp.UsersApprove GetModelByCache(int ID)
        {
            string CacheKey = "UsersApproveModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.UserExp.UsersApprove)objModel;
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
        public List<Maticsoft.Model.UserExp.UsersApprove> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.UserExp.UsersApprove> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.UserExp.UsersApprove> modelList = new List<Maticsoft.Model.UserExp.UsersApprove>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.UserExp.UsersApprove model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.UserExp.UsersApprove();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["ApproveType"] != null && dt.Rows[n]["ApproveType"].ToString() != "")
                    {
                        model.ApproveType = int.Parse(dt.Rows[n]["ApproveType"].ToString());
                    }
                    if (dt.Rows[n]["ImgURL"] != null && dt.Rows[n]["ImgURL"].ToString() != "")
                    {
                        model.ImgURL = dt.Rows[n]["ImgURL"].ToString();
                    }
                    if (dt.Rows[n]["CreatedDate"] != null && dt.Rows[n]["CreatedDate"].ToString() != "")
                    {
                        model.CreatedDate = DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["ApprovedTime"] != null && dt.Rows[n]["ApprovedTime"].ToString() != "")
                    {
                        model.ApprovedTime = DateTime.Parse(dt.Rows[n]["ApprovedTime"].ToString());
                    }
                    if (dt.Rows[n]["ApprovedUserID"] != null && dt.Rows[n]["ApprovedUserID"].ToString() != "")
                    {
                        model.ApprovedUserID = int.Parse(dt.Rows[n]["ApprovedUserID"].ToString());
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion Method

        #region NewMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserExp.UsersApprove GetModelByUidAndType(int userId, int approveType)
        {
            return dal.GetModelByUidAndType(userId, approveType);
        }

        #endregion NewMethod
    }
}