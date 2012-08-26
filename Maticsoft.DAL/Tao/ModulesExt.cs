using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Modules
    {
        /// <summary>
        /// 根据ModuleID得到ModuleName
        /// </summary>
        public Model.Tao.Modules GetModuleName(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ModuleName  ");
            strSql.Append("FROM Tao_Modules ");
            strSql.Append("WHERE ModuleID=@ModuleID ");

            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
};
            parameters[0].Value = ModuleID;

            Model.Tao.Modules model = new Model.Tao.Modules();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleName"] != null && ds.Tables[0].Rows[0]["ModuleName"].ToString() != "")
                {
                    model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据moduleId更新Module的价格
        /// </summary>
        public int UpDateModulePrice(int moduleId, decimal price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Modules  ");
            strSql.Append("SET Price=@Price  ");
            strSql.Append("WHERE ModuleID=@ModuleID ");
            SqlParameter[] parameter = {
                                       new SqlParameter("@ModuleID",SqlDbType.Int,4),
                                       new SqlParameter("@Price",SqlDbType.Money)
                                       };
            parameter[0].Value = moduleId;
            parameter[1].Value = price;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameter);
        }

        /// <summary>
        /// 上传课程章节
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool CreateModule(Model.Tao.Modules model, int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@TimeDuration", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@VideoContent", SqlDbType.VarChar,300),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,300),
					new SqlParameter("@CourseID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.TimeDuration;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Tags;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.VideoContent;
            parameters[8].Value = model.CreatedUserID;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.PV;
            parameters[11].Value = model.Sequence;
            parameters[12].Value = model.Attachment;
            parameters[13].Value = courseId;
            DbHelperSQL.RunProcedure("sp_cc_ModuleCreate", parameters, out rowsAffected);
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
        /// 创建新课程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool CreateNewModule(Model.Tao.Modules model, int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleName",SqlDbType.NVarChar),
                                        new SqlParameter("@Type",SqlDbType.Int),
                                        new SqlParameter("@VideoContent",SqlDbType.VarChar),
                                        new SqlParameter("@CreatedUserID",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@ImageUrl",SqlDbType.VarChar),
                                        new SqlParameter("@Tags",SqlDbType.VarChar),
                                        new SqlParameter("@Description",SqlDbType.VarChar),
                                        new SqlParameter("@Sequence",SqlDbType.VarChar),
                                        new SqlParameter("@TimeDur",SqlDbType.Int)
                                        };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.VideoContent;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = courseId;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.Tags;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Sequence;
            parameters[9].Value = model.TimeDuration;
            DbHelperSQL.RunProcedure("sp_CreateNewModule", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpDateLocalModule(Model.Tao.Modules model, int cid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleName",SqlDbType.NVarChar),
                                        new SqlParameter("@VideoContent",SqlDbType.VarChar),
                                        new SqlParameter("@ImageUrl",SqlDbType.VarChar),
                                        new SqlParameter("@Tags",SqlDbType.VarChar),
                                        new SqlParameter("@Description",SqlDbType.VarChar),
                                        new SqlParameter("@Sequence",SqlDbType.VarChar),
                                        new SqlParameter("@TimeDur",SqlDbType.Int),
                                        new SqlParameter("@ModuleId",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.VideoContent;
            parameters[2].Value = model.ImageUrl;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.Sequence;
            parameters[6].Value = model.TimeDuration;
            parameters[7].Value = model.ModuleID;
            parameters[8].Value = cid;
            DbHelperSQL.RunProcedure("sp_UpDateLocalModule", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateModuleExtInfo(Model.Tao.Modules model, int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleName",SqlDbType.NVarChar),
                                        new SqlParameter("@Type",SqlDbType.Int),
                                        new SqlParameter("@CreatedUserID",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@Tags",SqlDbType.VarChar),
                                        new SqlParameter("@Description",SqlDbType.VarChar),
                                        new SqlParameter("@Sequence",SqlDbType.VarChar),
                                        new SqlParameter("@VideoPath",SqlDbType.NVarChar)
                                        };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.CreatedUserID;
            parameters[3].Value = courseId;
            parameters[4].Value = model.Tags;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Sequence;
            parameters[7].Value = model.VideoContent;
            DbHelperSQL.RunProcedure("sp_CreateModuleExtInfo", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateModuleExtInfo(Model.Tao.Modules model, int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleName",SqlDbType.NVarChar),
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@Tags",SqlDbType.VarChar),
                                        new SqlParameter("@Description",SqlDbType.VarChar),
                                        new SqlParameter("@Sequence",SqlDbType.VarChar),
                                        new SqlParameter("@VideoPath",SqlDbType.NVarChar),
                                        new SqlParameter("@ModuleId",SqlDbType.Int)
                                        };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = courseId;
            parameters[2].Value = model.Tags;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.Sequence;
            parameters[5].Value = model.VideoContent;
            parameters[6].Value = model.ModuleID;
            DbHelperSQL.RunProcedure("sp_UpdateModuleExtInfo", parameters, out rowsAffected);
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
        /// 删除课程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DeleteModule(int moduleId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleId",SqlDbType.Int),
                                        };
            parameters[0].Value = moduleId;
            DbHelperSQL.RunProcedure("sp_DeleteModule", parameters, out rowsAffected);
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
        /// 设置课程价格
        /// </summary>
        public DataSet SetCoursePricr(int userId, int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TCM.ModuleID,TM.ModuleName,TCM.ModuleIndex,TM.Price  ");
            strSql.Append("FROM Tao_CourseModule TCM  ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TCM.CourseID=TC.CourseID  ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TCM.ModuleID  ");
            strSql.Append("WHERE TC.CourseID=@CourseId AND TM.CreatedUserID=@UserID  ");
            strSql.Append("ORDER BY ModuleIndex ASC  ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            parameters[1].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取课程的名称和课程已存入的价格
        /// </summary>
        public DataSet GetCourseInfo(int userID, int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CourseName,SUM(TM.Price )AS TotalMoney  ");
            strSql.Append("FROM Tao_CourseModule TCM  ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TCM.CourseID=TC.CourseID   ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TCM.ModuleID  ");
            strSql.Append("WHERE TC.CourseID=@CourseId AND TM.CreatedUserID=@UserId  ");
            strSql.Append("GROUP BY CourseName   ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserId",SqlDbType.Int),
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = userID;
            parameters[1].Value = courseId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet getModuleInfo(int userId, int CourseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TCM.ModuleIndex, TM.ModuleID,ModuleName,Description,TM.Status,ImageUrl,Price,TimeDuration,PV,CreatedDate,Tags,TrueName,CreatedUserID ");
            strSql.Append("FROM Tao_CourseModule TCM ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TCM.ModuleID ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=TM.CreatedUserID ");
            strSql.Append("WHERE TCM.CourseID =@CourseId ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        //new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = CourseId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int CloseCourse(int ModuleId, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Modules SET Status=@Status ");
            strSql.Append("WHERE ModuleID=@ModuleID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@Status",SqlDbType.Int),
                                        new SqlParameter("@ModuleID",SqlDbType.Int),
                                        };
            parameters[0].Value = Status;
            parameters[1].Value = ModuleId;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool UpdatePubCourseInfo(Maticsoft.Model.Tao.Modules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Modules set ");
            strSql.Append("ModuleName=@ModuleName,");
            strSql.Append("Description=@Description,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("Price=@Price,");
            strSql.Append("UpdatedDate=@UpdatedDate");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
                    new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Tags;
            parameters[3].Value = model.Price;
            parameters[4].Value = DateTime.Now;
            parameters[5].Value = model.ModuleID;

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

        public DataSet GetModuleInfo(int? cid, int? mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER()OVER ( ORDER BY Sequence ) AS RNum,* FROM ( ");
            strSql.Append("SELECT tm.ModuleID,ModuleName,tm.Price,tm.TimeDuration ,TrueName ,tm.Sequence,tcm.CourseID,CreatedUserID ");
            strSql.Append("FROM dbo.Tao_CourseModule tcm  ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tcm.ModuleID=tm.ModuleID ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON au.UserID=tm.CreatedUserID ");
            strSql.Append("WHERE CourseID=" + cid.Value);
            if (mid.HasValue)
            {
                strSql.Append(" AND tm.ModuleID=" + mid.Value);
            }
            strSql.Append(" )A");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal GetModulePrice(int mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Price FROM dbo.Tao_Modules ");
            strSql.Append("WHERE ModuleID=@mid");
            SqlParameter[] parameters = {
                                        new SqlParameter("@mid",SqlDbType.Int)
                                        };
            parameters[0].Value = mid;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0M;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        public DataSet GetModuleByCid(int Cid, int type, int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT tm.ModuleID,tm.ModuleName,tm.TimeDuration,tm.Price,tm.Tags,tm.CreatedDate,tcm.CourseID,tm.Sequence,tm.Description,tm.VideoContent,tm.Tags ");
            strSql.Append("FROM dbo.Tao_CourseModule tcm ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tcm.ModuleID=tm.ModuleID ");
            strSql.Append("WHERE CourseID=@cid AND tm.Type=@Type AND tm.CreatedUserID=@uid  ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@cid",SqlDbType.Int),
                                        new SqlParameter("@Type",SqlDbType.Int),
                                        new SqlParameter("@uid",SqlDbType.Int)
                                        };
            parameters[0].Value = Cid;
            parameters[1].Value = type;
            parameters[2].Value = uid;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int GetMaxModuleSeq(int cid, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(tm.Sequence)  ");
            strSql.Append("FROM dbo.Tao_CourseModule tcm ");
            strSql.Append("INNER JOIN dbo.Tao_Modules tm ON tcm.ModuleID = tm.ModuleID ");
            strSql.Append("WHERE CourseID=@cid AND tm.Type=@type ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@cid",SqlDbType.Int),
                                        new SqlParameter("@type",SqlDbType.Int)
                                        };
            parameters[0].Value = cid;
            parameters[1].Value = type;
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

        public bool DeleteModuleInfo(int cid, int mid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int),
                                        new SqlParameter("@Module",SqlDbType.Int)
                                        };
            parameters[0].Value = cid;
            parameters[1].Value = mid;
            DbHelperSQL.RunProcedure("sp_DeleModuleBuID", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetModuleInfo(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.Tao_Modules WHERE ModuleID IN( ");
            strSql.Append("SELECT TOP 1 ModuleID FROM dbo.Tao_CourseModule ");
            strSql.AppendFormat("WHERE CourseID ={0} ", courseId);
            strSql.Append("AND Status=3 ORDER BY ModuleIndex ASC) ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetCourseModuleList(int courseId, out int rowCount, out int pageCount, int? PageIndex, int? PageSize)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@CourseId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float)
                    };
            parameters[0].Value = courseId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfo", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            return ds;
        }
    }
}