var Registerdisplay = 1;
//验证昵称
function NameBlur() {
    var us = document.getElementById("username").value;
    if (us == null || us == "") {
        document.getElementById("username").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
    }
    else {
        document.getElementById("username").style.backgroundColor = "white";
        Registerdisplay += 1;
    }
}
//验证时间格式
function Birthtime() {
    var time = document.getElementById("Birth").value;
    var rex = /^(\d{4})-(0\d{1}|1[0-2])-(0\d{1}|[12]\d{1}|3[01])$/;
    if (!rex.test(time)) {
        document.getElementById("Birth").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
    }
    else {
        document.getElementById("Birth").style.backgroundColor = "white";
        Registerdisplay += 1;
    }
}
//验证重复密码
function Repwdyz() {
    var pwd = document.getElementById("Pwd").value;
    var repwd = document.getElementById("Repwd").value;
    if (repwd == pwd) {
        document.getElementById("Repwd").style.backgroundColor = "white";
        Registerdisplay += 1;
    }
    else if(repwd==""||pwd=="")
    {
        document.getElementById("Repwd").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
        document.getElementById("Pwd").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
    }
}

//验证手机号码
function phoneyz() {
    var ph = document.getElementById("phone").value;
    var re = /^1\d{10}$/
    if (!re.test(ph))
        document.getElementById("phone").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
    else {
        document.getElementById("phone").style.backgroundColor = "white";
        Registerdisplay += 1;
    }
}
//验证邮箱
function Emailyz() {
    var em = document.getElementById("E_mail").value;
    var re = /^[a-zA-Z0-9_-]+@([a-zA-Z0-9]+\.)+(com|cn|net|org)$/;
    if (!re.test(em)) {
        document.getElementById("E_mail").style.backgroundColor = "rgba(222, 191, 17, 0.84)";
    }
    else {
        document.getElementById("E_mail").style.backgroundColor = "white";
        Registerdisplay += 1;
    }
}
function BtnRegister_dis()
{
    if (Registerdisplay == 5) {
        document.getElementById("BtnRegister").removeAttribute("disabled");
    }
}


