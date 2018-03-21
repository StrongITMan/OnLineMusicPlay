<%@ Page Title="我的音乐" 
    Language="C#"
     MasterPageFile="~/主文件夹/FristMusic.master" 
    AutoEventWireup="true" CodeFile="Mymusic.aspx.cs" 
    Inherits="主文件夹_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" ClientIDMode="Static">
       
    <script src="../JavaScript文件夹/Mymusic_1.js"></script>
     <script src="../Scripts/jquery-1.10.2.js"></script>
    <style>
        .div_music_head{
            width:25.5%;
            height:100%;
            padding:0px;
            float:left;
            background-color:rgba(255, 255, 255, 0.6);
        }
        .div_music_list{
            margin:10px 0 0 0px;
            width:100%;
            height:70px;
            float:left;
        }
            .div_music_list:hover {
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1), inset 0 0 1px rgba(255, 255, 255, 0.6);
                background: rgba(0, 0, 0, 0.1);
                color: rgba(0, 0, 0, 0.84);
            }
            .div_music_list img{
                width:60px;
                height:60px;
                margin:0px 10px 0 50px;
                float:left;
            }
            .span_listmusic{
                height:30px;
                float:left;
                text-align:left;
                font-size:20px;
                font-family:行楷;
            }
            .span_listmusic2{
                height:30px;
                float:left;
                text-align:left;
                font-size:18px;
                font-family:行楷;
                color:rgba(0, 0, 0, 0.16);
            }
         .span_music{
              text-align:center;
              width:100px;
              height:20px;
              margin:0px 0 0 20px;
              padding:10px;
              font-size:22px;
              font-family:楷书;
         }
          .span_music img{
              width:20px;
              height:20px
          }
        .auto-style4 {
            float: left;
        }

    </style>

