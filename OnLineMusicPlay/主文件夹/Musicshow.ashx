<%@ WebHandler Language="C#" Class="Musicshow" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
public class Musicshow : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        int dw = Convert.ToInt32(context.Request["ID"]);
        List<Model.Music> list = new BLL.MusicBLL().GetMusicData(dw);
        DataContractJsonSerializer dj = new DataContractJsonSerializer(typeof(List<Model.Music>));
        dj.WriteObject(context.Response.OutputStream, list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}