using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class SendInvite
    {
        public static Maticsoft.Accounts.Bus.User GetUNameByMid(int mid)
        {
            return DAL.Tao.SendInvite.GetUNameByMid(mid);
        }

        public static DataSet GetInviteCourseById(int uid)
        {
            return DAL.Tao.SendInvite.GetInviteCourseByID(uid);
        }
    }
}