using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 主文件夹_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btnlogin_Click(object sender, EventArgs e)
    {
        string phone = txtLongin.Text;
        string pwd = txtpwd.Text;
        Model.CustomerMusic cs = new Model.CustomerMusic();
        cs = new BLL.CustomerBLL().SelectLogin(phone,pwd);
        if(cs.Phone=="0")
        {
            loginerror.Text = cs.UserPwd;
        }
        else
        {
            loginerror.Text = "登录成功!";
            Session["Logins"] = cs;
            int xw = new BLL.CustomerBLL().UpdateCustomerID(cs.ID);
            Response.Redirect("Mymusic.aspx");
        }
    }
}