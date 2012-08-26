using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    /// <summary>
    /// SendInvite
    /// </summary>
    public partial class SendInvite
    {
        private readonly Maticsoft.DAL.Tao.SendInvite dal = new Maticsoft.DAL.Tao.SendInvite();

        public SendInvite()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int InviteID)
        {
            return dal.Exists(InviteID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.SendInvite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.SendInvite model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int InviteID)
        {
            return dal.Delete(InviteID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string InviteIDlist)
        {
            return dal.DeleteList(InviteIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.SendInvite GetModel(int InviteID)
        {
            return dal.GetModel(InviteID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Tao.SendInvite GetModelByCache(int InviteID)
        {
            string CacheKey = "SendInviteModel-" + InviteID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(InviteID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Tao.SendInvite)objModel;
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
        public List<Maticsoft.Model.Tao.SendInvite> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SendInvite> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.SendInvite> modelList = new List<Maticsoft.Model.Tao.SendInvite>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.SendInvite model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.SendInvite();
                    if (dt.Rows[n]["InviteID"] != null && dt.Rows[n]["InviteID"].ToString() != "")
                    {
                        model.InviteID = int.Parse(dt.Rows[n]["InviteID"].ToString());
                    }
                    if (dt.Rows[n]["ConstitutorID"] != null && dt.Rows[n]["ConstitutorID"].ToString() != "")
                    {
                        model.ConstitutorID = int.Parse(dt.Rows[n]["ConstitutorID"].ToString());
                    }
                    if (dt.Rows[n]["InviteeID"] != null && dt.Rows[n]["InviteeID"].ToString() != "")
                    {
                        model.InviteeID = int.Parse(dt.Rows[n]["InviteeID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["InviteStatus"] != null && dt.Rows[n]["InviteStatus"].ToString() != "")
                    {
                        model.InviteStatus = int.Parse(dt.Rows[n]["InviteStatus"].ToString());
                    }
                    if (dt.Rows[n]["InviteDate"] != null && dt.Rows[n]["InviteDate"].ToString() != "")
                    {
                        model.InviteDate = DateTime.Parse(dt.Rows[n]["InviteDate"].ToString());
                    }
                    if (dt.Rows[n]["DisposeDate"] != null && dt.Rows[n]["DisposeDate"].ToString() != "")
                    {
                        model.DisposeDate = DateTime.Parse(dt.Rows[n]["DisposeDate"].ToString());
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
    }
}