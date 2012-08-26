/* File Created: 六月 29, 2012 */
$(document).ready(function () {
    GetTradePageInfo('currentMon');
    $("#tabB").click(function () {
        $('.pages').find('a').remove();
        PageID = 1;
        GetTradePageInfo('allMon');
    });
    $("#tabA").click(function () {
        $('.pages').find('a').remove();
        PageID = 1;
        GetTradePageInfo('currentMon');
    });
});

var PageID; //页码全局变量
var PageName; //总页码
//获取本月账户信息
function GetTradeInfo(tableId, pageIndex) {
    $.ajax({
        url: "TradeDetail.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: tableId,
            UserId: $("[id$='hfUid']").val(),
            PageIndex: pageIndex
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                $("#bala").html('¥' + resultData.BALANCE);
                createRows(resultData.DATA, tableId, pageIndex);
            } else {
                $("#" + tableId).html("没找到相关账户信息");
            }
        }
    });
}


//获取分页信息
function GetTradePageInfo(tableId) {
    $.ajax({
        url: "TradeDetail.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: tableId,
            UserId: $("[id$='hfUid']").val(),
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
                        GetTradeInfo(tableId, pageIndex);
                    });

                    $(".First").click(function () {
                        if ($(".First").css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) - 1;
                            if (pageIndex == 0) {
                                alert('当前已经是第一页了！');
                                return false;
                            }
                            PageID = parseInt(PageID) - 1;
                            GetTradeInfo(tableId, pageIndex);
                        }
                    });
                    $(".Next").click(function () {
                        if ($(this).css("cursor") == "pointer") {
                            var pageIndex = parseInt(PageID) + 1;
                            GetTradeInfo(tableId, pageIndex);
                        }
                    });
                }
            } else {
                $("#" + tableId).html("没找到相关账户信息");
            }
        }
    });
    GetTradeInfo(tableId, 1);
}


function createRows(jsonArr, tableId, pageindex) {
    var libody = "";
    var MainTable = $("#" + tableId);
    MainTable.find('td').parent().remove();
    $.each(jsonArr, function (i, n) {
        var lis = "";
        lis += '<tr><td width="150">' + n.DataTime + '</td>';
        lis += '<td style="text-align:right;"">¥' + n.InCome + '&nbsp;&nbsp;&nbsp;</td>';
        lis += '<td style="text-align:right;">¥' + n.Pay + '&nbsp;&nbsp;&nbsp;</td>';
        lis += '<td style="text-align:right;">¥' + n.Balance + '&nbsp;&nbsp;&nbsp;</td>';
        lis += '<td>' + n.Remark + '</td></tr>';
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

