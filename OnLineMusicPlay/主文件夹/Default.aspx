<%@ Page Title="默认页面" 
    Language="C#" 
    MasterPageFile="~/主文件夹/FristMusic.master"
     AutoEventWireup="true"
     CodeFile="Default.aspx.cs"
     Inherits="主文件夹_Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../CSS文件夹/play1.css" rel="stylesheet" />
    <div style="width:100%;height:90%;padding:0px;margin:0 0 0 0;">
        <div class="hsldr-container" >
            <ul >
                <li >
                    <img src="../images/imageshow/1020.jpg" />
                    <div class="caption">This is a caption</div>
                </li>
                <li>
                   <img src="../images/imageshow/1021.jpg" />
                    <div class="caption" >This is another caption</div>
                </li>
                <li>
                    <img src="../images/imageshow/1022.jpg" />

                    <div class="caption">This is one more caption</div>
                </li>
                <li>
                   <img src="../images/imageshow/1023.jpg" />

                    <div class="caption">This is one more caption</div>
                </li>
            </ul>
       </div>
        <script src="../JavaScript文件夹/play1.js" type="text/javascript"></script>
        <script src="../JavaScript文件夹/play2.js"></script>
        <script src="../JavaScript文件夹/play3.js"></script>
        <script type="text/javascript">
	    $( document ).ready(function() {
		    $( ".hsldr-container" ).hslider({navBar: true,auto: true,delay: 4000});});
        </script>
        
       <div style="width: 70%; height:1000px; margin: 0 15% 0 15%; border: 1px solid green;padding:0px;">
           <div style="position:relative;width:100%;height:50px;background-color:burlywood;border:1px solid gray;text-align:left;">
            <span style="font-size:24px;font-family:行楷;margin:5px 5px 0 10px;padding:0px;">热门推荐</span>
            <a style="font-family:行楷;margin:0 10px 0 10px;">华语</a>|
            <a style="font-family:行楷;margin:0 10px 0 10px;">流行</a>|
            <a style="font-family:行楷;margin:0 10px 0 10px;">摇滚</a>|
            <a style="font-family:行楷;margin:0 10px 0 10px;">民乐</a>|
            <a style="font-family:行楷;margin:0 10px 0 10px;">电子</a>|
            <hr style="height:4px;background-color:red"/>
        </div>
             <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" Width="70%" >
                <ItemTemplate>
                            <div style="position:relative;width:200px;height:200px;float:left;margin:10px 5px 0 15px">
                                <img src="../images/photo-1431036101494-66a36de47def.jpg" alt="" style="width:200px;height:200px;" />
                                <span style="position:absolute;bottom:0 ;left:0;width:200px;height:40px;background-color:rgba(255, 255, 255, 0.60);border-top:2px double black;">
                                  <label style="font-size:20px;color:deepskyblue;margin:4px 3px 0 30px;float:left;">1235</label><label style="font-size:25px;margin:0 10px 0 0;padding:0px;float:left;">♪</label><img style="height:30px;width:30px;border-radius:15px;margin:5px 0 0 20px;" src="../images/imagepang/like.png" />
                                </span>
                            </div>
                </ItemTemplate>
       </asp:DataList>
       </div>
   </div>
</asp:Content>

