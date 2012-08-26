using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Categories
    /// </summary>
    public partial class Categories
    {
        public Categories()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CategoryId", "Tao_Categories");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Categories");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
};
            parameters[0].Value = CategoryId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Categories(");
            strSql.Append("Name,Sequence,ParentCategoryId,Depth,Path,Description,IconUrl,Status,CreatedDate,CreatedUserID,RewriteName)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Sequence,@ParentCategoryId,@Depth,@Path,@Description,@IconUrl,@Status,@CreatedDate,@CreatedUserID,@RewriteName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@ParentCategoryId", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@IconUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sequence;
            parameters[2].Value = model.ParentCategoryId;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.IconUrl;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.RewriteName;

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
        public bool Update(Maticsoft.Model.Tao.Categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Categories set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Sequence=@Sequence,");
            strSql.Append("ParentCategoryId=@ParentCategoryId,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("Path=@Path,");
            strSql.Append("Description=@Description,");
            strSql.Append("IconUrl=@IconUrl,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("CreatedUserID=@CreatedUserID,");
            strSql.Append("RewriteName=@RewriteName");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@ParentCategoryId", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@IconUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
					new SqlParameter("@CategoryId", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sequence;
            parameters[2].Value = model.ParentCategoryId;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.IconUrl;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.RewriteName;
            parameters[11].Value = model.CategoryId;

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
        public bool Delete(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Categories ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
};
            parameters[0].Value = CategoryId;

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
        public bool DeleteList(string CategoryIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Categories ");
            strSql.Append(" where CategoryId in (" + CategoryIdlist + ")  ");
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
        public Maticsoft.Model.Tao.Categories GetModel(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CategoryId,Name,Sequence,ParentCategoryId,Depth,Path,Description,IconUrl,Status,CreatedDate,CreatedUserID,RewriteName from Tao_Categories ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
};
            parameters[0].Value = CategoryId;

            Maticsoft.Model.Tao.Categories model = new Maticsoft.Model.Tao.Categories();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IconUrl"] != null && ds.Tables[0].Rows[0]["IconUrl"].ToString() != "")
                {
                    model.IconUrl = ds.Tables[0].Rows[0]["IconUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RewriteName"] != null && ds.Tables[0].Rows[0]["RewriteName"].ToString() != "")
                {
                    model.RewriteName = ds.Tables[0].Rows[0]["RewriteName"].ToString();
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
            strSql.Append("select CategoryId,Name,Sequence,ParentCategoryId,Depth,Path,Description,IconUrl,Status,CreatedDate,CreatedUserID,RewriteName ");
            strSql.Append(" FROM Tao_Categories  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  order by Sequence asc  ");
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
            strSql.Append(" CategoryId,Name,Sequence,ParentCategoryId,Depth,Path,Description,IconUrl,Status,CreatedDate,CreatedUserID,RewriteName ");
            strSql.Append(" FROM Tao_Categories ");
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
            parameters[0].Value = "Tao_Categories";
            parameters[1].Value = "CategoryId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region NewMethod

        #region 根据父级类别得到一个对象实体

        /// <summary>
        /// 根据父级类别得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Categories GetModelByParentCategoryId(int ParentCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CategoryId,Name,Sequence,ParentCategoryId,Depth,Path,Description,IconUrl,Status,CreatedDate,CreatedUserID,RewriteName from Tao_Categories ");
            strSql.Append(" where CategoryId=@ParentCategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentCategoryId", SqlDbType.Int,4)
};
            parameters[0].Value = ParentCategoryId;

            Maticsoft.Model.Tao.Categories model = new Maticsoft.Model.Tao.Categories();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IconUrl"] != null && ds.Tables[0].Rows[0]["IconUrl"].ToString() != "")
                {
                    model.IconUrl = ds.Tables[0].Rows[0]["IconUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RewriteName"] != null && ds.Tables[0].Rows[0]["RewriteName"].ToString() != "")
                {
                    model.RewriteName = ds.Tables[0].Rows[0]["RewriteName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion 根据父级类别得到一个对象实体

        #endregion NewMethod
    }
}