using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:OrderItems
    /// </summary>
    public partial class OrderItems
    {
        public OrderItems()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ItemID", "Tao_OrderItems");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ItemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_OrderItems");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
};
            parameters[0].Value = ItemID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.OrderItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_OrderItems(");
            strSql.Append("OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@CourseID,@ModuleID,@Price,@ItemDescription,@ImageUrl,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@ItemDescription", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.ItemDescription;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Remark;

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
        public bool Update(Maticsoft.Model.Tao.OrderItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_OrderItems set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("Price=@Price,");
            strSql.Append("ItemDescription=@ItemDescription,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@ItemDescription", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@ItemID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.ItemDescription;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.ItemID;

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
        public bool Delete(int ItemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_OrderItems ");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
};
            parameters[0].Value = ItemID;

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
        public bool DeleteList(string ItemIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_OrderItems ");
            strSql.Append(" where ItemID in (" + ItemIDlist + ")  ");
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
        public Maticsoft.Model.Tao.OrderItems GetModel(int ItemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ItemID,OrderID,CourseID,ModuleID,Price,ItemDescription,ImageUrl,Remark from Tao_OrderItems ");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
};
            parameters[0].Value = ItemID;

            Maticsoft.Model.Tao.OrderItems model = new Maticsoft.Model.Tao.OrderItems();
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
            strSql.Append(" FROM Tao_OrderItems ");
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
            strSql.Append(" FROM Tao_OrderItems ");
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
            parameters[0].Value = "Tao_OrderItems";
            parameters[1].Value = "ItemID";
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