using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;
using Maticsoft.Model.SysManage;

namespace Maticsoft.DAL.SysManage
{
    /// <summary>
    /// DAL base on SqlParameter
    /// </summary>
    public class SysTree
    {
        public int AddTreeNode(SysNode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Tree(");
            strSql.Append("TreeText,ParentID,Location,OrderID,comment,Url,PermissionID,ImageUrl)");
            strSql.Append(" values (");
            strSql.Append("@TreeText,@ParentID,@Location,@OrderID,@comment,@Url,@PermissionID,@ImageUrl)");
            SqlParameter[] parameters = {
											new SqlParameter("@TreeText", SqlDbType.VarChar,100),
											new SqlParameter("@ParentID", SqlDbType.Int,4),
											new SqlParameter("@Location", SqlDbType.VarChar,50),
											new SqlParameter("@OrderID", SqlDbType.Int,4),
											new SqlParameter("@comment", SqlDbType.VarChar,50),
											new SqlParameter("@Url", SqlDbType.VarChar,100),
											new SqlParameter("@PermissionID", SqlDbType.Int,4),
											new SqlParameter("@ImageUrl", SqlDbType.VarChar,100)};

            parameters[0].Value = model.TreeText;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Location;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Comment;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.PermissionID;
            parameters[7].Value = model.ImageUrl;

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

        public void UpdateNode(SysNode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Tree set ");
            strSql.Append("TreeText=@TreeText,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Location=@Location,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("comment=@comment,");
            strSql.Append("Url=@Url,");
            strSql.Append("PermissionID=@PermissionID,");
            strSql.Append("ImageUrl=@ImageUrl");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
											new SqlParameter("@NodeID", SqlDbType.Int,4),
											new SqlParameter("@TreeText", SqlDbType.VarChar,100),
											new SqlParameter("@ParentID", SqlDbType.Int,4),
											new SqlParameter("@Location", SqlDbType.VarChar,50),
											new SqlParameter("@OrderID", SqlDbType.Int,4),
											new SqlParameter("@comment", SqlDbType.VarChar,50),
											new SqlParameter("@Url", SqlDbType.VarChar,100),
											new SqlParameter("@PermissionID", SqlDbType.Int,4),
											new SqlParameter("@ImageUrl", SqlDbType.VarChar,100)};
            parameters[0].Value = model.NodeID;
            parameters[1].Value = model.TreeText;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Location;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Comment;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.PermissionID;
            parameters[8].Value = model.ImageUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DelTreeNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_Tree ");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
											new SqlParameter("@NodeID", SqlDbType.Int,4)
										};
            parameters[0].Value = NodeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DelTreeNodes(string nodeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_Tree ");
            strSql.Append(" where NodeID in(" + nodeidlist + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void MoveNodes(string nodeidlist, int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Tree set ");
            strSql.Append("ParentID=" + ParentID);
            strSql.Append(" where NodeID in(" + nodeidlist + ")");

            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Tree ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by parentid,orderid ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetPermissionCatalogID(int permissionID)
        {
            string sql = "select CategoryID from Accounts_Permissions where PermissionID=" + permissionID;
            object res = DbHelperSQL.GetSingle(sql);
            if (res == null)
            {
                return 0;
            }
            return (int)res;
        }

        /// <summary>
        /// Get Menu Node
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public SysNode GetNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Tree ");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
											new SqlParameter("@NodeID", SqlDbType.Int,4)
										};
            parameters[0].Value = NodeID;

            SysNode node = new SysNode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.TreeText = ds.Tables[0].Rows[0]["TreeText"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();

                return node;
            }
            else
            {
                return null;
            }
        }

        #region ��־

        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="time"></param>
        /// <param name="loginfo"></param>
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(day,[datetime],getdate())>" + days;
            DeleteLog(str);
        }

        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SA_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }

        #endregion ��־
    }
}