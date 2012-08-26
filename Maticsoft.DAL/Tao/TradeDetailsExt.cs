using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class TradeDetails
    {
        /// <summary>
        /// 获得用户账户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Model.AccountTrade> GetTradeDetials(int UserId)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = UserId;
            Model.AccountTrade model = new Model.AccountTrade();
            DataSet ds = DbHelperSQL.RunProcedure("sp_TradeDetails", parameters, "ds");
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 统计账户余额信息记录条数
        /// </summary>
        public int TradeRecordNum(int userId, string limit)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(0)FROM Tao_TradeDetails  ");
            strSql.Append("WHERE UserID=@UserId ");
            if (!string.IsNullOrEmpty(limit))
            {
                strSql.Append(" AND DATEDIFF(M,CreateDate,GETDATE())=0");
            }
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
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
        /// 获得账户消费记录信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="whereStr">记录时间范围</param>
        /// <returns></returns>
        public DataSet GetTradeRecord(int startIndex, int pageSize, int userId, string whereStr, out decimal balance)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserId",SqlDbType.Int),
                                        new SqlParameter("@TimeLimit",SqlDbType.VarChar),
                                        new SqlParameter("@Blance",SqlDbType.Money),
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            parameters[1].Value = whereStr;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Value = startIndex;
            parameters[4].Value = pageSize;
            DataSet ds = DbHelperSQL.RunProcedure("sp_TradeRecord", parameters, "ds");
            object obj = parameters[2].Value;
            if (obj != null && Maticsoft.Common.PageValidate.IsDecimal(obj.ToString()))
            {
                balance = decimal.Parse(obj.ToString());
            }
            else
            {
                balance = 0;
            }
            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.AccountTrade> DataTableToList(DataTable dt)
        {
            List<Model.AccountTrade> modelList = new List<Model.AccountTrade>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.AccountTrade model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.AccountTrade();
                    if (dt.Rows[0]["Pay"] != null && dt.Rows[0]["Pay"].ToString() != "")
                    {
                        model.Pay = decimal.Parse(dt.Rows[0]["Pay"].ToString());
                    }
                    if (dt.Rows[0]["PayCount"] != null && dt.Rows[0]["PayCount"].ToString() != "")
                    {
                        model.Buycourse = int.Parse(dt.Rows[0]["PayCount"].ToString());
                    }
                    if (dt.Rows[0]["InCome"] != null && dt.Rows[0]["InCome"].ToString() != "")
                    {
                        model.Income = decimal.Parse(dt.Rows[0]["InCome"].ToString());
                    }
                    if (dt.Rows[0]["SellCount"] != null && dt.Rows[0]["SellCount"].ToString() != "")
                    {
                        model.SellCount = int.Parse(dt.Rows[0]["SellCount"].ToString());
                    }
                    if (dt.Rows[0]["Rechange"] != null && dt.Rows[0]["Rechange"].ToString() != "")
                    {
                        model.Recharge = decimal.Parse(dt.Rows[0]["Rechange"].ToString());
                    }
                    if (dt.Rows[0]["ChangeCount"] != null && dt.Rows[0]["ChangeCount"].ToString() != "")
                    {
                        model.Count = int.Parse(dt.Rows[0]["ChangeCount"].ToString());
                    }
                    if (dt.Rows[0]["Blance"] != null && dt.Rows[0]["Blance"].ToString() != "")
                    {
                        model.Blance = decimal.Parse(dt.Rows[0]["Blance"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.TradeDetails> GetListByUId(out int rowCount, out int pageCount, out decimal Balance, int UserID, int? PageIndex, int? PageSize, bool action)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@Blance", SqlDbType.Money),
                    new SqlParameter("@Action", SqlDbType.Bit),
                    };
            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = action;
            DataSet ds = DbHelperSQL.RunProcedure("sp_AjaxTradeRecord", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            Balance = Convert.ToDecimal(parameters[5].Value);
            if (ds != null)
            {
                return TableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.TradeDetails> TableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.TradeDetails> modelList = new List<Maticsoft.Model.Tao.TradeDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.TradeDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.TradeDetails();
                    if (dt.Rows[n]["RNum"] != null && dt.Rows[n]["RNum"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["RNum"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"] != null && dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["Pay"] != null && dt.Rows[n]["Pay"].ToString() != "")
                    {
                        model.Pay = decimal.Parse(dt.Rows[n]["Pay"].ToString());
                    }
                    if (dt.Rows[n]["Income"] != null && dt.Rows[n]["Income"].ToString() != "")
                    {
                        model.TradeAmount = decimal.Parse(dt.Rows[n]["Income"].ToString());
                    }
                    if (dt.Rows[n]["Balance"] != null && dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }

                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}