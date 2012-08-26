using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.SysManage
{
    /// <summary>
    /// 用户扩展类
    /// </summary>
    public partial class UsersExp
    {
        #region Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.SysManage.UsersExpModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersExp(");
            strSql.Append("UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,PvCount,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Gravatar,@Singature,@TelPhone,@QQ,@MSN,@HomePage,@Birthday,@BirthdayVisible,@BirthdayIndexVisible,@Constellation,@ConstellationVisible,@ConstellationIndexVisible,@NativePlace,@NativePlaceVisible,@NativePlaceIndexVisible,@RegionId,@Address,@AddressVisible,@AddressIndexVisible,@BodilyForm,@BodilyFormVisible,@BodilyFormIndexVisible,@BloodType,@BloodTypeVisible,@BloodTypeIndexVisible,@Marriaged,@MarriagedVisible,@MarriagedIndexVisible,@PersonalStatus,@PersonalStatusVisible,@PersonalStatusIndexVisible,@Grade,@Balance,@Points,@PvCount,@LastAccessTime,@LastAccessIP,@LastPostTime,@LastLoginTime,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Gravatar", SqlDbType.VarChar,200),
					new SqlParameter("@Singature", SqlDbType.NVarChar,200),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,30),
					new SqlParameter("@MSN", SqlDbType.VarChar,30),
					new SqlParameter("@HomePage", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BirthdayVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BirthdayIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Constellation", SqlDbType.VarChar,10),
					new SqlParameter("@ConstellationVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@ConstellationIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,300),
					new SqlParameter("@NativePlaceVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@NativePlaceIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,300),
					new SqlParameter("@AddressVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@AddressIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@BodilyForm", SqlDbType.NVarChar,10),
					new SqlParameter("@BodilyFormVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BodilyFormIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@BloodType", SqlDbType.NVarChar,10),
					new SqlParameter("@BloodTypeVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BloodTypeIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Marriaged", SqlDbType.NVarChar,10),
					new SqlParameter("@MarriagedVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@MarriagedIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@PersonalStatus", SqlDbType.NVarChar,10),
					new SqlParameter("@PersonalStatusVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@PersonalStatusIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Points", SqlDbType.Int,4),
					new SqlParameter("@PvCount", SqlDbType.Int,4),
					new SqlParameter("@LastAccessTime", SqlDbType.DateTime),
					new SqlParameter("@LastAccessIP", SqlDbType.VarChar,50),
					new SqlParameter("@LastPostTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Gravatar;
            parameters[2].Value = model.Singature;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.QQ;
            parameters[5].Value = model.MSN;
            parameters[6].Value = model.HomePage;
            parameters[7].Value = model.Birthday;
            parameters[8].Value = model.BirthdayVisible;
            parameters[9].Value = model.BirthdayIndexVisible;
            parameters[10].Value = model.Constellation;
            parameters[11].Value = model.ConstellationVisible;
            parameters[12].Value = model.ConstellationIndexVisible;
            parameters[13].Value = model.NativePlace;
            parameters[14].Value = model.NativePlaceVisible;
            parameters[15].Value = model.NativePlaceIndexVisible;
            parameters[16].Value = model.RegionId;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.AddressVisible;
            parameters[19].Value = model.AddressIndexVisible;
            parameters[20].Value = model.BodilyForm;
            parameters[21].Value = model.BodilyFormVisible;
            parameters[22].Value = model.BodilyFormIndexVisible;
            parameters[23].Value = model.BloodType;
            parameters[24].Value = model.BloodTypeVisible;
            parameters[25].Value = model.BloodTypeIndexVisible;
            parameters[26].Value = model.Marriaged;
            parameters[27].Value = model.MarriagedVisible;
            parameters[28].Value = model.MarriagedIndexVisible;
            parameters[29].Value = model.PersonalStatus;
            parameters[30].Value = model.PersonalStatusVisible;
            parameters[31].Value = model.PersonalStatusIndexVisible;
            parameters[32].Value = model.Grade;
            parameters[33].Value = model.Balance;
            parameters[34].Value = model.Points;
            parameters[35].Value = model.PvCount;
            parameters[36].Value = model.LastAccessTime;
            parameters[37].Value = model.LastAccessIP;
            parameters[38].Value = model.LastPostTime;
            parameters[39].Value = model.LastLoginTime;
            parameters[40].Value = model.Remark;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.SysManage.UsersExpModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            strSql.Append("Gravatar=@Gravatar,");
            strSql.Append("Singature=@Singature,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("MSN=@MSN,");
            strSql.Append("HomePage=@HomePage,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("BirthdayVisible=@BirthdayVisible,");
            strSql.Append("BirthdayIndexVisible=@BirthdayIndexVisible,");
            strSql.Append("Constellation=@Constellation,");
            strSql.Append("ConstellationVisible=@ConstellationVisible,");
            strSql.Append("ConstellationIndexVisible=@ConstellationIndexVisible,");
            strSql.Append("NativePlace=@NativePlace,");
            strSql.Append("NativePlaceVisible=@NativePlaceVisible,");
            strSql.Append("NativePlaceIndexVisible=@NativePlaceIndexVisible,");
            strSql.Append("RegionId=@RegionId,");
            strSql.Append("Address=@Address,");
            strSql.Append("AddressVisible=@AddressVisible,");
            strSql.Append("AddressIndexVisible=@AddressIndexVisible,");
            strSql.Append("BodilyForm=@BodilyForm,");
            strSql.Append("BodilyFormVisible=@BodilyFormVisible,");
            strSql.Append("BodilyFormIndexVisible=@BodilyFormIndexVisible,");
            strSql.Append("BloodType=@BloodType,");
            strSql.Append("BloodTypeVisible=@BloodTypeVisible,");
            strSql.Append("BloodTypeIndexVisible=@BloodTypeIndexVisible,");
            strSql.Append("Marriaged=@Marriaged,");
            strSql.Append("MarriagedVisible=@MarriagedVisible,");
            strSql.Append("MarriagedIndexVisible=@MarriagedIndexVisible,");
            strSql.Append("PersonalStatus=@PersonalStatus,");
            strSql.Append("PersonalStatusVisible=@PersonalStatusVisible,");
            strSql.Append("PersonalStatusIndexVisible=@PersonalStatusIndexVisible,");
            strSql.Append("Grade=@Grade,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("Points=@Points,");
            strSql.Append("PvCount=@PvCount,");
            strSql.Append("LastAccessTime=@LastAccessTime,");
            strSql.Append("LastAccessIP=@LastAccessIP,");
            strSql.Append("LastPostTime=@LastPostTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Gravatar", SqlDbType.VarChar,200),
					new SqlParameter("@Singature", SqlDbType.NVarChar,200),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,30),
					new SqlParameter("@MSN", SqlDbType.VarChar,30),
					new SqlParameter("@HomePage", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BirthdayVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BirthdayIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Constellation", SqlDbType.VarChar,10),
					new SqlParameter("@ConstellationVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@ConstellationIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,300),
					new SqlParameter("@NativePlaceVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@NativePlaceIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,300),
					new SqlParameter("@AddressVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@AddressIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@BodilyForm", SqlDbType.NVarChar,10),
					new SqlParameter("@BodilyFormVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BodilyFormIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@BloodType", SqlDbType.NVarChar,10),
					new SqlParameter("@BloodTypeVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BloodTypeIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Marriaged", SqlDbType.NVarChar,10),
					new SqlParameter("@MarriagedVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@MarriagedIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@PersonalStatus", SqlDbType.NVarChar,10),
					new SqlParameter("@PersonalStatusVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@PersonalStatusIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Points", SqlDbType.Int,4),
					new SqlParameter("@PvCount", SqlDbType.Int,4),
					new SqlParameter("@LastAccessTime", SqlDbType.DateTime),
					new SqlParameter("@LastAccessIP", SqlDbType.VarChar,50),
					new SqlParameter("@LastPostTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.Gravatar;
            parameters[1].Value = model.Singature;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.QQ;
            parameters[4].Value = model.MSN;
            parameters[5].Value = model.HomePage;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.BirthdayVisible;
            parameters[8].Value = model.BirthdayIndexVisible;
            parameters[9].Value = model.Constellation;
            parameters[10].Value = model.ConstellationVisible;
            parameters[11].Value = model.ConstellationIndexVisible;
            parameters[12].Value = model.NativePlace;
            parameters[13].Value = model.NativePlaceVisible;
            parameters[14].Value = model.NativePlaceIndexVisible;
            parameters[15].Value = model.RegionId;
            parameters[16].Value = model.Address;
            parameters[17].Value = model.AddressVisible;
            parameters[18].Value = model.AddressIndexVisible;
            parameters[19].Value = model.BodilyForm;
            parameters[20].Value = model.BodilyFormVisible;
            parameters[21].Value = model.BodilyFormIndexVisible;
            parameters[22].Value = model.BloodType;
            parameters[23].Value = model.BloodTypeVisible;
            parameters[24].Value = model.BloodTypeIndexVisible;
            parameters[25].Value = model.Marriaged;
            parameters[26].Value = model.MarriagedVisible;
            parameters[27].Value = model.MarriagedIndexVisible;
            parameters[28].Value = model.PersonalStatus;
            parameters[29].Value = model.PersonalStatusVisible;
            parameters[30].Value = model.PersonalStatusIndexVisible;
            parameters[31].Value = model.Grade;
            parameters[32].Value = model.Balance;
            parameters[33].Value = model.Points;
            parameters[34].Value = model.PvCount;
            parameters[35].Value = model.LastAccessTime;
            parameters[36].Value = model.LastAccessIP;
            parameters[37].Value = model.LastPostTime;
            parameters[38].Value = model.LastLoginTime;
            parameters[39].Value = model.Remark;
            parameters[40].Value = model.UserID;

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
        public bool Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UsersExp ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;

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
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UsersExp ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
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
        public Maticsoft.Model.SysManage.UsersExpModel GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Accounts_UsersExp ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;

            Maticsoft.Model.SysManage.UsersExpModel model = new Maticsoft.Model.SysManage.UsersExpModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserAvatar"] != null && ds.Tables[0].Rows[0]["UserAvatar"].ToString() != "")
                {
                    model.Gravatar = ds.Tables[0].Rows[0]["UserAvatar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Singature"] != null && ds.Tables[0].Rows[0]["Singature"].ToString() != "")
                {
                    model.Singature = ds.Tables[0].Rows[0]["Singature"].ToString();
                }
                //if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                //{
                //    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                //{
                //    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                //{
                //    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["HomePage"] != null && ds.Tables[0].Rows[0]["HomePage"].ToString() != "")
                //{
                //    model.HomePage = ds.Tables[0].Rows[0]["HomePage"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["Birthday"] != null && ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                //{
                //    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["BirthdayVisible"] != null && ds.Tables[0].Rows[0]["BirthdayVisible"].ToString() != "")
                //{
                //    model.BirthdayVisible = int.Parse(ds.Tables[0].Rows[0]["BirthdayVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["BirthdayIndexVisible"] != null && ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.BirthdayIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.BirthdayIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["Constellation"] != null && ds.Tables[0].Rows[0]["Constellation"].ToString() != "")
                //{
                //    model.Constellation = ds.Tables[0].Rows[0]["Constellation"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["ConstellationVisible"] != null && ds.Tables[0].Rows[0]["ConstellationVisible"].ToString() != "")
                //{
                //    model.ConstellationVisible = int.Parse(ds.Tables[0].Rows[0]["ConstellationVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["ConstellationIndexVisible"] != null && ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.ConstellationIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.ConstellationIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["NativePlace"] != null && ds.Tables[0].Rows[0]["NativePlace"].ToString() != "")
                //{
                //    model.NativePlace = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["NativePlaceVisible"] != null && ds.Tables[0].Rows[0]["NativePlaceVisible"].ToString() != "")
                //{
                //    model.NativePlaceVisible = int.Parse(ds.Tables[0].Rows[0]["NativePlaceVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["NativePlaceIndexVisible"] != null && ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.NativePlaceIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.NativePlaceIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["RegionId"] != null && ds.Tables[0].Rows[0]["RegionId"].ToString() != "")
                //{
                //    model.RegionId = int.Parse(ds.Tables[0].Rows[0]["RegionId"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                //{
                //    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["AddressVisible"] != null && ds.Tables[0].Rows[0]["AddressVisible"].ToString() != "")
                //{
                //    model.AddressVisible = int.Parse(ds.Tables[0].Rows[0]["AddressVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["AddressIndexVisible"] != null && ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.AddressIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.AddressIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["BodilyForm"] != null && ds.Tables[0].Rows[0]["BodilyForm"].ToString() != "")
                //{
                //    model.BodilyForm = ds.Tables[0].Rows[0]["BodilyForm"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["BodilyFormVisible"] != null && ds.Tables[0].Rows[0]["BodilyFormVisible"].ToString() != "")
                //{
                //    model.BodilyFormVisible = int.Parse(ds.Tables[0].Rows[0]["BodilyFormVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["BodilyFormIndexVisible"] != null && ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.BodilyFormIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.BodilyFormIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["BloodType"] != null && ds.Tables[0].Rows[0]["BloodType"].ToString() != "")
                //{
                //    model.BloodType = ds.Tables[0].Rows[0]["BloodType"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["BloodTypeVisible"] != null && ds.Tables[0].Rows[0]["BloodTypeVisible"].ToString() != "")
                //{
                //    model.BloodTypeVisible = int.Parse(ds.Tables[0].Rows[0]["BloodTypeVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["BloodTypeIndexVisible"] != null && ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.BloodTypeIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.BloodTypeIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["Marriaged"] != null && ds.Tables[0].Rows[0]["Marriaged"].ToString() != "")
                //{
                //    model.Marriaged = ds.Tables[0].Rows[0]["Marriaged"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["MarriagedVisible"] != null && ds.Tables[0].Rows[0]["MarriagedVisible"].ToString() != "")
                //{
                //    model.MarriagedVisible = int.Parse(ds.Tables[0].Rows[0]["MarriagedVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["MarriagedIndexVisible"] != null && ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.MarriagedIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.MarriagedIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["PersonalStatus"] != null && ds.Tables[0].Rows[0]["PersonalStatus"].ToString() != "")
                //{
                //    model.PersonalStatus = ds.Tables[0].Rows[0]["PersonalStatus"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["PersonalStatusVisible"] != null && ds.Tables[0].Rows[0]["PersonalStatusVisible"].ToString() != "")
                //{
                //    model.PersonalStatusVisible = int.Parse(ds.Tables[0].Rows[0]["PersonalStatusVisible"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"] != null && ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString() != "")
                //{
                //    if ((ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString().ToLower() == "true"))
                //    {
                //        model.PersonalStatusIndexVisible = true;
                //    }
                //    else
                //    {
                //        model.PersonalStatusIndexVisible = false;
                //    }
                //}
                //if (ds.Tables[0].Rows[0]["Grade"] != null && ds.Tables[0].Rows[0]["Grade"].ToString() != "")
                //{
                //    model.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
                //}
                if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["Points"] != null && ds.Tables[0].Rows[0]["Points"].ToString() != "")
                //{
                //    model.Points = int.Parse(ds.Tables[0].Rows[0]["Points"].ToString());
                //}
                if (ds.Tables[0].Rows[0]["PvCount"] != null && ds.Tables[0].Rows[0]["PvCount"].ToString() != "")
                {
                    model.PvCount = int.Parse(ds.Tables[0].Rows[0]["PvCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastAccessTime"] != null && ds.Tables[0].Rows[0]["LastAccessTime"].ToString() != "")
                {
                    model.LastAccessTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastAccessTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastAccessIP"] != null && ds.Tables[0].Rows[0]["LastAccessIP"].ToString() != "")
                {
                    model.LastAccessIP = ds.Tables[0].Rows[0]["LastAccessIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastPostTime"] != null && ds.Tables[0].Rows[0]["LastPostTime"].ToString() != "")
                {
                    model.LastPostTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastPostTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"] != null && ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                //{
                //    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["TeachDescription"] != null && ds.Tables[0].Rows[0]["TeachDescription"].ToString() != "")
                {
                    model.TeachDescription = ds.Tables[0].Rows[0]["TeachDescription"].ToString();
                }
                //if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                //{
                //    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                //{
                //    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                //}
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
            strSql.Append("select * ");
            strSql.Append(" FROM Accounts_UsersExp ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM Accounts_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Accounts_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.UserID desc");
            }
            strSql.Append(")AS Row, T.*  from Accounts_UsersExp T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.Users> GetListByTeacherkey(out int rowCount, out int pageCount, string key, int? PageIndex, int? PageSize)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@KeyStr", SqlDbType.NVarChar),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float)
                    };
            parameters[0].Value = key;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_SearchTeacherByKey", parameters, "ds");
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
        public List<Maticsoft.Model.SysManage.Users> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.SysManage.Users> modelList = new List<Maticsoft.Model.SysManage.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SysManage.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.SysManage.Users();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}