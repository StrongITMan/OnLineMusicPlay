<%@ Page Title="我的音乐未登录窗口"
     Language="C#" 
    MasterPageFile="~/主文件夹/FristMusic.master" 
    AutoEventWireup="true" 
    CodeFile="Mymusic2.aspx.cs"
     Inherits="主文件夹_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:70%;height:500px;border:1px solid gray;margin:auto;background-color:white;">
        <img src="../images/imagepang/link2.jpg" style="width:300px;height:300px;margin:100px 0 0 100px;"/>
        <div style="float:right;width:300px;height:250px;margin:150px 100px 0 0;">
            <asp:Label ID="Label1" runat="server" Text="登录听风" Style="font-size:46px;float:left;font-weight:600;font-family:黑体;margin:20px 0 0 0;"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="一键收藏喜爱的音乐" Style="font-size:26px;float:left;font-family:黑体;margin:20px 0 0 0;"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="方便随时随地收听!" Style="font-size:26px;float:left;font-family:黑体;margin:20px 0 0 0;"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="立即登录" Style="font-size:26px;float:left;font-family:黑体;margin:20px 0 0 0;width:150px;height:50px;" OnClick="Button1_Click" />
        </div>
       
    </div>
</asp:Content>

