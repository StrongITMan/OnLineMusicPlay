
//列表图标点击事件
function Listmusisc() {
    var list = document.getElementById("Musiclist_img").src;
    if(list.substring(list.lastIndexOf("/")+1)=="regiht.ico")
    {
        $("#Musiclist_img").attr('src', '../images/imagepang/bottom.ico');
        $("#div_AlubmaMusic").html("");
        ListMusic();
    }
    else if(list.substring(list.lastIndexOf("/")+1)=="bottom.ico")
    {
        $("#div_AlubmaMusic").html("");
        $("#Musiclist_img").attr('src', '../images/imagepang/regiht.ico');
    }
}
//打开创建歌单界面
function openlistClick() {
    document.getElementById("openlist").style.display = "block";
}

//关闭创建歌单界面
function close1click() {
    document.getElementById("openlist").style.display = "none";
}
//歌单列表
function ListMusic()
{
    $.ajax({
        url: "Albummusic.ashx",
        type: "get",
        success: function (data) {
            var jsondata = $.parseJSON(data);
            $.each(jsondata,function(i,obj)
            {
                var datashow = "<div class='div_music_list' id='divdisplay' onclick='AlbumClick(" + obj.AlbumID + ")' ><img src='"+obj.ImageUrl+"' /><span class='span_listmusic'>" + obj.AlbumName + "</span><br /><br /><span class='span_listmusic2'>" + obj.Listeners + "</span><b style='font-size:25px;margin:0px;padding:0px;float:left;top:0px;'>♪</b></div>";
                $("#div_AlubmaMusic").append(datashow);
            })
        }
    });
}
//歌单背景图片
function ImageBackground()
{

}
//新建列表
function ListMusic_click() {
    var albuName = document.getElementById("txtAubm").value;
    var albutert = document.getElementById("txtstert").value;
    if (albuName == null || albuName == "")
    {
        document.getElementById("errorList").innerHTML = "请输入歌单名称!";
        return;
    }
    else if (albutert == null || albutert == "") {
        document.getElementById("errorList").innerHTML = "请输入歌单介绍!";
        return;
    }
    $.ajax({
        url: "ListMusic_click.ashx",
        type: "post",
        data:{"Name":albuName,"ster":albutert},
        success: function (data) {
            var js = $.parseJSON(data);
            document.getElementById("errorList").innerHTML = js;
        }
    });
}


//歌曲列表
function AlbumClick(xw) {
    $("#Div_Music_show").html("");
    $.ajax({
        url:"Musicshow.ashx",
        type: "post",
        data: { "ID": xw },
        success: function (data) {
            var jsdata = $.parseJSON(data);
            $.each(jsdata, function (i, obj) {
                var musi = "<div  style='width:100%;height:30px;margin:0 0 0 0;padding:0px;display:flex;'><label style='margin:5px 0px 0px 20px;' >" + obj.MusicID + "</label><a style='flex:1;text-align:center;'><img src='../images/imagepang/bfzn_004.ico' style='text-align:right;height:30px;width:30px;margin:0 0 0 10px;padding:0px;' /></a><a href='#' style='text-decoration:none;flex:1;margin:5px 0 0 10px;text-align:left;'><label>" + obj.MusicName + "</label></a><label style='flex:1;margin:5px 0 0 10px;text-align:left;'>" + obj.MusicTime + "</label><a href='#' style='text-decoration:none;flex:1;margin:5px 0 0 10px;padding:0px;text-align:left;'><label>" + obj.SongsterName + "</label></a><a style='text-decoration:none;flex:1;margin:5px 0 0 10px;padding:0px;text-align:left;'><label>" + obj.TypeName + "</label></a></div> ";
                $("#Div_Music_show").append(musi);
            })
        }
    });
}


//歌曲

