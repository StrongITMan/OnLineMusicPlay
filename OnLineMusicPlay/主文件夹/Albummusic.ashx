<%@ WebHandler Language="C#" Class="Albummusic" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Web.SessionState;
public class Albummusic : IHttpHandler,IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        ////context.Response.Write("Hello World");

        if (context.Session["Logins"] != null)
        {
            Model.CustomerMusic xw = (Model.CustomerMusic)context.Session["Logins"];
            List<Model.Albummusic> cs = new List<Model.Albummusic>();

            cs = new BLL.AlbummusicBLL().SelectAlbu(xw.ID);

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(List<Model.Albummusic>));
            ds.WriteObject(context.Response.OutputStream, cs);

        }
        else
        {
            context.Response.Write("");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}