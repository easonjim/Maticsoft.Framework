using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Maticsoft.Common
{
    public sealed class HiUploader
    {
        public static void DeleteImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    string path = "";
                    if (fileName.StartsWith("~/"))
                    {
                        path = HttpContext.Current.Request.PhysicalApplicationPath + (Globals.ApplicationPath + fileName.Substring(1, fileName.Length - 1));
                    }
                    else
                    {
                        path = HttpContext.Current.Request.PhysicalApplicationPath + (Globals.ApplicationPath + fileName);
                    }
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                }
            }
        }

        private static bool CheckPostedFile(HttpPostedFile postedFile)
        {
            if ((postedFile == null) || (postedFile.ContentLength == 0))
            {
                return false;
            }
            string str = Path.GetExtension(postedFile.FileName).ToLower();
            if ((((str != ".jpg") && (str != ".gif")) && ((str != ".jpeg") && (str != ".png"))) && (str != ".bmp"))
            {
                return false;
            }
            string str2 = postedFile.ContentType.ToLower();
            if ((((str2 != "image/pjpeg") && (str2 != "image/jpeg")) && ((str2 != "image/gif") && (str2 != "image/bmp"))) && ((str2 != "image/png") && (str2 != "image/x-png")))
            {
                return false;
            }
            return true;
        }

        private static string GenerateFilename(string extension)
        {
            return (Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + extension);
        }

        public static string UploadCategoryImage(HttpPostedFile postedFile)
        {
            if (!CheckPostedFile(postedFile))
            {
                return string.Empty;
            }
            string str = "UploadedFile/Categories/" + GenerateFilename(Path.GetExtension(postedFile.FileName));
            postedFile.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath+(Globals.ApplicationPath + str));
            return str;
        }
    }
}
