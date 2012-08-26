/* File Created: 六月 27, 2012 */
$(document).ready(function () {
    GethotKey();
});
document.onclick = HideFinishEditor;
function HideFinishEditor() {
    $("#divsearch").hide();
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
        resu += '<a href="../courselist.aspx?key=' + escape(arr[i].substring(0, 2)) + '&type=0" title="' + arr[i] + '">' + arr[i] + '</a>';
    }
    return resu;
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


function showIntelliSense() {
    if (HotKey()) {
        var QueryText = document.getElementById("txtSearchword").value.replace(/(^[\s]*)|([\s]*$)/g, "");
        if (QueryText == "") {
            $("#divsearch").hide();
            return
        } else {
            $("#divsearch").html("<div class=\"serchboxx\"><div style=\"height: 22px; line-height: 22px;\"><div class=\"left\">&nbsp;&nbsp;<font color=\"#245fa5\">请选择搜索范围</font></div><div class=\"paixucssright\"><img src=\"imagesN/jiantou2.gif\" width=\"9\" height=\"5\" /></div></div><div id=\"div0\" onmouseover=\"changeSelColor('div0',0)\" class=\"bjyellow2\" onclick=\"gosearch(0);\">搜索和&nbsp;<font color=\"#c20201\">" + QueryText + "</font>&nbsp;相关的老师</div><div id=\"div1\" onmouseover=\"changeSelColor('div1',1)\" class=\"bjwhite2\" onclick=\"gosearch(1);\">搜索和&nbsp;<font color=\"#c20201\">" + QueryText + "</font>&nbsp;相关的课程</div>");
            $("#divsearch").show();
        }
    }
}


var selTSNID = "div0";
var selItemNum = 0;
function HotKey() {
    var evt = null;
    if (window.event) {
        evt = window.event;
    } else {
    evt = SearchEvent();
    }
    var isShowIS = false;
    var keyCode = evt.keyCode;
    switch (keyCode) {
        case 38:
            if ((selItemNum - 1) >= 0) {
                changeSelColor("div" + (selItemNum - 1), (selItemNum - 1))
            } else {
                changeSelColor("div" + 2, 2)
            }
            break;
        case 40:
            if (selItemNum != -1) {
                if ((selItemNum + 1) > 2) {
                    changeSelColor("div" + 0, 0);
                } else {
                    changeSelColor("div" + (selItemNum + 1), (selItemNum + 1));
                }
            } else {
                changeSelColor("div" + 1, 1);
            }
            break;
        case 13:
            gosearch();
            $("#divsearch").hide();
            break;
        case 27:
            $("#divsearch").hide();
            selTSNID = "div0";
            selItemNum = 0;
            break;
        default:
            isShowIS = true;
            break;
    }
    return isShowIS;
}

function changeSelColor(TsnID, ItemNum) {
    if (selTSNID != "") {
        if (document.getElementById(selTSNID) != null) {
            document.getElementById(selTSNID).style.backgroundColor = "#fffff7";
        }
    }
    if (document.getElementById(TsnID) != null) {
        document.getElementById(TsnID).style.backgroundColor = "#fef9d1";
        if (TsnID == "div0") {
            searchType = "0";
        }
        if (TsnID == "div1") {
            searchType = "1";
        }
    }
    selTSNID = TsnID;
    selItemNum = ItemNum;
}


function gosearch(strtype) {
    var strSearchWord = $("#txtSearchword").val();
    if (strSearchWord == "  搜课程 找老师") {
        strSearchWord = "";
    }
    if ($.trim(strSearchWord)!= "") {
        if (strtype == null) {
            strtype = 0;
        }
        if (strtype == 0) {
            $("#txtSearchword").val("");
            $("#divsearch").hide();
            window.location.href = '../TeacherList.aspx?key=' + escape(strSearchWord);
        } else if (strtype == 1) {
            $("#txtSearchword").val("");
            $("#divsearch").hide();
            window.location.href = '../courselist.aspx?key=' + escape(strSearchWord);
        } else {
            $("#txtSearchword").val("");
            $("#divsearch").hide();
        }
    }
}

//获取URL参数
(function ($) {
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]);
        return null;
    };
})(jQuery);

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