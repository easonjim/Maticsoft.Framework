/* File Created: 十二月 30, 2011 */
$(function () {
    $("[id$='txtSearch']").focus(function () {
        if ($("[id$='txtSearch']").val() == "搜索感兴趣的") {
            $("[id$='txtSearch']").val("");
        }
    }).blur(function () {
        if ($("[id$='txtSearch']").val() == "") {
            $("[id$='txtSearch']").val("搜索感兴趣的");
        }
    });

    $("[id$='btnSearch']").click(function () {
        if ($("[id$='txtSearch']").val() == "搜索感兴趣的") {
            alert("请输入搜索关键字！");
            return false;
        }
    });
});