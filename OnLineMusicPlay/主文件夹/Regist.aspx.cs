using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
public partial class 主文件夹_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        Model.CustomerMusic cus = new Model.CustomerMusic();
        cus.UserName = username.Text;
        cus.UserPwd =Dbhelper.Encryption(Pwd.Text);
        cus.Phone = phone.Text;
        cus.Email = E_mail.Text;
        cus.Birthday = Birth.Text;
      
        if(radSex.Checked==true)
        {
            cus.Sex = "男";
        }
        else if(radSex.Checked== false)
        {
            cus.Sex = "女";
        }

        int count = new BLL.CustomerBLL().InsterRegist(cus);
        switch (count)
        {
            case -3:
                Showerror.Text = "用户已经存在!";
            break;
            case -2:
                Showerror.Text = "数据库连接失败!";
                break;
            case -1:
                Showerror.Text = "数据操作失败!";
                break;
            case 0:
                Showerror.Text = "注册失败,检查数据!";
                break;
            default:
                Response.Write("注册成功");
                Response.Redirect("login.aspx");
                break;
        }
    }
}