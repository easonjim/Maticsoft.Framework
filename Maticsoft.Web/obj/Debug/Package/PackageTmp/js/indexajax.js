/* File Created: 六月 26, 2012 */
$(document).ready(function () {
    ajaxload();
    GetRecommendList();
    GetOfflineList();
    GetpublicCourseList();
    GetLifeCourseList(23, 'life', 'l', 'r'); //生活
    GetLifeCourseList(8, 'trade', 'tradel', 'trader'); //商业职场
    GetLifeCourseList(16, 'compute', 'computel', 'computer'); //计算机与网络
    GetLifeCourseList(63, 'art', 'artl', 'artr'); //艺术
    GetLifeCourseList(30, 'lau', 'laul', 'laur'); //语言
    GetLifeCourseList(65, 'stu', 'stul', 'stur'); //中小学教育
    GetLifeCourseList(1, 'prof', 'profl', 'profr'); //职业认证
    GetLifeCourseList(64, 'sports', 'sportsl', 'sportsr'); //体育
    TeacherRecommended();
    GethotKey();
});


var PageID; //页码全局变量
var PageName; //总页码

//获取推荐课程信息
function GetRecommendList() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "Recommended"
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, 'rec');
            } else {
                $("#rec").html("没找到相关课程信息")
            }
        }
    });
}


//获取线下课程信息
function GetOfflineList() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "OffLineCourse"
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createOffLineLi(resultData.DATA, 'offline');
            } else {
                $("#rec").html("没找到相关课程信息")
            }
        }
    });
}


//根据数据数组，添加表格行列
function createOffLineLi(jsonArr, ulId) {
    var libody = "";
    var MainUl = $("#" + ulId);
    MainUl.find('li').remove();
    $.each(jsonArr, function (i, n) {
        var lis = "";

        lis += '<li><a href="#" class="img"><img src="' + n.ImageUrl + '" width="129" height="86" /></a>';
        lis += '<a href="OnlineBook.aspx?cid=' + n.CourseID + '"  target="_blank" ><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　';
        lis += '<a href="Offlineshow.aspx?cid=' + n.CourseID + '" target="_blank" class="tit">' + cutstr(n.CourseName, 14) + '</a>';
        lis += '<p>时间：' +n.TimeDuration + '<br />';
        lis += '地点：' + cutstr(GetRegionName(n.RegionID), 12) + '<br />';
        lis += '讲师：' + getName(n.CreatedUserID) + '&nbsp;&nbsp; 价格：' + manageOffPrice(n.Price) + '</p></li> ';
        if (i == 1) {
            lis += '<li style="position:relative;top:-35px;margin:10px 0 -35px 10px;height:255px;"><img src="imagesN/TLaoShi_bg084.gif" width="162" height="231" /></li> ';
        }
        libody += lis
    });
    MainUl.append(libody);

}


function manageOffPrice(price) {
    if (price == 0) {
        return '<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" />';
    } else {
        return '¥' + price + '&nbsp;';
    }
}

function GetRegionName(regionId) {
    var name="";
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "RegionName",
            regionId: regionId
        },
        async: false,
        success: function (UserData) {
            if (UserData.STATUS == "SUCCESS") {
                name = UserData.DATA;

            } else {
            }
        }
    });
    return name;
}

function getName(uid) {
    var uname;
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "UserInfo",
            Uid: uid
        },
        async: false,
        success: function (UserData) {
            if (UserData.STATUS == "SUCCESS") {
                uname = UserData.UserName;

            } else {
            }
        }
    });
    return uname;
} 


function GethotKey() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "HotKey"
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                ShowHotKey(resultData.DATA);
            } else {
                $("#hotkey").html("");
            }
        }
    });
}

function ShowHotKey(jsonArr) {
    var libody = "";
    var MainDiv = $("#hotkey");
    MainDiv.find('a').remove();
    $.each(jsonArr, function (i, n) {
        var lis = "";
        var tags = SplitHotstr(n.Tags, ' ');
        lis += tags;
        libody += lis
    });
    MainDiv.append(libody);
}


function SplitHotstr(str, separator) {
    if (!str) {
        return "";
    }
    str = cutstr(str, 10);
    var arr = str.split(separator);
    var resu = '';
    for (var i = 0; i < arr.length; i++) {
        resu += '<a href="courselist.aspx?key=' + escape(arr[i].substring(0, 2)) + '&type=0" title="' + arr[i] + '">' + arr[i] + '</a>';
    }
    return resu;
}



