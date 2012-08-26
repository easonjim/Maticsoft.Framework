using System;
using System.Web;

namespace Maticsoft.Common
{
    public class FileUpLoad
    {
        public static void uploadFileControl(HttpPostedFile hpf, string savePath, string FileType, out string OutPath)
        {
            OutPath = string.Empty;
            if (hpf != null)
            {
                if (!string.IsNullOrEmpty(hpf.ToString()))
                {
                    try
                    {
                        string ext = System.IO.Path.GetExtension(hpf.FileName).ToLower();
                        if (!IsFileType(FileType, ext))
                        {
                            return;
                        }
                        string filename = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + ext;//文件重命名_userId_CourseID
                        string pathStr = HttpContext.Current.Server.MapPath("/" + savePath);
                        if (!System.IO.Directory.Exists(pathStr))
                        {
                            System.IO.Directory.CreateDirectory(pathStr);
                        }
                        string path = "/" + savePath + "/" + filename;
                        hpf.SaveAs(HttpContext.Current.Server.MapPath(path));
                        OutPath = path;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                OutPath = string.Empty;
            }
        }

        private static bool IsFileType(string fielType, string ext)
        {
            if (fielType.Equals("pic"))
            {
                if (ext != ".jpg" && ext != ".jepg" && ext != ".bmp" && ext != ".gif")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (fielType.Equals("video"))
            {
                if (ext != ".avi" && ext != ".rmvb" && ext != ".wmv" && ext != ".swf" && ext != ".flv")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (fielType.Equals("material"))
            {
                if (ext != ".doc" && ext != ".docx" && ext != ".ppt" && ext != ".xlsx" && ext != ".txt" && ext != ".pdf")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}