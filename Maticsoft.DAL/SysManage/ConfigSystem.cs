﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.SysManage
{
    /// <summary>
    /// Config system
    /// </summary>
    public class ConfigSystem
    {
        #region Method

        /// <summary>
        /// Whether there is Exists
        /// </summary>
        public bool Exists(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_Config_System");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters = {
					new SqlParameter("@Keyname", SqlDbType.VarChar)};
            parameters[0].Value = Keyname;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Config_System(");
            strSql.Append("Keyname,Value,Description)");
            strSql.Append(" values (");
            strSql.Append("@Keyname,@Value,@Description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Keyname", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar),
					new SqlParameter("@Description", SqlDbType.VarChar,200)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = Description;

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

        public void Update(int ID, string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_System set ");
            strSql.Append("Keyname=@Keyname,");
            strSql.Append("Value=@Value,");
            strSql.Append("Description=@Description");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Keyname", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar),
					new SqlParameter("@Description", SqlDbType.VarChar,200)};
            parameters[0].Value = ID;
            parameters[1].Value = Keyname;
            parameters[2].Value = Value;
            parameters[3].Value = Description;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Update a record
        /// </summary>
        public void Update(string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_System set ");
            strSql.Append("Value=@Value,");
            strSql.Append("Description=@Description");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters = {
					new SqlParameter("@Keyname", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar),
					new SqlParameter("@Description", SqlDbType.VarChar,200)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = Description;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Config_System ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public string GetValue(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Value from SA_Config_System ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public string GetValue(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Value from SA_Config_System ");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters = {
					new SqlParameter("@Keyname", SqlDbType.VarChar)};
            parameters[0].Value = Keyname;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// Query data list
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Keyname,Value,Description ");
            strSql.Append(" FROM SA_Config_System ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method
    }
}