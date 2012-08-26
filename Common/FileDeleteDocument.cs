using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Maticsoft.Common
{
    public class FileDeleteDocument
    {
        private string serverPath;
        public FileDeleteDocument()
        {
            getServerPath();
        }
        private void getServerPath()
        {
            serverPath = HttpContext.Current.Server.MapPath("~/");
        }
        private string _errorMessage;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errorMessage
        {
            get { return _errorMessage; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fileName"></param>
        public bool fileDelete(string fileName)
        {
            string filePath = getFileFullPath(fileName);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

            if (fileInfo.Exists == true)
            {
                fileInfo.Delete();
                return true;
            }
            else
            {
                _errorMessage = "文件不存在";
                return false;
            }
        }
        protected string getFileFullPath(string fileName)
        {
            string filefullpath;
            if (fileName.StartsWith("~/"))
            {
                filefullpath = fileName.Substring(1, fileName.Length - 1);
            }
            else
            {
                filefullpath = fileName;
            }
            filefullpath = serverPath + filefullpath;
            return filefullpath;
        }
    }
}
