using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 主文件夹_FristMusic : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Logins"]!=null)
        {
            
            Mymusicworld.NavigateUrl = "~/主文件夹/Mymusic.aspx";
        }
        else
        {
            Mymusicworld.NavigateUrl = "~/主文件夹/Mymusic2.aspx";
        }
    }
}
