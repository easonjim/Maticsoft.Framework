using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Courses
    {
        /// <summary>
        /// 添加新的课程信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCourse(Model.Tao.Courses model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@CourseName", SqlDbType.VarChar,300),
                    new SqlParameter("@Description", SqlDbType.NVarChar),
                    new SqlParameter("@ShortDescription", SqlDbType.NVarChar,1000),
                    new SqlParameter("@CategoryId", SqlDbType.Int),
                    new SqlParameter("@TimeDuration", SqlDbType.Int),
                    new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@Tags", SqlDbType.NVarChar,300),
                    new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
                    new SqlParameter("@Type", SqlDbType.Int),
                    new SqlParameter("@VideoContent", SqlDbType.VarChar,300),
                    new SqlParameter("@CreatedUserID", SqlDbType.Int),
                    new SqlParameter("@Recommended", SqlDbType.Bit),
                    new SqlParameter("@Latest", SqlDbType.Bit),
                    new SqlParameter("@Hotsale", SqlDbType.Bit),
                    new SqlParameter("@SpecialOffer", SqlDbType.Bit),
                    new SqlParameter("@Price", SqlDbType.Int),
                    new SqlParameter("@Sequence", SqlDbType.Int),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,300),
                    new SqlParameter("@ModuleNum", SqlDbType.Int),
                    new SqlParameter("@CourseTypes", SqlDbType.Int)
                    };
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.CategoryId.Value;
            parameters[4].Value = model.TimeDuration.Value;
            parameters[5].Value = model.ExpiryDate;
            parameters[6].Value = model.Status.Value;
            parameters[7].Value = model.Tags;
            parameters[8].Value = model.ImageUrl;
            parameters[9].Value = model.Type.Value;
            parameters[10].Value = model.VideoContent;
            parameters[11].Value = model.CreatedUserID.Value;
            parameters[12].Value = model.Recommended;
            parameters[13].Value = model.Latest.Value;
            parameters[14].Value = model.Hotsale.Value;
            parameters[15].Value = model.SpecialOffer.Value;
            parameters[16].Value = model.Price.Value;
            parameters[17].Value = model.Sequence.Value;
            parameters[18].Value = model.Attachment;
            parameters[19].Value = model.ModuleNum.Value;
            parameters[20].Value = model.CourseTypes.Value;
            return DbHelperSQL.RunProcedure("sp_cc_Course_Create", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除数据表中的URL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateAttachUrl(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses SET Attachment=''  ");
            strSql.Append("WHERE CourseID= " + id);
            int revs = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (revs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据CourseID得到CourseName
        /// </summary>
        public Model.Tao.Courses GetCourseName(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CourseName  ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE CourseID=@CourseID ");

            SqlParameter[] parameters = {
                    new SqlParameter("@CourseID", SqlDbType.Int,4)
};
            parameters[0].Value = CourseID;

            Model.Tao.Courses model = new Model.Tao.Courses();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CourseName"] != null && ds.Tables[0].Rows[0]["CourseName"].ToString() != "")
                {
                    model.CourseName = ds.Tables[0].Rows[0]["CourseName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

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
        /// 更新课程的发布价格和课程时效
        /// </summary>
        public int UPdateCoursePrice(Model.Tao.Courses model)
        {
            StringBuilder strSql = new StringBuilder();//[UpdatedDate]
            strSql.Append("UPDATE Tao_Courses  ");
            strSql.Append("SET CourseSpan=@CourseSpan,ExpiryDate=@ExpiryDate,ViewCount=@ViewCount,UpdatedDate=@UpdatedDate,Price=@Price  ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseSpan",SqlDbType.Int),
                                        new SqlParameter("@ExpiryDate",SqlDbType.DateTime),
                                        new SqlParameter("@ViewCount",SqlDbType.Int),
                                        new SqlParameter("@CourseID",SqlDbType.Int),
                                        new SqlParameter("@UpdatedDate",SqlDbType.DateTime),
                                        new SqlParameter("@Price",SqlDbType.Decimal)
                                        };
            parameters[0].Value = model.CourseSpan;
            parameters[1].Value = model.ExpiryDate;
            parameters[2].Value = model.ViewCount;
            parameters[3].Value = model.CourseID;
            parameters[4].Value = model.UpdatedDate;
            parameters[5].Value = model.Price;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 发布课程
        /// </summary>
        public int PublishCourse(int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            DbHelperSQL.RunProcedure("sp_PublishCourse", parameters, out rowsAffected);
            return rowsAffected;
        }

        public int PubCourse(int courseId, int status)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            parameters[1].Value = status;
            DbHelperSQL.RunProcedure("sp_PubCours", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 修改课程缩略图
        /// </summary>
        /// <param name="courseId">课程ID</param>
        /// <returns></returns>
        public bool EditCourseThumbnai(Model.Tao.Courses modle)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses  ");
            strSql.Append("SET ImageUrl=@ImageUrl,UpdatedDate=GETDATE() ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int),
                                        new SqlParameter("@ImageUrl",SqlDbType.VarChar,300)
                                        };
            parameters[0].Value = modle.CourseID;
            parameters[1].Value = modle.ImageUrl;
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

        /// <summary>
        /// 课程信息列表
        /// </summary>
        /// <param name="CateId">课程分类ID</param>
        /// <param name="Orderstr">排序条件</param>
        /// <returns></returns>
        public DataSet GetCourseList(int CateId, string Orderstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CourseID,CourseName,TimeDuration,SalesVolume,Price,ImageUrl  ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE Status = 1");
            if (CateId != -1)
            {
                strSql.Append("AND CategoryId = " + CateId);
            }
            if (!string.IsNullOrEmpty(Orderstr))
            {
                strSql.Append("ORDER BY " + Orderstr + " DESC ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得CateID获得记录数
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public int GetRecordCount(int cateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_Courses ");
            strSql.Append("WHERE Status = 1 ");
            if (cateId > 0)
            {
                strSql.Append(" AND CategoryId=" + cateId);
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
        /// 获取分页数据信息
        /// </summary>
        /// <param name="WhereStr">查询条件</param>
        /// <param name="OrderStr">排序规则</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="RowCount">总行数</param>
        /// <param name="PageCount">总页数</param>
        /// <returns></returns>
        public DataSet GetPageRecord(string WhereStr, string OrderStr, int pageIndex, out int RowCount, out int PageCount)
        {
            RowCount = 0;
            PageCount = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@tn",SqlDbType.NVarChar),
                                        new SqlParameter("@idn",SqlDbType.NVarChar),
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@wh",SqlDbType.NVarChar),
                                        new SqlParameter("@oby",SqlDbType.NVarChar),
                                        new SqlParameter("@rc",SqlDbType.Int),
                                        new SqlParameter("@pc",SqlDbType.Int)
                                        };
            parameters[0].Value = "Tao_Courses";
            parameters[1].Value = "CourseID";
            parameters[2].Value = pageIndex;
            parameters[3].Value = 3;
            parameters[4].Value = WhereStr;
            parameters[5].Value = OrderStr;
            parameters[6].Direction = ParameterDirection.Output;
            parameters[7].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_cc_GetPageDataO", parameters, "ds");
            RowCount = Convert.ToInt32(parameters[6].Value);
            PageCount = Convert.ToInt32(parameters[7].Value);
            return ds;
        }

        /// <summary>
        /// 得到分页数据源
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSinglePageRecord(int startIndex, int endIndex)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@startIndex",SqlDbType.Int),
                                        new SqlParameter("@endIndex",SqlDbType.Int),
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            DataSet ds = DbHelperSQL.RunProcedure("sp_cc_GetPagedData", parameters, "ds");
            return ds;
        }

        #region 获得已开课程的数量、结果集

        /// <summary>
        /// 获得已开课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int PublishCourseCount(int userID, int status, int ctypes)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT COUNT( TC.CreatedUserID)  ");
            //strSql.Append("FROM Tao_CourseModule TCM  ");
            //strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TCM.CourseID  ");
            //strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TCM.ModuleID  ");
            //strSql.Append("WHERE TC.Status=3 AND TCM.Status=2 AND TC.CreatedUserID=@UserID ");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE Status=@Status AND CourseTypes=@CTypes  AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int),
                                        new SqlParameter("@CTypes",SqlDbType.Int)
                                        };
            parameters[0].Value = userID;
            parameters[1].Value = status;
            parameters[2].Value = ctypes;
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
        /// 获得线下课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int PublishOfflineCourseCount(int userID, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) ");
            strSql.Append("FROM Tao_OffLineCourse ");
            strSql.Append("WHERE Status=@Status  AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = userID;
            parameters[1].Value = status;
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
        /// 得到已开课程信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="startIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="RowCount">总行数</param>
        /// <returns></returns>
        public DataSet GetPubLishCourse(int userID, int startIndex, int pageSize, int Status, int Ctypes)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int),
                                        new SqlParameter("@CTypes",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = userID;
            parameters[3].Value = Status;
            parameters[4].Value = Ctypes;

            DataSet ds = DbHelperSQL.RunProcedure("sp_PublishCourseDetail", parameters, "ds");
            return ds;
        }

        /// <summary>
        /// 得到已开课程信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="startIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="RowCount">总行数</param>
        /// <returns></returns>
        public DataSet GetPubLishOffLineCourse(int userID, int startIndex, int pageSize, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY CreatedDate desc) AS RNum,* FROM  ");
            strSql.Append("(SELECT CourseID,CourseName,ImageUrl,CreatedDate,CASE WHEN CoursePrice IS NULL THEN 0 ELSE CoursePrice END AS CoursePrice,BookCount  ");
            strSql.Append("FROM Tao_OffLineCourse ");
            strSql.Append("WHERE Status=@Status AND CreatedUserID=@UserID )A )AS TEMP	 ");
            strSql.Append("WHERE RNum  BETWEEN @pi and @pi+@ps-1");
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = userID;
            parameters[3].Value = Status;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        #endregion 获得已开课程的数量、结果集

        #region 获得未发布课程信息、未审核课程信息

        /// <summary>
        /// 获取所有未发布、未审核课程的数量
        /// </summary>
        public int unPubCourseCount(int userId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM Tao_Courses ");
            strSql.Append("WHERE CourseTypes=0 AND Status=@Status AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@Status",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = status;
            parameters[1].Value = userId;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 根据ID获取为完成的课程
        /// </summary>
        public DataSet UnPubCourse(int userID, int startIndex, int pageSize, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY CreatedUserID) AS RNum,*  ");
            strSql.Append("FROM (SELECT CreatedUserID,CourseID,CourseName,ImageUrl  ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE CourseTypes=0 AND Status=@Status AND CreatedUserID=@UserID)A ) AS TEMP	 ");
            strSql.Append("WHERE RNum  BETWEEN @startIndex and @startIndex+@pageSize-1");
            SqlParameter[] parameters ={
                                      new SqlParameter("@UserID",SqlDbType.Int),
                                      new SqlParameter("@startIndex",SqlDbType.Int),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@Status",SqlDbType.Int),
                                      };
            parameters[0].Value = userID;
            parameters[1].Value = startIndex;
            parameters[2].Value = pageSize;
            parameters[3].Value = status;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion 获得未发布课程信息、未审核课程信息

        /// <summary>
        /// 根据课程的状态、类别得到不同的结果集
        /// </summary>
        public DataSet PublishCourseInfo(Model.Tao.Courses model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP(4) CreatedUserID,CourseID,CourseName,ImageUrl ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE CreatedUserID=" + model.CreatedUserID);
            if (model.Status.HasValue)
            {
                strSql.Append(" AND Status=" + model.Status);
            }
            if (model.CourseTypes.HasValue)
            {
                strSql.Append(" AND CourseTypes=" + model.CourseTypes);
            }
            strSql.Append(" ORDER BY CreatedDate DESC ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetOrgCourse(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CourseID,CourseName,ShortDescription,ImageUrl,Price  ");
            strSql.Append("FROM Tao_Courses  ");
            strSql.Append("WHERE CreatedUserID=@UserId AND CourseTypes=1 AND Status=0  ");
            strSql.Append("ORDER BY CourseID DESC ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public bool updateOrgCourse(Model.Tao.Courses model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses ");
            strSql.Append("SET CourseName=@CourseName,ShortDescription=@ShortDescription,CategoryId=@CategoryId, ");
            strSql.Append("Tags=@Tags,Price=@Price,UpdatedDate=@UpdatedDate ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseName",SqlDbType.VarChar),
                                        new SqlParameter("@ShortDescription",SqlDbType.NVarChar),
                                        new SqlParameter("@CategoryId",SqlDbType.Int),
                                        new SqlParameter("@Tags",SqlDbType.NVarChar),
                                        new SqlParameter("@Price",SqlDbType.Money),
                                        new SqlParameter("@UpdatedDate",SqlDbType.DateTime),
                                        new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.ShortDescription;
            parameters[2].Value = model.CategoryId;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Price;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = model.CourseID;
            if (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int changeCourseType(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses SET CourseTypes=1  ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public int getModelCount(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1)  ");
            strSql.Append("FROM Tao_CourseModule TCM ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TCM.ModuleID=TM.ModuleID ");
            strSql.Append("WHERE CourseID =@CourseID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int unOffLinePublishCount(int userId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) ");
            strSql.Append("FROM Tao_OffLineCourse ");
            strSql.Append("WHERE Status=@Status AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            parameters[1].Value = status;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int unPublishCount(int userId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE Status=@Status AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            parameters[1].Value = status;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public DataSet unPublishCourseInfo(int userID, int startIndex, int pageSize, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY UpdatedDate desc) AS RNum,* FROM ( ");
            strSql.Append("SELECT CourseID,CourseName,Price,CreatedDate,UpdatedDate,ImageUrl ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE Status=@Status AND CreatedUserID=@UserID) ");
            strSql.Append("A )AS TEMP	WHERE RNum  BETWEEN @pi AND @pi+@ps-1 ");

            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = userID;
            parameters[3].Value = status;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet unPublishOfflineCourseInfo(int userID, int startIndex, int pageSize, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY UpdatedDate desc) AS RNum,* FROM ( ");
            strSql.Append("SELECT CourseID,CourseName,CoursePrice,CreatedDate,UpdatedDate,ImageUrl,BookCount ");
            strSql.Append("FROM Tao_OffLineCourse ");
            strSql.Append("WHERE Status=@Status AND CreatedUserID=@UserID) ");
            strSql.Append("A )AS TEMP	WHERE RNum  BETWEEN @pi AND @pi+@ps-1 ");

            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Status",SqlDbType.Int)
                                        };
            parameters[0].Value = startIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = userID;
            parameters[3].Value = status;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int DeleteCourseunApprove(int courseId)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            DbHelperSQL.RunProcedure("sp_DeleteCourseUnApprove", parameters, out rowsAffected);
            return rowsAffected;
        }

        public bool UpdateModuleCount(int courseId, int ModuleCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_Courses SET ModuleNum=@ModuleNum,UpdatedDate=GETDATE() ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleNum",SqlDbType.Int),
                                         new SqlParameter("@CourseID",SqlDbType.Int)
                                        };
            parameters[0].Value = ModuleCount;
            parameters[1].Value = courseId;
            int i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateModuleCount(int courseId, int ModuleCount, int Time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @timedur INT  ");
            strSql.Append("SELECT  @timedur = TimeDuration ");
            strSql.Append("FROM dbo.Tao_Courses ");
            strSql.Append("WHERE CourseID = @CourseID ");
            strSql.Append("IF ( @timedur > 0 ) UPDATE  dbo.Tao_Courses SET ModuleNum = @ModuleNum , TimeDuration = @timedur + @ts WHERE   CourseID = @CourseID ");
            strSql.Append("ELSE UPDATE  dbo.Tao_Courses SET ModuleNum = 1 , TimeDuration = @ts  WHERE CourseID = @CourseID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleNum",SqlDbType.Int),
                                         new SqlParameter("@CourseID",SqlDbType.Int),
                                         new SqlParameter("@ts",SqlDbType.Int)
                                        };
            parameters[0].Value = ModuleCount;
            parameters[1].Value = courseId;
            parameters[2].Value = Time;
            int i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int orgCourseCount(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1)FROM ( ");
            strSql.Append("SELECT TC.CourseID FROM Tao_CourseModule TCM ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TCM.ModuleID=TM.ModuleID ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TCM.CourseID ");
            strSql.Append("WHERE TM.CreatedUserID=@userId  AND TC.CreatedUserID <>@userId  GROUP BY TC.CourseID )A ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@userId",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
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

        public DataSet getOrgCourseInfo(int startindex, int pagesize, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY UpdatedDate desc) AS RNum,* FROM( ");
            strSql.Append("SELECT CourseID,CourseName,ImageUrl,ShortDescription,Price,UpdatedDate,Status,CreatedUserID,TrueName   ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=CreatedUserID ");
            strSql.Append("WHERE CourseID IN (");
            strSql.Append("	SELECT TC.CourseID FROM Tao_CourseModule TCM ");
            strSql.Append("	LEFT JOIN Tao_Modules TM ON TCM.ModuleID=TM.ModuleID ");
            strSql.Append("	LEFT JOIN Tao_Courses TC ON TC.CourseID=TCM.CourseID ");
            strSql.Append("	WHERE TM.CreatedUserID=@UserId AND TC.CreatedUserID <>@UserId GROUP BY TC.CourseID  ");
            strSql.Append(") )A )AS TEMP	WHERE RNum  BETWEEN @si AND @si+@pi-1 ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@si",SqlDbType.Int),
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = startindex;
            parameters[1].Value = pagesize;
            parameters[2].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetUserNameByCourseId(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TrueName ");
            strSql.Append("FROM    dbo.Accounts_Users ");
            strSql.Append("WHERE   UserID IN ( ");
            strSql.Append("SELECT DISTINCT ( tm.CreatedUserID ) ");
            strSql.Append("FROM    dbo.Tao_CourseModule tcm ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tcm.ModuleID = tm.ModuleID ");
            strSql.Append("WHERE   CourseID =@CourseId ) ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = courseId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public bool UpdataCourseTime(int cid, int time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE  dbo.Tao_Courses ");
            strSql.Append("SET     TimeDuration = @TimeDuration ");
            strSql.Append("WHERE CourseID=@CourseID ");
            SqlParameter[] para = {
                                  new SqlParameter("@TimeDuration",SqlDbType.Int),
                                  new SqlParameter("@CourseID",SqlDbType.Int)
                                  };
            para[0].Value = time;
            para[1].Value = cid;
            int res = DbHelperSQL.ExecuteSql(strSql.ToString(), para);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdataCourseStatus(int cid)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            parameters[0].Value = cid;
            DbHelperSQL.RunProcedure("sp_UpdataCourseStatus", parameters, out rowsAffected);
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
        /// 首页推荐课程
        /// </summary>
        public DataSet GetRecommendedCourse(int? topSum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (topSum.HasValue)
            {
                strSql.Append(" TOP " + topSum.Value);
            }
            strSql.Append(" CourseID,CourseName,TimeDuration,Price,PV,tc.CreatedUserID,ImageUrl,au.TrueName,au.DepartmentID,te.Name,CategoryId ");
            strSql.Append("FROM    dbo.Tao_Courses  tc ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON tc.CreatedUserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON au.DepartmentID=te.EnterpriseID ");
            strSql.Append("WHERE Recommended=1 and tc.status=3 ORDER BY PV DESC  ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetIndexList(int pi, int ps, int cateId)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@ParentCateId",SqlDbType.Int)
                                        };
            parameters[0].Value = pi;
            parameters[1].Value = ps;
            parameters[2].Value = cateId;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfoForIndex", parameters, "ds");
            return ds;
        }

        public int IndexListCount(int cateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(*) ");
            strSql.Append("FROM    dbo.Tao_Courses  tc ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON tc.CreatedUserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON au.DepartmentID=te.EnterpriseID ");
            strSql.Append("LEFT JOIN (SELECT (SELECT dbo.Get_StrArrayStrOfIndex(Path,'|',1))AS parentId,CategoryId  FROM dbo.Tao_Categories WHERE CategoryId IN( ");
            strSql.Append("SELECT CategoryId FROM dbo.Tao_Courses)) A ON tc.CategoryId=a.CategoryId ");
            strSql.Append("WHERE tc.Status=3 AND parentId= " + cateId);

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public DataSet GetHotCourse(string andStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER ( ORDER BY PV DESC ) AS RNum,*FROM ( ");
            strSql.Append("SELECT TOP 10 CourseID,CourseName,PV,UpdatedDate ");
            strSql.Append("FROM    dbo.Tao_Courses ");
            strSql.Append("WHERE   Status = 3  ");
            if (andStr.Equals("D"))
            {
                strSql.Append("  ");
            }
            else if (andStr.Equals("W"))
            {
                strSql.Append(" AND  DATEDIFF(D,UpdatedDate,GETDATE()) <=7 ");
            }
            else
            {
                strSql.Append(" AND  DATEDIFF(D,UpdatedDate,GETDATE()) <=30 ");
            }
            strSql.Append(" ORDER BY PV DESC");
            strSql.Append(")A ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetLastCourse(int pi)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER() OVER ( ORDER BY CreatedDate DESC ) AS RNum,*FROM ( ");
            strSql.Append("SELECT TOP 5  CourseID,CourseName,TimeDuration,Price,PV,tc.CreatedUserID,ImageUrl,au.TrueName,au.DepartmentID,te.Name,tc.CreatedDate ");
            strSql.Append("FROM    dbo.Tao_Courses  tc ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON tc.CreatedUserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON au.DepartmentID=te.EnterpriseID WHERE tc.Status=3 ");
            strSql.Append("ORDER BY tc.CreatedDate DESC )A) AS TEMP ");
            strSql.Append("WHERE   RNum BETWEEN " + pi + " AND 5 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public static int GetUploadType(int cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP 1 tm.Type ");
            strSql.Append("FROM    dbo.Tao_CourseModule tcm ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tm.ModuleID=tcm.ModuleID ");
            strSql.Append("WHERE   CourseID =  " + cid);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 首页推荐课程
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetRecommendedCourseList(int? topSum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (topSum.HasValue)
            {
                strSql.Append(" TOP " + topSum.Value);
            }
            strSql.Append(" CourseID,CourseName,TimeDuration,Price,PV,tc.CreatedUserID,ImageUrl,au.TrueName,au.DepartmentID,te.Name,CategoryId ");
            strSql.Append("FROM    dbo.Tao_Courses  tc ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON tc.CreatedUserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON au.DepartmentID=te.EnterpriseID ");
            strSql.Append("WHERE Recommended=1 and tc.status=3 ORDER BY PV DESC  ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, bool topNum)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentCateId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@TopNum", SqlDbType.Bit)
                    };
            parameters[0].Value = CateId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = topNum;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfoForAjaxIndex", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@CateId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@OrderType", SqlDbType.Int),
                    new SqlParameter("@TimeStr", SqlDbType.NVarChar),
                    new SqlParameter("@CourseType", SqlDbType.Int)
                    };
            parameters[0].Value = CateId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = OrderType;
            parameters[6].Value = TimeStr;
            parameters[7].Value = CourseType;
            DataSet ds = DbHelperSQL.RunProcedure("sp_SearchCourseListByCateID", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByuserID(out int rowCount, out int pageCount, int Uid, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@OrderType", SqlDbType.Int),
                    new SqlParameter("@TimeStr", SqlDbType.NVarChar),
                    new SqlParameter("@CourseType", SqlDbType.Int)
                    };
            parameters[0].Value = Uid;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = OrderType;
            parameters[6].Value = TimeStr;
            parameters[7].Value = CourseType;
            DataSet ds = DbHelperSQL.RunProcedure("sp_SearchCourseListByUID", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByKEY(out int rowCount, out int pageCount, string keyStr, int? PageIndex, int? PageSize, int OrderType, string TimeStr, int CourseType, int? dpt)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@KeyStr", SqlDbType.NVarChar),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@OrderType", SqlDbType.Int),
                    new SqlParameter("@TimeStr", SqlDbType.NVarChar),
                    new SqlParameter("@CourseType", SqlDbType.Int),
                    new SqlParameter("@DepartmentID", SqlDbType.Int)
                    };
            parameters[0].Value = keyStr;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = OrderType;
            parameters[6].Value = TimeStr;
            parameters[7].Value = CourseType;
            parameters[8].Value = dpt;
            DataSet ds = DbHelperSQL.RunProcedure("sp_SearchCourseListByKey", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.SearchCourse> modelList = new List<Maticsoft.Model.Tao.SearchCourse>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.SearchCourse model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.SearchCourse();
                    if (dt.Rows[n]["CourseID"] != null && dt.Rows[n]["CourseID"].ToString() != "")
                    {
                        model.Courseid = int.Parse(dt.Rows[n]["CourseID"].ToString());
                    }
                    if (dt.Rows[n]["CourseName"] != null && dt.Rows[n]["CourseName"].ToString() != "")
                    {
                        model.Coursename = dt.Rows[n]["CourseName"].ToString();
                    }
                    if (dt.Rows[n]["CategoryId"] != null && dt.Rows[n]["CategoryId"].ToString() != "")
                    {
                        model.CategoryId = int.Parse(dt.Rows[n]["CategoryId"].ToString());
                    }
                    if (dt.Rows[n]["TimeDuration"] != null && dt.Rows[n]["TimeDuration"].ToString() != "")
                    {
                        model.Timeduration = int.Parse(dt.Rows[n]["TimeDuration"].ToString());
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.Imageurl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.Createduserid = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.Pv = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.EnterName = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentId = dt.Rows[n]["DepartmentID"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得相关课程信息
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentCateId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float)
                    };
            parameters[0].Value = CateId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfoForVideoShow", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据教师获得相关课程信息
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByTeacherID(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float)
                    };
            parameters[0].Value = CateId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfoForAjaxTeacher", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        public int GetPubSourse(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM dbo.Tao_Courses  ");
            strSql.AppendFormat("WHERE CreatedUserID={0} AND Status=3 ", uid);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
                return Convert.ToInt32(obj.ToString());
            else
                return 0;
        }

        public int GetSellCourseNum(int couresid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM ( ");
            strSql.Append("SELECT  CourseID,OrderID FROM dbo.Tao_OrderItems ");
            strSql.AppendFormat("WHERE CourseID={0} AND OrderID IN(SELECT OrderID FROM dbo.Tao_Orders  ", couresid);
            strSql.Append("WHERE Status=1) GROUP BY OrderID,CourseID)A ");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
                return Convert.ToInt32(obj.ToString());
            else
                return 0;
        }

        public int GetTeacherCount(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT( DISTINCT CreatedUserID ) FROM dbo.Tao_Modules ");
            strSql.AppendFormat("WHERE ModuleID IN(SELECT ModuleID FROM dbo.Tao_CourseModule WHERE CourseID={0}) ", courseId);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
                return Convert.ToInt32(obj);
            return 0;
        }

        /// <summary>
        /// 获得已开课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int PublishCourseCount(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) ");
            strSql.Append("FROM Tao_Courses ");
            strSql.Append("WHERE Status=3  AND CreatedUserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = userID;
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
    }
}