<%@ WebHandler Language="C#" Class="DefaultJava" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
public class DefaultJava : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<Model.Albummusic> cs = new BLL.AlbummusicBLL().SelectAlbu(-1);
        DataContractJsonSerializer dr = new DataContractJsonSerializer(typeof(List<Model.Albummusic>));
        dr.WriteObject(context.Response.OutputStream, cs);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}