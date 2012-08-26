using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Messages
{
    /// <summary>
    /// ReceivedMessages
    /// </summary>
    public partial class ReceivedMessages
    {
        private readonly Maticsoft.DAL.Messages.ReceivedMessages dal = new Maticsoft.DAL.Messages.ReceivedMessages();

        public ReceivedMessages()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ReceiveMessageId)
        {
            return dal.Exists(ReceiveMessageId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.Messages.ReceivedMessages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Messages.ReceivedMessages model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ReceiveMessageId)
        {
            return dal.Delete(ReceiveMessageId);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ReceiveMessageIdlist)
        {
            return dal.DeleteList(ReceiveMessageIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Messages.ReceivedMessages GetModel(long ReceiveMessageId)
        {
            return dal.GetModel(ReceiveMessageId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Messages.ReceivedMessages GetModelByCache(long ReceiveMessageId)
        {
            string CacheKey = "ReceivedMessagesModel-" + ReceiveMessageId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ReceiveMessageId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Messages.ReceivedMessages)objModel;
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
        public List<Maticsoft.Model.Messages.ReceivedMessages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Messages.ReceivedMessages> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Messages.ReceivedMessages> modelList = new List<Maticsoft.Model.Messages.ReceivedMessages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Messages.ReceivedMessages model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Messages.ReceivedMessages();
                    if (dt.Rows[n]["ReceiveMessageId"].ToString() != "")
                    {
                        model.ReceiveMessageId = long.Parse(dt.Rows[n]["ReceiveMessageId"].ToString());
                    }
                    if (dt.Rows[n]["AddresserId"].ToString() != "")
                    {
                        model.AddresserId = int.Parse(dt.Rows[n]["AddresserId"].ToString());
                    }
                    if (dt.Rows[n]["AddresseeId"].ToString() != "")
                    {
                        model.AddresseeId = int.Parse(dt.Rows[n]["AddresseeId"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.PublishContent = dt.Rows[n]["PublishContent"].ToString();
                    if (dt.Rows[n]["PublishDate"].ToString() != "")
                    {
                        model.PublishDate = DateTime.Parse(dt.Rows[n]["PublishDate"].ToString());
                    }
                    if (dt.Rows[n]["LastTime"].ToString() != "")
                    {
                        model.LastTime = DateTime.Parse(dt.Rows[n]["LastTime"].ToString());
                    }
                    if (dt.Rows[n]["IsRead"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsRead"].ToString() == "1") || (dt.Rows[n]["IsRead"].ToString().ToLower() == "true"))
                        {
                            model.IsRead = true;
                        }
                        else
                        {
                            model.IsRead = false;
                        }
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