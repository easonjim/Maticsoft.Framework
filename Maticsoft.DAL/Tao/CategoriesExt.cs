using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Categories
    {
        /// <summary>
        /// 添加新的分类 主页菜单导航
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCate(Maticsoft.Model.Tao.Categories model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Sequence", SqlDbType.Int),
					new SqlParameter("@Status", SqlDbType.Bit),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@ParentCategoryId", SqlDbType.Int),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
					new SqlParameter("@IconUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateUserID", SqlDbType.Int)
					};
            parameters[0].Value = model.Name;
            parameters[1].Value = 4;
            parameters[2].Value = 0;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.ParentCategoryId.Value;
            parameters[5].Value = model.RewriteName;
            parameters[6].Value = model.IconUrl;
            parameters[7].Value = model.CreatedUserID;
            return DbHelperSQL.RunProcedure("sp_cc_Category_Create", parameters, out rowsAffected);
        }

        /// <summary>
        /// 对类别进行排序
        /// </summary>
        /// <param name="categoryId">类别ID</param>
        /// <param name="zIndex">排序方式</param>
        /// <returns></returns>
        public int SwapCategorySequence(int categoryId, Maticsoft.Common.CategoryZIndex zIndex)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int),
					new SqlParameter("@ZIndex", SqlDbType.Int)
					};
            parameters[0].Value = categoryId;
            parameters[1].Value = (int)zIndex;
            return DbHelperSQL.RunProcedure("sp_cc_Category_SwapSequence", parameters, out rowsAffected);
        }

        /// <summary>
        /// 级联删除分类及子类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Maticsoft.Common.CategoryActionStatus DeleteCategory(int categoryId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int)
					};
            parameters[0].Value = categoryId;
            return (Maticsoft.Common.CategoryActionStatus)((int)DbHelperSQL.RunProcedure("sp_cc_Category_Delete", parameters, out rowsAffected));
        }

        /// <summary>
        /// 更新分类信息
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Maticsoft.Common.CategoryActionStatus UpdateCategory(Maticsoft.Model.Tao.Categories category)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@CategoryId", SqlDbType.Int),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
					new SqlParameter("@IconUrl", SqlDbType.NVarChar,300)
					};
            parameters[0].Value = category.Name;
            parameters[1].Value = category.CategoryId;
            parameters[2].Value = category.Description;
            parameters[3].Value = category.RewriteName;
            parameters[4].Value = category.IconUrl;
            DbHelperSQL.RunProcedure("sp_cc_Category_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return Common.CategoryActionStatus.Success;
            }
            else
            {
                return Common.CategoryActionStatus.UnknowError;
            }
        }

        public bool UpdateImgURL(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Categories SET IconUrl='' ");
            strSql.Append("WHERE CategoryId= " + id);
            int res = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到最大Depth
        /// </summary>
        public int GetDepth()
        {
            return DbHelperSQL.GetMaxID("Depth", "Tao_Categories") - 1;
        }

        public List<Maticsoft.Model.Tao.Categories> GetAllCate(int? parentId)
        {
            return GetListByCondition(parentId);
        }

        #region 根据参数数组 执行 查询任务，并返回查询到的泛型集合

        /// <summary>
        /// 根据参数数组 执行 查询任务，并返回查询到的泛型集合
        /// </summary>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        private List<Maticsoft.Model.Tao.Categories> GetListByCondition(int? parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Tao_Categories ");
            if (parentId.HasValue)
            {
                strSql.Append(" Where ParentCategoryId=" + parentId.Value);
            }
            else
            {
                strSql.Append(" Where ParentCategoryId =0 ");
            }
            strSql.Append(" ORDER BY  Sequence ");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            List<Maticsoft.Model.Tao.Categories> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Maticsoft.Model.Tao.Categories>();
                //循环将 数据表 中的 所有行 转成 实体对象  并 添加到泛型集合中
                foreach (DataRow dr in dt.Rows)
                {
                    Maticsoft.Model.Tao.Categories model = new Maticsoft.Model.Tao.Categories();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion 根据参数数组 执行 查询任务，并返回查询到的泛型集合

        /// <summary>
        /// LoadEntityData
        /// </summary>
        /// <param name="model">Entity</param>
        /// <param name="dr">DataRow</param>
        private void LoadEntityData(ref Maticsoft.Model.Tao.Categories model, DataRow dr)
        {
            if (dr["CategoryId"].ToString() != "")
            {
                model.CategoryId = int.Parse(dr["CategoryId"].ToString());
            }
            if (dr["Name"].ToString() != "")
            {
                model.Name = dr["Name"].ToString();
            }
            if (dr["Sequence"].ToString() != "")
            {
                model.Sequence = int.Parse(dr["Sequence"].ToString());
            }
            if (dr["ParentCategoryId"].ToString() != "")
            {
                model.ParentCategoryId = int.Parse(dr["ParentCategoryId"].ToString());
            }
            if (dr["Depth"].ToString() != "")
            {
                model.Depth = int.Parse(dr["Depth"].ToString());
            }
            if (dr["Path"].ToString() != "")
            {
                model.Path = dr["Path"].ToString();
            }
            if (dr["Description"].ToString() != "")
            {
                model.Description = dr["Description"].ToString();
            }
            if (dr["IconUrl"].ToString() != "")
            {
                model.IconUrl = dr["IconUrl"].ToString();
            }
            if (dr["Status"].ToString() != "")
            {
                model.Status = int.Parse(dr["Status"].ToString());
            }
            if (dr["CreatedDate"].ToString() != "")
            {
                model.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
            }
            if (dr["CreatedUserID"].ToString() != "")
            {
                model.CreatedUserID = int.Parse(dr["CreatedUserID"].ToString());
            }
            if (dr["RewriteName"].ToString() != "")
            {
                model.RewriteName = dr["RewriteName"].ToString();
            }
        }

        /// <summary>
        /// 获取课程分类
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCate0(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CategoryId,Name  ");
            strSql.Append("FROM Tao_Categories  ");
            if (parentId > 0)
            {
                strSql.Append("WHERE ParentCategoryId=" + parentId);
            }
            else
            {
                strSql.Append("WHERE ParentCategoryId=0 ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetCate()
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("DECLARE @TableVariable TABLE ([path] varchar(4000))  ");
            //strSql.Append("INSERT @TableVariable  ");
            //strSql.Append("select [path] from Tao_Categories order by REPLACE([path],convert(varchar,CategoryId),'')  ");
            //strSql.Append("select a.* from (Tao_Categories a left join @TableVariable b on a.Path = b.path) ");
            //strSql.Append("order by b.[path], a.Sequence ");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Tao_Categories ");
            strSql.Append("ORDER BY Sequence,[path] DESC ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
    }
}