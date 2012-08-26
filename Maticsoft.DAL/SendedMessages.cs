using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Messages
{
    /// <summary>
    /// 数据访问类:SendedMessages
    /// </summary>
    public partial class SendedMessages
    {
        public SendedMessages()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long SendMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_SendedMessages");
            strSql.Append(" where SendMessageId=@SendMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@SendMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = SendMessageId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.Messages.SendedMessages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_SendedMessages(");
            strSql.Append("AddresserId,AddresseeId,Title,PublishContent,PublishDate,ReceiveMessageId)");
            strSql.Append(" values (");
            strSql.Append("@AddresserId,@AddresseeId,@Title,@PublishContent,@PublishDate,@ReceiveMessageId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AddresserId", SqlDbType.Int,4),
					new SqlParameter("@AddresseeId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,3000),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt,8)};
            parameters[0].Value = model.AddresserId;
            parameters[1].Value = model.AddresseeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.PublishContent;
            parameters[4].Value = model.PublishDate;
            parameters[5].Value = model.ReceiveMessageId;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Messages.SendedMessages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_SendedMessages set ");
            strSql.Append("AddresserId=@AddresserId,");
            strSql.Append("AddresseeId=@AddresseeId,");
            strSql.Append("Title=@Title,");
            strSql.Append("PublishContent=@PublishContent,");
            strSql.Append("PublishDate=@PublishDate,");
            strSql.Append("ReceiveMessageId=@ReceiveMessageId");
            strSql.Append(" where SendMessageId=@SendMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@AddresserId", SqlDbType.Int,4),
					new SqlParameter("@AddresseeId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,3000),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt,8),
					new SqlParameter("@SendMessageId", SqlDbType.BigInt,8)};
            parameters[0].Value = model.AddresserId;
            parameters[1].Value = model.AddresseeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.PublishContent;
            parameters[4].Value = model.PublishDate;
            parameters[5].Value = model.ReceiveMessageId;
            parameters[6].Value = model.SendMessageId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long SendMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_SendedMessages ");
            strSql.Append(" where SendMessageId=@SendMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@SendMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = SendMessageId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SendMessageIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_SendedMessages ");
            strSql.Append(" where SendMessageId in (" + SendMessageIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Messages.SendedMessages GetModel(long SendMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SendMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,ReceiveMessageId from SA_SendedMessages ");
            strSql.Append(" where SendMessageId=@SendMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@SendMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = SendMessageId;

            Maticsoft.Model.Messages.SendedMessages model = new Maticsoft.Model.Messages.SendedMessages();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SendMessageId"].ToString() != "")
                {
                    model.SendMessageId = long.Parse(ds.Tables[0].Rows[0]["SendMessageId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddresserId"].ToString() != "")
                {
                    model.AddresserId = int.Parse(ds.Tables[0].Rows[0]["AddresserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddresseeId"].ToString() != "")
                {
                    model.AddresseeId = int.Parse(ds.Tables[0].Rows[0]["AddresseeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PublishContent"] != null)
                {
                    model.PublishContent = ds.Tables[0].Rows[0]["PublishContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(ds.Tables[0].Rows[0]["PublishDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveMessageId"].ToString() != "")
                {
                    model.ReceiveMessageId = long.Parse(ds.Tables[0].Rows[0]["ReceiveMessageId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SendMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,ReceiveMessageId ");
            strSql.Append(" FROM SA_SendedMessages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by PublishDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SendMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,ReceiveMessageId ");
            strSql.Append(" FROM SA_SendedMessages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SA_SendedMessages";
            parameters[1].Value = "SendMessageId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}