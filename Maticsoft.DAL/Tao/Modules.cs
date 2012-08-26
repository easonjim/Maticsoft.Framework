using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Modules
    /// </summary>
    public partial class Modules
    {
        public Modules()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ModuleID", "Tao_Modules");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Modules");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
};
            parameters[0].Value = ModuleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strModuleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Modules");
            strSql.Append(" where ModuleName=@ModuleName");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.Int,4)
};
            parameters[0].Value = strModuleName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Modules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Modules(");
            strSql.Append("ModuleName,Description,TimeDuration,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Price,PV,Sequence,Attachment,UpdatedDate)");
            strSql.Append(" values (");
            strSql.Append("@ModuleName,@Description,@TimeDuration,@Status,@Tags,@ImageUrl,@Type,@VideoContent,@CreatedDate,@CreatedUserID,@Price,@PV,@Sequence,@Attachment,@UpdatedDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@TimeDuration", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@VideoContent", SqlDbType.VarChar),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,300),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.TimeDuration;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Tags;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.VideoContent;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.Price;
            parameters[11].Value = model.PV;
            parameters[12].Value = model.Sequence;
            parameters[13].Value = model.Attachment;
            parameters[14].Value = model.UpdatedDate;

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
        public bool Update(Maticsoft.Model.Tao.Modules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Modules set ");
            strSql.Append("ModuleName=@ModuleName,");
            strSql.Append("Description=@Description,");
            strSql.Append("TimeDuration=@TimeDuration,");
            strSql.Append("Status=@Status,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("Type=@Type,");
            strSql.Append("VideoContent=@VideoContent,");
            //strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("CreatedUserID=@CreatedUserID,");
            //strSql.Append("Price=@Price,");
            strSql.Append("PV=@PV,");
            strSql.Append("Sequence=@Sequence,");
            strSql.Append("Attachment=@Attachment,");
            strSql.Append("UpdatedDate=@UpdatedDate");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@TimeDuration", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@VideoContent", SqlDbType.VarChar),
                    //new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
                    //new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,300),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.TimeDuration;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Tags;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.VideoContent;
            //parameters[8].Value = model.CreatedDate;
            parameters[8].Value = model.CreatedUserID;
            //parameters[10].Value = model.Price;
            parameters[9].Value = model.PV;
            parameters[10].Value = model.Sequence.Value;
            parameters[11].Value = model.Attachment;
            parameters[12].Value = model.UpdatedDate;
            parameters[13].Value = model.ModuleID;

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
        public bool Delete(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Modules ");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
};
            parameters[0].Value = ModuleID;

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
        public bool DeleteList(string ModuleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Modules ");
            strSql.Append(" where ModuleID in (" + ModuleIDlist + ")  ");
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
        public Maticsoft.Model.Tao.Modules GetModel(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ModuleID,ModuleName,Description,TimeDuration,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Price,PV,Sequence,Attachment,UpdatedDate from Tao_Modules ");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
};
            parameters[0].Value = ModuleID;

            Maticsoft.Model.Tao.Modules model = new Maticsoft.Model.Tao.Modules();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleName"] != null && ds.Tables[0].Rows[0]["ModuleName"].ToString() != "")
                {
                    model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TimeDuration"] != null && ds.Tables[0].Rows[0]["TimeDuration"].ToString() != "")
                {
                    model.TimeDuration = int.Parse(ds.Tables[0].Rows[0]["TimeDuration"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VideoContent"] != null && ds.Tables[0].Rows[0]["VideoContent"].ToString() != "")
                {
                    model.VideoContent = ds.Tables[0].Rows[0]["VideoContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PV"] != null && ds.Tables[0].Rows[0]["PV"].ToString() != "")
                {
                    model.PV = int.Parse(ds.Tables[0].Rows[0]["PV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Attachment"] != null && ds.Tables[0].Rows[0]["Attachment"].ToString() != "")
                {
                    model.Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdatedDate"] != null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
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
            strSql.Append("select ModuleID,ModuleName,Description,TimeDuration,Status,Tags,ImageUrl,Type,VideoContent,CreatedUserID,Price,PV,Sequence,Attachment ");
            strSql.Append(" FROM Tao_Modules ");
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
            strSql.Append(" ModuleID,ModuleName,Description,TimeDuration,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Price,PV,Sequence,Attachment,UpdatedDate ");
            strSql.Append(" FROM Tao_Modules ");
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
            parameters[0].Value = "Tao_Modules";
            parameters[1].Value = "ModuleID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region NewMethod

        /// <summary>
        /// 更新浏览量
        /// </summary>
        public bool UpdatePV(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Modules set ");
            strSql.Append("PV=PV+1 ");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleID;
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

        public DataSet GetList(int courseID, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID,ModuleName,Description,TimeDuration,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Price,PV,Sequence,Attachment,UpdatedDate ");
            strSql.Append(" FROM Tao_Modules ");
            if (status > -1)
            {
                strSql.AppendFormat(" where ModuleID in (SELECT ModuleID FROM Tao_CourseModule where CourseID={0}) and Status={1}", courseID, status);
            }
            else
            {
                strSql.AppendFormat(" where ModuleID in (SELECT ModuleID FROM Tao_CourseModule where CourseID={0})", courseID);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetCounts(int courseID, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Count(1) ");
            strSql.Append(" FROM Tao_Modules ");
            if (status > -1)
            {
                strSql.AppendFormat(" where ModuleID in (SELECT ModuleID FROM Tao_CourseModule where CourseID={0}) and Status={1}", courseID, status);
            }
            else
            {
                strSql.AppendFormat(" where ModuleID in (SELECT ModuleID FROM Tao_CourseModule where CourseID={0})", courseID);
            }

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

        /// <summary>
        /// 批量处理数据
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("update Tao_Modules set " + strWhere);
                strSql.Append(" where ModuleID in (" + IDlist + ")");
                rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion NewMethod
    }
}