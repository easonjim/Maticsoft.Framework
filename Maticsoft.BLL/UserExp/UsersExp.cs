using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Model;

namespace Maticsoft.BLL.UserExp
{
    /// <summary>
    /// UsersExp
    /// </summary>
    public partial class UsersExp
    {
        private readonly Maticsoft.DAL.UserExp.UsersExp dal = new Maticsoft.DAL.UserExp.UsersExp();

        public UsersExp()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.UserExp.UsersExp model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.UserExp.UsersExp model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            return dal.Delete(UserID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserExp.UsersExp GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 根据用户名称获取用户ID
        /// </summary>
        /// <param name="strUserName">用户名称</param>
        /// <returns></returns>
        public int GetUserIDByUserName(string strUserName)
        {
            return dal.GetUserIDByUserName(strUserName);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.UserExp.UsersExp GetModelByCache(int UserID)
        {
            string CacheKey = "UsersExpModel-" + UserID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.UserExp.UsersExp)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataTable GetUserList(QueryUsers query)
        {
            return dal.GetUserList(query);
        }

        public int GetUserCount(QueryUsers query)
        {
            return dal.GetUserCount(query);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.UserExp.UsersExp> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.UserExp.UsersExp> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.UserExp.UsersExp> modelList = new List<Maticsoft.Model.UserExp.UsersExp>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.UserExp.UsersExp model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.UserExp.UsersExp();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserAvatar"] != null && dt.Rows[n]["UserAvatar"].ToString() != "")
                    {
                        model.UserAvatar = dt.Rows[n]["UserAvatar"].ToString();
                    }
                    if (dt.Rows[n]["Singature"] != null && dt.Rows[n]["Singature"].ToString() != "")
                    {
                        model.Singature = dt.Rows[n]["Singature"].ToString();
                    }
                    if (dt.Rows[n]["Birthday"] != null && dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    if (dt.Rows[n]["BirthdayVisible"] != null && dt.Rows[n]["BirthdayVisible"].ToString() != "")
                    {
                        model.BirthdayVisible = int.Parse(dt.Rows[n]["BirthdayVisible"].ToString());
                    }
                    if (dt.Rows[n]["BirthdayIndexVisible"] != null && dt.Rows[n]["BirthdayIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BirthdayIndexVisible"].ToString() == "1") || (dt.Rows[n]["BirthdayIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.BirthdayIndexVisible = true;
                        }
                        else
                        {
                            model.BirthdayIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["Constellation"] != null && dt.Rows[n]["Constellation"].ToString() != "")
                    {
                        model.Constellation = dt.Rows[n]["Constellation"].ToString();
                    }
                    if (dt.Rows[n]["ConstellationVisible"] != null && dt.Rows[n]["ConstellationVisible"].ToString() != "")
                    {
                        model.ConstellationVisible = int.Parse(dt.Rows[n]["ConstellationVisible"].ToString());
                    }
                    if (dt.Rows[n]["ConstellationIndexVisible"] != null && dt.Rows[n]["ConstellationIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ConstellationIndexVisible"].ToString() == "1") || (dt.Rows[n]["ConstellationIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.ConstellationIndexVisible = true;
                        }
                        else
                        {
                            model.ConstellationIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["NativePlace"] != null && dt.Rows[n]["NativePlace"].ToString() != "")
                    {
                        model.NativePlace = dt.Rows[n]["NativePlace"].ToString();
                    }
                    if (dt.Rows[n]["NativePlaceVisible"] != null && dt.Rows[n]["NativePlaceVisible"].ToString() != "")
                    {
                        model.NativePlaceVisible = int.Parse(dt.Rows[n]["NativePlaceVisible"].ToString());
                    }
                    if (dt.Rows[n]["NativePlaceIndexVisible"] != null && dt.Rows[n]["NativePlaceIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["NativePlaceIndexVisible"].ToString() == "1") || (dt.Rows[n]["NativePlaceIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.NativePlaceIndexVisible = true;
                        }
                        else
                        {
                            model.NativePlaceIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["UserRegionID"] != null && dt.Rows[n]["UserRegionID"].ToString() != "")
                    {
                        model.UserRegionID = int.Parse(dt.Rows[n]["UserRegionID"].ToString());
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["AddressVisible"] != null && dt.Rows[n]["AddressVisible"].ToString() != "")
                    {
                        model.AddressVisible = int.Parse(dt.Rows[n]["AddressVisible"].ToString());
                    }
                    if (dt.Rows[n]["AddressIndexVisible"] != null && dt.Rows[n]["AddressIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["AddressIndexVisible"].ToString() == "1") || (dt.Rows[n]["AddressIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.AddressIndexVisible = true;
                        }
                        else
                        {
                            model.AddressIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["BodilyForm"] != null && dt.Rows[n]["BodilyForm"].ToString() != "")
                    {
                        model.BodilyForm = dt.Rows[n]["BodilyForm"].ToString();
                    }
                    if (dt.Rows[n]["BodilyFormVisible"] != null && dt.Rows[n]["BodilyFormVisible"].ToString() != "")
                    {
                        model.BodilyFormVisible = int.Parse(dt.Rows[n]["BodilyFormVisible"].ToString());
                    }
                    if (dt.Rows[n]["BodilyFormIndexVisible"] != null && dt.Rows[n]["BodilyFormIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BodilyFormIndexVisible"].ToString() == "1") || (dt.Rows[n]["BodilyFormIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.BodilyFormIndexVisible = true;
                        }
                        else
                        {
                            model.BodilyFormIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["BloodType"] != null && dt.Rows[n]["BloodType"].ToString() != "")
                    {
                        model.BloodType = dt.Rows[n]["BloodType"].ToString();
                    }
                    if (dt.Rows[n]["BloodTypeVisible"] != null && dt.Rows[n]["BloodTypeVisible"].ToString() != "")
                    {
                        model.BloodTypeVisible = int.Parse(dt.Rows[n]["BloodTypeVisible"].ToString());
                    }
                    if (dt.Rows[n]["BloodTypeIndexVisible"] != null && dt.Rows[n]["BloodTypeIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BloodTypeIndexVisible"].ToString() == "1") || (dt.Rows[n]["BloodTypeIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.BloodTypeIndexVisible = true;
                        }
                        else
                        {
                            model.BloodTypeIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["Marriaged"] != null && dt.Rows[n]["Marriaged"].ToString() != "")
                    {
                        model.Marriaged = dt.Rows[n]["Marriaged"].ToString();
                    }
                    if (dt.Rows[n]["MarriagedVisible"] != null && dt.Rows[n]["MarriagedVisible"].ToString() != "")
                    {
                        model.MarriagedVisible = int.Parse(dt.Rows[n]["MarriagedVisible"].ToString());
                    }
                    if (dt.Rows[n]["MarriagedIndexVisible"] != null && dt.Rows[n]["MarriagedIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["MarriagedIndexVisible"].ToString() == "1") || (dt.Rows[n]["MarriagedIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.MarriagedIndexVisible = true;
                        }
                        else
                        {
                            model.MarriagedIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["PersonalStatus"] != null && dt.Rows[n]["PersonalStatus"].ToString() != "")
                    {
                        model.PersonalStatus = dt.Rows[n]["PersonalStatus"].ToString();
                    }
                    if (dt.Rows[n]["PersonalStatusVisible"] != null && dt.Rows[n]["PersonalStatusVisible"].ToString() != "")
                    {
                        model.PersonalStatusVisible = int.Parse(dt.Rows[n]["PersonalStatusVisible"].ToString());
                    }
                    if (dt.Rows[n]["PersonalStatusIndexVisible"] != null && dt.Rows[n]["PersonalStatusIndexVisible"].ToString() != "")
                    {
                        if ((dt.Rows[n]["PersonalStatusIndexVisible"].ToString() == "1") || (dt.Rows[n]["PersonalStatusIndexVisible"].ToString().ToLower() == "true"))
                        {
                            model.PersonalStatusIndexVisible = true;
                        }
                        else
                        {
                            model.PersonalStatusIndexVisible = false;
                        }
                    }
                    if (dt.Rows[n]["Grade"] != null && dt.Rows[n]["Grade"].ToString() != "")
                    {
                        model.Grade = int.Parse(dt.Rows[n]["Grade"].ToString());
                    }
                    if (dt.Rows[n]["Integral"] != null && dt.Rows[n]["Integral"].ToString() != "")
                    {
                        model.Integral = int.Parse(dt.Rows[n]["Integral"].ToString());
                    }
                    if (dt.Rows[n]["PvCount"] != null && dt.Rows[n]["PvCount"].ToString() != "")
                    {
                        model.PvCount = int.Parse(dt.Rows[n]["PvCount"].ToString());
                    }
                    if (dt.Rows[n]["LastAccessTime"] != null && dt.Rows[n]["LastAccessTime"].ToString() != "")
                    {
                        model.LastAccessTime = DateTime.Parse(dt.Rows[n]["LastAccessTime"].ToString());
                    }
                    if (dt.Rows[n]["LastAccessIP"] != null && dt.Rows[n]["LastAccessIP"].ToString() != "")
                    {
                        model.LastAccessIP = dt.Rows[n]["LastAccessIP"].ToString();
                    }
                    if (dt.Rows[n]["LastPostTime"] != null && dt.Rows[n]["LastPostTime"].ToString() != "")
                    {
                        model.LastPostTime = DateTime.Parse(dt.Rows[n]["LastPostTime"].ToString());
                    }
                    if (dt.Rows[n]["LastLoginTime"] != null && dt.Rows[n]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(dt.Rows[n]["LastLoginTime"].ToString());
                    }
                    if (dt.Rows[n]["Blong"] != null && dt.Rows[n]["Blong"].ToString() != "")
                    {
                        model.Blong = dt.Rows[n]["Blong"].ToString();
                    }
                    if (dt.Rows[n]["height"] != null && dt.Rows[n]["height"].ToString() != "")
                    {
                        model.height = int.Parse(dt.Rows[n]["height"].ToString());
                    }
                    if (dt.Rows[n]["weight"] != null && dt.Rows[n]["weight"].ToString() != "")
                    {
                        model.weight = int.Parse(dt.Rows[n]["weight"].ToString());
                    }
                    if (dt.Rows[n]["Image"] != null && dt.Rows[n]["Image"].ToString() != "")
                    {
                        model.Image = dt.Rows[n]["Image"].ToString();
                    }
                    if (dt.Rows[n]["UserCareer"] != null && dt.Rows[n]["UserCareer"].ToString() != "")
                    {
                        model.UserCareer = dt.Rows[n]["UserCareer"].ToString();
                    }
                    if (dt.Rows[n]["UserHobby"] != null && dt.Rows[n]["UserHobby"].ToString() != "")
                    {
                        model.UserHobby = dt.Rows[n]["UserHobby"].ToString();
                    }
                    if (dt.Rows[n]["TeachDescription"] != null && dt.Rows[n]["TeachDescription"].ToString() != "")
                    {
                        model.TeachDescription = dt.Rows[n]["TeachDescription"].ToString();
                    }
                    if (dt.Rows[n]["Balance"] != null && dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion Method
    }
}