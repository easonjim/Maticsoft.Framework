/* File Created: 七月 6, 2012 */


$(document).ready(function () {

    GetTradePageInfo();
});

var PageID; //页码全局变量
var PageName; //总页码
//根据课程ID 获取所有课程的章节信息
function CourseInfo(pageIndex, actions,strKEY) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: actions,
            StrKey:strKEY,
            PageIndex: pageIndex
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createRows(resultData.DATA, pageIndex);
            } else {
                $("#modInfo").html("没找到相关教师信息");
                $('.pages').find('a').remove();
            }
        }
    });
}


//获取分页信息
function GetTradePageInfo() {

    var actions='GetTeacherByKEY';

    var strKEY=$.getUrlParam('key');
         CourseInfo(1,actions,strKEY);

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: actions,
            PageIndex: 1,
            StrKey:strKEY
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                PageName = resultData.PAGECOUNT;
                if (resultData.PAGECOUNT != 0) {
                    var count = "<a class=\"First\" href=\"javascript:void(0);\">上一页</a>";
                    if (resultData.PAGECOUNT > 10) {
                        for (i = 1; i <= 10; i++) {
                            count += "<a  class=\"pageID\" href=\"javascript:void(0);\">" + i + "</a>";
                        }
                    }
                    else {
                        for (i = 1; i <= resultData.PAGECOUNT; i++) {
                            count += "<a class=\"pageID\" href=\"javascript:void(0);\">" + i + "</a>";
                        }
                    }
                    count += "<a class=\"Next\" href=\"javascript:void(0);\">下一页</a>";
                    $('.pages').find('a').remove();
                    $('.pages').append(count);

                    $(".pageID").click(function () {
                        var pageIndex = $(this).text();
         CourseInfo(pageIndex,actions,strKEY);
                    });

                    $(".First").click(function () {
                        if ($(".First").css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            PageID = parseInt(PageID) - 1;
         CourseInfo(pageIndex,actions,strKEY);
                        }
                    });
                    $(".Next").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) + 1;
         CourseInfo(pageIndex,actions,strKEY);
                        }
                    });
                }
            } else {
                $("#" + tableId).html("没找到相关教师信息");
                $('.pages').find('a').remove();
            }
        }
    });
}


function createRows(jsonArr, pageindex) {
    var libody = "";
    var MainTable = $("#modInfo");
    MainTable.find('li').remove();
    MainTable.html('');
    $.each(jsonArr, function (i, n) {
        var lis = "";
        lis += '<li>';
        lis += '<a href="TeacherDes.aspx?uid=' + n.UserID + '" target="_blank"><img src="' + getTeacherInfo(n.UserID, 0) + '" width="95" height="63" />' + n.TrueName + '</a>';
        lis += '<p>';
        lis += ' <strong>认证：</strong>' + getAuthentic(n.UserID) + '  | ';
        lis += '<strong>共开课数：</strong>' + getCourseCount(n.UserID) + '</p>';
        lis += '<p><strong>标签：</strong>' + getTeacherInfo(n.UserID, 1) + '  |<a href="TeacherDes.aspx?uid=' + n.UserID + '" target="_blank" style="font-size:12px;color:Gray;font-weight:normal;background:none;padding-left:0px;">详细信息</a></p>  ';

        libody += lis
    });
    MainTable.append(libody);

    PageID = 1;
    PageID = pageindex; //获取返回的页码

    var Fir = Number($(".pageID").eq(0).text());
    var zongye = Math.round(Number(PageName) / 10);
    $(".pageID").each(function (a) {

        if (Number($(this).text()) == PageID) {
            if (a > 8) {
                var d = a - 4;
                $(".pageID").empty();

                for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                    var num = b + d;
                    $(".pageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                    if (b + d >= Number(PageName))
                        break;
                }
            }
            if (a == 0 && Fir != 1) {
                var d = 5 - a;
                $(".pageID").empty();
                for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                    var num = b - d;
                    $(".pageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                }
            }
        }
    })

    $(".pageID").each(function () {
        if (Number($(this).text()) == PageID) {
            $(".pageID").css("background", "#FFF");
            $(this).css("background", "#FC9");
        }
    })

    if (Number(PageID) == 1)//先初始化
    {
        $(".First").css("cursor", "default");
        $(".First").css("background", "#F3F4F6");
        $(".First").css("color", "#999");
        $(".pageID").eq(0).css("background", "#FC9");
        $(".Next").css("cursor", "pointer");
        $(".Next").css("color", "#000");
        $(".First").css("text-decoration", "none");
    }
    else {
        $(".First").css("cursor", "pointer");
        $(".First").css("color", "#000");
        if (Number(PageName) == Number(PageID))//判断是否点击最后一个数
        {
            $(".Next").css("cursor", "default");
            $(".Next").css("background", "#F3F4F6");
            $(".Next").css("color", "#999");
            $(".Next").css("text-decoration", "none");
        }
        else {
            $(".Next").css("cursor", "pointer");
            $(".Next").css("color", "#000");
        }
    }

    if (Number(PageName) == 1 && Number(PageID) == 1) {
        $(".First").css("cursor", "default");
        $(".First").css("background", "#F3F4F6");
        $(".First").css("color", "#999");
        $(".First").css("text-decoration", "none");
        $(".Next").css("cursor", "default");
        $(".Next").css("background", "#F3F4F6");
        $(".Next").css("color", "#999");
        $(".Next").css("text-decoration", "none");
    }
}

function getAuthentic(uid) {
    var nav = "";

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async: false,
        data: {
            action: 'GetAuthentic',
            uid: uid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                nav = resultData.COUNT;
            } else {
                nav = "";
            }
        }
    });
    return nav;
}

