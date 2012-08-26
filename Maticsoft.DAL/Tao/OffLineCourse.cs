/*----------------------------------------------------------------

// Copyright (C) 2012 动软卓越 版权所有。
//
// 文件名：OffLineCourse.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/07/20 11:56:54
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;//Please add references
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:OffLineCourse
    /// </summary>
    public partial class OffLineCourse
    {
        public OffLineCourse()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CourseID", "Tao_OffLineCourse");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_OffLineCourse");
            strSql.Append(" WHERE CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.OffLineCourse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Tao_OffLineCourse(");
            strSql.Append("CourseName,Description,CategoryId,StartTime,EndTime,TimeSpan,RegionID,Address,CoursePrice,Tags,ImageURL,LimitCount,Recommended,Latest,Hotsale,PV,AttentionCount,BookCount,CreatedUserID,CreatedDate,UpdatedDate,Status)");
            strSql.Append(" VALUES (");
            strSql.Append("@CourseName,@Description,@CategoryId,@StartTime,@EndTime,@TimeSpan,@RegionID,@Address,@CoursePrice,@Tags,@ImageURL,@LimitCount,@Recommended,@Latest,@Hotsale,@PV,@AttentionCount,@BookCount,@CreatedUserID,@CreatedDate,@UpdatedDate,@Status)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TimeSpan", SqlDbType.NVarChar,50),
					new SqlParameter("@RegionID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@CoursePrice", SqlDbType.Decimal,5),
					new SqlParameter("@Tags", SqlDbType.NVarChar,50),
					new SqlParameter("@ImageURL", SqlDbType.NVarChar,300),
					new SqlParameter("@LimitCount", SqlDbType.Int,4),
					new SqlParameter("@Recommended", SqlDbType.Bit,1),
					new SqlParameter("@Latest", SqlDbType.Bit,1),
					new SqlParameter("@Hotsale", SqlDbType.Bit,1),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@AttentionCount", SqlDbType.Int,4),
					new SqlParameter("@BookCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CategoryId;
            parameters[3].Value = model.StartTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.TimeSpan;
            parameters[6].Value = model.RegionID;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.CoursePrice;
            parameters[9].Value = model.Tags;
            parameters[10].Value = model.ImageURL;
            parameters[11].Value = model.LimitCount;
            parameters[12].Value = model.Recommended;
            parameters[13].Value = model.Latest;
            parameters[14].Value = model.Hotsale;
            parameters[15].Value = model.PV;
            parameters[16].Value = model.AttentionCount;
            parameters[17].Value = model.BookCount;
            parameters[18].Value = model.CreatedUserID;
            parameters[19].Value = model.CreatedDate;
            parameters[20].Value = model.UpdatedDate;
            parameters[21].Value = model.Status;

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
        public bool Update(Maticsoft.Model.Tao.OffLineCourse model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_OffLineCourse SET ");
            strSql.Append("CourseName=@CourseName,");
            strSql.Append("Description=@Description,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("TimeSpan=@TimeSpan,");
            strSql.Append("RegionID=@RegionID,");
            strSql.Append("Address=@Address,");
            strSql.Append("CoursePrice=@CoursePrice,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("ImageURL=@ImageURL,");
            strSql.Append("LimitCount=@LimitCount,");
            strSql.Append("Recommended=@Recommended,");
            strSql.Append("Latest=@Latest,");
            strSql.Append("Hotsale=@Hotsale,");
            strSql.Append("PV=@PV,");
            strSql.Append("AttentionCount=@AttentionCount,");
            strSql.Append("BookCount=@BookCount,");
            strSql.Append("CreatedUserID=@CreatedUserID,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("UpdatedDate=@UpdatedDate,");
            strSql.Append("Status=@Status");
            strSql.Append(" WHERE CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TimeSpan", SqlDbType.NVarChar,50),
					new SqlParameter("@RegionID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@CoursePrice", SqlDbType.Decimal,5),
					new SqlParameter("@Tags", SqlDbType.NVarChar,50),
					new SqlParameter("@ImageURL", SqlDbType.NVarChar,300),
					new SqlParameter("@LimitCount", SqlDbType.Int,4),
					new SqlParameter("@Recommended", SqlDbType.Bit,1),
					new SqlParameter("@Latest", SqlDbType.Bit,1),
					new SqlParameter("@Hotsale", SqlDbType.Bit,1),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@AttentionCount", SqlDbType.Int,4),
					new SqlParameter("@BookCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CategoryId;
            parameters[3].Value = model.StartTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.TimeSpan;
            parameters[6].Value = model.RegionID;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.CoursePrice;
            parameters[9].Value = model.Tags;
            parameters[10].Value = model.ImageURL;
            parameters[11].Value = model.LimitCount;
            parameters[12].Value = model.Recommended;
            parameters[13].Value = model.Latest;
            parameters[14].Value = model.Hotsale;
            parameters[15].Value = model.PV;
            parameters[16].Value = model.AttentionCount;
            parameters[17].Value = model.BookCount;
            parameters[18].Value = model.CreatedUserID;
            parameters[19].Value = model.CreatedDate;
            parameters[20].Value = model.UpdatedDate;
            parameters[21].Value = model.Status;
            parameters[22].Value = model.CourseID;

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
        public bool Delete(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Tao_OffLineCourse ");
            strSql.Append(" WHERE CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseID;

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
        public bool DeleteList(string CourseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Tao_OffLineCourse ");
            strSql.Append(" WHERE CourseID in (" + CourseIDlist + ")  ");
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
        /// 批量更新状态
        /// </summary>
        public bool UpdateList(string CourseIDlist, int Status)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(CourseIDlist))
            {
                strSql.Append("update Tao_OffLineCourse set Status=" + Status);
                strSql.Append(" where CourseID in (" + CourseIDlist + ")");

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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.OffLineCourse GetModel(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP 1 CourseID,CourseName,Description,CategoryId,StartTime,EndTime,TimeSpan,RegionID,Address,CoursePrice,Tags,ImageURL,LimitCount,Recommended,Latest,Hotsale,PV,AttentionCount,BookCount,CreatedUserID,CreatedDate,UpdatedDate,Status FROM Tao_OffLineCourse ");
            strSql.Append(" WHERE CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseID;

            Maticsoft.Model.Tao.OffLineCourse model = new Maticsoft.Model.Tao.OffLineCourse();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseName"] != null && ds.Tables[0].Rows[0]["CourseName"].ToString() != "")
                {
                    model.CourseName = ds.Tables[0].Rows[0]["CourseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"] != null && ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"] != null && ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TimeSpan"] != null && ds.Tables[0].Rows[0]["TimeSpan"].ToString() != "")
                {
                    model.TimeSpan = ds.Tables[0].Rows[0]["TimeSpan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegionID"] != null && ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = int.Parse(ds.Tables[0].Rows[0]["RegionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CoursePrice"] != null && ds.Tables[0].Rows[0]["CoursePrice"].ToString() != "")
                {
                    model.CoursePrice = decimal.Parse(ds.Tables[0].Rows[0]["CoursePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageURL"] != null && ds.Tables[0].Rows[0]["ImageURL"].ToString() != "")
                {
                    model.ImageURL = ds.Tables[0].Rows[0]["ImageURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LimitCount"] != null && ds.Tables[0].Rows[0]["LimitCount"].ToString() != "")
                {
                    model.LimitCount = int.Parse(ds.Tables[0].Rows[0]["LimitCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recommended"] != null && ds.Tables[0].Rows[0]["Recommended"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Recommended"].ToString() == "1") || (ds.Tables[0].Rows[0]["Recommended"].ToString().ToLower() == "true"))
                    {
                        model.Recommended = true;
                    }
                    else
                    {
                        model.Recommended = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Latest"] != null && ds.Tables[0].Rows[0]["Latest"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Latest"].ToString() == "1") || (ds.Tables[0].Rows[0]["Latest"].ToString().ToLower() == "true"))
                    {
                        model.Latest = true;
                    }
                    else
                    {
                        model.Latest = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Hotsale"] != null && ds.Tables[0].Rows[0]["Hotsale"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Hotsale"].ToString() == "1") || (ds.Tables[0].Rows[0]["Hotsale"].ToString().ToLower() == "true"))
                    {
                        model.Hotsale = true;
                    }
                    else
                    {
                        model.Hotsale = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PV"] != null && ds.Tables[0].Rows[0]["PV"].ToString() != "")
                {
                    model.PV = int.Parse(ds.Tables[0].Rows[0]["PV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AttentionCount"] != null && ds.Tables[0].Rows[0]["AttentionCount"].ToString() != "")
                {
                    model.AttentionCount = int.Parse(ds.Tables[0].Rows[0]["AttentionCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BookCount"] != null && ds.Tables[0].Rows[0]["BookCount"].ToString() != "")
                {
                    model.BookCount = int.Parse(ds.Tables[0].Rows[0]["BookCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedDate"] != null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append("SELECT CourseID,CourseName,Description,CategoryId,StartTime,EndTime,TimeSpan,RegionID,Address,CoursePrice,Tags,ImageURL,LimitCount,Recommended,Latest,Hotsale,PV,AttentionCount,BookCount,CreatedUserID,CreatedDate,UpdatedDate,Status ");
            strSql.Append(" FROM Tao_OffLineCourse ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" CourseID,CourseName,Description,CategoryId,StartTime,EndTime,TimeSpan,RegionID,Address,CoursePrice,Tags,ImageURL,LimitCount,Recommended,Latest,Hotsale,PV,AttentionCount,BookCount,CreatedUserID,CreatedDate,UpdatedDate,Status ");
            strSql.Append(" FROM Tao_OffLineCourse ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_OffLineCourse ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append("ORDER BY T.CourseID desc");
            }
            strSql.Append(")AS Row, T.*  FROM Tao_OffLineCourse T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
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
            parameters[0].Value = "Tao_OffLineCourse";
            parameters[1].Value = "CourseID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        public bool UpdateOffLineCourseStatus(int status, int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.Tao_OffLineCourse ");
            strSql.AppendFormat("SET Status={0} ", status);
            strSql.AppendFormat("WHERE CourseID={0} ", courseId);
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }

        public DataSet unPublishCourseInfo(int userID, int startIndex, int pageSize, int status)
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

        public int unPublishCount(int userId, int status)
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

        public bool DeleteCourseunApprove(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM dbo.Tao_OffLineCourse ");
            strSql.AppendFormat("WHERE CourseID={0}", courseId);
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 5 * ");
            strSql.Append(" FROM Tao_OffLineCourse ");
            strSql.Append(" WHERE Status=3  ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetOff()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.Tao_OffLineCourse ");
            strSql.Append("WHERE StartTime> GETDATE() ");
            strSql.Append("AND Status=3 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetIndexList(int pi, int ps, int uid, int type)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@ps",SqlDbType.Int),
                                        new SqlParameter("@UID",SqlDbType.Int),
                                        new SqlParameter("@Type",SqlDbType.Int)
                                        };
            parameters[0].Value = pi;
            parameters[1].Value = ps;
            parameters[2].Value = uid;
            parameters[3].Value = type;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CourseInfoForOffLine", parameters, "ds");
            return ds;
        }

        public int IndexListCount(int uid, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(*) ");
            strSql.Append("FROM    dbo.Tao_OffLineCourse   ");
            strSql.Append("WHERE Status=3 AND CreatedUserID= " + uid);
            if (type == 1)
            {
                strSql.Append(" AND StartTime >= GETDATE() ");
            }
            else
            {
                strSql.Append(" AND StartTime < GETDATE() ");
            }

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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.SearchCourse> GetListByCateId(out int rowCount, out int pageCount, int CateId, int? PageIndex, int? PageSize, int OrderType, string TimeStr)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@CateId", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@OrderType", SqlDbType.Int),
                    new SqlParameter("@TimeStr", SqlDbType.NVarChar)
                    };
            parameters[0].Value = CateId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = OrderType;
            parameters[6].Value = TimeStr;
            DataSet ds = DbHelperSQL.RunProcedure("sp_SearchOffLineCourseListByCateID", parameters, "ds");
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
                    if (dt.Rows[n]["StartTime"] != null && dt.Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = Convert.ToDateTime(dt.Rows[n]["StartTime"]);
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.Imageurl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.Createduserid = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["CoursePrice"] != null && dt.Rows[n]["CoursePrice"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["CoursePrice"].ToString());
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.Pv = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["BookCount"] != null && dt.Rows[n]["BookCount"].ToString() != "")
                    {
                        model.Pv = int.Parse(dt.Rows[n]["BookCount"].ToString());
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
    }
}