/*----------------------------------------------------------------

// Copyright (C) 2012 动软卓越 版权所有。
//
// 文件名：EntryForm.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/07/22 16:29:24
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:EntryForm
    /// </summary>
    public partial class EntryForm
    {
        public EntryForm()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Tao_EntryForm");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_EntryForm");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.EntryForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Tao_EntryForm(");
            strSql.Append("UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,Remark,State,CourseID)");
            strSql.Append(" VALUES (");
            strSql.Append("@UserName,@Age,@Email,@TelPhone,@Phone,@QQ,@MSN,@HouseAddress,@CompanyAddress,@RegionId,@Sex,@Description,@Remark,@State,@CourseID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@MSN", SqlDbType.VarChar,100),
					new SqlParameter("@HouseAddress", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,200),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.Int),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@State", SqlDbType.SmallInt,2),
					new SqlParameter("@CourseID", SqlDbType.SmallInt,2)
                                        };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.MSN;
            parameters[7].Value = model.HouseAddress;
            parameters[8].Value = model.CompanyAddress;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.State;
            parameters[14].Value = model.CourseID;

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
        public bool Update(Maticsoft.Model.Tao.EntryForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Tao_EntryForm SET ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Age=@Age,");
            strSql.Append("Email=@Email,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("MSN=@MSN,");
            strSql.Append("HouseAddress=@HouseAddress,");
            strSql.Append("CompanyAddress=@CompanyAddress,");
            strSql.Append("RegionId=@RegionId,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Description=@Description,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("State=@State");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@MSN", SqlDbType.VarChar,100),
					new SqlParameter("@HouseAddress", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,200),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.Int),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@State", SqlDbType.SmallInt,2),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.MSN;
            parameters[7].Value = model.HouseAddress;
            parameters[8].Value = model.CompanyAddress;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.State;
            parameters[14].Value = model.ID;

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
            strSql.Append("DELETE FROM Tao_EntryForm ");
            strSql.Append(" WHERE ID=@ID");
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

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Tao_EntryForm ");
            strSql.Append(" WHERE ID in (" + IDlist + ")  ");
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
        public Maticsoft.Model.Tao.EntryForm GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP 1 ID,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,Remark,State FROM Tao_EntryForm ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.Tao.EntryForm model = new Maticsoft.Model.Tao.EntryForm();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    model.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                {
                    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseAddress"] != null && ds.Tables[0].Rows[0]["HouseAddress"].ToString() != "")
                {
                    model.HouseAddress = ds.Tables[0].Rows[0]["HouseAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CompanyAddress"] != null && ds.Tables[0].Rows[0]["CompanyAddress"].ToString() != "")
                {
                    model.CompanyAddress = ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegionId"] != null && ds.Tables[0].Rows[0]["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(ds.Tables[0].Rows[0]["RegionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
            strSql.Append("SELECT ID,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,Remark,State ");
            strSql.Append(" FROM Tao_EntryForm ");
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
            strSql.Append(" ID,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,Remark,State ");
            strSql.Append(" FROM Tao_EntryForm ");
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
            strSql.Append("SELECT COUNT(1) FROM Tao_EntryForm ");
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
                strSql.Append("ORDER BY T.ID desc");
            }
            strSql.Append(")AS Row, T.*  FROM Tao_EntryForm T ");
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
            parameters[0].Value = "Tao_EntryForm";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region 批量处理

        /// <summary>
        /// 批量处理
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_EntryForm set " + strWhere);
            strSql.Append(" where Id in(" + IDlist + ")  ");
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

        #endregion 批量处理
    }
}