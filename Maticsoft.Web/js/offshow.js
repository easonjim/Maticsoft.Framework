/* File Created: 六月 29, 2012 */

$(document).ready(function () {
    GetTradePageInfo();
    $(".button29").click(function () {
        if (!$("[id$='hfUid']").val()) {
            ShowFailTip('你尚未登录，请登陆后再进行评论！', 2000);
            return false;
        } else if (!$(".textarea03").val()) {
            ShowFailTip('请输入评论内容！', 2000);
            return false;
        }
        else if (!$(".textarea03").val().length > 110) {
            ShowFailTip('评论内容不能超过110个字符！', 2000);
            return false;
        } else {
            $.ajax({
                url: "HomeIndex.aspx",
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                data: {
                    action: "InsertCom",
                    Uid: $("[id$='hfUid']").val(),
                    Mid: $.getUrlParam('mid'),
                    Cid: $.getUrlParam('cid'),
                    Ctype: $("[id$='CommentType']").val(),
                    Pid: 0,
                    Con: $(".textarea03").val()
                },
                success: function (AddData) {
                    if (AddData.STATUS == "SUCCESS") {
                        ShowSuccessTip('评论成功！');
                        ajaxload();
                        $(".textarea03").val('');
                    } else {
                        ajaxload();
                    }
                }
            });
        }
    });
    ajaxload();

    GetLifeCourseList($.getUrlParam('cid'), 'releate', 'l', 'r');

});



/*-----------------------课程章节信息 start---------------------------*/
var PageID; //页码全局变量
var PageName; //总页码
//根据课程ID 获取所有课程的章节信息
function CourseInfo(pageIndex) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: 'ModuleList',
            cid: $.getUrlParam('cid'),
            PageIndex: pageIndex
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createRows(resultData.DATA, pageIndex);
            } else {
                $("#modInfo").html("没找到相关章节信息");
            }
        }
    });
}


//获取分页信息
function GetTradePageInfo() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: 'ModuleList',
            cid: $.getUrlParam('cid'),
            PageIndex: 1
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
                        CourseInfo(pageIndex);
                    });

                    $(".First").click(function () {
                        if ($(".First").css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            PageID = parseInt(PageID) - 1;
                            CourseInfo(pageIndex);
                        }
                    });
                    $(".Next").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) + 1;
                            CourseInfo(pageIndex);
                        }
                    });
                }
            } else {
                $("#" + tableId).html("没找到相关账户信息");
            }
        }
    });
    CourseInfo(1);
}