//获取公开课课程信息
function GetpublicCourseList() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "PubCourse"
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, 'pub');
            } else {
                $("#pub").html("没找到相关课程信息");
            }
        }
    });
}

var AllpageSize = 2;
//获取生活课程信息
function GetLifeCourseList(cid, ulId, l, r) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "OtherCourse",
            CateId: cid,
            pageIndex: 1,
            pageSize: AllpageSize
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, ulId);
                createPageBar(cid, ulId, 1, resultData.ROWCOUNT, resultData.PAGECOUNT, l, r);
            } else {
                $("#" + ulId).html("没找到相关课程信息");
            }
        }
    });
}

//根据数据数组，添加表格行列
function createLi(jsonArr, ulId) {
    var libody = "";
    var MainUl = $("#" + ulId);
    MainUl.find('li').remove();
    $.each(jsonArr, function (i, n) {
        var lis = "";
        lis += '<li><a href="OnLineCourse.aspx?cid=' + n.CourseID + '" target="_blank"><img src="' + n.ImageUrl + '" width="170" height="113" />' + cutstr(n.CourseName, 19) + '</a>';
        lis += '<p>时长：' + arrive_timer_format(n.TimeDuration) + '<br />';
        lis += '老师：' + n.TrueName + '<br />';
        lis += '价格：' + managePrice(n.Price) + '<img src="imagesN/TLaoShi_bg090.gif" width="19" height="11" /></p></li>';
        libody += lis
    });
    MainUl.append(libody);
}

//分页
function createPageBar(cid, ulId, pageIndex, rowcount, pagecount, l, r) {
    var pageBarDivR = $("#" + r);
    var pageBarDivL = $("#" + l);
    pageBarDivR.find('a').remove();
    pageBarDivL.find('a').remove();
    pageBarDivL.append(" <a href='javascript:loadPagedList(" + cid + ",\"" + ulId + "\"," + prevPage(pageIndex) + ",\"" + l + "\",\"" + r + "\"" + ")' class='l'></a> ");
    pageBarDivR.append(" <a href='javascript:loadPagedList(" + cid + ",\"" + ulId + "\"," + lastPage(pageIndex, pagecount) + ",\"" + l + "\",\"" + r + "\"" + ")' class='r' ></a> ");
}

function loadPagedList(cid, ulId, pi, l, r) {
    var pageBarDivR = $("#" + r);
    var pageBarDivL = $("#" + l);
    pageBarDivR.find('a').remove();
    pageBarDivL.find('a').remove();
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "OtherCourse",
            CateId: cid,
            pageIndex: pi,
            pageSize: AllpageSize
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, ulId);
                createPageBar(cid, ulId, pi, resultData.ROWCOUNT, resultData.PAGECOUNT, l, r);
            } else {
                $("#" + ulId).html("没找到相关课程信息");
            }
        }
    });
}


//上一页
function prevPage(pageIndex) {
    if (pageIndex > 1) return pageIndex - 1;
    else return 1;
}
//下一页
function lastPage(pageIndex, pageCount) {
    if (pageIndex < pageCount) return pageIndex + 1;
    else return pageCount;
}


function TeacherRecommended() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "TeaRec",
            TopNum: 2
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createTecLi(resultData.DATA);
            } else {
                $("#teacher").html("没找到相关教师信息");
            }
        }
    });
}

