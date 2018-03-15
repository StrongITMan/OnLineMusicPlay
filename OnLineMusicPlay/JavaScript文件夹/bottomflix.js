//返回顶部触发函数
function backtop() {
    if (document.documentElement.scrollTop + document.body.scrollTop > 100) {
        document.getElementById("homehide").style.display = "block";
    }
    else {
        document.getElementById("homehide").style.display = "none";
    }
};
// 播放音频和暂停音频
function Playpause() {
    var audio = document.getElementById("js-video");
    var index = document.getElementById("js-play").src;
    if (index.substring(index.lastIndexOf("/") + 1) == "bfzn_004.ico") {
        $("#js-play").attr('src', '../images/imagepang/bfzn_003.ico');
        audio.play(); //播放
    }
    else if (index.substring(index.lastIndexOf("/") + 1) == "bfzn_003.ico") {
        $("#js-play").attr('src', '../images/imagepang/bfzn_004.ico');
        audio.pause();//暂停
    }
};

//音量控制条
function change() {
    var valu = document.getElementById('range').value;
    document.getElementById('Mv1').innerHTML = valu;
    document.getElementById('js-video').volume = valu / 100;
}
//声音图标的点击事件
function musicstop() {
    var xw = document.getElementById('Mv1').innerText;
    if (xw == 0) {
        document.getElementById('js-video').volume = 0.5;
        document.getElementById('range').value = 50;
        document.getElementById('Mv1').innerHTML = 50;
    }
    else {
        document.getElementById('js-video').volume = 0;
        document.getElementById('range').value = 0;
        document.getElementById('Mv1').innerHTML = 0;
    }
}

    //音乐播放进度条和显示时间
$(function () {
    AudioControl('js-video')
    function AudioControl(id) {
        // 音频控制进度条
        var audio = document.getElementById(id);
        $(audio).on('loadedmetadata', function () {
            audio.pause();
            // 进度条控制
            $(document).on('touchend', '.timeline', function (e) {
                var x = e.originalEvent.changedTouches[0].clientX - this.offsetLeft;
                var X = x < 0 ? 0 : x;
                var W = $(this).width();
                var place = X > W ? W : X;
                audio.currentTime = (place / W).toFixed(2) * audio.duration
                $(this).children().css({ width: (place / W).toFixed(2) * 100 + "%" })
            });
        })
        setInterval(function () {
            var currentTime = audio.currentTime;
            setTimeShow(currentTime);
        }, 1000);
        //设置播放时间
        function setTimeShow(t) {
            t = Math.floor(t);
            var playTime = secondToMin(audio.currentTime);
            $("#sizetime").html(playTime);
            $("#timeshowtime").text(secondToMin(audio.duration));
            $('.timeline').children().css({ width: (t / audio.duration).toFixed(4) * 100 + "%" });
        }
        // 计算时间
        
        function secondToMin(s) {
            var MM = Math.floor(s / 60);
            var SS = s % 60;
            if (MM < 10)
                MM = "0" + MM;
            if (SS < 10)
                SS = "0" + SS;
            var min = MM + ":" + SS;
            return min.split('.')[0];
        }
    }
})