function createRows(jsonArr, pageindex) {
    var libody = "";
    var MainTable = $("#modInfo");
    MainTable.find('td').parent().remove();
    $.each(jsonArr, function (i, n) {
        var lis = "";

        lis += '<tr><td>第' + n.Sequence + '节</td>';

        lis += '<td><a href="show.aspx?mid=' + n.ModuleID + '&cid=' + $.getUrlParam('cid') + '">' + n.ModuleName + '</a></td>';
        lis += '<td>' + n.TrueName + '</td>';

        lis += '<td>' + arrive_timer_format(n.TimeDuration) + '</td>';
        if (parseFloat(n.Price) <= 0) {
            lis += '<td>免费</td></tr>';
        } else {
            lis += '<td>¥' + n.Price + ' <a href="shopCart.aspx?CourseId=' + $.getUrlParam('cid') + '&mid=' + n.ModuleID + '"><img src="imagesN/TLaoShi_bt031.gif" width="44" height="20" title="购买"/></a></td></tr>';
        }
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

/*-----------------------课程章节信息 end---------------------------*/

var CPageID; //页码全局变量
var CPageName; //总页码

//--------------封装循环显示的评论方便回调的时候使用--------------------//	
function xunhuan(data, pageIndex) {
    $('#divComm').empty();
    var libody = "";
    $.each(data, function (i, n) {

    
        var html = '';
        html += '<div class="act">';
        html += '<dl>';
        html += '<dt style="height:auto;font-style:normal;font-size:12px;line-height:18px;margin-bottom:10px;"><span class="NameHuiFU">' + getName(n.UserID) + '</span>&nbsp;&nbsp;&nbsp;&nbsp;<span>' + n.CommentInfo + '</span><div style="color:#7d7d7d;">' + n.CommentDate + '<span class="HuiFSub" >回复(' + n.CCount + ')</span></div></dt>';


        html += '<div class = "ajaxHF" id="' + n.CommentID + '">';



        html += '</div>';

        html += '<div class="TianChon">';
        html += '</div>';
        html += '</dl><a href=#""><img src="' + getimg(n.UserID) + '" width="48" height="48" class="imgCss"/></a></div>'

        libody += html;


    });


    $('#divComm').append(libody);

    CreatetCom();

    $(".top").each(function (index) {

        $(".top").eq(index).html($(".ajaxHF").eq(index).children(".HuiFURw").length);

    })


    CPageID = pageIndex; //获取返回的页码

    var Fir = Number($(".CpageID").eq(0).text());
    var zongye = Math.round(Number(CPageName) / 10);
    $(".CpageID").each(function (a) {

        if (Number($(this).text()) == CPageID) {
            if (a > 8) {
                var d = a - 4;
                $(".CpageID").empty();

                for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                    var num = b + d;
                    $(".CpageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                    if (b + d >= Number(CPageName))
                        break;
                }
            }
            if (a == 0 && Fir != 1) {
                var d = 5 - a;
                $(".CpageID").empty();
                for (var b = Fir, g = 0; b < Fir + 10, g < 10; b++, g++) {
                    var num = b - d;
                    $(".CpageID").eq(g).html("<a href=\"javascript:void(0);\">" + num + "</a>");
                }
            }
        }
    })

    $(".CpageID").each(function () {
        if (Number($(this).text()) == CPageID) {
            $(".CpageID").css("background", "#FFF");
            $(this).css("background", "#FC9");
        }
    })

    if (Number(CPageID) == 1)//先初始化
    {
        $(".CFirst").css("cursor", "default");
        $(".CFirst").css("background", "#F3F4F6");
        $(".CFirst").css("color", "#999");
        $(".CpageID").eq(0).css("background", "#FC9");
        $(".CNext").css("cursor", "pointer");
        $(".CNext").css("color", "#000");
        $(".CFirst").css("text-decoration", "none");
    }
    else {
        $(".CFirst").css("cursor", "pointer");
        $(".CFirst").css("color", "#000");
        if (Number(CPageName) == Number(CPageID))//判断是否点击最后一个数
        {
            $(".CNext").css("cursor", "default");
            $(".CNext").css("background", "#F3F4F6");
            $(".CNext").css("color", "#999");
            $(".CNext").css("text-decoration", "none");
        }
        else {
            $(".CNext").css("cursor", "pointer");
            $(".CNext").css("color", "#000");
        }
    }

    if (Number(CPageName) == 1 && Number(CPageID) == 1) {
        $(".CFirst").css("cursor", "default");
        $(".CFirst").css("background", "#F3F4F6");
        $(".CFirst").css("color", "#999");
        $(".CFirst").css("text-decoration", "none");
        $(".CNext").css("cursor", "default");
        $(".CNext").css("background", "#F3F4F6");
        $(".CNext").css("color", "#999");
        $(".CNext").css("text-decoration", "none");
    }

}


function CreatetCom() {
    $('.ajaxHF').each(function (index) {
        $.ajax({
            url: "HomeIndex.aspx",
            type: 'post',
            dataType: 'json',
            timeout: 10000,
            data: {
                action: "joinCom",
                ParentID: $('.ajaxHF').eq(index).attr('id')
            },
            success: function (ChildData) {
                if (ChildData.STATUS == "SUCCESS") {
                    var libody = "";
                    $.each(ChildData.DATA, function (j, n) {

                        var html = '';

                        html += '<div class="HuiFURw">';
                        html += '<img src="' + getimg(n.UserID) + '" width="48" height="48"  class="imgCss"/>';
                        html += '<span class="NameHuiFU">' + getName(n.UserID) + '</span>';
                        html += ' <span class="countHuiFu">' + n.CommentInfo + '</span>';


                        html += '</div>';
                        html += '<span class="color" style="float:left; margin-left:20px;">' + n.CommentDate + '</span><br/>'
                        libody += html
                    });
                    $('.ajaxHF').eq(index).html(libody);
                } else {

                }
            }
        });
    });
}


function  getName(uid) {
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
function getimg(uid) {
    var uimg;
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
                uimg = UserData.UserAvatar;
            } else {
            }
        }
    });
    return uimg;
}

