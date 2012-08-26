
$(document).ready(function () {
    $("[id$='txtUserName']").focus(function () {
        $("#MsgUserName").html('<div  class=\"zcsuccedbj\">4-20位汉字、数字、字母组成</div>');
    }).blur(function () {
        userOnBlur();
    });
    $("[id$='txtMail']").focus(function () {
        $("#MsgEmail").html('<div  class=\"zcsuccedbj\">请输入电子信箱，可用于登录和找回密码</div>');
    }).blur(function () {
        EmailCheck();
    });
    $("[id$='txtPass']").focus(function () {
        $("#msgPassword").html('<div  class=\"zcsuccedbj\">密码需由6-16个字符，区分大小写</div>');
    }).blur(function () {
        PwdCheck();
    });
    $("[id$='txtConfirm']").focus(function () {
        $("#MsgConfirm").html('<div  class=\"zcsuccedbj\">请再次输入您的密码</div>');
    }).blur(function () {
        ComPwdCheck();
    });

    $("[id$='btnSubmit']").click(function () {
        userOnBlur();
        EmailCheck();
        PwdCheck();
        ComPwdCheck();
        CheckAgreement();
        if (userresult && emailresult && pwdresult && conresult && agreement) {
            return true;
        } else {
            return false;
        }
    });

});

function change() {
    $("[id$='ImageCheck']").attr("src", "ValidateCode.aspx?" + Math.random());
}
function registerClick() {
    if (checkName() == false || checkPass() == false || checkConfirm() == false || checkMail() == false || CheckCode() == false) {
        return false;
    }
    return true;
}

var patrn = /^[0-9A-Za-z_]{4,20}$/ ;  //用户名
var patrn1 = /^([a-zA-Z0-9]|[._]){6,16}$/;

function isEmail(value) {
    var patrn = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;//
    if (!patrn.exec(value)) {
        return false;
    } else {
        return true;
    }
}

var userresult;
function userOnBlur() {
    var userName = $("[id$='txtUserName']").val();
    if (!userName) {
        $("#MsgUserName").html('<div  class=\"zcsuccedbja\">4-20位汉字、数字、字母组成</div>');
        userresult = false;
        return false;
    } else if (userName.length > 20 || userName.length < 4) {
        $("#MsgUserName").html('<div  class=\"zcsuccedbja\">4-20位汉字、数字、字母组成</div>');
        userresult = false;
        return false;
    } else if (!patrn.exec(userName)) {
        $("#MsgUserName").html('<div  class=\"zcsuccedbja\">用户名只能由汉字、字母， 数字和下划线组成！</div>');
        userresult = false;
        return false;
    } 
    else {

        //用户名框的onblur事件里的自动检测用户名是否重名
        $.ajax({
            url: "RegisterValidate.aspx",
            type: 'post', dataType: 'text', timeout: 10000, async: false,
            data: { action: "CheckUser", UserName: userName },
            success: function (resultData) {
                if (resultData == "COUNTREG") {
                    $("#MsgUserName").html('<div  class=\"zcsuccedbja\">该用户名已经存在！请重新输入！</div>');
                    userresult = false;
                    return false;
                } else if (resultData == "ERRORPARA") {
                    alert("网络忙，请稍后再试!");
                    userresult = false;
                    return false;
                }
                else {
                    $("#MsgUserName").html('<div  class=\"zcduigou\"><img src=\"images/duigou.gif\" width=\"17\" height=\"13\" /></div>');
                    userresult = true;
                    return true;
                }
            }
        });
    }
}

