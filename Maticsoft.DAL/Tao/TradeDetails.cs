using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:TradeDetails
    /// </summary>
    public partial class TradeDetails
    {
        public TradeDetails()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Tao_TradeDetails");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_TradeDetails");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.TradeDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_TradeDetails(");
            strSql.Append("UserID,CreateDate,TradeType,TradeAmount,Balance,Payer,Payee,PaymentTypeId,Status,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@CreateDate,@TradeType,@TradeAmount,@Balance,@Payer,@Payee,@PaymentTypeId,@Status,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@TradeType", SqlDbType.Int,4),
					new SqlParameter("@TradeAmount", SqlDbType.Money,8),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Payer", SqlDbType.Int,4),
					new SqlParameter("@Payee", SqlDbType.Int,4),
					new SqlParameter("@PaymentTypeId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.CreateDate;
            parameters[2].Value = model.TradeType;
            parameters[3].Value = model.TradeAmount;
            parameters[4].Value = model.Balance;
            parameters[5].Value = model.Payer;
            parameters[6].Value = model.Payee;
            parameters[7].Value = model.PaymentTypeId;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.TradeDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_TradeDetails set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("TradeType=@TradeType,");
            strSql.Append("TradeAmount=@TradeAmount,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("Payer=@Payer,");
            strSql.Append("Payee=@Payee,");
            strSql.Append("PaymentTypeId=@PaymentTypeId,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@TradeType", SqlDbType.Int,4),
					new SqlParameter("@TradeAmount", SqlDbType.Money,8),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Payer", SqlDbType.Int,4),
					new SqlParameter("@Payee", SqlDbType.Int,4),
					new SqlParameter("@PaymentTypeId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.CreateDate;
            parameters[2].Value = model.TradeType;
            parameters[3].Value = model.TradeAmount;
            parameters[4].Value = model.Balance;
            parameters[5].Value = model.Payer;
            parameters[6].Value = model.Payee;
            parameters[7].Value = model.PaymentTypeId;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.ID;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_TradeDetails ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_TradeDetails ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Maticsoft.Model.Tao.TradeDetails GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,CreateDate,TradeType,TradeAmount,Balance,Payer,Payee,PaymentTypeId,Status,Remark from Tao_TradeDetails ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Maticsoft.Model.Tao.TradeDetails model = new Maticsoft.Model.Tao.TradeDetails();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TradeType"] != null && ds.Tables[0].Rows[0]["TradeType"].ToString() != "")
                {
                    model.TradeType = int.Parse(ds.Tables[0].Rows[0]["TradeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TradeAmount"] != null && ds.Tables[0].Rows[0]["TradeAmount"].ToString() != "")
                {
                    model.TradeAmount = decimal.Parse(ds.Tables[0].Rows[0]["TradeAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Payer"] != null && ds.Tables[0].Rows[0]["Payer"].ToString() != "")
                {
                    model.Payer = int.Parse(ds.Tables[0].Rows[0]["Payer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Payee"] != null && ds.Tables[0].Rows[0]["Payee"].ToString() != "")
                {
                    model.Payee = int.Parse(ds.Tables[0].Rows[0]["Payee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaymentTypeId"] != null && ds.Tables[0].Rows[0]["PaymentTypeId"].ToString() != "")
                {
                    model.PaymentTypeId = int.Parse(ds.Tables[0].Rows[0]["PaymentTypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select ID,UserID,CreateDate,TradeType,TradeAmount,Balance,Payer,Payee,PaymentTypeId,Status,Remark ");
            strSql.Append(" FROM Tao_TradeDetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" ID,UserID,CreateDate,TradeType,TradeAmount,Balance,Payer,Payee,PaymentTypeId,Status,Remark ");
            strSql.Append(" FROM Tao_TradeDetails ");
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
            parameters[0].Value = "Tao_TradeDetails";
            parameters[1].Value = "ID";
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