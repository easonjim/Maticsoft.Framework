using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Orders
    {
        /// <summary>
        /// 获得已选课程信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public DataSet GetBuyCourse(int pageSize, int startIndex, int UserId, string whereStr)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UserId",SqlDbType.Int),
                                        new SqlParameter("@TimeLimit",SqlDbType.VarChar)
                                        };
            parameters[0].Value = pageSize;
            parameters[1].Value = startIndex;
            parameters[2].Value = UserId;
            parameters[3].Value = whereStr;
            DataSet ds = DbHelperSQL.RunProcedure("sp_ChoseCourse", parameters, "ds");
            return ds;
        }

        /// <summary>
        /// 已选课程数量
        /// </summary>
        public int GetBuyCourseCount(int userId, string limit)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM (SELECT   DISTINCT BuyerID,TOI.OrderID,TC.CourseName,AU.TrueName,Tao_OrderHistory.Amount,OrderDate,TC.CourseID,TCN.Comment  ");
            strSql.Append("FROM Tao_OrderHistory ");
            strSql.Append("LEFT JOIN Tao_OrderItemHistory TOI ON Tao_OrderHistory.OrderID=TOI.OrderID ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TOI.CourseID ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=Tao_OrderHistory.BuyerID ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TOI.ModuleID ");
            strSql.Append("LEFT JOIN Tao_Comment TCN ON TOI.OrderID=TCN.OrderID ");
            strSql.Append("WHERE BuyerID=@UserID  ");

            if (!string.IsNullOrEmpty(limit))
            {
                strSql.Append(" AND DATEDIFF(M,OrderDate,GETDATE())>3");
            }
            else
            {
                strSql.Append(" AND DATEDIFF(M,OrderDate,GETDATE())<=3");
            }
            strSql.Append("  )A");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
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
        /// 账户充值---确认订单 未付款
        /// </summary>
        public int Rechange(Model.Tao.Orders model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,60),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,5),
					new SqlParameter("@PaymentTypeId", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int)
                                        };
            parameters[0].Value = model.BuyerID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.PaymentTypeId;
            parameters[5].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("sp_CreateRechangeDate", parameters);
            if (parameters[5] != null)
            {
                return Convert.ToInt32(parameters[5].Value);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 充值成功，更新订单状态，用户余额，消费明细
        /// </summary>
        public bool ModifyOrderStatus(int orderId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@OrderId",SqlDbType.Int)
                                        };
            parameters[0].Value = orderId;
            DbHelperSQL.RunProcedure("sp_ModifyOrderStatus", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CreateNewOrderInfo(Model.Tao.Orders orders, int courseId, int? mid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@BuyerID",SqlDbType.Int),
                                        new SqlParameter("@UserName",SqlDbType.NVarChar),
                                        new SqlParameter("@Email",SqlDbType.VarChar),
                                        new SqlParameter("@Amount",SqlDbType.Decimal),
                                        new SqlParameter("@SellerID",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@ModuleId",SqlDbType.Int),
                                        new SqlParameter("@OrderId",SqlDbType.Int)
                                        };
            parameters[0].Value = orders.BuyerID;
            parameters[1].Value = orders.UserName;
            parameters[2].Value = orders.Email;
            parameters[3].Value = orders.Amount;
            parameters[4].Value = orders.SellerID.Value;
            parameters[5].Value = courseId;
            parameters[6].Value = mid;
            parameters[7].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("sp_CreateOrderInfo", parameters, out rowsAffected);

            if (parameters[7].Value != null)
            {
                return Convert.ToInt32(parameters[7].Value);
            }
            else
            {
                return 0;
            }
        }

        public int SaveLeanCourse(Model.Tao.Orders orders, int courseId, int? mid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@BuyerID",SqlDbType.Int),
                                        new SqlParameter("@UserName",SqlDbType.NVarChar),
                                        new SqlParameter("@Email",SqlDbType.VarChar),
                                        new SqlParameter("@Amount",SqlDbType.Decimal),
                                        new SqlParameter("@SellerID",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@ModuleId",SqlDbType.Int)
                                        };
            parameters[0].Value = orders.BuyerID;
            parameters[1].Value = orders.UserName;
            parameters[2].Value = orders.Email;
            parameters[3].Value = orders.Amount;
            parameters[4].Value = orders.SellerID.Value;
            parameters[5].Value = courseId;
            parameters[6].Value = mid;
            DbHelperSQL.RunProcedure("sp_SaveLearnCourse", parameters, out rowsAffected);

            return rowsAffected;
        }

        public int CreateNewOrderInfo(Model.Tao.Orders orders, int courseId, string mid, int types)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO dbo.Tao_Orders( OrderDate ,BuyerID , UserName ,Email , Remark ,Amount ,Status ,SellerID , PaymentTypeId ) ");
            strSql.Append("VALUES  ( GETDATE() ," + orders.BuyerID + " , '" + orders.UserName + "','" + orders.Email + "' ,N'购买课程' ,  " + orders.Amount + " ,0 ," + orders.SellerID + " ,0 ); ");
            strSql.Append("DECLARE @OrderId INT SET  @OrderId= @@IDENTITY ");
            strSql.Append("INSERT dbo.Tao_OrderItems ");
            strSql.Append("( OrderID ,CourseID ,ModuleID ,Price ) ");
            strSql.Append("SELECT @OrderId," + courseId + ",tcm.ModuleID,tm.Price FROM dbo.Tao_CourseModule tcm ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tcm.ModuleID=tm.ModuleID ");
            strSql.Append("WHERE CourseID=" + courseId);
            if (types.Equals(1))
            {
                strSql.Append(" AND tm.ModuleID IN(" + mid + ")");
            }
            strSql.Append("SELECT @OrderId");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool ModifyOrderInfo(int orderId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@OrderId",SqlDbType.Int)
                                        };
            parameters[0].Value = orderId;
            DbHelperSQL.RunProcedure("sp_ModifyCourseOrderInfo", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 支付接口支付，更新订单的状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool ModifyBuyCourseStatus(int orderId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@OrderId",SqlDbType.Int)
                                        };
            parameters[0].Value = orderId;
            DbHelperSQL.RunProcedure("sp_ModifyBuyOrderStauts", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePaymentID(Model.Tao.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Orders SET PaymentTypeId=@PaymentTypeId ");
            strSql.Append("WHERE OrderID=@OrderID ");

            SqlParameter[] parameters = {
                                        new SqlParameter("@OrderId",SqlDbType.Int),
                                        new SqlParameter("@PaymentTypeId",SqlDbType.Int)
                                        };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.PaymentTypeId;
            int res = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int IsBuyed(int cid, int uid, int mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM dbo.Tao_OrderHistory toh ");
            strSql.Append("LEFT JOIN dbo.Tao_OrderItemHistory toih ON toh.OrderID=toih.OrderID ");
            strSql.Append("WHERE BuyerID=" + uid + " AND CourseID=" + cid);
            if (!mid.Equals(0))
            {
                strSql.Append("  AND ModuleID=" + mid);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
        }
    }
}