var emailresult;
function EmailCheck() {
    var inputEmail = $("[id$='txtMail']").val();
    if (!inputEmail) {
        $("#MsgEmail").html('<div  class=\"zcsuccedbja\">输入邮箱格式不正确！</div>');
        emailresult = false;
        return false;
    } else if (inputEmail.length > 45) {
        $("#MsgEmail").html('<div  class=\"zcsuccedbja\">输入邮箱过长，邮件地址只能在50个字符以内！</div>');
        emailresult = false;
        return false;
    } else if (!isEmail(inputEmail)) {
        $("#MsgEmail").html('<div  class=\"zcsuccedbja\">输入邮箱格式不正确！</div>');
        emailresult = false;
        return false;
    } else {
        //用户名框的onblur事件里的自动检测邮箱是否已经注册
        $.ajax({
            url: "RegisterValidate.aspx",
            type: 'post', dataType: 'text', timeout: 10000, async: false,
            data: { action: "CheckEmil", Email: inputEmail },
            success: function (resultData) {
                if (resultData == "COUNTREG") {
                    $("#MsgEmail").html('<div  class=\"zcsuccedbja\">该邮箱已被使用，请更换其它邮箱！</div>');
                    emailresult = false;
                    return false;
                } else if (resultData == "ERRORPARA") {
                    alert("网络忙，请稍后再试!");
                    emailresult = false;
                    return false;
                }
                else {
                    $("#MsgEmail").html('<div  class=\"zcduigou\"><img src=\"images/duigou.gif\" width=\"17\" height=\"13\" /></div>');
                    emailresult = true;
                    return true;
                }
            }
        });
    }
}

var agreement;
function CheckAgreement() {
    if ($("[id$='chkAgree']").attr("checked") != true) {
        ShowFailTip("阅读并同意《陶老师服务协议》后方可注册！", 2000);
        agreement = false;
        return false;
    } else {
        agreement = true;
    }
}

var pwdresult;
function PwdCheck() {
    var inputPwd = $("[id$='txtPass']").val();
    var inputConfirmPwd = $("[id$='txtConfirm']").val();
    if (!inputPwd) {
        $("#msgPassword").html('<div  class=\"zcsuccedbja\">密码需由6-16个字符，区分大小写！</div>');
        pwdresult = false;
        return false;
    }
    else  if (inputConfirmPwd && inputPwd != inputConfirmPwd) {
        $("#msgPassword").html('<div  class=\"zcsuccedbja\">两次输入密码不一致！</div>');
        pwdresult = false;
        return false;
    } else {
        $("#msgPassword").html('<div  class=\"zcduigou\"><img src=\"images/duigou.gif\" width=\"17\" height=\"13\" /></div>');
        pwdresult = true;
        return true;
    }
}

var conresult;
function ComPwdCheck() {
    var inputPwd = $("[id$='txtPass']").val();
    var inputConfirmPwd = $("[id$='txtConfirm']").val();
    if (!inputConfirmPwd || inputPwd != inputConfirmPwd) {
        $("#MsgConfirm").html('<div  class=\"zcsuccedbja\">两次输入密码不一致！</div>');
        conresult = false;
        return false;
    } else {
        $("#MsgConfirm").html('<div  class=\"zcduigou\"><img src=\"images/duigou.gif\" width=\"17\" height=\"13\" /></div>');
        conresult = true;
        return true;
    }
}

var codereuslt;
function CheckInputCode() {
    var inputCode = $("[id$='txtCheckCode']").val();
    if (!inputCode) {
        $("#msgCode").html('<div  class=\"zcsuccedbja\">请输入图片中的字符，不区分大小写！</div>');
        codereuslt = false;
        return false;
    } else {
        //用户名框的onblur事件里的自动检测验证码是否输入正确
        $.ajax({
            url: "RegisterValidate.aspx",
            type: 'post', dataType: 'text', timeout: 10000, async: false,
            data: { action: "CheckCode", InputCode: inputCode },
            success: function (resultData) {
                if (resultData == "FAILED") {
                    $("#msgCode").html('<div  class=\"zcsuccedbja\">输入验证码错误！请重新输入！</div>');
                    codereuslt = false;
                    return false;
                } else if (resultData == "SESSIONERROR") {
                    alert("验证码失效，请重新刷新页面！");
                    codereuslt = false;
                    return false;
                } else if (resultData == "ERRORPARA") {
                    alert("网络忙，请稍后再试!");
                    codereuslt = false;
                    return false;
                }
                else {
                    $("#msgCode").html('<div  class=\"zcduigou\"><img src=\"images/duigou.gif\" width=\"17\" height=\"13\" /></div>');
                    codereuslt = true;
                    return true;
                }
            }
        });
    }
}

function checkMail() {
    var Mail = $("[id$='txtMail']").val();
    if (Mail == "") {
        $('#MsgMail').text('请您输入邮箱！').show();
        return false;
    }
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
    if (!reg.test(Mail)) {
        $('#MsgMail').text('您输入的邮箱格式不正确！').show();
        return false;
    }
    $('#MsgMail').hide();
}

