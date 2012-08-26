using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Upload handler for uploading files.
/// </summary>
public class Upload : IHttpHandler
{
    public Upload()
    {
    }

    #region IHttpHandler Members

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {

        #region
        // Example of using a passed in value in the query string to set a categoryId
        // Now you can do anything you need to witht the file.
        //int categoryId = 0;
        //if (context.Request.QueryString["CategoryID"] != null)
        //{
        //    try
        //    {
        //        categoryId = Convert.ToInt32(context.Request.QueryString["CategoryID"]);
        //    }
        //    catch (Exception err)
        //    {
        //        categoryId = 0;
        //    }
        //}
        //if (categoryId > 0)
        //{
        //}
        #endregion

        if (context.Request.Files.Count > 0)
        {            
            string tempFile = context.Request.PhysicalApplicationPath;            
            for(int j = 0; j < context.Request.Files.Count; j++)
            {                
                HttpPostedFile uploadFile = context.Request.Files[j];                
                if (uploadFile.ContentLength > 0)
                {    
               
                    // use this if using flash to upload
                    uploadFile.SaveAs(string.Format("{0}{1}{2}", tempFile, "Upload\\", uploadFile.FileName));

                    // HttpPostedFile has an InputStream also.  You can pass this to 
                    // a function, or business logic. You can save it a database:

                    //byte[] fileData = new byte[uploadFile.ContentLength];
                    //uploadFile.InputStream.Write(fileData, 0, fileData.Length);
                    // save byte array into database.
                                     
                }                
            }
        }
        // Used as a fix for a bug in mac flash player that makes the onComplete event not fire
        HttpContext.Current.Response.Write(" ");
    }

    #endregion
}
