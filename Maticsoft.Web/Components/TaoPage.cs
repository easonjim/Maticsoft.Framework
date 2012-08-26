using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.Components
{
    public class TaoPage : System.Web.UI.Page
    {
        #region MyRegion
        private int userId = -1;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int courseId = 0;
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        #endregion

        private void InitializeComponent()
        {
            //检测用户是否登录
            if (!Common.CommonCode.CheckUserLogin())
            {
                //没有登录,把用户导向登录页面
                Common.CommonCode.GoLoginPage();
                return;
            }
            else
            {
                Maticsoft.Accounts.Bus.User user = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                UserId = user.UserID;
            }
        }
    }
}