using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.Model.SysManage;
namespace Maticsoft.BLL.SysManage
{
    
    /// <summary>
    /// 
    /// </summary>
    public class UserLog
    {
        private static Maticsoft.DAL.SysManage.UserLog dal = new DAL.SysManage.UserLog();
               
        #region 
        
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="model">Ҫ���ӵ���־ʵ�����</param>
        public static void LogUserAdd(Maticsoft.Model.SysManage.UserLog model)
        {
            dal.LogUserAdd(model);
        }

        public static DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ݲ�ѯ������ȡ��־�б�
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns>���ص����ݼ�</returns>
        public static DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// ɾ��һ����־��¼
        /// </summary>
        /// <param name="iID">Ҫɾ������־���</param>
        public static void Delete(int iID)
        {
            dal.LogUserDelete(iID);
        }
        public static void Delete(string IdList)
        {
            dal.LogUserDelete(IdList);
        }
        /// <summary>
        /// ɾ��ĳһ����֮ǰ������
        /// </summary>
        /// <param name="dtDateBefore">����</param>
        public static void Delete(DateTime dtDateBefore)
        {
            dal.LogUserDelete(dtDateBefore);
        }
                
        #endregion

    
    }
    
}
