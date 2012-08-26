/* File Created: 七月 5, 2012 */

$(document).ready(function () {
GetTradePageInfo();
});


var PageID; //页码全局变量
var PageName; //总页码
//根据课程ID 获取所有课程的章节信息
function CourseInfo(pageIndex, uid, ctype, tstr, st,actions,strKEY,strDept) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: actions,
            uid: uid,
            CourseType: ctype,
            TimeStr:tstr,
            SortT: st,
            PDT: strDept,
            StrKey:strKEY,
            PageIndex: pageIndex
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createRows(resultData.DATA, pageIndex);
            } else {
                $("#modInfo").html("没找到相关章节信息");
                $('.pages').find('a').remove();
            }
        }
    });
}


//获取分页信息
function GetTradePageInfo() {

    var actions='GetCourseByUserID';

    var uid=$.getUrlParam('uid');
    var ctype=$("#HfcourseType").val();
    var tstr=$("#hfDate").val();
    var st=$("#hfSortType").val();
    var strKEY=$.getUrlParam('key');
    var strDept=$.getUrlParam('did');
         CourseInfo(1, uid, ctype, tstr, st, actions,strKEY,strDept);

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: actions,
            PageIndex: 1,
            uid: uid,
            CourseType: ctype,
            TimeStr: tstr,
            SortT: st,
            PDT:strDept ,
            StrKey:strKEY,
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
                        CourseInfo(pageIndex, uid, ctype, tstr, st, actions,strKEY,strDept);
                    });

                    $(".First").click(function () {
                        if ($(".First").css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            PageID = parseInt(PageID) - 1;
                        CourseInfo(pageIndex, uid, ctype, tstr, st, actions,strKEY,strDept);
                        }
                    });
                    $(".Next").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) + 1;
                        CourseInfo(pageIndex, uid, ctype, tstr, st, actions,strKEY,strDept);
                        }
                    });
                }
            } else {
                $("#" + tableId).html("没找到相关账户信息");
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
        lis += '<a href="show.aspx?cid=' + n.CourseID + '" target="_blank"><img src="' +ImgManage( n.ImageUrl )+ '" width="95" height="63" />' + cutstr(n.CourseName, 19) + '</a>';
        lis += '<p>';
        lis += '<strong>时长：</strong>' + arrive_timer_format(n.TimeDuration) + '  | ';
        lis += ' <strong>教师：</strong>' + n.TrueName + ' (共'+TeacherInfo(n.CourseID)+'人）  | ';
        lis += '<strong>已选/关注：</strong>'+GetChoseCount( n.CourseID)+'/'+GetFavCount(n.CourseID)+' </p>';
        lis += '<p><strong>分类：</strong>'+navInfo(n.CategoryId)+'  |  ';
        lis += '<strong>价格：</strong>' + managePrice(n.Price) + '</p></li>';

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


function ImgManage(imgPath) {
    if (!imgPath ) {
        return "/images/pics/none.gif";
    } else {
    return imgPath;
    }
}

function managePrice(price) {
    if (price == 0) {
        return '免费&nbsp;';
    } else {
        return '¥' + price + '&nbsp;';
    }
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

function navInfo(uid) {
    var nav="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async:false,
        data: {
            action: 'GetCateNav',
            uid: uid
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