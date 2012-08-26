/**
* IndexHandke.cs
*
* 功 能： [N/A]
* 类 名： IndexHandke
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/26 14:18:52  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Jayrock.Json;
using System.IO;

namespace Maticsoft.Web.AjaxHandle
{
    public class IndexHandke : IHttpHandler
    {
        public const string TAO_KEY_STATUS = "STATUS";
        public const string TAO_KEY_DATA = "DATA";

        public const string TAO_STATUS_SUCCESS = "SUCCESS";
        public const string TAO_STATUS_FAILED = "FAILED";
        public const string TAO_STATUS_ERROR = "ERROR";
        BLL.Tao.Courses coursesBLL = new BLL.Tao.Courses();
        BLL.Tao.OffLineCourse OffLinebll = new BLL.Tao.OffLineCourse();
        BLL.Tao.Comment bll = new BLL.Tao.Comment();
        Model.Tao.PageModel page = new Model.Tao.PageModel();
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["Action"];

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            try
            {
                switch (action)
                {
                    #region 推荐课程
                    case "Recommended":
                        RecommendedCourse(context);
                        break;
                    #endregion
                    #region 公开课
                    case "PubCourse":
                        PubCourseList(context);
                        break;
                    #endregion
                    #region 其他课程
                    case "OtherCourse":
                        OtherCourseList(context);
                        break;
                    #endregion
                    #region 名师推荐
                    case "TeaRec":
                        TeacherRecommended(context);
                        break;
                    #endregion
                    #region 评论内容
                    case "SelectPage":
                        IndexCommen(context);
                        break;
                    #endregion
                    #region 加载评论内容
                    case "FirstPage":
                        FirstPageCommen(context);
                        break;
                    #endregion
                    #region 加载评论内容
                    case "joinCom":
                        JoinComment(context);
                        break;
                    #endregion
                    #region 热门关键字
                    case "HotKey":
                        HotKey(context);
                        break;
                    #endregion
                    #region
                    case "ModuleList":
                        ShowCourseModule(context);
                        break;
                    #endregion
                    #region 视频评论分页
                    case "VideoComPage":
                        VideoCommen(context);
                        break;
                    #endregion
                    #region 视频评论信息
                    case "VideoCom":
                        VideoCommen(context);
                        break;
                    #endregion
                    #region 插入评论评论信息
                    case "InsertCom":
                        InsertComment(context);
                        break;
                    #endregion
                    #region 根据uid获取用户信息
                    case "UserInfo":
                        GetUserInfo(context);
                        break;
                    #endregion
                    #region 获取相关课程信息
                    case "RelateCourse":
                        RelateCourse(context);
                        break;
                    #endregion
                    #region 课程列表信息
                    case "GetCourseByCateID":
                        GetCourseByCateID(context);
                        break;
                    #endregion
                    #region 课程列表信息
                    case "GetCourseByKEY":
                        GetCourseByKEY(context);
                        break;
                    #endregion
                    #region 导航信息
                    case "GetCateNav":
                        GetCateNav(context);
                        break;
                    #endregion
                    #region 获取教师信息
                    case "GetTeacherCount":
                        GetTeacherCount(context);
                        break;
                    #endregion
                    #region 获取已关注该课程的人数
                    case "GetFavCount":
                        GetFavCount(context);
                        break;
                    #endregion
                    #region 获取已购买课程的人数
                    case "GetChoseCount":
                        GetChoseCount(context);
                        break;
                    #endregion
                    case "uploadico":
                        string strFileUrl = Maticsoft.Common.ConfigHelper.GetConfigString("CourseThumbnai");
                        UploadPic(context.Request, context.Response, strFileUrl);
                        break;
                    case "RelateTeacherCourse":
                        RelateTeacherCourse(context);
                        break;
                    case "GetCourseByUserID":
                        GetCourseByUserID(context);
                        break;
                    case "GetTeacherByKEY":
                        GetTeacherByKEY(context);
                        break;
                    case "GetTeachInfo":
                        GetTeachInfo(context);
                        break;
                    case "getCourseCount":
                        getCourseCount(context);
                        break;
                    case "GetAuthentic":
                        GetAuthentic(context);
                        break;

                    case "OffLineCourse":
                        OffLineCourse(context);
                        break;
                    case "RegionName":
                        RegionName(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                JsonObject json = new JsonObject();
                json.Put(TAO_KEY_STATUS, TAO_STATUS_ERROR);
                json.Put(TAO_KEY_DATA, ex);
                context.Response.Write(json.ToString());
            }
        }


        private void RegionName(HttpContext context)
        {
            BLL.Tao.Regions regionbll = new BLL.Tao.Regions();
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(context.Request.Params["regionId"]))
            {
                int rid = Common.Globals.SafeInt(context.Request.Params["regionId"], 0);

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, regionbll.GetRegionAllName(rid));
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void OffLineCourse(HttpContext context)
        {

            List<Maticsoft.Model.Tao.OffLineCourse> list = OffLinebll.GetModelList();
            JsonObject json = new JsonObject();
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(
                    new JsonObject(
                        new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "CategoryId", "RegionID" },
                        new object[] { info.CourseID, info.CourseName, info.StartTime.ToString("yyyy-MM-dd"), info.CoursePrice, info.PV, info.CreatedUserID, info.ImageURL, info.CategoryId, info.RegionID }
                        )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据关键字查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetAuthentic(HttpContext context)
        {


            string uid = context.Request.Params["uid"];
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(uid))
            {
                BLL.UserExp.UsersExp userBll = new BLL.UserExp.UsersExp();
                System.Data.DataSet dsUser = userBll.GetUserCertificate(int.Parse(uid), null, 1);
                System.Text.StringBuilder strAuthenticArray = new System.Text.StringBuilder();
                for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
                {
                    strAuthenticArray.Append(dsUser.Tables[0].Rows[i]["ApproveName"].ToString());
                    strAuthenticArray.Append("&nbsp;");
                }

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("COUNT", strAuthenticArray.ToString());
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据关键字查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void getCourseCount(HttpContext context)
        {


            string uid = context.Request.Params["uid"];
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(uid))
            {
                int count = coursesBLL.PublishCourseCount(int.Parse(uid));

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("COUNT", count);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }


        /// <summary>
        /// 根据关键字查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetTeachInfo(HttpContext context)
        {
            BLL.SysManage.UsersExp ubll = new BLL.SysManage.UsersExp();


            string uid = context.Request.Params["uid"];
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(uid))
            {
                List<Maticsoft.Model.UserExp.UsersExp> list = ubll.GetModelList(int.Parse(uid));
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "UserAvatar", "Tags" },
                            new object[] { info.UserAvatar, info.Tags }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据关键字查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetTeacherByKEY(HttpContext context)
        {
            BLL.SysManage.UsersExp ubll = new BLL.SysManage.UsersExp();
            int RowCount = 0;
            int PageCount = 0;

            string strIKey = context.Request.Params["StrKey"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = 7;


            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strIKey))
            {
                List<Maticsoft.Model.SysManage.Users> list = ubll.GetListByTeacherkey(out RowCount, out PageCount, strIKey, intPi, intPz);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "UserID", "UesrName", "TrueName" },
                            new object[] { info.UserID, info.UserName, info.TrueName }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }


        private void RelateTeacherCourse(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strId = context.Request.Params["CateId"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = Maticsoft.Common.Globals.SafeInt(context.Request.Params["pageSize"], 1);
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strId))
            {
                List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByTeacherID(out RowCount, out PageCount, int.Parse(strId), intPi, intPz);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                            new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }



        private void UploadPic(HttpRequest Request, HttpResponse Response, string strFileUrl)
        {
            HttpPostedFile file = Request.Files["Filedata"];
            if (file != null)
            {
                //文件夹是否存在
                string pathStr = HttpContext.Current.Server.MapPath("/" + strFileUrl);
                if (!Directory.Exists(pathStr))
                {
                    //不存在则自动创建文件夹
                    Directory.CreateDirectory(pathStr);
                }
                string ext = Path.GetExtension(file.FileName).ToLower();
                string fileName = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + ext;
                string savepath = pathStr + "/" + fileName;
                JsonObject json = new JsonObject();
                try
                {
                    file.SaveAs(savepath);
                    json.Accumulate("Status", "OK");
                    json.Accumulate("SavePath", "/" + strFileUrl + "/" + fileName);
                    Response.Write(("1|" + json.ToString()));
                }
                catch (Exception)
                {
                    json.Accumulate("Status", "Failed");
                    json.Accumulate("ErrorMessage", "系统忙，请稍后再试！");
                    Response.Write("0|" + json.ToString());
                }
            }
            else
            {
                JsonObject json = new JsonObject();
                json.Accumulate("Status", "Failed");
                json.Accumulate("ErrorMessage", " 系统忙，请稍后再试！");
                Response.Write("0|" + json.ToString());
            }
        }

        /// <summary>
        /// 获取已购买课程的人数
        /// </summary>
        /// <param name="context"></param>
        private void GetChoseCount(HttpContext context)
        {
            JsonObject json = new JsonObject();
            string strCid = context.Request.Params["cid"];
            if (!string.IsNullOrEmpty(strCid))
            {
                int counts = coursesBLL.GetSellCourseNum(int.Parse(strCid));

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("NUM", counts);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 获取已关注该课程的人数
        /// </summary>
        /// <param name="context"></param>
        private void GetFavCount(HttpContext context)
        {
            JsonObject json = new JsonObject();
            BLL.Tao.Favorite favoriteBLL = new BLL.Tao.Favorite();
            string strCid = context.Request.Params["cid"];
            if (!string.IsNullOrEmpty(strCid))
            {
                int counts = favoriteBLL.GetFavCourseCount(int.Parse(strCid));

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("NUM", counts);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 获取开课教师人数
        /// </summary>
        /// <param name="context"></param>
        private void GetTeacherCount(HttpContext context)
        {
            JsonObject json = new JsonObject();
            string strCid = context.Request.Params["cid"];
            if (!string.IsNullOrEmpty(strCid))
            {
                int counts = coursesBLL.GetTeacherCount(int.Parse(strCid));

                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("NUM", counts);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void GetCateNav(HttpContext context)
        {
            JsonObject json = new JsonObject();
            string strId = context.Request.Params["cateID"];
            int cateId = Common.Globals.SafeInt(strId, 0);
            BLL.Tao.Categories categoriesBLL = new BLL.Tao.Categories();
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            Maticsoft.Model.Tao.Categories model = categoriesBLL.GetModelByCache(cateId);
            if (null != model)
            {
                string[] strPath = model.Path.Split('|');
                str.Append(" 全部分类 ");
                foreach (string s in strPath)
                {
                    if (Maticsoft.Common.PageValidate.IsNumber(s))
                    {
                        Maticsoft.Model.Tao.Categories categoriesModel = categoriesBLL.GetModelByCache(int.Parse(s));
                        if (null != categoriesModel)
                        {
                            str.Append("&nbsp;&gt;&nbsp;" + categoriesModel.Name);
                        }
                    }
                }
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("NAV", str.ToString());
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据关键字查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetCourseByKEY(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strIKey = context.Request.Params["StrKey"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = 7;
            int OrderType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["SortT"], 0);
            int courseType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["CourseType"], 0);
            string strTime = context.Request.Params["TimeStr"];

            int? deptid = null;
            if (context.Request.Params["DPT"] != "null")
            {
                deptid = Maticsoft.Common.Globals.SafeInt(context.Request.Params["DPT"], -1);
            }

            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strIKey))
            {
                List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByKEY(out RowCount, out PageCount, strIKey, intPi, intPz, OrderType, strTime, courseType, deptid);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                            new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据分类ID查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetCourseByCateID(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strId = context.Request.Params["cateID"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = 7;
            int OrderType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["SortT"], 0);
            int courseType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["CourseType"], 0);
            string strTime = context.Request.Params["TimeStr"];

            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strId))
            {
                int CID = Common.Globals.SafeInt(strId, -1);
                if (courseType == 1)
                {
                    List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByCateId(out RowCount, out PageCount, CID, intPi, intPz, OrderType, strTime, courseType);
                    if (list.Count > 0)
                    {
                        JsonArray data = new JsonArray();
                        list.ForEach(info => data.Add(
                            new JsonObject(
                                new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                                new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                                )));
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                        json.Put(TAO_KEY_DATA, data);
                    }
                }
                else if (courseType == 2)
                {
                    BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();
                    List<Maticsoft.Model.Tao.SearchCourse> Offlist = bll.GetListByCateId(out RowCount, out PageCount, CID, intPi, intPz, OrderType, strTime);
                    if (Offlist.Count > 0)
                    {
                        JsonArray data = new JsonArray();
                        Offlist.ForEach(info => data.Add(
                            new JsonObject(
                                new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId", "BookCount" },
                                new object[] { info.Courseid, info.Coursename, info.StartTime.ToString("yyyy-MM-dd"), info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId,info.BookCount }
                                )));
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                        json.Put(TAO_KEY_DATA, data);
                    }
                }
                else
                {
                    List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByCateId(out RowCount, out PageCount, CID, intPi, intPz, OrderType, strTime, courseType);
                    if (list.Count > 0)
                    {
                        JsonArray data = new JsonArray();
                        list.ForEach(info => data.Add(
                            new JsonObject(
                                new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                                new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                                )));
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                        json.Put(TAO_KEY_DATA, data);
                    }
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        /// <summary>
        /// 根据分类ID查询课程信息
        /// </summary>
        /// <param name="context"></param>
        private void GetCourseByUserID(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strId = context.Request.Params["uid"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = 7;
            int OrderType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["SortT"], 0);
            int courseType = Maticsoft.Common.Globals.SafeInt(context.Request.Params["CourseType"], 0);
            string strTime = "0";

            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strId))
            {
                int CID = Common.Globals.SafeInt(strId, -1);
                List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByuserID(out RowCount, out PageCount, CID, intPi, intPz, OrderType, strTime, courseType);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                            new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }


        private void RelateCourse(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strId = context.Request.Params["CateId"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = Maticsoft.Common.Globals.SafeInt(context.Request.Params["pageSize"], 1);
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strId))
            {
                List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListByCateId(out RowCount, out PageCount, int.Parse(strId), intPi, intPz);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                            new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void GetUserInfo(HttpContext context)
        {
            JsonObject json = new JsonObject();
            string strUid = context.Request.Params["Uid"];
            if (!string.IsNullOrEmpty(strUid))
            {
                BLL.UserExp.UsersExp user = new BLL.UserExp.UsersExp();
                DataSet ds = user.GetUserInfo(int.Parse(strUid));
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        json.Put("UserName", ds.Tables[0].Rows[0]["UserName"]);
                        json.Put("UserAvatar", ds.Tables[0].Rows[0]["UserAvatar"]);
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    }
                    else
                    {
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                    }
                }
                else
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void InsertComment(HttpContext context)
        {
            JsonObject json = new JsonObject();
            string strMid = context.Request.Params["Mid"];
            string strCid = context.Request.Params["Cid"];
            string strUid = context.Request.Params["Uid"];
            string strPid = context.Request.Params["Pid"];//
            string strCtype = context.Request.Params["Ctype"];

            string strContent = context.Request.Params["Con"];
            if (!string.IsNullOrEmpty(strMid) && !string.IsNullOrEmpty(strCid) && !string.IsNullOrEmpty(strUid) && !string.IsNullOrEmpty(strPid))
            {
                Model.Tao.Comment model = new Model.Tao.Comment();
                model.CourseID = int.Parse(strCid);
                if (strMid != "null")
                {
                    model.ModuleID = int.Parse(strMid);
                }
                model.UserID = int.Parse(strUid);
                model.ParentID = int.Parse(strPid);
                model.Comments = strContent;
                model.Status = 1;
                model.CommentDate = DateTime.Now;
                model.Type = Common.Globals.SafeInt(strCtype, 0);
                int comId = bll.Add(model);
                if (comId > 0)
                {
                    List<Maticsoft.Model.Tao.Comment> list = bll.GetModelList(comId);
                    if (list.Count > 0)
                    {
                        JsonArray data = new JsonArray();
                        list.ForEach(info => data.Add(new JsonObject(
                            new string[] { "CommentID", "OrderID", "CourseID", "ModuleID", "UserID", "CommentInfo", "CommentDate", "ParentID", "Score", "Status" },
                            new object[] { info.CommentID, info.OrderID, info.CourseID, info.ModuleID, info.UserID, info.Comments, info.CommentDate.ToString("yyyy-MM-dd HH:mm:ss"), info.ParentID, info.Score, info.Status }
                            )));
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                        json.Put(TAO_KEY_DATA, data);
                    }
                    else
                    {
                        json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                    }
                }
                else
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_ERROR);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_ERROR);
            }
            context.Response.Write(json.ToString());
        }

        private void VideoCommen(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;
            JsonObject json = new JsonObject();

            string strIndex = context.Request.Params["PageIndex"];
            string strMid = context.Request.Params["Mid"];
            string strCid = context.Request.Params["Cid"];
            string strCtype = context.Request.Params["Ctype"];
            int type = Common.Globals.SafeInt(strCtype, 0);
            page.PageIndex = Common.Globals.SafeInt(strIndex, 1);
            page.PageSize = 10;
            if (!string.IsNullOrEmpty(strMid) && strMid != "null")
            {
                page.Moduleid = int.Parse(strMid);
            }
            if (!string.IsNullOrEmpty(strCid) && strCid != "null")
            {
                page.Courseid = int.Parse(strCid);
            }
            List<Maticsoft.Model.Tao.Comment> list = bll.GetCommentList(out RowCount, out PageCount, page, type);
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                    new string[] { "CommentID", "OrderID", "CourseID", "ModuleID", "UserID", "CommentInfo", "CommentDate", "ParentID", "Score", "Status", "CCount" },
                    new object[] { info.CommentID, info.OrderID, info.CourseID, info.ModuleID, info.UserID, info.Comments, info.CommentDate.ToString("yyyy-MM-dd HH:mm:ss"), info.ParentID, info.Score, info.Status, info.CCount }
                    )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void ShowCourseModule(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;
            BLL.Tao.Modules mbll = new BLL.Tao.Modules();
            string strCid = context.Request.Params["cid"];
            string strIndex = context.Request.Params["PageIndex"];
            int PageIndex = Common.Globals.SafeInt(strIndex, 1);
            int PageSize = 10;
            JsonObject json = new JsonObject();
            List<Maticsoft.Model.Tao.Modules> list = mbll.GetCourseList(int.Parse(strCid), out RowCount, out PageCount, PageIndex, PageSize);
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                    new string[] { "Sequence", "ModuleName", "TrueName", "TimeDuration", "Price", "ModuleID" },
                    new object[] { info.Sequence, info.ModuleName, info.TrueName, info.TimeDuration, info.Price, info.ModuleID }
                    )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void HotKey(HttpContext context)
        {
            JsonObject json = new JsonObject();
            List<Maticsoft.Model.Tao.Courses> list = coursesBLL.GetHotKey();
            if (list != null)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                    new string[] { "Tags" },
                    new object[] { info.Tags }
                    )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void JoinComment(HttpContext context)
        {
            string strPid = context.Request.Params["ParentID"];
            JsonObject json = new JsonObject();
            List<Maticsoft.Model.Tao.Comment> list = bll.GetChildComment(int.Parse(strPid));
            if (list != null)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                    new string[] { "CommentID", "OrderID", "CourseID", "ModuleID", "UserID", "CommentInfo", "CommentDate", "ParentID", "Score", "Status" },
                    new object[] { info.CommentID, info.OrderID, info.CourseID, info.ModuleID, info.UserID, info.Comments, info.CommentDate.ToString("yyyy-MM-dd HH:mm:ss"), info.ParentID, info.Score, info.Status }
                    )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void FirstPageCommen(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;
            JsonObject json = new JsonObject();

            string strIndex = context.Request.Params["PageIndex"];
            page.PageIndex = Common.Globals.SafeInt(strIndex, 1);
            page.PageSize = 10;
            List<Maticsoft.Model.Tao.Comment> list = bll.GetCommentList(out RowCount, out PageCount, page, -1);
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                    new string[] { "CommentID", "OrderID", "CourseID", "ModuleID", "UserID", "CommentInfo", "CommentDate", "ParentID", "Score", "Status", "CCount" },
                    new object[] { info.CommentID, info.OrderID, info.CourseID, info.ModuleID, info.UserID, info.Comments, info.CommentDate.ToString("yyyy-MM-dd HH:mm:ss"), info.ParentID, info.Score, info.Status, info.CCount }
                    )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void IndexCommen(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;
            JsonObject json = new JsonObject();
            BLL.Tao.Comment bll = new BLL.Tao.Comment();
            Model.Tao.PageModel page = new Model.Tao.PageModel();
            page.PageIndex = 1;
            page.PageSize = 10;
            List<Maticsoft.Model.Tao.Comment> list = bll.GetCommentList(out RowCount, out PageCount, page, -1);
            if (list.Count > 0)
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void TeacherRecommended(HttpContext context)
        {
            string topStr = context.Request.Params["TopNum"];
            int topNum = Common.Globals.SafeInt(topStr, 0);
            BLL.UserExp.UsersExp userBll = new BLL.UserExp.UsersExp();
            DataSet ds = userBll.GetReTeacher(topNum);
            JsonObject json = new JsonObject();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    data.Add(ds.Tables[0]);
                    json.Put(TAO_KEY_DATA, data);
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                }
                else
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void OtherCourseList(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;

            string strId = context.Request.Params["CateId"];
            string strPi = context.Request.Params["pageIndex"];
            int intPi = 0;
            if (!int.TryParse(strPi, out intPi))//将字符串页码 转成 整型页码，如果失败，设置页码为1
            {
                intPi = 1;
            }
            int intPz = Maticsoft.Common.Globals.SafeInt(context.Request.Params["pageSize"], 1);
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(strId))
            {
                List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListCateId(out RowCount, out PageCount, int.Parse(strId), intPi, intPz, false);
                if (list.Count > 0)
                {
                    JsonArray data = new JsonArray();
                    list.ForEach(info => data.Add(
                        new JsonObject(
                            new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                            new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                            )));
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, data);
                }
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void RecommendedCourse(HttpContext context)
        {
            List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetRecommendedCourseList(4);
            JsonObject json = new JsonObject();
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(
                    new JsonObject(
                        new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                        new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                        )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }


        private void PubCourseList(HttpContext context)
        {
            int RowCount = 0;
            int PageCount = 0;
            List<Maticsoft.Model.Tao.SearchCourse> list = coursesBLL.GetListCateId(out RowCount, out PageCount, 34, null, null, true);
            JsonObject json = new JsonObject();
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(
                    new JsonObject(
                        new string[] { "CourseID", "CourseName", "TimeDuration", "Price", "PV", "CreatedUserID", "ImageUrl", "TrueName", "DepartmentID", "NAME", "CategoryId" },
                        new object[] { info.Courseid, info.Coursename, info.Timeduration, info.Price, info.Pv, info.Createduserid, info.Imageurl, info.TrueName, info.DepartmentId, info.EnterName, info.CategoryId }
                        )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }
    }
}