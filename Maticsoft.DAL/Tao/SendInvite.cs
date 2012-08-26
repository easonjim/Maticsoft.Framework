using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Tao_SendInvite
    /// </summary>
    public partial class SendInvite
    {
        public SendInvite()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int InviteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_SendInvite");
            strSql.Append(" where InviteID=@InviteID");
            SqlParameter[] parameters = {
					new SqlParameter("@InviteID", SqlDbType.Int,4)
};
            parameters[0].Value = InviteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.SendInvite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_SendInvite(");
            strSql.Append("ConstitutorID,InviteeID,ModuleID,InviteStatus,InviteDate,DisposeDate)");
            strSql.Append(" values (");
            strSql.Append("@ConstitutorID,@InviteeID,@ModuleID,@InviteStatus,@InviteDate,@DisposeDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ConstitutorID", SqlDbType.Int,4),
					new SqlParameter("@InviteeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@InviteStatus", SqlDbType.Int,4),
					new SqlParameter("@InviteDate", SqlDbType.DateTime),
					new SqlParameter("@DisposeDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ConstitutorID;
            parameters[1].Value = model.InviteeID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.InviteStatus;
            parameters[4].Value = model.InviteDate;
            parameters[5].Value = model.DisposeDate;

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
        public bool Update(Maticsoft.Model.Tao.SendInvite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_SendInvite set ");
            strSql.Append("ConstitutorID=@ConstitutorID,");
            strSql.Append("InviteeID=@InviteeID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("InviteStatus=@InviteStatus,");
            strSql.Append("InviteDate=@InviteDate,");
            strSql.Append("DisposeDate=@DisposeDate");
            strSql.Append(" where InviteID=@InviteID");
            SqlParameter[] parameters = {
					new SqlParameter("@ConstitutorID", SqlDbType.Int,4),
					new SqlParameter("@InviteeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@InviteStatus", SqlDbType.Int,4),
					new SqlParameter("@InviteDate", SqlDbType.DateTime),
					new SqlParameter("@DisposeDate", SqlDbType.DateTime),
					new SqlParameter("@InviteID", SqlDbType.Int,4)};
            parameters[0].Value = model.ConstitutorID;
            parameters[1].Value = model.InviteeID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.InviteStatus;
            parameters[4].Value = model.InviteDate;
            parameters[5].Value = model.DisposeDate;
            parameters[6].Value = model.InviteID;

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
        public bool Delete(int InviteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_SendInvite ");
            strSql.Append(" where InviteID=@InviteID");
            SqlParameter[] parameters = {
					new SqlParameter("@InviteID", SqlDbType.Int,4)
};
            parameters[0].Value = InviteID;

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
        public bool DeleteList(string InviteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_SendInvite ");
            strSql.Append(" where InviteID in (" + InviteIDlist + ")  ");
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
        public Maticsoft.Model.Tao.SendInvite GetModel(int InviteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 InviteID,ConstitutorID,InviteeID,ModuleID,InviteStatus,InviteDate,DisposeDate from Tao_SendInvite ");
            strSql.Append(" where InviteID=@InviteID");
            SqlParameter[] parameters = {
					new SqlParameter("@InviteID", SqlDbType.Int,4)
};
            parameters[0].Value = InviteID;

            Maticsoft.Model.Tao.SendInvite model = new Maticsoft.Model.Tao.SendInvite();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InviteID"] != null && ds.Tables[0].Rows[0]["InviteID"].ToString() != "")
                {
                    model.InviteID = int.Parse(ds.Tables[0].Rows[0]["InviteID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ConstitutorID"] != null && ds.Tables[0].Rows[0]["ConstitutorID"].ToString() != "")
                {
                    model.ConstitutorID = int.Parse(ds.Tables[0].Rows[0]["ConstitutorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InviteeID"] != null && ds.Tables[0].Rows[0]["InviteeID"].ToString() != "")
                {
                    model.InviteeID = int.Parse(ds.Tables[0].Rows[0]["InviteeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InviteStatus"] != null && ds.Tables[0].Rows[0]["InviteStatus"].ToString() != "")
                {
                    model.InviteStatus = int.Parse(ds.Tables[0].Rows[0]["InviteStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InviteDate"] != null && ds.Tables[0].Rows[0]["InviteDate"].ToString() != "")
                {
                    model.InviteDate = DateTime.Parse(ds.Tables[0].Rows[0]["InviteDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DisposeDate"] != null && ds.Tables[0].Rows[0]["DisposeDate"].ToString() != "")
                {
                    model.DisposeDate = DateTime.Parse(ds.Tables[0].Rows[0]["DisposeDate"].ToString());
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
            strSql.Append("select InviteID,ConstitutorID,InviteeID,ModuleID,InviteStatus,InviteDate,DisposeDate ");
            strSql.Append(" FROM Tao_SendInvite ");
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
            strSql.Append(" InviteID,ConstitutorID,InviteeID,ModuleID,InviteStatus,InviteDate,DisposeDate ");
            strSql.Append(" FROM Tao_SendInvite ");
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
            parameters[0].Value = "Tao_SendInvite";
            parameters[1].Value = "InviteID";
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