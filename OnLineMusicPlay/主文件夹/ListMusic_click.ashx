<%@ WebHandler Language="C#" Class="ListMusic_click" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Web.SessionState;
public class ListMusic_click : IHttpHandler,IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string name = context.Request["Name"];
        string ster = context.Request["ster"];

        Model.Albummusic cs = new Model.Albummusic();
        cs.AlbumName = name;
        cs.Albumabstract=ster;

        if (context.Session["Logins"] != null)
        {
            Model.CustomerMusic xw = (Model.CustomerMusic)context.Session["Logins"];
            cs.ID = xw.ID;
        }
        else
        {
                context.Response.Write( "创建失败");
        }
        int list = new BLL.AlbummusicBLL().Insertalbudata(cs);
        if(list==1)
        {
            context.Response.Write( "创建成功");
        }
        else
        {
            context.Response.Write( "创建失败");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}