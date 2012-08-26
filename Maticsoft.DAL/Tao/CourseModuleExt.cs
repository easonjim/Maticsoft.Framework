using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using Maticsoft.DBUtility;
using Maticsoft.Model;

namespace Maticsoft.DAL.Tao
{
    public partial class CourseModule
    {
        /// <summary>
        /// 保存学习资料
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        public int UploadAttachment(Model.Tao.Courses courseModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses SET Attachment=@Attachment ");
            strSql.Append("WHERE CourseID= @CourseID");
            SqlParameter[] parameters = {
										new SqlParameter("@CourseID",SqlDbType.Int,4),
										new SqlParameter("@Attachment",SqlDbType.VarChar,300)
										};
            parameters[0].Value = courseModel.CourseID;
            parameters[1].Value = courseModel.Attachment;
            int res = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return res;
        }

        /// <summary>
        /// 视频最终页 Top 课程信息
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public DataSet GetCourseModel(int CourseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TC.CourseID,TC.CourseName,TC.TimeDuration,TC.Description, TC.Price,TC.SalesVolume,AU.TrueName,TE.Name,AUE.TeachDescription ");
            strSql.Append("FROM Tao_Courses TC ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=TC.CreatedUserID ");
            strSql.Append("LEFT JOIN Tao_Enterprise TE ON TE.CreatedUserID=TC.CreatedUserID ");
            strSql.Append("LEFT JOIN Accounts_UsersExp AUE ON AUE.UserID=TC.CreatedUserID ");
            strSql.Append("WHERE CourseID=@CourseId ");
            SqlParameter[] parameters = {
										new SqlParameter("@CourseId",SqlDbType.Int)
										};
            parameters[0].Value = CourseId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 视频最终页--相关章节信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public DataSet ContractModule(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TM.ModuleID,TM.ModuleName,TM.TimeDuration,TM.ImageUrl,AU.TrueName,TCM.ModuleIndex,TM.Price ");
            strSql.Append("FROM Tao_CourseModule TCM ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TCM.CourseID ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TCM.ModuleID ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON TM.CreatedUserID=AU.UserID ");
            strSql.Append("WHERE TCM.CourseID=@courseId ");
            SqlParameter[] parameters = {
										new SqlParameter("@courseId",SqlDbType.Int)
										};
            parameters[0].Value = courseId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCourseList(QueryCourses query)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
					new SqlParameter("@PageIndex", DbType.Int32),
					new SqlParameter("@PageSize", DbType.Int32),
					new SqlParameter("@SqlPopulate", DbType.String)
                };
            parameters[0].Value = query.PageIndex;
            parameters[1].Value = query.PageSize;
            parameters[2].Value = GetCourseMouleSql(query);

            using (IDataReader reader = DbHelperSQL.RunProcedure("sp_cc_CourseMoule_Get", parameters))
            {
                dt = ConverDataReaderToDataTable(reader);
            }
            return dt;
        }

        /// <summary>
        /// 获取课程小节列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetModuleList(QueryCourses query)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
					new SqlParameter("@PageIndex", DbType.Int32),
					new SqlParameter("@PageSize", DbType.Int32),
					new SqlParameter("@SqlPopulate", DbType.String)
                };
            parameters[0].Value = query.PageIndex;
            parameters[1].Value = query.PageSize;
            parameters[2].Value = GetCourseMouleSql(query);

