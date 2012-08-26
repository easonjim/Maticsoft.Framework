using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:CourseModule
    /// </summary>
    public partial class CourseModule
    {
        public CourseModule()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Tao_CourseModule");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_CourseModule");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_CourseModule(");
            strSql.Append("CourseID,ModuleID,ModuleIndex,CreateDate,Status,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@CourseID,@ModuleID,@ModuleIndex,@CreateDate,@Status,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleIndex", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.ModuleIndex;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.UpdateDate;

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
        public bool Update(Maticsoft.Model.Tao.CourseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_CourseModule set ");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("ModuleIndex=@ModuleIndex,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleIndex", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.ModuleIndex;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.UpdateDate;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from Tao_CourseModule ");
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

        public bool Delete(int iCourseId, int iModuleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseModule ");
            strSql.Append(" where CourseId=@CourseId AND ModuleId = @ModuleId");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4),
                    new SqlParameter("@ModuleId", SqlDbType.Int,4)
};
            parameters[0].Value = iCourseId;
            parameters[1].Value = iModuleId;

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
            strSql.Append("delete from Tao_CourseModule ");
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
        public Maticsoft.Model.Tao.CourseModule GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CourseID,ModuleID,ModuleIndex,CreateDate,Status,UpdateDate from Tao_CourseModule ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Maticsoft.Model.Tao.CourseModule model = new Maticsoft.Model.Tao.CourseModule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleIndex"] != null && ds.Tables[0].Rows[0]["ModuleIndex"].ToString() != "")
                {
                    model.ModuleIndex = int.Parse(ds.Tables[0].Rows[0]["ModuleIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModel(int CourseID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CourseID,ModuleID,ModuleIndex,CreateDate,Status,UpdateDate from Tao_CourseModule ");
            strSql.Append(" where CourseID=@CourseID and ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
                                        new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = CourseID;
            parameters[1].Value = ModuleID;

            Maticsoft.Model.Tao.CourseModule model = new Maticsoft.Model.Tao.CourseModule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleIndex"] != null && ds.Tables[0].Rows[0]["ModuleIndex"].ToString() != "")
                {
                    model.ModuleIndex = int.Parse(ds.Tables[0].Rows[0]["ModuleIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
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
            strSql.Append("select ID,CourseID,ModuleID,ModuleIndex,CreateDate,Status,UpdateDate ");
            strSql.Append(" FROM Tao_CourseModule ");
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
            strSql.Append(" ID,CourseID,ModuleID,ModuleIndex,CreateDate,Status,UpdateDate ");
            strSql.Append(" FROM Tao_CourseModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method

        #region NewMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Tao_CourseModule ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            Maticsoft.Model.Tao.CourseModule model = new Maticsoft.Model.Tao.CourseModule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleIndex"] != null && ds.Tables[0].Rows[0]["ModuleIndex"].ToString() != "")
                {
                    model.ModuleIndex = int.Parse(ds.Tables[0].Rows[0]["ModuleIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.CourseModule GetFirstModel(int cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 A.* FROM dbo.Tao_CourseModule A ");
            strSql.Append("LEFT JOIN dbo.Tao_Courses B ON A.CourseID=b.CourseID ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules C ON A.ModuleID=C.ModuleID ");
            strSql.AppendFormat("WHERE A.CourseID={0} AND C.Status=3  ", cid);
            strSql.Append("ORDER BY A.ModuleIndex ASC ");
            Maticsoft.Model.Tao.CourseModule model = new Maticsoft.Model.Tao.CourseModule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleIndex"] != null && ds.Tables[0].Rows[0]["ModuleIndex"].ToString() != "")
                {
                    model.ModuleIndex = int.Parse(ds.Tables[0].Rows[0]["ModuleIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion NewMethod
    }
}