<div style="width:100%;height:100%;padding:0px;margin:0px;float:left;background-color:#f0f0f0;">
 <div class="div_music_head">
        <div style="width:100%;height:150px;border-bottom:1px solid gray;">
            <asp:Label ID="name" runat="server" Text="" style="font-size:24px;color:black;font-weight:600;margin:0 0 0 60px;font-family:华文行楷;border-bottom:2px solid black;padding:2px;"></asp:Label><asp:Image ID="Image1" runat="server"  style="width:40px;height:40px;margin:10px 0 0 5px;padding:0px;"/><br /><br />
            <asp:Label ID="phone" runat="server" Text="" style="font-size:18px;margin:10px 0 0 20px;padding:0px;font-weight:300;"></asp:Label><br />
            <asp:Label ID="email" runat="server" Text="" style="font-size:18px;margin:10px 0 0 20px;padding:0px;font-weight:300;"></asp:Label><br />
            <asp:Label ID="last" runat="server" Text=""  style="font-size:18px;margin:10px 0 0 20px;padding:0px;font-weight:300;"></asp:Label><br />
        </div>
        <br />
       <span class="span_music" onclick="Listmusisc()"><img id="Musiclist_img"  src="../images/imagepang/regiht.ico"/><a href="#" style="color:black;">创建的歌单</a></span>
         <input   value="创建歌单" type="button" style="margin:0 0 0 30px;width:80px;height:30px;background-color:white;font-size:16px;border:1px solid gray;border-radius:10px;text-align:center;" onclick="openlistClick()"/>
      <div id="div_AlubmaMusic"  style="width:100%;height:834px;margin:0 0 0 0;padding:0px;">
          
      </div>
    </div>
        <%--创建歌单--%>
         <div id="openlist" style="position:fixed;top:200px;left:400px;width:500px;height:300px;background-color:white;border-radius:10px;display:none;">
            <div style="width:100%;height:50px;margin:0 0 0 0;padding:0px;background-color:rgba(0, 0, 0, 0.84);color:white; border-top-right-radius:10px;border-top-left-radius:10px;">
                <a href="#" style="float:right;color:white;font-size:35px;margin:0 0 0 0;padding:0px;" id="close2" onclick="close1click()" title="关闭">×</a>
                <br />
                <span style="font-size:20px;bottom:0px;">新建歌单</span> 
            </div>
            <div style="width:100%;height:245px;text-align:center;font-size:20px;">
                <br /><br />
                <asp:Label ID="Label1" runat="server" Text="Label">歌单名称:</asp:Label><asp:TextBox ID="txtAubm" Style="width:200px;height:30px;" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Label">歌单简介:</asp:Label><asp:TextBox ID="txtstert" Style="width:200px;height:30px;" runat="server"></asp:TextBox><br />
                <asp:Label ID="errorList" runat="server" style="float:left;margin:0px 0 0 220px;"></asp:Label><br />
                <input type="button" id="Newlist" value="新建" Style="width:70px;height:35px;font-size:20px;margin:0px 0 0 250px;float:left" onclick="ListMusic_click()"/>
            </div>
        </div>

        
    <%--歌曲列表--%>
    <div style="width: 74.5%; height:100%; top:0px; margin:0px 0 0 0;padding:0px;float:left;background-color:rgba(0, 0, 0, 0.16);">
        <div style="width:100%;height:100%;margin:10px 0 0 0;padding:0px;">
            <span style="font-size:24px;color:white;margin:0 0 0 10px;float:left;">歌曲列表</span>
            <input id="deletmusicList" type="button" style="font-size:16px;float:right;margin:5px 10px 0 0" value="删除歌单" onclick=""/>
            <input id="openFile" type="button" style="font-size:16px;float:right;margin:5px 10px 0 0" value="更改封面" onclick="opfileClick()"/>
            <br /><br />
            <hr />
            <div id='Div_Music_show' style="width:100%;height:980px;margin:0 0 0 0;padding:0px;">
               <%-- <asp:DataList ID="Listshowdata" runat="server">
                    <ItemTemplate>
                        <div style="width:74%;height:30px;margin:0 0 0 0;padding:0px;border-bottom:1px solid gray;border-top:1px solid gray;display:flex;">
                            <a style="flex:1;text-align:center;"><asp:Label ID="Label2" runat="server" Text="1" style="margin:0px 10px 10px 0;"></asp:Label><img src="../images/imagepang/bfzn_004.ico" style="text-align:right;height:30px;width:30px;margin:0 0 0 10px;padding:0px;" /></a>
                            <a href="#" style="text-decoration:none;flex:1;margin:5px 0 0 10px;text-align:left;"><asp:Label ID="Label3" runat="server" Text="我的世界"></asp:Label></a>
                            <asp:Label ID="Label5" runat="server" style="flex:1;margin:5px 0 0 10px;text-align:left;" Text="00:04:05"></asp:Label>
                            <a href="#" style="text-decoration:none;flex:1;margin:5px 0 0 10px;padding:0px;text-align:left;"><asp:Label ID="Label6" runat="server" Text="游戏玩家"></asp:Label></a>
                            <a style="text-decoration:none;flex:1;margin:5px 0 0 10px;padding:0px;text-align:left;"><asp:Label ID="Label7" runat="server" Text="恋爱事件的原委" ></asp:Label></a> 
                        </div>
                    </ItemTemplate>
                </asp:DataList>--%>
            </div>
        </div>
    </div>
</div>
    <div id="divFile" style="display:none;width:500px;height:300px;border:1px solid red;position:fixed;left:35%;top:20%;background-color:gray;">
        <div style="width:100%;height:30px;background-color:rgba(0, 0, 0, 0.74);color:rgba(255, 255, 255, 0.6);border-bottom:2px solid black;">
            <label style="float:left;margin-left:20px;margin-top:5px;">上传</label><a href="#" onclick="Closeclick()"  style="float:right;font-size:20px;margin-right:20px;">×</a>
        </div>
        <div style="text-align:center;margin:auto;">
                <%--<asp:Image ID="pic" runat="server" Style="width:240px;height:210px;margin:20px 0 0 0;" /><br />--%>
              <br /><br /> <asp:Label ID="lbl_pic" runat="server"  Style="margin:20px 0 10px 0;font-size:15px;color:blue;"></asp:Label><br />
            <br /><asp:FileUpload ID="pic_upload" runat="server"  /><br /><br />
                 上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M<br />
            <asp:DropDownList ID="DropDownList1" runat="server" style="width:200px;height:20px;"></asp:DropDownList>
                <asp:Button  runat="server"   Text="上传" Style="margin:20px 0 0 20px;font-size:16px;"  OnClick="btn_upload_Click"/>
                 <%--<input type="button" ID="btn_upload" value="上传" style="margin:20px 0 0 20px;font-size:16px;"  onclick="btn_upload_Click()"/>--%>
        </div>
    </div>
</asp:Content>

