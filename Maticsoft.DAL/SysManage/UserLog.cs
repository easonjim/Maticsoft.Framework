using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.SysManage
{
    /// <summary>
    /// �û���־�Ĳ�����
    /// </summary>
    public class UserLog
    {
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="model"></param>
        public void LogUserAdd(Maticsoft.Model.SysManage.UserLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_UserLog(");
            strSql.Append("OPTime,Url,OPInfo,UserName,UserType,UserIP)");
            strSql.Append(" values (");
            strSql.Append("@OPTime,@Url,@OPInfo,@UserName,@UserType,@UserIP)");
            SqlParameter[] parameters = {
					new SqlParameter("@OPTime", SqlDbType.DateTime),
					new SqlParameter("@Url", SqlDbType.NVarChar),
					new SqlParameter("@OPInfo", SqlDbType.NVarChar),
                    new SqlParameter("@UserName", SqlDbType.NVarChar),
                    new SqlParameter("@UserType", SqlDbType.NVarChar),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.OPInfo;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.UserIP;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ���ݲ�ѯ������ȡ��־�б�
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns>���ص����ݼ�</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[OPTime],[url],[OPInfo],[UserName],[UserType],[UserIp] ");
            strSql.Append(" FROM SA_UserLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " Order By [OPTime] Desc ");
            }
            else
            {
                strSql.Append(" Order By [OPTime] Desc ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ɾ��һ����־��¼
        /// </summary>
        /// <param name="iID">Ҫɾ������־���</param>
        public void LogUserDelete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_UserLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void LogUserDelete(string IdList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_UserLog ");
            strSql.Append(" where ID in(" + IdList + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// ɾ��ĳһ����֮ǰ������
        /// </summary>
        /// <param name="dtDateBefore">����</param>
        public void LogUserDelete(DateTime dtDateBefore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_UserLog ");
            strSql.Append(" where OPTime <= @OPTime");
            SqlParameter[] parameters = {
					new SqlParameter("@OPTime", SqlDbType.DateTime)
				};
            parameters[0].Value = dtDateBefore;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��ĳһ����֮ǰ�������ô洢����
        /// </summary>
        /// <param name="dtDateBefore">����</param>
        public void LogDelete(DateTime dtDateBefore)
        {
            SqlParameter[] parameters = { new SqlParameter("@OPTime", SqlDbType.DateTime), };

            parameters[0].Value = dtDateBefore;
            DbHelperSQL.RunProcedure("sp_LogUser_delete", parameters);
        }

        ///// <summary>
        ///// �õ�Ҫ��ѯ�����ݵ�����
        ///// </summary>
        ///// <param name="strTable">Ҫ��ѯ�ı�</param>
        ///// <param name="strWhere">��ѯ������,���û��������1=1</param>
        ///// <returns>���صļ�¼����</returns>
        //public int GetRecSum(string strTable, string strWhere)
        //{
        //    string strCmd = "select count(*) from " + strTable + "   where  " + strWhere;
        //    int iResult = Convert.ToInt32(DbHelperSQL.GetSingle(strCmd));
        //    return iResult;
        //}
    }
}