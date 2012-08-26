using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Courses
    /// </summary>
    public partial class Courses
    {
        public Courses()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CourseID", "Tao_Courses");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Courses");
            strSql.Append(" where CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
};
            parameters[0].Value = CourseID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Courses model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Courses(");
            strSql.Append("CourseName,Description,ShortDescription,CategoryId,TimeDuration,CourseSpan,ExpiryDate,ViewCount,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Recommended,Latest,Hotsale,SpecialOffer,Price,PV,SalesVolume,Sequence,Attachment,ModuleNum,UpdatedDate,CourseTypes)");
            strSql.Append(" values (");
            strSql.Append("@CourseName,@Description,@ShortDescription,@CategoryId,@TimeDuration,@CourseSpan,@ExpiryDate,@ViewCount,@Status,@Tags,@ImageUrl,@Type,@VideoContent,@CreatedDate,@CreatedUserID,@Recommended,@Latest,@Hotsale,@SpecialOffer,@Price,@PV,@SalesVolume,@Sequence,@Attachment,@ModuleNum,@UpdatedDate,@CourseTypes)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.VarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@ShortDescription", SqlDbType.Text),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@TimeDuration", SqlDbType.Int,4),
					new SqlParameter("@CourseSpan", SqlDbType.Int,4),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@VideoContent", SqlDbType.VarChar,300),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@Recommended", SqlDbType.Bit,1),
					new SqlParameter("@Latest", SqlDbType.Bit,1),
					new SqlParameter("@Hotsale", SqlDbType.Bit,1),
					new SqlParameter("@SpecialOffer", SqlDbType.Bit,1),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@SalesVolume", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,300),
					new SqlParameter("@ModuleNum", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CourseTypes", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.CategoryId;
            parameters[4].Value = model.TimeDuration;
            parameters[5].Value = model.CourseSpan;
            parameters[6].Value = model.ExpiryDate;
            parameters[7].Value = model.ViewCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Tags;
            parameters[10].Value = model.ImageUrl;
            parameters[11].Value = model.Type;
            parameters[12].Value = model.VideoContent;
            parameters[13].Value = model.CreatedDate;
            parameters[14].Value = model.CreatedUserID;
            parameters[15].Value = model.Recommended;
            parameters[16].Value = model.Latest;
            parameters[17].Value = model.Hotsale;
            parameters[18].Value = model.SpecialOffer;
            parameters[19].Value = model.Price;
            parameters[20].Value = model.PV;
            parameters[21].Value = model.SalesVolume;
            parameters[22].Value = model.Sequence;
            parameters[23].Value = model.Attachment;
            parameters[24].Value = model.ModuleNum;
            parameters[25].Value = model.UpdatedDate;
            parameters[26].Value = model.CourseTypes;

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
        public bool Update(Maticsoft.Model.Tao.Courses model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Courses set ");
            strSql.Append("CourseName=@CourseName,");
            strSql.Append("Description=@Description,");
            strSql.Append("ShortDescription=@ShortDescription,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("TimeDuration=@TimeDuration,");
            strSql.Append("CourseSpan=@CourseSpan,");
            strSql.Append("ExpiryDate=@ExpiryDate,");
            strSql.Append("ViewCount=@ViewCount,");
            strSql.Append("Status=@Status,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("Type=@Type,");
            strSql.Append("VideoContent=@VideoContent,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("CreatedUserID=@CreatedUserID,");
            strSql.Append("Recommended=@Recommended,");
            strSql.Append("Latest=@Latest,");
            strSql.Append("Hotsale=@Hotsale,");
            strSql.Append("SpecialOffer=@SpecialOffer,");
            strSql.Append("Price=@Price,");
            strSql.Append("PV=@PV,");
            strSql.Append("SalesVolume=@SalesVolume,");
            strSql.Append("Sequence=@Sequence,");
            strSql.Append("Attachment=@Attachment,");
            strSql.Append("ModuleNum=@ModuleNum,");
            strSql.Append("UpdatedDate=@UpdatedDate,");
            strSql.Append("CourseTypes=@CourseTypes");
            strSql.Append(" where CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.VarChar,300),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@ShortDescription", SqlDbType.Text),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@TimeDuration", SqlDbType.Int,4),
					new SqlParameter("@CourseSpan", SqlDbType.Int,4),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@VideoContent", SqlDbType.VarChar,300),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
					new SqlParameter("@Recommended", SqlDbType.Bit,1),
					new SqlParameter("@Latest", SqlDbType.Bit,1),
					new SqlParameter("@Hotsale", SqlDbType.Bit,1),
					new SqlParameter("@SpecialOffer", SqlDbType.Bit,1),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@SalesVolume", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,300),
					new SqlParameter("@ModuleNum", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CourseTypes", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.CategoryId;
            parameters[4].Value = model.TimeDuration;
            parameters[5].Value = model.CourseSpan;
            parameters[6].Value = model.ExpiryDate;
            parameters[7].Value = model.ViewCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Tags;
            parameters[10].Value = model.ImageUrl;
            parameters[11].Value = model.Type;
            parameters[12].Value = model.VideoContent;
            parameters[13].Value = model.CreatedDate;
            parameters[14].Value = model.CreatedUserID;
            parameters[15].Value = model.Recommended;
            parameters[16].Value = model.Latest;
            parameters[17].Value = model.Hotsale;
            parameters[18].Value = model.SpecialOffer;
            parameters[19].Value = model.Price;
            parameters[20].Value = model.PV;
            parameters[21].Value = model.SalesVolume;
            parameters[22].Value = model.Sequence;
            parameters[23].Value = model.Attachment;
            parameters[24].Value = model.ModuleNum;
            parameters[25].Value = model.UpdatedDate;
            parameters[26].Value = model.CourseTypes;
            parameters[27].Value = model.CourseID;

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
            strSql.Append("delete from Tao_Courses ");
            strSql.Append(" where CourseID=@CourseID");
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
            strSql.Append("delete from Tao_Courses ");
            strSql.Append(" where CourseID in (" + CourseIDlist + ")  ");
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
        public Maticsoft.Model.Tao.Courses GetModel(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CourseID,CourseName,Description,ShortDescription,CategoryId,TimeDuration,CourseSpan,ExpiryDate,ViewCount,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Recommended,Latest,Hotsale,SpecialOffer,Price,PV,SalesVolume,Sequence,Attachment,ModuleNum,UpdatedDate,CourseTypes from Tao_Courses ");
            strSql.Append(" where CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)};
            parameters[0].Value = CourseID;

            Maticsoft.Model.Tao.Courses model = new Maticsoft.Model.Tao.Courses();
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
                if (ds.Tables[0].Rows[0]["ShortDescription"] != null && ds.Tables[0].Rows[0]["ShortDescription"].ToString() != "")
                {
                    model.ShortDescription = ds.Tables[0].Rows[0]["ShortDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TimeDuration"] != null && ds.Tables[0].Rows[0]["TimeDuration"].ToString() != "")
                {
                    model.TimeDuration = int.Parse(ds.Tables[0].Rows[0]["TimeDuration"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseSpan"] != null && ds.Tables[0].Rows[0]["CourseSpan"].ToString() != "")
                {
                    model.CourseSpan = int.Parse(ds.Tables[0].Rows[0]["CourseSpan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpiryDate"] != null && ds.Tables[0].Rows[0]["ExpiryDate"].ToString() != "")
                {
                    model.ExpiryDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpiryDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ViewCount"] != null && ds.Tables[0].Rows[0]["ViewCount"].ToString() != "")
                {
                    model.ViewCount = int.Parse(ds.Tables[0].Rows[0]["ViewCount"].ToString());
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
                if (ds.Tables[0].Rows[0]["SpecialOffer"] != null && ds.Tables[0].Rows[0]["SpecialOffer"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["SpecialOffer"].ToString() == "1") || (ds.Tables[0].Rows[0]["SpecialOffer"].ToString().ToLower() == "true"))
                    {
                        model.SpecialOffer = true;
                    }
                    else
                    {
                        model.SpecialOffer = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PV"] != null && ds.Tables[0].Rows[0]["PV"].ToString() != "")
                {
                    model.PV = int.Parse(ds.Tables[0].Rows[0]["PV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalesVolume"] != null && ds.Tables[0].Rows[0]["SalesVolume"].ToString() != "")
                {
                    model.SalesVolume = int.Parse(ds.Tables[0].Rows[0]["SalesVolume"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Attachment"] != null && ds.Tables[0].Rows[0]["Attachment"].ToString() != "")
                {
                    model.Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ModuleNum"] != null && ds.Tables[0].Rows[0]["ModuleNum"].ToString() != "")
                {
                    model.ModuleNum = int.Parse(ds.Tables[0].Rows[0]["ModuleNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedDate"] != null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseTypes"] != null && ds.Tables[0].Rows[0]["CourseTypes"].ToString() != "")
                {
                    model.CourseTypes = int.Parse(ds.Tables[0].Rows[0]["CourseTypes"].ToString());
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
            strSql.Append("SELECT ROW_NUMBER()OVER ( ORDER BY CreatedDate DESC) AS RNum,* FROM ( ");
            strSql.Append("SELECT CourseID,CourseName,Description,ShortDescription,CategoryId,TimeDuration,CourseSpan,ExpiryDate,ViewCount,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Recommended,Latest,Hotsale,SpecialOffer,Price,PV,SalesVolume,Sequence,Attachment,ModuleNum,UpdatedDate,CourseTypes,TrueName ");
            strSql.Append("FROM Tao_Courses tc ");
            strSql.Append(" LEFT JOIN dbo.Accounts_Users au ON au.UserID=tc.CreatedUserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" )A");
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
            strSql.Append(" TC.*, TCM.ModuleIndex,AU.DepartmentID,AU.UserName ,CE.EnterpriseName ");
            strSql.Append(" FROM ((Tao_Courses TC Left Join Tao_CourseModule TCM ON TC.CourseID = TCM.CourseID) Left Join Accounts_Users AU On AU.UserID = TC.CreatedUserID) Left join CMS_Enterprise CE ON AU.DepartmentID = CE.EnterpriseID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCourseTop(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" TC.*, AU.DepartmentID,AU.UserName ,CE.EnterpriseName ");
            strSql.Append(" FROM (Tao_Courses TC Left Join Accounts_Users AU On AU.UserID = TC.CreatedUserID) Left join CMS_Enterprise CE ON AU.DepartmentID = CE.EnterpriseID");
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
        /// 更新浏览量
        /// </summary>
        public bool UpdatePV(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Courses set ");
            strSql.Append("PV=PV+1 ,UpdatedDate=GETDATE() ");
            strSql.Append(" where CourseID=@CourseID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)};
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
        /// 批量更新状态
        /// </summary>
        public bool UpdateList(string CourseIDlist, int Status)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(CourseIDlist))
            {
                strSql.Append("update Tao_Courses set Status=" + Status);
                strSql.Append(" where CourseID in (" + CourseIDlist + ")");

                strSql.Append("update Tao_CourseModule set Status=" + Status);
                strSql.Append(" where CourseID in (" + CourseIDlist + ")");

                strSql.Append("update Tao_Modules set Status=" + Status);
                strSql.Append(" where ModuleID in ");
                strSql.Append(" (select ModuleID from Tao_CourseModule where CourseID in (" + CourseIDlist + "))");

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
        /// 批量课程推荐
        /// </summary>
        public bool UpdateRecommendedList(string CourseIDlist, int Status, string colum)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(CourseIDlist))
            {
                strSql.Append("update Tao_Courses set " + colum + "=" + Status);
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

        ///// <summary>
        ///// 批量处理数据
        ///// </summary>
        //public bool UpdateList(string IDlist, string strWhere)
        //{
        //    int rows = 0;
        //    StringBuilder strSql = new StringBuilder();
        //    if (!string.IsNullOrEmpty(strWhere))
        //    {
        //        strSql.Append("update Tao_Courses set " + strWhere);
        //        strSql.Append(" where CourseID in (" + IDlist + ")");

        //        strSql.Append("update Tao_CourseModule set " + strWhere);
        //        strSql.Append(" where CourseID in (" + IDlist + ")");

        //        strSql.Append("update Tao_Modules set " + strWhere);
        //        strSql.Append(" where ModuleID in ");
        //        strSql.Append(" (select ModuleID from Tao_CourseModule where CourseID in (" + IDlist + "))");

        //        rows = DbHelperSQL.ExecuteSql(strSql.ToString());
        //    }
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 获取所有老师
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetCreatedUserIDList(int CourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct TrueName from Tao_Modules ");
            strSql.Append("LEFT JOIN Accounts_Users on Tao_Modules.CreatedUserID=Accounts_Users.UserID ");
            strSql.Append("where ModuleID in (select ModuleID from Tao_CourseModule where CourseID=@CourseID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
};
            parameters[0].Value = CourseID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 前5个相关课程推荐
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public DataSet GetCorrelatedCurriculum(int CourseID, int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " CourseID,UserID,CourseName,TrueName,ImageUrl from Tao_Courses ");
            strSql.Append("LEFT JOIN Accounts_Users on Tao_Courses.CreatedUserID=Accounts_Users.UserID ");
            strSql.Append("where CategoryId=(select CategoryId from Tao_Courses where CourseID=@CourseID) ");
            strSql.Append("and CourseID not in(select CourseID from Tao_Courses where CourseID=@CourseID) Order by PV desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
};
            parameters[0].Value = CourseID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetHotList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CourseID,CourseName,Description,ShortDescription,CategoryId,TimeDuration,CourseSpan,ExpiryDate,ViewCount,Status,Tags,ImageUrl,Type,VideoContent,CreatedDate,CreatedUserID,Recommended,Latest,Hotsale,SpecialOffer,Price,PV,SalesVolume,Sequence,Attachment,ModuleNum,UpdatedDate,CourseTypes ");
            strSql.Append(" FROM Tao_Courses ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion NewMethod
    }
}