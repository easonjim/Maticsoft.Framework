#define DEBUG
#define TEST
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;

namespace Maticsoft.Common.Handler
{
    public class StealLinkHandler4Flv : StealLinkHandlerBase
    {
        private static readonly byte[] _flvheader = HexToByte("464C5601010000000900000009"); //"FLV\x1\x1\0\0\0\x9\0\0\0\x9"
        private const string BasePath = "/UploadedFile/";

        #region 实现BaseHandler
        protected override void ProcessRequestEx(HttpContext context)
        {
            try
            {
                string userId = string.Empty;
                string courseId = string.Empty;
                string filePath = string.Empty;

                //获取文件名
                string fileName = Path.GetFileNameWithoutExtension(context.Request.Url.LocalPath);
                if (string.IsNullOrEmpty(fileName)) return;
                //文件名解密
                fileName = DESEncrypt.Decrypt(fileName);

#if TEST
                //拼接文件路径
                filePath = context.Server.MapPath(BasePath + fileName);
#else
                //获取[用户ID] [课程ID]
                string[] fileNames = fileName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                if (fileNames.Length != 3) return;
                //用户ID
                userId = fileNames[1];
                //课程ID
                courseId = fileNames[2];

                //拼接文件路径
                filePath = context.Server.MapPath(BasePath + userId + "/" + courseId + "/" + fileName);
#endif

                //文件不存在
                if (!File.Exists(filePath)) return;

                int pos;
                int length;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //获取文件流定位
                    string qs = context.Request.Params["start"];

                    if (string.IsNullOrEmpty(qs))
                    {
                        pos = 0;
                        length = Convert.ToInt32(fs.Length);
                    }
                    else
                    {
                        pos = Convert.ToInt32(qs);
                        length = Convert.ToInt32(fs.Length - pos) + _flvheader.Length;
                    }
                    //设置输出流缓存 [仅缓存在源服务器上]
                    context.Response.Cache.SetCacheability(HttpCacheability.Server);
                    context.Response.Cache.SetLastModified(DateTime.Now);

                    //设置输出流内容类型
                    context.Response.AppendHeader("Content-Type", "video/x-flv");
                    //设置输出流内容长度
                    context.Response.AppendHeader("Content-Length", length.ToString());
                    //追加FLV文件头
                    if (pos > 0)
                    {
                        context.Response.OutputStream.Write(_flvheader, 0, _flvheader.Length);
                        fs.Position = pos;
                    }
                    //初始化缓冲区
                    const int buffersize = 16384;   //buffersize 16K
                    byte[] buffer = new byte[buffersize];
                    //读入缓冲区
                    int count = fs.Read(buffer, 0, buffersize);
                    while (count > 0)
                    {
                        //检测客户端请求是否中断
                        if (context.Response.IsClientConnected)
                        {
                            //将缓冲区写入到输出流
                            context.Response.OutputStream.Write(buffer, 0, count);
                            count = fs.Read(buffer, 0, buffersize);
                        }
                        else
                        {
                            count = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 允许重复使用Handler
        /// </summary>
        protected override bool IsReusableEx
        {
            get { return true; }
        }
        #endregion

        #region HexToByte
        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        } 
        #endregion
    }
}