/* File Created: 二月 10, 2012 */
$(function () {

    $("[id$='btnAddFavorites']").hide();
    $("[id$='btnDelFavorites']").hide();
    $.ajax({
        url: "FavoritesAction.aspx",
        type: 'post', dataType: 'text', timeout: 10000,
        data: { action: "isFav", uid: $("[id$='hfCurrent']").val(), cid: $("[id$='hfCourseID']").val(), mid: $("[id$='hfModuleID']").val() },
        success: function (data) {
            if (data == "0") {
                $("[id$='btnAddFavorites']").show();
                $("[id$='btnDelFavorites']").hide();
                return false;
            } else if (data == "1") {
                $("[id$='btnAddFavorites']").hide();
                $("[id$='btnDelFavorites']").show();
                return false;
            } else {
                alert("未知错误");
                return false;
            }
        }
    });

    $("[id$='btnAddFavorites']").click(function () {
        $.ajax({
            url: "FavoritesAction.aspx",
            type: 'post', dataType: 'text', timeout: 10000,
            data: { action: "add", uid: $("[id$='hfCurrent']").val(), cid: $("[id$='hfCourseID']").val(), mid: $("[id$='hfModuleID']").val() },
            success: function (data) {
                if (data == "-1") {
                    alert("对不起，您尚未登录，无法进行收藏操作，请登录后再进行该操作！");
                    return false;
                } else if (data == "0") {
                    alert("错误的课程！");
                    return false;
                } else if (data == "1") {
                    alert("收藏成功！");
                    $("[id$='btnAddFavorites']").hide();
                    $("[id$='btnDelFavorites']").show();
                    return false;
                } else if (data == "2") {
                    alert("收藏失败！");
                    return false;
                } else {
                    alert("对不起，您已经收藏过该课程！");
                    return false;
                }
            }
        });
    });


    $("[id$='btnLearnCourse']").click(function () {
        $.ajax({
            url: "LearnCourseHandle.aspx",
            type: 'post', dataType: 'json', timeout: 10000,
            data: { cid: $("[id$='hfCourseID']").val(), mid: $("[id$='hfMid']").val(), uid: $("[id$='hfbuyId']").val(), uName: $("[id$='hfUName']").val(), uEmail: $("[id$='hfEmail']").val(), SellerId: $("[id$='hfUid']").val(), tprice: 0 },
            success: function (data) {
                if (data.status == "1") {
                    alert("添加成功！");
                    return false;
                } if (data.status == "-1") {
                    alert("请先登录！");
                    return false;
                } if (data.status == "2") {
                    alert("系统忙，请稍后再试！");
                    return false;
                } if (data.status == "3") {
                    alert("您已经购买或学习过该课程！");
                    return false;
                } else {
                    alert("系统错误，请联系管理员！");
                    return false;
                }
            }
        });
        return false;
    });

    $("[id$='btnDelFavorites']").click(function () {
        $.ajax({
            url: "FavoritesAction.aspx",
            type: 'post', dataType: 'text', timeout: 10000,
            data: { action: "del", uid: $("[id$='hfCurrent']").val(), cid: $("[id$='hfCourseID']").val(), mid: $("[id$='hfModuleID']").val() },
            success: function (data) {
                if (data == "-1") {
                    alert("对不起，您尚未登录，无法进行收藏操作，请登录后再进行该操作！");
                    return false;
                } else if (data == "-2") {
                    alert("错误的课程！");
                    return false;
                } else if (data == "1") {
                    alert("取消收藏成功！");
                    $("[id$='btnAddFavorites']").show();
                    $("[id$='btnDelFavorites']").hide();
                    return false;
                } else if (data == "0") {
                    alert("取消收藏失败，请稍后再试！");
                    return false;
                } else {
                    alert("系统忙，请稍后再试！");
                    return false;
                }
            }
        });
    });



    $("[id$='btnAddCourseNotes']").click(function () {
        if ($("[id$='NotebookArea']").val() == "") {
            alert('请先输入笔记内容！');
            return false;
        }
    });
});