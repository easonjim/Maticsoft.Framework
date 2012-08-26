using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class TradeDetails
    {
        /// <summary>
        /// 获得用户账户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Model.AccountTrade> GetTradeDetials(int UserId)
        {
            return dal.GetTradeDetials(UserId);
        }

        /// <summary>
        /// 获得账户消费记录信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="whereStr">记录时间范围</param>
        /// <returns></returns>
        public DataSet GetTradeRecord(int startIndex, int pageSize, int userId, string whereStr, out decimal balance)
        {
            return dal.GetTradeRecord(startIndex, pageSize, userId, whereStr, out balance);
        }

        /// <summary>
        /// 本月消费明细
        /// </summary>
        public int CurrentMonthRecord(int userId)
        {
            return TradeRecordNum(userId, "true");
        }

        /// <summary>
        /// 全部消费明细
        /// </summary>
        public int AllMonthRecord(int userId)
        {
            return TradeRecordNum(userId, "");
        }

        /// <summary>
        /// 统计账户余额信息记录条数
        /// </summary>
        private int TradeRecordNum(int userId, string limit)
        {
            return dal.TradeRecordNum(userId, limit);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.TradeDetails> GetListByUId(out int rowCount, out int pageCount, out decimal Balance, int UserID, int? PageIndex, int? PageSize, bool action)
        {
            return dal.GetListByUId(out rowCount, out pageCount, out Balance, UserID, PageIndex, PageSize, action);
        }
    }
}