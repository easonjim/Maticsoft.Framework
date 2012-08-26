/* File Created: 七月 5, 2012 */


$(document).ready(function () {

    GetLifeCourseList($("[id$='hfCid']").val(), 'releate', 'l', 'r');
});

function GetLifeCourseList(cid, ulId, l, r) {
    $.ajax({
        url: "HomeIndex.aspx",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            action: "RelateTeacherCourse",
            CateId: cid,
            pageIndex: 1,
            pageSize: 3
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, ulId);
                createPageBar(cid, ulId, 1, resultData.ROWCOUNT, resultData.PAGECOUNT, l, r);
            } else {
                $("#" + ulId).html("你还没有发布课程！");
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
        lis += '<li><a href="show.aspx?cid=' + n.CategoryId + '" target="_blank"><img src="' +ImgManage( n.ImageUrl )+ '" width="153" height="103" />' + cutstr(n.CourseName, 19) + '</a>';
        lis += '<p>时长：' + arrive_timer_format(n.TimeDuration) + '<br />';
        lis += '老师：' + n.TrueName + '<br />';
        lis += '价格：' + managePrice(n.Price) + '<img src="/imagesN/TLaoShi_bg090.gif" width="19" height="11" /></p></li>';
        libody += lis
    });
    MainUl.append(libody);
}

function ImgManage(imgPath) {
    if (!imgPath ) {
        return "/images/pics/none.gif";
    } else {
    return imgPath;
    }
}

//分页
function createPageBar(cid, ulId, pageIndex, rowcount, pagecount, l, r) {
    var pageBarDivR = $("#" + r);
    var pageBarDivL = $("#" + l);
    pageBarDivR.find('a').remove();
    pageBarDivL.find('a').remove();
    pageBarDivL.append(" <a href='javascript:loadPagedList(" + cid + ",\"" + ulId + "\"," + prevPage(pageIndex) + ",\"" + l + "\",\"" + r + "\"" + ")' class='left'></a> ");
    pageBarDivR.append(" <a href='javascript:loadPagedList(" + cid + ",\"" + ulId + "\"," + lastPage(pageIndex, pagecount) + ",\"" + l + "\",\"" + r + "\"" + ")' class='right' ></a> ");
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
            action: "RelateTeacherCourse",
            CateId: cid,
            pageIndex: pi,
            pageSize: 3
        },
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                createLi(resultData.DATA, ulId);
                createPageBar(cid, ulId, pi, resultData.ROWCOUNT, resultData.PAGECOUNT, l, r);
            } else {
                $("#" + ulId).html("你还没有发布课程");
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
