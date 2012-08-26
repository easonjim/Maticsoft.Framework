using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Messages
{
    /// <summary>
    /// SendedMessages
    /// </summary>
    public partial class SendedMessages
    {
        private Maticsoft.BLL.Messages.ReceivedMessages bll = new Maticsoft.BLL.Messages.ReceivedMessages();
        private readonly Maticsoft.DAL.Messages.SendedMessages dal = new Maticsoft.DAL.Messages.SendedMessages();

        public SendedMessages()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long SendMessageId)
        {
            return dal.Exists(SendMessageId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.Messages.SendedMessages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Messages.SendedMessages model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long SendMessageId)
        {
            return dal.Delete(SendMessageId);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string SendMessageIdlist)
        {
            return dal.DeleteList(SendMessageIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Messages.SendedMessages GetModel(long SendMessageId)
        {
            return dal.GetModel(SendMessageId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Messages.SendedMessages GetModelByCache(long SendMessageId)
        {
            string CacheKey = "SendedMessagesModel-" + SendMessageId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SendMessageId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.Messages.SendedMessages)objModel;
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
        public List<Maticsoft.Model.Messages.SendedMessages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Messages.SendedMessages> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Messages.SendedMessages> modelList = new List<Maticsoft.Model.Messages.SendedMessages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Messages.SendedMessages model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Messages.SendedMessages();
                    if (dt.Rows[n]["SendMessageId"].ToString() != "")
                    {
                        model.SendMessageId = long.Parse(dt.Rows[n]["SendMessageId"].ToString());
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
                    if (dt.Rows[n]["ReceiveMessageId"].ToString() != "")
                    {
                        model.ReceiveMessageId = long.Parse(dt.Rows[n]["ReceiveMessageId"].ToString());
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

        /// <summary>
        /// 群发信息
        /// </summary>
        /// <param name="sendMessageList"></param>
        /// <param name="receiveMessageList"></param>
        /// <returns></returns>
        public int SendMessage(IList<Maticsoft.Model.Messages.SendedMessages> sendMessageList, IList<Maticsoft.Model.Messages.ReceivedMessages> receiveMessageList)
        {
            int num = 0;
            foreach (Maticsoft.Model.Messages.SendedMessages info in sendMessageList)
            {
                Add(info);
                num++;
            }
            foreach (Maticsoft.Model.Messages.ReceivedMessages info2 in receiveMessageList)
            {
                bll.Add(info2);
                num++;
            }
            return num;
        }
    }
}