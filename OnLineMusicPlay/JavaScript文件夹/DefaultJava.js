window.onload = function showMusicList() {
    $.ajax({
        url: "DefaultJava.ashx",
        type: "get",
        success: function (data) {
            var jsdata = $.parseJSON(data);
            $.each(jsdata, function (i, obj) {
                var xw = "<div style='position:relative;width:200px;height:200px;float:left;margin:10px 5px 0 15px'><img src='" + obj.ImageUrl + "' alt='' style='width:200px;height:200px;' /><span style='position:absolute;bottom:0 ;left:0;width:200px;height:40px;background-color:rgba(255, 255, 255, 0.60);border-top:2px double black;'><label style='font-size:16px;color:rgba(168, 209, 63, 0.85);margin:6px 3px 0 10px;float:left;'>" + obj.AlbumName + "</label>  <label style='font-size:20px;color:deepskyblue;margin:6px 2px 0 25px;float:left;'>" + obj.Listeners + " </label><label style='font-size:25px;margin:4px 10px 0 0;padding:0px;float:left;'>♪</label></span></div>";
                $("#Div_showList_1").append(xw);
            })
        }
    });
}