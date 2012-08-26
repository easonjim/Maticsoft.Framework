using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Messages
{
    /// <summary>
    /// 数据访问类:ReceivedMessages
    /// </summary>
    public partial class ReceivedMessages
    {
        public ReceivedMessages()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ReceiveMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_ReceivedMessages");
            strSql.Append(" where ReceiveMessageId=@ReceiveMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = ReceiveMessageId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.Messages.ReceivedMessages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_ReceivedMessages(");
            strSql.Append("AddresserId,AddresseeId,Title,PublishContent,PublishDate,LastTime,IsRead)");
            strSql.Append(" values (");
            strSql.Append("@AddresserId,@AddresseeId,@Title,@PublishContent,@PublishDate,@LastTime,@IsRead)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AddresserId", SqlDbType.Int,4),
					new SqlParameter("@AddresseeId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,3000),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@LastTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Bit,1)};
            parameters[0].Value = model.AddresserId;
            parameters[1].Value = model.AddresseeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.PublishContent;
            parameters[4].Value = model.PublishDate;
            parameters[5].Value = model.LastTime;
            parameters[6].Value = model.IsRead;

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
        public bool Update(Maticsoft.Model.Messages.ReceivedMessages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_ReceivedMessages set ");
            strSql.Append("AddresserId=@AddresserId,");
            strSql.Append("AddresseeId=@AddresseeId,");
            strSql.Append("Title=@Title,");
            strSql.Append("PublishContent=@PublishContent,");
            strSql.Append("PublishDate=@PublishDate,");
            strSql.Append("LastTime=@LastTime,");
            strSql.Append("IsRead=@IsRead");
            strSql.Append(" where ReceiveMessageId=@ReceiveMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@AddresserId", SqlDbType.Int,4),
					new SqlParameter("@AddresseeId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,3000),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@LastTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Bit,1),
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt,8)};
            parameters[0].Value = model.AddresserId;
            parameters[1].Value = model.AddresseeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.PublishContent;
            parameters[4].Value = model.PublishDate;
            parameters[5].Value = model.LastTime;
            parameters[6].Value = model.IsRead;
            parameters[7].Value = model.ReceiveMessageId;

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
        public bool Delete(long ReceiveMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_ReceivedMessages ");
            strSql.Append(" where ReceiveMessageId=@ReceiveMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = ReceiveMessageId;

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
        public bool DeleteList(string ReceiveMessageIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_ReceivedMessages ");
            strSql.Append(" where ReceiveMessageId in (" + ReceiveMessageIdlist + ")  ");
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
        public Maticsoft.Model.Messages.ReceivedMessages GetModel(long ReceiveMessageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReceiveMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,LastTime,IsRead from SA_ReceivedMessages ");
            strSql.Append(" where ReceiveMessageId=@ReceiveMessageId");
            SqlParameter[] parameters = {
					new SqlParameter("@ReceiveMessageId", SqlDbType.BigInt)
};
            parameters[0].Value = ReceiveMessageId;

            Maticsoft.Model.Messages.ReceivedMessages model = new Maticsoft.Model.Messages.ReceivedMessages();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ReceiveMessageId"].ToString() != "")
                {
                    model.ReceiveMessageId = long.Parse(ds.Tables[0].Rows[0]["ReceiveMessageId"].ToString());
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
                if (ds.Tables[0].Rows[0]["LastTime"].ToString() != "")
                {
                    model.LastTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRead"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsRead"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRead"].ToString().ToLower() == "true"))
                    {
                        model.IsRead = true;
                    }
                    else
                    {
                        model.IsRead = false;
                    }
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
            strSql.Append("select ReceiveMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,LastTime,IsRead ");
            strSql.Append(" FROM SA_ReceivedMessages ");
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
            strSql.Append(" ReceiveMessageId,AddresserId,AddresseeId,Title,PublishContent,PublishDate,LastTime,IsRead ");
            strSql.Append(" FROM SA_ReceivedMessages ");
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
            parameters[0].Value = "SA_ReceivedMessages";
            parameters[1].Value = "ReceiveMessageId";
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