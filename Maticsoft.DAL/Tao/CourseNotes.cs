using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:CourseNotes
    /// </summary>
    public partial class CourseNotes
    {
        public CourseNotes()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("NoteID", "Tao_CourseNotes");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NoteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_CourseNotes");
            strSql.Append(" where NoteID=@NoteID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoteID", SqlDbType.Int,4)
};
            parameters[0].Value = NoteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseNotes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_CourseNotes(");
            strSql.Append("UserID,CourseID,ModuleID,Updatetime,Contents)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@CourseID,@ModuleID,@Updatetime,@Contents)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
					new SqlParameter("@Contents", SqlDbType.NVarChar,2000)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.Updatetime;
            parameters[4].Value = model.Contents;

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
        public bool Update(Maticsoft.Model.Tao.CourseNotes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_CourseNotes set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("Updatetime=@Updatetime,");
            strSql.Append("Contents=@Contents");
            strSql.Append(" where NoteID=@NoteID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
					new SqlParameter("@Contents", SqlDbType.NVarChar,2000),
					new SqlParameter("@NoteID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.Updatetime;
            parameters[4].Value = model.Contents;
            parameters[5].Value = model.NoteID;

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
        public bool Delete(int NoteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseNotes ");
            strSql.Append(" where NoteID=@NoteID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoteID", SqlDbType.Int,4)
};
            parameters[0].Value = NoteID;

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
        public bool DeleteList(string NoteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseNotes ");
            strSql.Append(" where NoteID in (" + NoteIDlist + ")  ");
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
        public Maticsoft.Model.Tao.CourseNotes GetModel(int NoteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NoteID,UserID,CourseID,ModuleID,Updatetime,Contents from Tao_CourseNotes ");
            strSql.Append(" where NoteID=@NoteID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoteID", SqlDbType.Int,4)
};
            parameters[0].Value = NoteID;

            Maticsoft.Model.Tao.CourseNotes model = new Maticsoft.Model.Tao.CourseNotes();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NoteID"] != null && ds.Tables[0].Rows[0]["NoteID"].ToString() != "")
                {
                    model.NoteID = int.Parse(ds.Tables[0].Rows[0]["NoteID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Updatetime"] != null && ds.Tables[0].Rows[0]["Updatetime"].ToString() != "")
                {
                    model.Updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["Updatetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null && ds.Tables[0].Rows[0]["Contents"].ToString() != "")
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
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
            strSql.Append("select NoteID,UserID,CourseID,ModuleID,Updatetime,Contents ");
            strSql.Append(" FROM Tao_CourseNotes ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" Order By Updatetime desc");
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
            strSql.Append(" NoteID,UserID,CourseID,ModuleID,Updatetime,Contents ");
            strSql.Append(" FROM Tao_CourseNotes ");
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
            parameters[0].Value = "Tao_CourseNotes";
            parameters[1].Value = "NoteID";
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