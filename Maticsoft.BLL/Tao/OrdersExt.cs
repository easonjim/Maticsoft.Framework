using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class Orders
    {
        /// <summary>
        /// 获得已选课程信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public DataSet GetBuyCourse(int pageSize, int startIndex, int UserId, string whereStr)
        {
            return dal.GetBuyCourse(pageSize, startIndex, UserId, whereStr);
        }

        /// <summary>
        /// 已选课程数量
        /// </summary>
        private int GetBuyCourseCount(int userId, string limit)
        {
            return dal.GetBuyCourseCount(userId, limit);
        }

        /// <summary>
        /// 获得近三个月已选课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int BuyCourseCount(int userID)
        {
            return GetBuyCourseCount(userID, "");
        }

        /// <summary>
        /// 获得三个月前已选课程的数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int CourseCountHis(int userID)
        {
            return GetBuyCourseCount(userID, "True");
        }

        /// <summary>
        /// 账户充值---确认订单 未付款
        /// </summary>
        public int Rechange(Model.Tao.Orders model)
        {
            return dal.Rechange(model);
        }

        /// <summary>
        /// 充值成功，更新订单状态，用户余额，消费明细
        /// </summary>
        public bool ModifyOrderStatus(int orderId)
        {
            return dal.ModifyOrderStatus(orderId);
        }

        public int CreateNewOrderInfo(Model.Tao.Orders orders, int courseId, string mids, int types)
        {
            return dal.CreateNewOrderInfo(orders, courseId, mids, types);
        }

        public int SaveLeanCourse(Model.Tao.Orders orders, int courseId, int? mid)
        {
            return dal.SaveLeanCourse(orders, courseId, mid);
        }

        public bool IsBuyed(int cid, int uid, int mid)
        {
            int res = dal.IsBuyed(cid, uid, mid);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModifyOrderInfo(int orderId)
        {
            return dal.ModifyOrderInfo(orderId);
        }

        /// <summary>
        /// 支付接口支付，更新订单的状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool ModifyBuyCourseStatus(int orderId)
        {
            return dal.ModifyBuyCourseStatus(orderId);
        }

        public bool UpdatePaymentID(Model.Tao.Orders model)
        {
            return dal.UpdatePaymentID(model);
        }
    }
}