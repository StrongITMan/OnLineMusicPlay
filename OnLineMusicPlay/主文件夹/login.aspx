<%@ Page Title="登录"
     Language="C#"
     MasterPageFile="~/主文件夹/FristMusic.master" 
    AutoEventWireup="true" 
    CodeFile="login.aspx.cs"
     Inherits="主文件夹_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../CSS文件夹/LoginCss.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <div class="div_login1">
       <span class="span_font">登录:</span>
        <hr class="hr_login"/>
        <div class="div_login2">
            <p>
                <asp:Label ID="Labe1" runat="server" Text="手机号码:"></asp:Label><asp:TextBox ID="txtLongin" runat="server" MaxLength="11" TextMode="Phone" CssClass="txt_login"></asp:TextBox>
            </p>
            <p>
               <asp:Label ID="Labe2" runat="server" Text="用户密码:"></asp:Label><asp:TextBox ID="txtpwd" runat="server" MaxLength="16" TextMode="Password" CssClass="txt_login"></asp:TextBox>
           </p>
            <p>
                <asp:Label ID="loginerror" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Btnlogin" runat="server" Text="登录"  CssClass="Btn_login" OnClick="Btnlogin_Click"/>
                <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/主文件夹/Regist.aspx" Style="margin:0 0 0 20px;color:blue;text-decoration:underline;font-size:18px;" >
                    去注册
                </asp:HyperLink>
            </p>
        </div>
    </div>
</asp:Content>

