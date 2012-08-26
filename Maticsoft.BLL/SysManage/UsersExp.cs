using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model.SysManage;


namespace Maticsoft.BLL.SysManage
{
    /// <summary>
    /// 用户扩展类，继承了USER类相关属性和方法
    /// </summary>
    public class UsersExp : Maticsoft.Model.SysManage.UsersExpModel
    {
        private readonly Maticsoft.DAL.SysManage.UsersExp dal = new DAL.SysManage.UsersExp();

        #region  Method

        /// <summary>
        /// 增加用户扩展数据
        /// </summary>
        public bool AddUsersExp(Maticsoft.Model.SysManage.UsersExpModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新用户扩展数据
        /// </summary>
        public bool UpdateUsersExp(Maticsoft.Model.SysManage.UsersExpModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除用户扩展数据
        /// </summary>
        public bool DeleteUsersExp(int UserID)
        {

            return dal.Delete(UserID);
        }

        /// <summary>
        /// 删除用户扩展数据
        /// </summary>
        public bool DeleteListUsersExp(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到用户扩展实体
        /// </summary>
        public Maticsoft.Model.SysManage.UsersExpModel GetUsersExpModel(int UserID)
        {
            return dal.GetModel(UserID);
        }


        /// <summary>
        /// 得到用户全部属性信息实体
        /// </summary>
        public Maticsoft.Model.SysManage.UsersExpModel GetUsersModel(int UserID)
        {
            //Users
            Maticsoft.Model.SysManage.UsersExpModel model = dal.GetModel(UserID);
            if (model == null)
            {
                model = new UsersExpModel();
            }
            Maticsoft.Accounts.Bus.User user = new Accounts.Bus.User(UserID);
            model.Activity = user.Activity;
            model.DepartmentID = user.DepartmentID;
            model.Email = user.Email;
            model.EmployeeID = user.EmployeeID;
            model.Phone = user.Phone;
            model.Sex = user.Sex;
            model.Style = user.Style;
            model.TrueName = user.TrueName;
            model.User_cLang = user.User_cLang;
            model.User_dateApprove = user.User_dateApprove;
            model.User_dateCreate = user.User_dateCreate;
            model.User_dateExpire = user.User_dateExpire;
            model.User_dateValid = user.User_dateValid;
            model.User_iApprover = user.User_iApprover;
            model.User_iApproveState = user.User_iApproveState;
            model.User_iCreator = user.User_iCreator;
            model.UserID = user.UserID;
            model.UserName = user.UserName;
            model.UserType = user.UserType;
            return model;
        }



        /// <summary>
        /// 得到用户扩展实体，从缓存中
        /// </summary>
        public Maticsoft.Model.SysManage.UsersExpModel GetUsersExpModelByCache(int UserID)
        {

            string CacheKey = "UsersExpModel-" + UserID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetUsersModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.SysManage.UsersExpModel)objModel;
        }

        /// <summary>
        /// 获得用户扩展数据列表
        /// </summary>
        public DataSet GetUsersExpList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得用户扩展数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.UsersExpModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 获得用户扩展数据列表
        /// </summary>
        public List<Maticsoft.Model.UserExp.UsersExp> GetModelList(int uid)
        {
            DataSet ds = dal.GetList(" UserID=" + uid);
            return DataTList(ds.Tables[0]);
        }



        /// <summary>
        /// 获得用户扩展数据列表
        /// </summary>
        public List<Maticsoft.Model.UserExp.UsersExp> DataTList(DataTable dt)
        {
            List<Maticsoft.Model.UserExp.UsersExp> modelList = new List<Maticsoft.Model.UserExp.UsersExp>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.UserExp.UsersExp model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.UserExp.UsersExp();
                    if (dt.Rows[n]["UserAvatar"] != null && dt.Rows[n]["UserAvatar"].ToString() != "")
                    {
                        model.UserAvatar = dt.Rows[n]["UserAvatar"].ToString();
                    }

                    if (dt.Rows[0]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得用户扩展数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.UsersExpModel> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.SysManage.UsersExpModel> modelList = new List<Maticsoft.Model.SysManage.UsersExpModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SysManage.UsersExpModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.SysManage.UsersExpModel();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Gravatar"] != null && dt.Rows[n]["Gravatar"].ToString() != "")
                    {
                        model.Gravatar = dt.Rows[n]["Gravatar"].ToString();
                    }
                    if (dt.Rows[n]["Singature"] != null && dt.Rows[n]["Singature"].ToString() != "")
                    {
                        model.Singature = dt.Rows[n]["Singature"].ToString();
                    }
                    if (dt.Rows[n]["TelPhone"] != null && dt.Rows[n]["TelPhone"].ToString() != "")
                    {
                        model.TelPhone = dt.Rows[n]["TelPhone"].ToString();
                    }
                    if (dt.Rows[n]["QQ"] != null && dt.Rows[n]["QQ"].ToString() != "")
                    {
                        model.QQ = dt.Rows[n]["QQ"].ToString();
                    }
                    if (dt.Rows[n]["MSN"] != null && dt.Rows[n]["MSN"].ToString() != "")
                    {
                        model.MSN = dt.Rows[n]["MSN"].ToString();
                    }
                    if (dt.Rows[n]["HomePage"] != null && dt.Rows[n]["HomePage"].ToString() != "")
                    {
                        model.HomePage = dt.Rows[n]["HomePage"].ToString();
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
                    if (dt.Rows[n]["RegionId"] != null && dt.Rows[n]["RegionId"].ToString() != "")
                    {
                        model.RegionId = int.Parse(dt.Rows[n]["RegionId"].ToString());
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
                    if (dt.Rows[n]["Balance"] != null && dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    if (dt.Rows[n]["Points"] != null && dt.Rows[n]["Points"].ToString() != "")
                    {
                        model.Points = int.Parse(dt.Rows[n]["Points"].ToString());
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
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["TeachDescription"] != null && dt.Rows[n]["TeachDescription"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["TeachDescription"].ToString();
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SysManage.Users> GetListByTeacherkey(out int rowCount, out int pageCount, string key, int? PageIndex, int? PageSize)
        {
            return dal.GetListByTeacherkey(out rowCount, out pageCount, key, PageIndex, PageSize);
        }
    }
}