            using (IDataReader reader = DbHelperSQL.RunProcedure("sp_cc_MouleList_Get", parameters))
            {
                dt = ConverDataReaderToDataTable(reader);
            }
            return dt;
        }

        public static DataTable ConverDataReaderToDataTable(IDataReader reader)
        {
            if (reader == null)
            {
                return null;
            }
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            int fieldCount = reader.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }
            table.BeginLoadData();
            object[] values = new object[fieldCount];
            while (reader.Read())
            {
                reader.GetValues(values);
                table.LoadDataRow(values, true);
            }
            table.EndLoadData();
            return table;
        }

        /// <summary>
        /// 获取组织课程体系
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetCourseMouleSql(QueryCourses query)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("select distinct ");
            if (query.TopCount.HasValue)
            {
                strWhere.Append("top " + query.TopCount);
            }
            strWhere.Append(" TC.CourseID from (((Tao_CourseModule CM left join Tao_Courses TC ON TC.CourseID = CM.CourseID) ");
            strWhere.Append("Left Join Tao_Modules TM ON CM.ModuleID = TM.ModuleID) ");
            strWhere.Append("Left Join Tao_Categories TCA ON TC.CategoryId = TCA.CategoryId) ");
            strWhere.Append("Left Join Accounts_Users AU ON TC.CreatedUserID = AU.UserID ");
            strWhere.Append("Where 1=1 ");
            if (query.CategoryId.HasValue)
            {
                strWhere.Append(" AND TCA.CategoryId = " + query.CategoryId);
            }
            if (!string.IsNullOrEmpty(query.ModuleName))
            {
                strWhere.Append(" AND TM.ModuleName = '" + query.ModuleName + "'");
            }
            if (query.CourseID.HasValue)
            {
                strWhere.Append(" AND TC.CourseID = " + query.CourseID);
            }
            if (query.CourseTypes.HasValue)
            {
                strWhere.Append(" AND TC.CourseTypes = " + query.CourseTypes);
            }
            if (query.ModuleId.HasValue)
            {
                strWhere.Append(" AND CM.ModuleId = " + query.ModuleId);
            }
            if (query.Status.HasValue)
            {
                strWhere.Append(" AND TC.Status = " + query.Status);
            }
            if (query.Userid.HasValue)
            {
                strWhere.Append(" AND (TC.CreatedUserID = " + query.Userid + " OR  TM.CreatedUserID = " + query.Userid + ") ");
            }
            if (!string.IsNullOrEmpty(query.Tags))
            {
                strWhere.Append(" AND (TC.CourseName LIKE '%" + query.Tags + "%' OR TC.Tags LIKE '%" + query.Tags + "%' OR TM.ModuleName LIKE '%" + query.Tags + "%' OR TM.Tags LIKE '%" + query.Tags + "%')");
            }
            return strWhere.ToString();
        }

        public int GetCourseMouleCount(QueryCourses query)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("select Count(0) AS count from ");
            strWhere.Append(" (select distinct TC.CourseID from (((Tao_CourseModule CM left join Tao_Courses TC ON TC.CourseID = CM.CourseID) ");
            strWhere.Append("Left Join Tao_Modules TM ON CM.ModuleID = TM.ModuleID) ");
            strWhere.Append("Left Join Tao_Categories TCA ON TC.CategoryId = TCA.CategoryId) ");
            strWhere.Append("Left Join Accounts_Users AU ON TC.CreatedUserID = AU.UserID ");
            strWhere.Append("Where 1=1 ");
            if (query.CategoryId.HasValue)
            {
                strWhere.Append(" AND TCA.CategoryId = " + query.CategoryId);
            }
            if (!string.IsNullOrEmpty(query.ModuleName))
            {
                strWhere.Append(" AND TM.ModuleName = '" + query.ModuleName + "'");
            }
            if (query.CourseID.HasValue)
            {
                strWhere.Append(" AND TC.CourseID = " + query.CourseID);
            }
            if (query.CourseTypes.HasValue)
            {
                strWhere.Append(" AND TC.CourseTypes = " + query.CourseTypes);
            }
            if (query.ModuleId.HasValue)
            {
                strWhere.Append(" AND CM.ModuleId = " + query.ModuleId);
            }
            if (query.Status.HasValue)
            {
                strWhere.Append(" AND TC.Status = " + query.Status);
            }
            if (query.Userid.HasValue)
            {
                strWhere.Append(" AND (TC.CreatedUserID = " + query.Userid + " OR  TM.CreatedUserID = " + query.Userid + ") ");
            }
            if (!string.IsNullOrEmpty(query.Tags))
            {
                strWhere.Append(" AND (TC.CourseName LIKE '%" + query.Tags + "%' OR TC.Tags LIKE '%" + query.Tags + "%' OR TM.ModuleName LIKE '%" + query.Tags + "%' OR TM.Tags LIKE '%" + query.Tags + "%')");
            }
            strWhere.Append(") AS T");
            return Convert.ToInt32(DbHelperSQL.Query(strWhere.ToString()).Tables[0].Rows[0][0]);
        }

        public DataSet GetCourseMoulePriceAndCount(QueryCourses query)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("select ");
            strWhere.Append(" count(0) AS Count,SUM(TM.Price) as ModulePrice,SUM(TM.TimeDuration) AS TimeDuration from (((Tao_CourseModule CM left join Tao_Courses TC ON TC.CourseID = CM.CourseID) ");
            strWhere.Append("Left Join Tao_Modules TM ON CM.ModuleID = TM.ModuleID) ");
            strWhere.Append("Left Join Tao_Categories TCA ON TC.CategoryId = TCA.CategoryId) ");
            strWhere.Append("Left Join Accounts_Users AU ON TC.CreatedUserID = AU.UserID ");
            strWhere.Append("Where 1=1 ");
            if (query.CategoryId.HasValue)
            {
                strWhere.Append(" AND TCA.CategoryId = " + query.CategoryId);
            }
            if (!string.IsNullOrEmpty(query.ModuleName))
            {
                strWhere.Append(" AND TM.ModuleName = '" + query.ModuleName + "'");
            }
            if (query.CourseID.HasValue)
            {
                strWhere.Append(" AND TC.CourseID = " + query.CourseID);
            }
            if (query.CourseTypes.HasValue)
            {
                strWhere.Append(" AND TC.CourseTypes = " + query.CourseTypes);
            }
            if (query.ModuleId.HasValue)
            {
                strWhere.Append(" AND CM.ModuleId = " + query.ModuleId);
            }
            if (query.Status.HasValue)
            {
                strWhere.Append(" AND TC.Status = " + query.Status);
            }
            if (query.Userid.HasValue)
            {
                strWhere.Append(" AND (TC.CreatedUserID = " + query.Userid + " OR  TM.CreatedUserID = " + query.Userid + ") ");
            }
            if (!string.IsNullOrEmpty(query.Tags))
            {
                strWhere.Append(" AND (TC.CourseName LIKE '%" + query.Tags + "%' OR TC.Tags LIKE '%" + query.Tags + "%' OR TM.ModuleName LIKE '%" + query.Tags + "%' OR TM.Tags LIKE '%" + query.Tags + "%')");
            }
            return DbHelperSQL.Query(strWhere.ToString());
        }

        public bool ExistsCourseModule(int iCourseID, int iModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_CourseModule");
            strSql.Append(" where CourseID=@CourseID AND ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int),
					new SqlParameter("@ModuleID", SqlDbType.Int)
};
            parameters[0].Value = iCourseID;
            parameters[1].Value = iModule;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int GetMaxModuleIndex(int CourseId)
        {
            string strWhere = "CourseId = " + CourseId;
            return DbHelperSQL.GetMaxID("ModuleIndex", "Tao_CourseModule", strWhere);
        }

        public bool UpdateModuleIndex(Model.Tao.CourseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_CourseModule set ");
            strSql.Append("ModuleIndex=@ModuleIndex,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where CourseID=@CourseID And ModuleIndex = @ModuleIndex");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleIndex", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.ModuleIndex;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.UpdateDate;

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
        public bool DeleteList(string IDlist, int? iCourseID, int? ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseModule where 1=1");
            if (!string.IsNullOrEmpty(IDlist))
            {
                strSql.Append(" AND  ID in (" + IDlist + ")  ");
            }
            if (iCourseID.HasValue && ModuleID.HasValue)
            {
                strSql.Append(" AND CourseID = " + iCourseID + " AND ModuleID= " + ModuleID);
            }

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
        public Model.Tao.CourseModule GetModel(int? ID, int? iCourseID, int? ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Tao_CourseModule ");
            strSql.Append(" where 1=1");
            if (ID.HasValue)
            {
                strSql.Append(" AND ID= " + ID);
            }
            if (iCourseID.HasValue && ModuleID.HasValue)
            {
                strSql.Append(" AND CourseID = " + iCourseID + " AND ModuleID= " + ModuleID);
            }

            Model.Tao.CourseModule model = new Model.Tao.CourseModule();
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

        public bool SendEmailSuccess(int moduleId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_CourseModule  ");
            strSql.Append("SET Status=@Status ");
            strSql.Append("WHERE ModuleID= @ModuleID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = moduleId;
            parameters[1].Value = status;
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

        public DataSet GetSearchRes(int startIndex, int pageSize, string keyStr, int orderType, string strWhere)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@OrderType",SqlDbType.Int),
                                        new SqlParameter("@keyStr",SqlDbType.NVarChar),
                                        new SqlParameter("@whereStr",SqlDbType.NVarChar)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = orderType;
            parameters[3].Value = keyStr;
            parameters[4].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_SearchCourseByKey", parameters, "ds");
        }

        public DataSet GetSearchByCateID(int startIndex, int pageSize, int orderType, int cateId)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@OrderType",SqlDbType.Int),
                                        new SqlParameter("@CateId",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = orderType;
            parameters[3].Value = cateId;
            return DbHelperSQL.RunProcedure("sp_SearchCourseByCategorieID", parameters, "ds");
        }

        public int CourseRowsCount(string strKey, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM Tao_Courses ");
            strSql.Append("WHERE CourseID IN( ");
            strSql.Append("select distinct  TC.CourseID from (((Tao_CourseModule CM  ");
            strSql.Append("left join Tao_Courses TC ON TC.CourseID = CM.CourseID)  ");
            strSql.Append("Left Join Tao_Modules TM ON CM.ModuleID = TM.ModuleID LEFT JOIN Accounts_Users AU ON AU.UserID=TM.CreatedUserID) )  ");
            strSql.Append("Where TC.Status=3  AND  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("  TrueName LIKE'%" + strKey + "%')");
            }
            else
            {
                strSql.Append("(TC.CourseName LIKE '%" + strKey + "%' OR TC.Tags LIKE '%" + strKey + "%' OR TM.ModuleName LIKE '%" + strKey + "%' OR TM.Tags LIKE '%" + strKey + "%' OR   TrueName LIKE'%" + strKey + "%')) ");
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

        public int GetCountByCateId(int cateId)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@cateId",SqlDbType.Int)
                                        };
            parameters[0].Value = cateId;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseCountByCategorieID", parameters, "ds");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                return Convert.ToInt32(ds.Tables[0].Rows[0]["CourseCount"]);
            }
            else
            {
                return 0;
            }
        }

        public int GetCourserteacher(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM ( ");
            strSql.Append("select CreatedUserID from Tao_CourseModule tcm ");
            strSql.Append("left join Tao_Modules tm on tcm.ModuleID=tm.ModuleID ");
            strSql.Append("where CourseID=@CourseID ");
            strSql.Append("group by CreatedUserID)A ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
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

        public int CourseCountByUid(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1)  ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE CourseID IN( ");
            strSql.Append("select distinct  TC.CourseID from (((Tao_CourseModule CM  ");
            strSql.Append("left join Tao_Courses TC ON TC.CourseID = CM.CourseID)  ");
            strSql.Append("Left Join Tao_Modules TM ON CM.ModuleID = TM.ModuleID ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=TM.CreatedUserID) )  ");
            strSql.Append(")and Status=3 AND CreatedUserID=@Userid ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@Userid",SqlDbType.Int)
                                        };
            parameters[0].Value = uid;
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

        public DataSet CourseBuUid(int startIndex, int pageSize, int? uid, int orderType)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@OrderType",SqlDbType.Int),
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = orderType;
            parameters[3].Value = uid.Value;
            return DbHelperSQL.RunProcedure("sp_SearchCourseByUid", parameters, "ds");
        }
    }
}