//------------------封装遍历循环的评论回复框-------------------------//
function HuiFu() {
    $('.HuiFSub').each(function (index) {
        var stre = function () {//填充函数
            var textBox = '<br/><div class="HuiFBox" style="display:none;" > <ol style=" margin-bottom:10px;"><li style="overflow:hidden;padding:5px 0;"><textarea name="HuiFuBox"  class="textarea04" style="width:530px; height:56px;margin-right:5px;"></textarea></li><li  style="height:100%;overflow:hidden;padding:5px 0;"><input name="" type="button" class="button29"  style="float:right;margin-right:10px;"/></li></ol></div>'
            $('.TianChon').eq(index).html(textBox);
            $('.HuiFBox').slideDown();
            $('.button29').click(function () {
                if ($('.textarea04').val() == "") {
                    ShowFailTip("内容不能为空!!!");
                    return false;
                } else {
                    if ($('.textarea04').val().length > 110) {
                        ShowFailTip("输入内容过多");
                        return false;
                    }
                    $.ajax({
                        url: "HomeIndex.aspx",
                        type: 'post',
                        dataType: 'json',
                        timeout: 10000,
                        data: {
                            action: "InsertCom",
                            Uid: $("[id$='hfUid']").val(),
                            Mid: $.getUrlParam('mid'),
                            Cid: $.getUrlParam('cid'),
                            Pid: $('.ajaxHF').eq(index).attr('id'),
                            Ctype: $("[id$='CommentType']").val(),
                            Con: $(".textarea04").val()
                        },
                        success: function (AddData) {
                            if (AddData.STATUS == "SUCCESS") {
                                var libody = "";
                                $.each(AddData.DATA, function (j, n) {
                                
                                    var html = '';

                                    html += '<div class="HuiFURw">';
                                    html += '<img src="' + getimg(n.UserID) + '" width="48" height="48"  class="imgCss"/>';
                                    html += '<span class="NameHuiFU">' + getName(n.UserID) + '</span>';
                                    html += ' <span class="countHuiFu">' + n.CommentInfo + '</span>';


                                    html += '</div>';
                                    html += '<span class="color" style="float:left; margin-left:20px;">' + n.CommentDate + '</span><br/>'
                                    libody += html
                                });
                                $(".ajaxHF").eq(index).append(libody);
                                $('.HuiFBox').slideUp('slow', function () {//下滑完全结束时回调函数
                                    $('.TianChon').empty();
                                });
                            } else {

                            }
                        }
                    });
                }
            })
        };
        //----------------滑动显示评论回复的效果----------------------//
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


function ajaxload() {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "VideoComPage",
            PageIndex: 1,
            Mid:  $.getUrlParam('mid'),
            Cid: $.getUrlParam('cid'),
             Ctype: $("[id$='CommentType']").val()
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                CPageName = resultData.PAGECOUNT;
                if (resultData.PAGECOUNT != 0) {
                    var countPage = "<a class=\"CFirst\" href=\"javascript:void(0);\">上一页</a>";
                    if (resultData.PAGECOUNT > 10) {
                        for (i = 1; i <= 10; i++) {
                            countPage += "<a  class=\"CpageID\" href=\"javascript:void(0);\">" + i + "</a>";
                        }
                    }
                    else {
                        for (i = 1; i <= resultData.PAGECOUNT; i++) {
                            countPage += "<a class=\"CpageID\" href=\"javascript:void(0);\">" + i + "</a>";
                        }
                    }
                    countPage += "<a class=\"CNext\" href=\"javascript:void(0);\">下一页</a>";
                    $('.cpages').empty();
                    $('.cpages').append(countPage);

                    $(".CpageID").click(function () {
                        var pageIndex = $(this).text();
                        LoadData(pageIndex);
                    });

                    $(".CFirst").click(function () {
                        if ($(".CFirst").css("cursor") == "pointer") {
                            var pageIndex = parseInt(CPageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            CPageID = parseInt(CPageID) - 1;
                            LoadData(pageIndex);
                        }
                    });
                    $(".CNext").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(CPageID) + 1;
                            LoadData(pageIndex);
                        }
                    });
                }
            } else {

            }
        }
    });
    LoadData(1);
}

function LoadData(pageIndex) {

    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "VideoCom",
            PageIndex: pageIndex,
            Mid: $.getUrlParam('mid'),
            Cid: $.getUrlParam('cid'),
            Ctype: $("[id$='CommentType']").val()
        },
        success: function (PageData) {
            if (PageData.STATUS == "SUCCESS") {
                xunhuan(PageData.DATA, pageIndex);
                HuiFu(); //评论信息
            } else {
                $("#divComm").html("");
            }
        }
    });
}


function GetLifeCourseList(cid, ulId, l, r) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "RelateCourse",
            CateId: cid,
            pageIndex: 1,
            pageSize: 4
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
        lis += '<li><a href="show.aspx?cid=' + n.CategoryId + '" target="_blank"><img src="' + n.ImageUrl + '" width="170" height="113" />' + cutstr(n.CourseName, 19) + '</a>';
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
            action: "RelateCourse",
            CateId: cid,
            pageIndex: pi,
            pageSize: 4
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
