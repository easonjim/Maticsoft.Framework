using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.SysManage
{
    /// <summary>
    /// 数据访问类:SA_Feedback
    /// </summary>
    public class SA_Feedback
    {
        public SA_Feedback()
        { }

        #region Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.SysManage.SA_Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Feedback(");
            strSql.Append("Feedback_cContent,Feedback_cMail,Feedback_cPhone,Feedback_cUserName,Feedback_cCompany,Feedback_cUserIP,Feedback_bSolved,Feedback_dateCreate)");
            strSql.Append(" values (");
            strSql.Append("@Feedback_cContent,@Feedback_cMail,@Feedback_cPhone,@Feedback_cUserName,@Feedback_cCompany,@Feedback_cUserIP,@Feedback_bSolved,@Feedback_dateCreate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Feedback_cContent", SqlDbType.Text),
					new SqlParameter("@Feedback_cMail", SqlDbType.NVarChar,30),
					new SqlParameter("@Feedback_cPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@Feedback_cUserName", SqlDbType.NVarChar,30),
					new SqlParameter("@Feedback_cCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@Feedback_cUserIP", SqlDbType.NVarChar,20),
					new SqlParameter("@Feedback_bSolved", SqlDbType.Bit,1),
					new SqlParameter("@Feedback_dateCreate", SqlDbType.DateTime)};
            parameters[0].Value = model.Feedback_cContent;
            parameters[1].Value = model.Feedback_cMail;
            parameters[2].Value = model.Feedback_cPhone;
            parameters[3].Value = model.Feedback_cUserName;
            parameters[4].Value = model.Feedback_cCompany;
            parameters[5].Value = model.Feedback_cUserIP;
            parameters[6].Value = model.Feedback_bSolved;
            parameters[7].Value = DateTime.Now;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.SysManage.SA_Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Feedback set ");
            strSql.Append("Feedback_cContent=@Feedback_cContent,");
            strSql.Append("Feedback_cMail=@Feedback_cMail,");
            strSql.Append("Feedback_cPhone=@Feedback_cPhone,");
            strSql.Append("Feedback_cUserName=@Feedback_cUserName,");
            strSql.Append("Feedback_cCompany=@Feedback_cCompany,");
            strSql.Append("Feedback_cUserIP=@Feedback_cUserIP,");
            strSql.Append("Feedback_bSolved=@Feedback_bSolved,");
            strSql.Append("Feedback_cResult=@Feedback_cResult");
            strSql.Append(" where Feedback_iID=@Feedback_iID");
            SqlParameter[] parameters = {
					new SqlParameter("@Feedback_iID", SqlDbType.Int,4),
					new SqlParameter("@Feedback_cContent", SqlDbType.Text),
					new SqlParameter("@Feedback_cMail", SqlDbType.NVarChar,30),
					new SqlParameter("@Feedback_cPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@Feedback_cUserName", SqlDbType.NVarChar,30),
					new SqlParameter("@Feedback_cCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@Feedback_cUserIP", SqlDbType.NVarChar,20),
					new SqlParameter("@Feedback_bSolved", SqlDbType.Bit,1),
                    new SqlParameter("@Feedback_cResult", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Feedback_iID;
            parameters[1].Value = model.Feedback_cContent;
            parameters[2].Value = model.Feedback_cMail;
            parameters[3].Value = model.Feedback_cPhone;
            parameters[4].Value = model.Feedback_cUserName;
            parameters[5].Value = model.Feedback_cCompany;
            parameters[6].Value = model.Feedback_cUserIP;
            parameters[7].Value = model.Feedback_bSolved;
            parameters[8].Value = model.Feedback_cResult;
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
        public bool Delete(int Feedback_iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Feedback ");
            strSql.Append(" where Feedback_iID=@Feedback_iID");
            SqlParameter[] parameters = {
					new SqlParameter("@Feedback_iID", SqlDbType.Int,4)
};
            parameters[0].Value = Feedback_iID;

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
        public bool DeleteList(string Feedback_iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Feedback ");
            strSql.Append(" where Feedback_iID in (" + Feedback_iIDlist + ")  ");
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
        public Maticsoft.Model.SysManage.SA_Feedback GetModel(int Feedback_iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Feedback_iID,Feedback_cContent,Feedback_cMail,Feedback_cPhone,Feedback_cUserName,Feedback_cCompany,Feedback_cUserIP,Feedback_bSolved,Feedback_dateCreate,Feedback_cResult from SA_Feedback ");
            strSql.Append(" where Feedback_iID=@Feedback_iID");
            SqlParameter[] parameters = {
					new SqlParameter("@Feedback_iID", SqlDbType.Int,4)
};
            parameters[0].Value = Feedback_iID;

            Maticsoft.Model.SysManage.SA_Feedback model = new Maticsoft.Model.SysManage.SA_Feedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Feedback_iID"].ToString() != "")
                {
                    model.Feedback_iID = int.Parse(ds.Tables[0].Rows[0]["Feedback_iID"].ToString());
                }
                model.Feedback_cContent = ds.Tables[0].Rows[0]["Feedback_cContent"].ToString();
                model.Feedback_cMail = ds.Tables[0].Rows[0]["Feedback_cMail"].ToString();
                model.Feedback_cPhone = ds.Tables[0].Rows[0]["Feedback_cPhone"].ToString();
                model.Feedback_cUserName = ds.Tables[0].Rows[0]["Feedback_cUserName"].ToString();
                model.Feedback_cCompany = ds.Tables[0].Rows[0]["Feedback_cCompany"].ToString();
                model.Feedback_cUserIP = ds.Tables[0].Rows[0]["Feedback_cUserIP"].ToString();
                model.Feedback_cResult = ds.Tables[0].Rows[0]["Feedback_cResult"].ToString();
                if (ds.Tables[0].Rows[0]["Feedback_bSolved"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Feedback_bSolved"].ToString() == "1") || (ds.Tables[0].Rows[0]["Feedback_bSolved"].ToString().ToLower() == "true"))
                    {
                        model.Feedback_bSolved = true;
                    }
                    else
                    {
                        model.Feedback_bSolved = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Feedback_dateCreate"].ToString() != "")
                {
                    model.Feedback_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["Feedback_dateCreate"].ToString());
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
            strSql.Append("select Feedback_iID,Feedback_cContent,Feedback_cMail,Feedback_cPhone,Feedback_cUserName,Feedback_cCompany,Feedback_cUserIP,Feedback_bSolved,Feedback_dateCreate,Feedback_cResult ");
            strSql.Append(" FROM SA_Feedback ");
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
            strSql.Append(" Feedback_iID,Feedback_cContent,Feedback_cMail,Feedback_cPhone,Feedback_cUserName,Feedback_cCompany,Feedback_cUserIP,Feedback_bSolved,Feedback_dateCreate,Feedback_cResult ");
            strSql.Append(" FROM SA_Feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method
    }
}