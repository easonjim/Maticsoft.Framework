using System.Data;

namespace Maticsoft.BLL.UserExp
{
    public partial class UsersApprove
    {
        /// <summary>
        /// 根据UserId获取对应的认证资料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetUserApprove(int userId)
        {
            return dal.GetUserApprove(userId);
        }

        public int GetIdCardApprove(int userId)
        {
            return dal.GetIdCardApprove(userId);
        }
    }
}