<%@ WebHandler Language="C#" Class="Upload" %>
 
using System.IO;
using System.Web;

public class Upload : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        var uploads = context.Request.Files["upload"];
        var CKEditorFuncNum = context.Request["CKEditorFuncNum"];
        var file = Path.GetFileName(uploads.FileName);
        uploads.SaveAs(context.Server.MapPath(".") + "\\Images\\" + file);
        var url = "/Images/" + file;
        context.Response.Write(
            "<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}