using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Security;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web
{
    public class UserControlBase : System.Web.UI.UserControl
    {
        #region 权限控制
        

        //子类通过 new 重写该值        
        protected int Act_ShowInvalid = 2; //查看失效数据        
                        
                
        /// <summary>
        ///  权限角色验证对象
        /// </summary>
        public AccountsPrincipal UserPrincipal
        {
            get
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    return new AccountsPrincipal(Context.User.Identity.Name);
                }
                else
                {
                    return null;
                }
            }
        }

        //private Maticsoft.Accounts.Bus.User currentUser;
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Maticsoft.Accounts.Bus.User CurrentUser
        {
            get
            {
                if (Session["UserInfo"] == null)
                {
                    if (UserPrincipal != null)
                    {
                        return new Maticsoft.Accounts.Bus.User(UserPrincipal);
                    }
                    else
                    {
                        return new User();
                    }

                }
                else
                {
                    return (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                    
                }
            }
        }


        #endregion


        #region 公共方法

        /// <summary>
        /// 根据功能行为编号得到所属权限编号
        /// </summary>
        /// <returns></returns>
        public int GetPermidByActID(int ActionID)
        {            
            Actions bllAction = new Actions();        
            Hashtable ActHashtab=bllAction.GetHashListByCache();            
            object obj = ActHashtab[ActionID.ToString()];
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
        }

        #endregion 

    }
}