function getTeacherInfo(uid,utype) {
    var nav = "";

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async: false,
        data: {
            action: 'GetTeachInfo',
            uid: uid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                if (utype == 0) {
                    //pic
                    if (resultData.UserAvatar) {
                        nav = resultData.UserAvatar;
                    } else {
                        nav = "/images/pics/none.gif";
                    }
                } else {
                    //tags
                    if (resultData.Tags) {
                        nav = resultData.Tags;
                    } else {
                        nav = "   ";
                    }
                }
            } else {
                nav = "";
            }
        }
    });
    return nav;
}




function getCourseCount(uid) {
    var nav = "";

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async: false,
        data: {
            action: 'getCourseCount',
            uid: uid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                nav = resultData.COUNT;
            } else {
                nav = "0";
            }
        }
    });
    return nav;
}


//截取字符串
function cutstr(str, len) {
    var str_length = 0;
    var str_len = 0;
    if (!str) {
        return "";
    }
    str_cut = new String();
    str_len = str.length;
    for (var i = 0; i < str_len; i++) {
        a = str.charAt(i);
        str_length++;
        if (escape(a).length > 4) {
            //中文字符的长度经编码之后大于4
            str_length++;
        }
        str_cut = str_cut.concat(a);
        if (str_length >= len) {
            str_cut = str_cut.concat("...");
            return str_cut;
        }
    }
    //如果给定字符串小于指定长度，则返回源字符串；
    if (str_length < len) {
        return str;
    }
}

function navInfo(cateid) {
    var nav="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async:false,
        data: {
            action: 'GetCateNav',
            cateID: cateid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                nav= resultData.NAV;
            } else {
            nav= "";
            }
        }
    });
    return nav;
}


function TeacherInfo(courserid) {
    var num="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async:false,
        data: {
            action: 'GetTeacherCount',
            cid: courserid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                num= resultData.NUM;
            } else {
            num= "";
            }
        }
    });
    return num;
}


function GetFavCount(courserid) {
    var num="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async:false,
        data: {
            action: 'GetFavCount',
            cid: courserid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                num= resultData.NUM;
            } else {
            num= "";
            }
        }
    });
    return num;
}


function GetChoseCount(courserid) {
    var num="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async:false,
        data: {
            action: 'GetChoseCount',
            cid: courserid
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                num= resultData.NUM;
            } else {
            num= "";
            }
        }
    });
    return num;
}