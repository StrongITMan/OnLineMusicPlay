<%@ Page Title="注册" 
    Language="C#"
     MasterPageFile="~/主文件夹/FristMusic.master" 
    AutoEventWireup="true" 
    CodeFile="Regist.aspx.cs" 
    Inherits="主文件夹_Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" clientidmode="Static" Runat="Server">
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <link href="../CSS文件夹/LoginCss.css" rel="stylesheet" />
    <script src="../JavaScript文件夹/Regist.js"></script>

     <div class="div_login1">
       <span class="span_font">注册:</span>
        <hr class="hr_login"/>
        <div class="div_Regist1" onmouseover="BtnRegister_dis()">
            <p>
           <asp:Label ID="Labe1" runat="server" Text="用户名称:"></asp:Label><asp:TextBox ID="username"  runat="server" type="text"  class="txt_Regist" maxlength="12" onblur="NameBlur()"></asp:TextBox>
            </p>
            <p>
               <asp:Label ID="Labe2"  runat="server" Text="手机号码:"></asp:Label><asp:TextBox ID="phone" runat="server" type="tel" onblur="phoneyz()" class="txt_Regist"   placeholder="请输入您的手机号码!" maxlength="11" onkeyup="value = value.replace(/[^\d]/g, '')"></asp:TextBox>
           </p>
             <p>
               <asp:Label ID="Labe5"  runat="server">&nbsp;&nbsp;性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别:</asp:Label>
                 <asp:RadioButton ID="radSex"  runat="server" style="margin:0 60px 0 40px;" Text="男" Checked="true" GroupName="Sex"/><asp:RadioButton ID="radSex2" runat="server"  Text="女" GroupName="Sex"/>
             </p> 
              <p>
               <asp:Label ID="Labe3"  runat="server" Text="用户密码:"></asp:Label><asp:TextBox ID="Pwd" runat="server" class="txt_Regist" type="password"   placeholder="请输入密码!" maxlength="16" ></asp:TextBox>
              </p>  
            <p>
               <asp:Label ID="Labe4"  runat="server" Text="重复密码:"></asp:Label><asp:TextBox ID="Repwd" runat="server" class="txt_Regist" type="password" onblur="Repwdyz()"   placeholder="请再次输入密码!" maxlength="16"></asp:TextBox>
           </p> 
            <p>
               <asp:Label ID="Labe6"  runat="server" Text="出生日期:"></asp:Label><asp:TextBox ID="Birth" runat="server" type="datetime" onblur="Birthtime()"  class="txt_Regist" placeholder="1999-09-09"></asp:TextBox>
            </p> 
            <p>
               <asp:Label ID="Labe7"  runat="server" Text="邮箱地址:"></asp:Label><asp:TextBox ID="E_mail" runat="server" type="email" onblur="Emailyz()" class="txt_Regist"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Showerror" Style="margin:0 0 0 30px;" runat="server" Text="***"></asp:Label>
            </p>
            <p>
                <asp:Button ID="BtnRegister" runat="server"  Text="注册"  CssClass="Btn_regist" disabled="disabled" OnClick="BtnRegister_Click" />
            </p>
        </div>
     </div>
</asp:Content>