//根据数据数组，添加表格行列
function createTecLi(jsonArr) {
    var libody = "";
    var MainUl = $("#teacher");
    MainUl.find('li').remove();
    for (var i = 0; i < jsonArr.length; i++) {
        $.each(jsonArr[i], function (j, n) {
            var lis = "";
            lis += '<li><a href="TeacherDetailInfo.aspx?uid=' + n.UserID + '" target="_blank"><img src="' + n.UserAvatar + '" width="100" height="113" />姓名：' + cutstr(n.TrueName, 10) + ' </a>';
            lis += '<p>标签：' + Splitstr(n.Tags, '|') + '<br />';
            lis += '职业：' + cutstr(n.UserCareer, 10) + ' <br />';
            lis += '课程：<a href="searchCourse.aspx?key=' + n.TrueName + '&uid=' + n.UserID + '" target="_blank"><img src="imagesN/TLaoShi_bg092.gif" width="19" height="11" style="margin-top:-15px;margin-left:35px;" /> </a></p></li>';
            libody += lis
        });
    }
    MainUl.append(libody);
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

function Splitstr(str, separator) {
    if (!str) {
        return "";
    }
    str = cutstr(str, 10);
    var arr = str.split('|');
    var resu = '';
    for (var i = 0; i < arr.length; i++) {
        resu += '<a href="#" style="color:#8c8b8b;font-family:tahoma;font-size:12px;font-weight:normal;">' + arr[i] + '</a>&nbsp;'
    }
    return resu;
}

//时间秒数格式化
function arrive_timer_format(s) {
    var t;
    if (s > -1) {
        hour = Math.floor(s / 3600);
        min = Math.floor(s / 60) % 60;
        sec = s % 60;
        //day = parseInt(hour / 24);
        //if (day > 0) {
        //    hour = hour - 24 * day;
        //    t = day + "day " + hour + ":";
        //}
        //else
        if (hour < 10) { hour = '0' + hour; }
        t = hour + ":";
        if (min < 10) { t += "0"; }
        t += min + ":";
        if (sec < 10) { t += "0"; }
        t += sec;
    }
    return t;
}

function managePrice(price) {
    if (price == 0) {
        return '免费&nbsp;';
    } else {
        return '¥' + price + '&nbsp;';
    }
}




function LoadComment(data, pageindex) {
    $('#comInfo').empty();
    var libody = "";
    $.each(data, function (i, n) {
        var lis = "";
        var lis = '<li>';
        lis += '<div  class="HuiFu">';
        lis += '<a id="' + n.CommentID + '" href="javascript:void(0);" class="HuiFSub">' + n.CommentInfo + '<strong>（' + n.CCount + '回复）</strong></a>';
        lis += '</div>';
        lis += '<div class="TianChon">';
        lis += '</div>';
        lis += ' </li>';
        libody += lis;
    });
    $('#comInfo').append(libody);
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

function CreateChildCom(jsonArr,index) {
    var libody = "";
    var ComDiv = $(".TianChon" + index);
    ComDiv.empty();
        $.each(jsonArr, function (j, n) {

            var content = '<div class="HuiFBox"  style="display:none;"><p>' + n.CommentInfo + '</p></div>';
            libody += content
        });
    ComDiv.append(libody);
}

function ajaxload() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "SelectPage"
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
                    $('.pages').append(count);

                    $(".pageID").click(function () {
                        var pageIndex = $(this).text();
                        LoadPage(pageIndex);
                    });

                    $(".First").click(function () {
                        if ($(".First").css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            PageID = parseInt(PageID) - 1;
                            LoadPage(pageIndex);
                        }
                    });
                    $(".Next").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) + 1;
                            LoadPage(pageIndex);
                        }
                    });
                }
            } else {
                $("#comInfo").html("暂时没有评论信息");
            }
        }
    });
    LoadPage(1);
}

function LoadPage(pageIndex) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "FirstPage",
            PageIndex: pageIndex
        },
        success: function (PageData) {
            if (PageData.STATUS == "SUCCESS") {
                LoadComment(PageData.DATA, pageIndex);
                HuiFu(); //评论信息
            } else {
                $("#comInfo").html("暂时没有评论信息");
            }
        }
    });
}


function HuiFu() {
    var res = 0;
    $('.HuiFSub').each(function (index) {
        var stre = function () {
            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "joinCom",
                    ParentID: $('.TianChon').eq(index).parent().find('a').attr('id')
                },
                success: function (ChildData) {
                    if (ChildData.STATUS == "SUCCESS") {
                        var libody = "";
                        $.each(ChildData.DATA, function (j, n) {
                            var content = '<div class="HuiFBox"  style="display:none;"><p>' + n.CommentInfo + '</p></div>';
                            libody += content
                        });
                        $('.TianChon').eq(index).html(libody);
                        $('.HuiFBox').slideDown();
                    } else {
                        $("#TianChon").html("暂时没有回复信息");
                    }
                }
            });
        };

        var save = $(this);
        save.click(function () {
            if ($('.TianChon').eq(index).children('.HuiFBox').length > 0) {
                $('.HuiFBox').slideUp('slow', function () {
                    $('.TianChon').empty();
                });
            } else {
                if ($('.HuiFBox').length > 0) {
                    $('.HuiFBox').slideUp('slow', function () {
                        $('.TianChon').empty();
                        stre();
                    });
                } else {
                    stre();
                }
            }
        })
    })
}