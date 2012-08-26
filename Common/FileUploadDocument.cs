using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace Common
{
    public class FileUploadDocument
    {
        private string filesPath;

        public FileUploadDocument()
        {
            setFilesPath();
        }

        public void setFilesPath()
        {
            if (ConfigurationManager.AppSettings["UploadFilePath"] != null)
            {
                filesPath = ConfigurationManager.AppSettings["UploadFilePath"].ToString();
                if (string.IsNullOrEmpty(filesPath))
                {
                    filesPath = "UploadedFile";
                }
            }
            else
            {
                filesPath = "UploadedFile";
            }
        }

        private string _errorMessage;
        private string _filePathForDataBase;
        private string _filePathForServer;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errorMessage
        {
            get { return _errorMessage; }
        }

        public string filePathForDataBase
        {
            get { return _filePathForDataBase; }
        }

        public string filePathForServer
        {
            get { return _filePathForServer; }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userPostedFile"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool upload(HttpPostedFile userPostedFile, string fileDoc, string folder)
        {
            string ReceiveFile = "";
            string filepath = HttpContext.Current.Server.MapPath("~/");
            try
            {
                if (userPostedFile == null)
                    return false;

                if (userPostedFile.ContentLength > 0)
                {
                    if (userPostedFile.ContentLength > 12000000)//最大长度
                    {
                        _errorMessage = "上传文件过大！";
                        return false;
                    }
                    else
                    {
                        ReceiveFile = System.IO.Path.GetFileName(userPostedFile.FileName);
                        string ReceiveExtension = System.IO.Path.GetExtension(userPostedFile.FileName);
                        string fileName = GenerateFilename(ReceiveExtension);
                        if (!Directory.Exists(filepath + "\\" + filesPath + "\\" + folder + "\\" + fileDoc + "\\" + fileName))
                        {
                            Directory.CreateDirectory(filepath + "\\" + filesPath + "\\" + folder + "\\" + fileDoc);
                        }
                        userPostedFile.SaveAs(filepath + "\\" + filesPath + "\\" + folder + "\\" + fileDoc + "\\" + fileName);
                        ReceiveFile = fileName;
                        _filePathForServer = filepath + "\\" + filesPath + "\\" + folder + "\\" + fileDoc + "\\" + fileName;
                        _filePathForDataBase = "~/" + filesPath + "/" + folder + "/" + fileDoc + "/" + fileName;
                        return true;
                    }
                }
                else
                {
                    _errorMessage = "找不到你要上传的文件";
                    return false;
                }
            }
            catch (Exception)
            {
                _errorMessage = "上传失败";
                return false;
            }
        }

        /// <summary>
        /// 返加上传在服务器中保存的文件名
        /// </summary>
        private string GenerateFilename(string extension)
        {
            return (Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + extension);
        }
    }
}