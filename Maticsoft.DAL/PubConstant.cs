namespace Maticsoft.DAL
{
    public class PubConstant
    {
        /// <summary>
        /// �õ�web.config������������ݿ������ַ�����
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = Maticsoft.Common.ConfigHelper.GetConfigString(configName);
            string ConStringEncrypt = Maticsoft.Common.ConfigHelper.GetConfigString("ConStringEncrypt");
            if (ConStringEncrypt == "true")
            {
                connectionString = Maticsoft.Common.DEncrypt.DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}