/* File Created: 二月 3, 2012 */
$(function () {
    var OldVaule = $("[id$='txtadvise']").val();
    $("[id$='txtadvise']").focus(function () {
        if ($("[id$='txtadvise']").val() == OldVaule) {
            $("[id$='txtadvise']").val("");
        }
    }).blur(function () {
        if ($("[id$='txtadvise']").val() == "") {
            $("[id$='txtadvise']").val(OldVaule);
        }
    });
    $("[id$='ResetId']").click(function () {
        $("[id$='txtadvise']").val(OldVaule);
        return false;
    });

    $("[id$='imgSubmit']").click(function () {
        if ($("[id$='txtadvise']").val() == OldVaule) {
            alert("请输入你的意见或建议！")
            return false;
        }
        $.ajax({
            url: "SiteAdvise.aspx",
            type: 'post', dataType: 'text', timeout: 10000,
            data: { adviseContent: $("[id$='txtadvise']").val() },
            success: function (resultData) {
                if (resultData == "yes") {
                    alert("提交成功！");
                }
                else {
                    alert("提交失败，请重试！");
                }
            }
        });
        return false;
    });
});