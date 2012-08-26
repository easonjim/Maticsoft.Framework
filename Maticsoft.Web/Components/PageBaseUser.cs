using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Security;
using Maticsoft.Accounts.Bus;
using System.IO;
using System.Globalization;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    /// <summary>
    /// 需要权限验证的页面基类：如用户中心
    /// </summary>
    public class PageBaseUser : PageBase
    {
        #region 权限控制
        //子类通过 new 重写该值
        //protected int Act_DeleteList = 1; //批量删除按钮       
        protected int permissionid = -1;
        BLL.Tao.Courses CourseBLL = new BLL.Tao.Courses();
        /// <summary>
        /// 页面访问需要的权限。可以在不同页面继承里来控制不同页面的权限。默认-1为无限制。
        /// </summary>
        public int PermissionID
        {
            set
            {
                permissionid = value;
            }
            get
            {
                return permissionid;
            }
        }

        #endregion
        
        #region 初始化
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ValidatingPermission();
        }
        private void ValidatingPermission()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                if ((PermissionID != -1) && (!userPrincipal.HasPermissionID(PermissionID)))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + Resources.Site.TooltipNoPermission + "');history.back();</script>");
                    Response.End();
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Clear();
                //Response.Write("<script defer>window.alert('请先登录！');parent.location='" + defaullogin + "';</script>");
                Response.Redirect(defaullogin);
                //Response.Write("<script defer>parent.location='" + defaullogin + "';</script>");
                Response.End();
            }
        }

        #endregion

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetImage(object obj, int height, int width)
        {
            string strImgUrl = "";
            if (null != obj && !string.IsNullOrEmpty(obj.ToString()))
            {
                strImgUrl = "<a href=\"" + StringPlus.TrimStart(obj.ToString(), "~") + "\" Target=\"_blank\"><img src=\"" + StringPlus.TrimStart(obj.ToString(), "~") + "\" style=\" height:" + height + "px;width:" + width + "px;border:none;\" /></a>";
            }
            else
            {
                strImgUrl = "<img src=\"../images/none.gif\" style=\" height:" + height + "px;width:" + width + "px\"/>";
            }
            return strImgUrl;
        }

        /// <summary>
        /// 获得审核状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetStatus(object obj)
        {
            System.Text.StringBuilder strStatus = new System.Text.StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strStatus.Append("未审核");
                            break;
                        case 1:
                            strStatus.Append("审核通过");
                            break;
                        case 2:
                            strStatus.Append("认证失败");
                            break;
                        default:
                            strStatus.Append("未定义的类型");
                            break;
                    }
                }
            }
            return strStatus.ToString();
        }

        /// <summary>
        /// 企业状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetEnterpriseState(object obj)
        {
            System.Text.StringBuilder strEnterpriseState = new System.Text.StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strEnterpriseState.Append("未审核");
                            break;
                        case 1:
                            strEnterpriseState.Append("正常");
                            break;
                        case 2:
                            strEnterpriseState.Append("冻结");
                            break;
                        default:
                            strEnterpriseState.Append("未定义");
                            break;
                    }
                }
            }
            return strEnterpriseState.ToString();
        }

        /// <summary>
        /// 根据CourseID获取CourseName
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public string GetCourseName(object intValue)
        {
            System.Text.StringBuilder strModuleName = new System.Text.StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    Model.Tao.Courses CourseModel = CourseBLL.GetCourseName(Convert.ToInt32(intValue));
                    if (CourseModel != null)
                    {
                        strModuleName.Append(CourseModel.CourseName);
                    }
                }
            }
            return strModuleName.ToString();
        }
    }
}