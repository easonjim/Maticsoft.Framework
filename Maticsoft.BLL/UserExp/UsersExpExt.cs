using System.Data;

namespace Maticsoft.BLL.UserExp
{
    public partial class UsersExp
    {
        /// <summary>
        /// 是否存在该用户名
        /// </summary>
        public bool ExistsUserName(string ColsName, string ColType)
        {
            return dal.ExistsUserName(ColsName, ColType);
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateGravatar(Model.UserExp.UsersExp model)
        {
            return dal.UpdateGravatar(model);
        }

        /// <summary>
        /// 更新用户基本资料--PersonalInfor.aspx
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int UpDateUserInfo(string TrueName, string Sex, string Phone, Model.UserExp.UsersExp ExpModel)
        {
            return dal.UpDateUserInfo(TrueName, Sex, Phone, ExpModel);
        }

        /// <summary>
        /// 得到一个结果集
        /// </summary>
        public DataSet GetUserExpModel(int userID)
        {
            return dal.GetUserExpModel(userID);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        public int UpDatePwd(int uid, byte[] newPwd)
        {
            return dal.UpDatePwd(uid, newPwd);
        }

        /// <summary>
        /// 修改教师名称和教师简介信息
        /// </summary>
        /// <param name="TrueName">教师名称</param>
        /// <param name="dec">教师简介</param>
        /// <param name="UserId">教师ID</param>
        /// <returns></returns>
        public bool EditUesInfo(string TrueName, string dec, int UserId, string DeprtName)
        {
            return dal.EditUesInfo(TrueName, dec, UserId, DeprtName);
        }

        public bool UpdateTeacherAc(string imgPath, int uid)
        {
            return dal.UpdateTeacherAc(imgPath, uid);
        }

        /// <summary>
        /// 获取用户认证状态
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="iAuthenticType">认证类型</param>
        /// <param name="iStatus">认证状态</param>
        /// <returns>DataSet</returns>
        public DataSet GetUserCertificate(int? iUserId, int? iAuthenticType, int? iStatus)
        {
            return dal.GetUserCertificate(iUserId, iAuthenticType, iStatus);
        }

        /// <summary>
        /// 检测邮箱是否已经注册
        /// </summary>
        /// <param name="Email">将要注册的Email地址</param>
        /// <returns></returns>
        public bool EmailExist(string Email)
        {
            return dal.EmailExist(Email);
        }

        /// <summary>
        /// 更新教师主页中的标签和教师简介
        /// </summary>
        public bool UpdateTeacher(string description, string tags, int userId)
        {
            return dal.UpdateTeacher(description, tags, userId);
        }

        public DataSet SearchTeacher(string keyStr)
        {
            return dal.SearchTeacher(keyStr);
        }

        public DataSet ApproveStatue(int uid)
        {
            return dal.ApproveStatue(uid);
        }

        public int SumCourseCount(int uid)
        {
            return dal.SumCourseCount(uid);
        }

        public int GetUserBalance(int UserId)
        {
            return dal.GetUserBalance(UserId);
        }

        public string GetUname(int Uid)
        {
            DataSet ds = dal.GetUName(Uid);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["TrueName"] != null && !string.IsNullOrEmpty(dt.Rows[0]["TrueName"].ToString()))
                    {
                        return dt.Rows[0]["TrueName"].ToString();
                    }
                    else
                    {
                        return dt.Rows[0]["UserName"].ToString();
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public DataSet GetReTeacher()
        {
            return dal.GetReTeacher();
        }

        public DataSet GetTeachCourse(int uid)
        {
            return dal.GetTeachCourse(uid);
        }

        /// <summary>
        /// 新版 名师推荐
        /// </summary>
        public DataSet GetReTeacher(int? top)
        {
            return dal.GetReTeacher(top);
        }

        public DataSet GetUserInfo(int uid)
        {
            return dal.GetUserInfo(uid);
        }
    }
}