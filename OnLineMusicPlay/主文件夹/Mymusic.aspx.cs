using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;

public partial class 主文件夹_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logins"] != null)
            {
                Model.CustomerMusic xw = (Model.CustomerMusic)Session["Logins"];
                name.Text = xw.UserName;
                phone.Text = "登录账户:" + xw.Phone;
                email.Text = "电子邮箱:" + xw.Email;
                last.Text = "最近登录:" + xw.LastLoginTime;
                Image1.ImageUrl = "../images/gradeimg/" + xw.RankName + ".jpg";
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        if (!IsPostBack)
        {
            DrodList();
        }
        
    }
    public void DrodList()
    {
        List<Model.Albummusic> cs = new List<Model.Albummusic>();
        cs = new BLL.AlbummusicBLL().SelectDropList(((Model.CustomerMusic)Session["Logins"]).ID);
        this.DropDownList1.DataSource = cs;
        this.DropDownList1.DataTextField = "AlbumName";
        this.DropDownList1.DataValueField = "AlbumID";
        this.DropDownList1.DataBind();
    }
    protected void Newlist_Click(object sender, EventArgs e)
    {
        //if(txtAubm.Text==null||txtAubm.Text=="")
        //{
        //    errorList.Text = "请输入歌单名称!";
        //    return;
        //}
        //if (txtstert.Text == null || txtstert.Text == "")
        //{
        //    errorList.Text = "请输入歌单介绍!";
        //    return;
        //}
        //Model.Albummusic cs = new Model.Albummusic();
        //cs.AlbumName = txtAubm.Text;
        //cs.Albumabstract=txtstert.Text;
        //Model.CustomerMusic xw = (Model.CustomerMusic)Session["Logins"];
        //cs.ID = xw.ID;
        //int list = new BLL.AlbummusicBLL().Insertalbudata(cs);

        //if(list==1)
        //{
        //    errorList.Text = "创建成功";
        //}
        //else
        //{
        //    errorList.Text = "创建失败";
        //}
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
         string imgurls="";
        Boolean fileOk = false;
        if (pic_upload.HasFile)//验证是否包含文件
        {
            //取得文件的扩展名,并转换成小写
            string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
            //验证上传文件是否图片格式
            fileOk = IsImage(fileExtension);

            if (fileOk)
            {
                //对上传文件的大小进行检测，限定文件最大不超过8M
                if (pic_upload.PostedFile.ContentLength < 8192000)
                {
                    string filepath = "/images/";
                    if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(Server.MapPath(filepath));
                    }
                    string virpath = filepath + CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径
                    string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                    pic_upload.PostedFile.SaveAs(mappath);//保存图片
                                                          //显示图片
                    //pic.ImageUrl = virpath;
                    //清空提示
                    lbl_pic.Text = "";
                    imgurls = virpath;
                }
                else
                {
                    //pic.ImageUrl = "";
                    lbl_pic.Text = "文件大小超出8M！请重新选择！";
                }
            }
            else
            {
                //pic.ImageUrl = "";
                lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
            }
        }
        else
        {
            //pic.ImageUrl = "";
            lbl_pic.Text = "请选择要上传的图片！";
        }

        //修改歌单背景图片
        int id =int.Parse( DropDownList1.SelectedValue);
        if(imgurls!="")
        {
            int updateimg = new BLL.AlbummusicBLL().UpdateAlbu(imgurls,id);
            if(updateimg>0)
            {
                lbl_pic.Text = "更改成功!";
            }
            else
            {
                lbl_pic.Text = "更改失败!";
            }
        }
        else
        {
            lbl_pic.Text = "请重新选择图片!";
        }
    }
    /// <summary>
    /// 验证是否指定的图片格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool IsImage(string str)
    {
        bool isimage = false;
        string thestr = str.ToLower();
        //限定只能上传jpg和gif图片
        string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
        //对上传的文件的类型进行一个个匹对
        for (int i = 0; i < allowExtension.Length; i++)
        {
            if (thestr == allowExtension[i])
            {
                isimage = true;
                break;
            }
        }
        return isimage;
    }

    /// <summary>
    /// 创建一个指定长度的随机salt值
    /// </summary>
    public string CreateSalt(int saltLenght)
    {
        //生成一个加密的随机数
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[saltLenght];
        rng.GetBytes(buff);
        //返回一个Base64随机数的字符串
        return Convert.ToBase64String(buff);
    }


    /// <summary>
    /// 返回加密后的字符串
    /// </summary>
    public string CreatePasswordHash(string pwd, int saltLenght)
    {
        string strSalt = CreateSalt(saltLenght);
        //把密码和Salt连起来
        string saltAndPwd = String.Concat(pwd, strSalt);
        //对密码进行哈希
        string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
        //转为小写字符并截取前16个字符串
        hashenPwd = hashenPwd.ToLower().Substring(0, 16);
        //返回哈希后的值
        return hashenPwd;
    }

}