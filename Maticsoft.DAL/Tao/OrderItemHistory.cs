using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:OrderItemHistory
    /// </summary>
    public partial class OrderItemHistory
    {
        public OrderItemHistory()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ItemID", "Tao_OrderItemHistory");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ItemID, int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_OrderItemHistory");
            strSql.Append(" where ItemID=@ItemID and OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = ItemID;
            parameters[1].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.Tao.OrderItemHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_OrderItemHistory(");
            strSql.Append("ItemID,OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ItemID,@OrderID,@CourseID,@ModuleID,@Price,@ItemDescription,@ImageUrl,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@ItemDescription", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000)};
            parameters[0].Value = model.ItemID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.CourseID;
            parameters[3].Value = model.ModuleID;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.ItemDescription;
            parameters[6].Value = model.ImageUrl;
            parameters[7].Value = model.Remark;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.OrderItemHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_OrderItemHistory set ");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("Price=@Price,");
            strSql.Append("ItemDescription=@ItemDescription,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ItemID=@ItemID and OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@ItemDescription", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.ItemDescription;
            parameters[4].Value = model.ImageUrl;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ItemID;
            parameters[7].Value = model.OrderID;

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
        public bool Delete(int ItemID, int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_OrderItemHistory ");
            strSql.Append(" where ItemID=@ItemID and OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = ItemID;
            parameters[1].Value = OrderID;

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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.OrderItemHistory GetModel(int ItemID, int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ItemID,OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark from Tao_OrderItemHistory ");
            strSql.Append(" where ItemID=@ItemID and OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = ItemID;
            parameters[1].Value = OrderID;

            Maticsoft.Model.Tao.OrderItemHistory model = new Maticsoft.Model.Tao.OrderItemHistory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ItemID"] != null && ds.Tables[0].Rows[0]["ItemID"].ToString() != "")
                {
                    model.ItemID = int.Parse(ds.Tables[0].Rows[0]["ItemID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemDescription"] != null && ds.Tables[0].Rows[0]["ItemDescription"].ToString() != "")
                {
                    model.ItemDescription = ds.Tables[0].Rows[0]["ItemDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
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
            strSql.Append("select ItemID,OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark ");
            strSql.Append(" FROM Tao_OrderItemHistory ");
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
            strSql.Append(" ItemID,OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark ");
            strSql.Append(" FROM Tao_OrderItemHistory ");
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
            parameters[0].Value = "Tao_OrderItemHistory";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region NewMethod

        #region 根据UserID从Tao_OrderItemHistory查询所有的ModuleID

        /// <summary>
        /// 根据UserID从Tao_OrderItemHistory查询所有的ModuleID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetModuleIDList(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID from Tao_OrderItemHistory where OrderID in");
            strSql.AppendFormat("(select OrderID from Tao_OrderHistory where BuyerID={0})", UserID);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion 根据UserID从Tao_OrderItemHistory查询所有的ModuleID

        #endregion NewMethod
    }
}