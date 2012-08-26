using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references
using Maticsoft.Model;//Please add references

namespace Maticsoft.DAL.UserExp
{
    /// <summary>
    /// 数据访问类:UsersExp
    /// </summary>
    public partial class UsersExp
    {
        public UsersExp()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "Accounts_UsersExp");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UsersExp");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.UserExp.UsersExp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersExp(");
            strSql.Append("UserID,UserAvatar,Singature,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,UserRegionID,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Integral,PvCount,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Blong,height,weight,Image,UserCareer,UserHobby,TeachDescription,Balance,Tags)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserAvatar,@Singature,@Birthday,@BirthdayVisible,@BirthdayIndexVisible,@Constellation,@ConstellationVisible,@ConstellationIndexVisible,@NativePlace,@NativePlaceVisible,@NativePlaceIndexVisible,@UserRegionID,@Address,@AddressVisible,@AddressIndexVisible,@BodilyForm,@BodilyFormVisible,@BodilyFormIndexVisible,@BloodType,@BloodTypeVisible,@BloodTypeIndexVisible,@Marriaged,@MarriagedVisible,@MarriagedIndexVisible,@PersonalStatus,@PersonalStatusVisible,@PersonalStatusIndexVisible,@Grade,@Integral,@PvCount,@LastAccessTime,@LastAccessIP,@LastPostTime,@LastLoginTime,@Blong,@height,@weight,@Image,@UserCareer,@UserHobby,@TeachDescription,@Balance,@Tags)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserAvatar", SqlDbType.VarChar,200),
					new SqlParameter("@Singature", SqlDbType.NVarChar,200),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BirthdayVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BirthdayIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Constellation", SqlDbType.VarChar,10),
					new SqlParameter("@ConstellationVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@ConstellationIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,300),
					new SqlParameter("@NativePlaceVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@NativePlaceIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@UserRegionID", SqlDbType.Int,4),
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
					new SqlParameter("@Integral", SqlDbType.Int,4),
					new SqlParameter("@PvCount", SqlDbType.Int,4),
					new SqlParameter("@LastAccessTime", SqlDbType.DateTime),
					new SqlParameter("@LastAccessIP", SqlDbType.VarChar,50),
					new SqlParameter("@LastPostTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Blong", SqlDbType.VarChar,100),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@weight", SqlDbType.Int,4),
					new SqlParameter("@Image", SqlDbType.VarChar,100),
					new SqlParameter("@UserCareer", SqlDbType.NVarChar,50),
					new SqlParameter("@UserHobby", SqlDbType.NVarChar,200),
					new SqlParameter("@TeachDescription", SqlDbType.VarChar),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Tags", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserAvatar;
            parameters[2].Value = model.Singature;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.BirthdayVisible;
            parameters[5].Value = model.BirthdayIndexVisible;
            parameters[6].Value = model.Constellation;
            parameters[7].Value = model.ConstellationVisible;
            parameters[8].Value = model.ConstellationIndexVisible;
            parameters[9].Value = model.NativePlace;
            parameters[10].Value = model.NativePlaceVisible;
            parameters[11].Value = model.NativePlaceIndexVisible;
            parameters[12].Value = model.UserRegionID;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.AddressVisible;
            parameters[15].Value = model.AddressIndexVisible;
            parameters[16].Value = model.BodilyForm;
            parameters[17].Value = model.BodilyFormVisible;
            parameters[18].Value = model.BodilyFormIndexVisible;
            parameters[19].Value = model.BloodType;
            parameters[20].Value = model.BloodTypeVisible;
            parameters[21].Value = model.BloodTypeIndexVisible;
            parameters[22].Value = model.Marriaged;
            parameters[23].Value = model.MarriagedVisible;
            parameters[24].Value = model.MarriagedIndexVisible;
            parameters[25].Value = model.PersonalStatus;
            parameters[26].Value = model.PersonalStatusVisible;
            parameters[27].Value = model.PersonalStatusIndexVisible;
            parameters[28].Value = model.Grade;
            parameters[29].Value = model.Integral;
            parameters[30].Value = model.PvCount;
            parameters[31].Value = model.LastAccessTime;
            parameters[32].Value = model.LastAccessIP;
            parameters[33].Value = model.LastPostTime;
            parameters[34].Value = model.LastLoginTime;
            parameters[35].Value = model.Blong;
            parameters[36].Value = model.height;
            parameters[37].Value = model.weight;
            parameters[38].Value = model.Image;
            parameters[39].Value = model.UserCareer;
            parameters[40].Value = model.UserHobby;
            parameters[41].Value = model.TeachDescription;
            parameters[42].Value = model.Balance;
            parameters[43].Value = model.Tags;

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
        public bool Update(Maticsoft.Model.UserExp.UsersExp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            strSql.Append("UserAvatar=@UserAvatar,");
            strSql.Append("Singature=@Singature,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("BirthdayVisible=@BirthdayVisible,");
            strSql.Append("BirthdayIndexVisible=@BirthdayIndexVisible,");
            strSql.Append("Constellation=@Constellation,");
            strSql.Append("ConstellationVisible=@ConstellationVisible,");
            strSql.Append("ConstellationIndexVisible=@ConstellationIndexVisible,");
            strSql.Append("NativePlace=@NativePlace,");
            strSql.Append("NativePlaceVisible=@NativePlaceVisible,");
            strSql.Append("NativePlaceIndexVisible=@NativePlaceIndexVisible,");
            strSql.Append("UserRegionID=@UserRegionID,");
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
            strSql.Append("Integral=@Integral,");
            strSql.Append("PvCount=@PvCount,");
            strSql.Append("LastAccessTime=@LastAccessTime,");
            strSql.Append("LastAccessIP=@LastAccessIP,");
            strSql.Append("LastPostTime=@LastPostTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("Blong=@Blong,");
            strSql.Append("height=@height,");
            strSql.Append("weight=@weight,");
            strSql.Append("Image=@Image,");
            strSql.Append("UserCareer=@UserCareer,");
            strSql.Append("UserHobby=@UserHobby,");
            strSql.Append("TeachDescription=@TeachDescription,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("Tags=@Tags");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserAvatar", SqlDbType.VarChar,200),
					new SqlParameter("@Singature", SqlDbType.NVarChar,200),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BirthdayVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@BirthdayIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@Constellation", SqlDbType.VarChar,10),
					new SqlParameter("@ConstellationVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@ConstellationIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,300),
					new SqlParameter("@NativePlaceVisible", SqlDbType.SmallInt,2),
					new SqlParameter("@NativePlaceIndexVisible", SqlDbType.Bit,1),
					new SqlParameter("@UserRegionID", SqlDbType.Int,4),
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
					new SqlParameter("@Integral", SqlDbType.Int,4),
					new SqlParameter("@PvCount", SqlDbType.Int,4),
					new SqlParameter("@LastAccessTime", SqlDbType.DateTime),
					new SqlParameter("@LastAccessIP", SqlDbType.VarChar,50),
					new SqlParameter("@LastPostTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Blong", SqlDbType.VarChar,100),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@weight", SqlDbType.Int,4),
					new SqlParameter("@Image", SqlDbType.VarChar,100),
					new SqlParameter("@UserCareer", SqlDbType.NVarChar,50),
					new SqlParameter("@UserHobby", SqlDbType.NVarChar,200),
					new SqlParameter("@TeachDescription", SqlDbType.VarChar),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@Tags", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserAvatar;
            parameters[1].Value = model.Singature;
            parameters[2].Value = model.Birthday;
            parameters[3].Value = model.BirthdayVisible;
            parameters[4].Value = model.BirthdayIndexVisible;
            parameters[5].Value = model.Constellation;
            parameters[6].Value = model.ConstellationVisible;
            parameters[7].Value = model.ConstellationIndexVisible;
            parameters[8].Value = model.NativePlace;
            parameters[9].Value = model.NativePlaceVisible;
            parameters[10].Value = model.NativePlaceIndexVisible;
            parameters[11].Value = model.UserRegionID;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.AddressVisible;
            parameters[14].Value = model.AddressIndexVisible;
            parameters[15].Value = model.BodilyForm;
            parameters[16].Value = model.BodilyFormVisible;
            parameters[17].Value = model.BodilyFormIndexVisible;
            parameters[18].Value = model.BloodType;
            parameters[19].Value = model.BloodTypeVisible;
            parameters[20].Value = model.BloodTypeIndexVisible;
            parameters[21].Value = model.Marriaged;
            parameters[22].Value = model.MarriagedVisible;
            parameters[23].Value = model.MarriagedIndexVisible;
            parameters[24].Value = model.PersonalStatus;
            parameters[25].Value = model.PersonalStatusVisible;
            parameters[26].Value = model.PersonalStatusIndexVisible;
            parameters[27].Value = model.Grade;
            parameters[28].Value = model.Integral;
            parameters[29].Value = model.PvCount;
            parameters[30].Value = model.LastAccessTime;
            parameters[31].Value = model.LastAccessIP;
            parameters[32].Value = model.LastPostTime;
            parameters[33].Value = model.LastLoginTime;
            parameters[34].Value = model.Blong;
            parameters[35].Value = model.height;
            parameters[36].Value = model.weight;
            parameters[37].Value = model.Image;
            parameters[38].Value = model.UserCareer;
            parameters[39].Value = model.UserHobby;
            parameters[40].Value = model.TeachDescription;
            parameters[41].Value = model.Balance;
            parameters[42].Value = model.Tags;
            parameters[43].Value = model.UserID;

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
					new SqlParameter("@UserID", SqlDbType.Int,4)};
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
        public Maticsoft.Model.UserExp.UsersExp GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserAvatar,Singature,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,UserRegionID,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Integral,PvCount,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Blong,height,weight,Image,UserCareer,UserHobby,TeachDescription,Balance,Tags from Accounts_UsersExp ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            Maticsoft.Model.UserExp.UsersExp model = new Maticsoft.Model.UserExp.UsersExp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserAvatar"] != null && ds.Tables[0].Rows[0]["UserAvatar"].ToString() != "")
                {
                    model.UserAvatar = ds.Tables[0].Rows[0]["UserAvatar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Singature"] != null && ds.Tables[0].Rows[0]["Singature"].ToString() != "")
                {
                    model.Singature = ds.Tables[0].Rows[0]["Singature"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birthday"] != null && ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BirthdayVisible"] != null && ds.Tables[0].Rows[0]["BirthdayVisible"].ToString() != "")
                {
                    model.BirthdayVisible = int.Parse(ds.Tables[0].Rows[0]["BirthdayVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BirthdayIndexVisible"] != null && ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BirthdayIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BirthdayIndexVisible = true;
                    }
                    else
                    {
                        model.BirthdayIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Constellation"] != null && ds.Tables[0].Rows[0]["Constellation"].ToString() != "")
                {
                    model.Constellation = ds.Tables[0].Rows[0]["Constellation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ConstellationVisible"] != null && ds.Tables[0].Rows[0]["ConstellationVisible"].ToString() != "")
                {
                    model.ConstellationVisible = int.Parse(ds.Tables[0].Rows[0]["ConstellationVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ConstellationIndexVisible"] != null && ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["ConstellationIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.ConstellationIndexVisible = true;
                    }
                    else
                    {
                        model.ConstellationIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["NativePlace"] != null && ds.Tables[0].Rows[0]["NativePlace"].ToString() != "")
                {
                    model.NativePlace = ds.Tables[0].Rows[0]["NativePlace"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NativePlaceVisible"] != null && ds.Tables[0].Rows[0]["NativePlaceVisible"].ToString() != "")
                {
                    model.NativePlaceVisible = int.Parse(ds.Tables[0].Rows[0]["NativePlaceVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NativePlaceIndexVisible"] != null && ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["NativePlaceIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.NativePlaceIndexVisible = true;
                    }
                    else
                    {
                        model.NativePlaceIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UserRegionID"] != null && ds.Tables[0].Rows[0]["UserRegionID"].ToString() != "")
                {
                    model.UserRegionID = int.Parse(ds.Tables[0].Rows[0]["UserRegionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddressVisible"] != null && ds.Tables[0].Rows[0]["AddressVisible"].ToString() != "")
                {
                    model.AddressVisible = int.Parse(ds.Tables[0].Rows[0]["AddressVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddressIndexVisible"] != null && ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["AddressIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.AddressIndexVisible = true;
                    }
                    else
                    {
                        model.AddressIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BodilyForm"] != null && ds.Tables[0].Rows[0]["BodilyForm"].ToString() != "")
                {
                    model.BodilyForm = ds.Tables[0].Rows[0]["BodilyForm"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BodilyFormVisible"] != null && ds.Tables[0].Rows[0]["BodilyFormVisible"].ToString() != "")
                {
                    model.BodilyFormVisible = int.Parse(ds.Tables[0].Rows[0]["BodilyFormVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BodilyFormIndexVisible"] != null && ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BodilyFormIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BodilyFormIndexVisible = true;
                    }
                    else
                    {
                        model.BodilyFormIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BloodType"] != null && ds.Tables[0].Rows[0]["BloodType"].ToString() != "")
                {
                    model.BloodType = ds.Tables[0].Rows[0]["BloodType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BloodTypeVisible"] != null && ds.Tables[0].Rows[0]["BloodTypeVisible"].ToString() != "")
                {
                    model.BloodTypeVisible = int.Parse(ds.Tables[0].Rows[0]["BloodTypeVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BloodTypeIndexVisible"] != null && ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["BloodTypeIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BloodTypeIndexVisible = true;
                    }
                    else
                    {
                        model.BloodTypeIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Marriaged"] != null && ds.Tables[0].Rows[0]["Marriaged"].ToString() != "")
                {
                    model.Marriaged = ds.Tables[0].Rows[0]["Marriaged"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MarriagedVisible"] != null && ds.Tables[0].Rows[0]["MarriagedVisible"].ToString() != "")
                {
                    model.MarriagedVisible = int.Parse(ds.Tables[0].Rows[0]["MarriagedVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MarriagedIndexVisible"] != null && ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["MarriagedIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.MarriagedIndexVisible = true;
                    }
                    else
                    {
                        model.MarriagedIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PersonalStatus"] != null && ds.Tables[0].Rows[0]["PersonalStatus"].ToString() != "")
                {
                    model.PersonalStatus = ds.Tables[0].Rows[0]["PersonalStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PersonalStatusVisible"] != null && ds.Tables[0].Rows[0]["PersonalStatusVisible"].ToString() != "")
                {
                    model.PersonalStatusVisible = int.Parse(ds.Tables[0].Rows[0]["PersonalStatusVisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"] != null && ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString() == "1") || (ds.Tables[0].Rows[0]["PersonalStatusIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.PersonalStatusIndexVisible = true;
                    }
                    else
                    {
                        model.PersonalStatusIndexVisible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Grade"] != null && ds.Tables[0].Rows[0]["Grade"].ToString() != "")
                {
                    model.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Integral"] != null && ds.Tables[0].Rows[0]["Integral"].ToString() != "")
                {
                    model.Integral = int.Parse(ds.Tables[0].Rows[0]["Integral"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["Blong"] != null && ds.Tables[0].Rows[0]["Blong"].ToString() != "")
                {
                    model.Blong = ds.Tables[0].Rows[0]["Blong"].ToString();
                }
                if (ds.Tables[0].Rows[0]["height"] != null && ds.Tables[0].Rows[0]["height"].ToString() != "")
                {
                    model.height = int.Parse(ds.Tables[0].Rows[0]["height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["weight"] != null && ds.Tables[0].Rows[0]["weight"].ToString() != "")
                {
                    model.weight = int.Parse(ds.Tables[0].Rows[0]["weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Image"] != null && ds.Tables[0].Rows[0]["Image"].ToString() != "")
                {
                    model.Image = ds.Tables[0].Rows[0]["Image"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserCareer"] != null && ds.Tables[0].Rows[0]["UserCareer"].ToString() != "")
                {
                    model.UserCareer = ds.Tables[0].Rows[0]["UserCareer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserHobby"] != null && ds.Tables[0].Rows[0]["UserHobby"].ToString() != "")
                {
                    model.UserHobby = ds.Tables[0].Rows[0]["UserHobby"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TeachDescription"] != null && ds.Tables[0].Rows[0]["TeachDescription"].ToString() != "")
                {
                    model.TeachDescription = ds.Tables[0].Rows[0]["TeachDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名称获取用户ID
        /// </summary>
        /// <param name="strUserName">用户名称</param>
        /// <returns></returns>
        public int GetUserIDByUserName(string strUserName)
        {
            int iUserID = 0;
            string strSql = "Select UserID from Accounts_Users where UserName = '" + strUserName + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                iUserID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return iUserID;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserAvatar,Singature,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,UserRegionID,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Integral,PvCount,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Blong,height,weight,Image,UserCareer,UserHobby,TeachDescription,Balance,Tags ");
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
            strSql.Append(" UserID,UserAvatar,Singature,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,UserRegionID,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Integral,PvCount,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Blong,height,weight,Image,UserCareer,UserHobby,TeachDescription,Balance,Tags ");
            strSql.Append(" FROM Accounts_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetUserList(QueryUsers query)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
					new SqlParameter("@PageIndex", DbType.Int32),
					new SqlParameter("@PageSize", DbType.Int32),
					new SqlParameter("@SqlPopulate", DbType.String)
                };
            parameters[0].Value = query.PageIndex;
            parameters[1].Value = query.PageSize;
            parameters[2].Value = GetUserInfoListSql(query);

            using (IDataReader reader = DbHelperSQL.RunProcedure("sp_cc_Accounts_Users_Get", parameters))
            {
                dt = DbHelperSQL.ConverDataReaderToDataTable(reader);
            }
            return dt;
        }

        public string GetUserInfoListSql(QueryUsers query)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct AU.UserID FROM (Accounts_Users AU Left Join Accounts_UsersExp UE ON AU.UserID = UE.UserID) Left Join Accounts_UsersApprove UA ON UA.UserID = AU.UserID Where 1=1");

            if (!string.IsNullOrEmpty(query.Tags))
            {
                strSql.Append("AU.UserName like '%" + query.Tags + "%'");
            }
            return strSql.ToString();
        }

        public int GetUserCount(QueryUsers query)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(0) from (select AU.UserID FROM (Accounts_Users AU Left Join Accounts_UsersExp UE ON AU.UserID = UE.UserID) Left Join Accounts_UsersApprove UA ON UA.UserID = AU.UserID Where 1=1");

            if (!string.IsNullOrEmpty(query.Tags))
            {
                strSql.Append("AU.UserName like '%" + query.Tags + "%'");
            }
            strSql.Append(" Group By AU.UserID) AS T1");
            return int.Parse(DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString());
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
            parameters[0].Value = "Accounts_UsersExp";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}