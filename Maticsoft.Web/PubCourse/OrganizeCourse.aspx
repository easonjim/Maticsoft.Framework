<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="OrganizeCourse.aspx.cs" Inherits="Maticsoft.Web.PubCourse.OrganizeCourse"   EnableEventValidation="false" %>
<%@ Register Src="../Controls/Categories.ascx" TagName="Categories" TagPrefix="uc1" %>
<%@ Register src="../Controls/RegionAjax.ascx" tagname="RegionAjax" tagprefix="MaticSoft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/regionjs.js" type="text/javascript"></script>
<script src="../Admin/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

             $("[id$='txtTag']").css("color", "Gray");
            $("[id$='txtTag']").focus(function () {
                if ($(this).val() == "空格分隔，最多为10个，每个标签不超过10个字") {
                    $(this).css("color", "black").val("");
                }
            }).blur(function () {
                if ($(this).val() == "") {
                    $(this).css("color", "Gray").val("空格分隔，最多为10个，每个标签不超过10个字");
                }
            });

            $("[id$='ddlCate2']").change(function () {
                $("[id$='hfTypes']").val($("[id$='ddlCate2']").val());
            });

            $("[id$='ddlCate1']").change(function () {
                $("[id$='hfty1']").val($("[id$='ddlCate1']").val());
                $("[id$='hfTypes']").val("");
            });

            $("[id$='btnNext']").click(function () {
                if (!$("[id$='ddlCate2']").val() && !$("[id$='ddlCate1']").val()) {
                    ShowFailTip("请输选择课程分类！");
                    return false;
                }
                if (!$("[id$='txtTitle']").val()) {
                    ShowFailTip("请输入课程标题！");
                    return false;
                }
                var reg = /\d{1,3}$/;
                if ($("[id$='txtCoursePrice']").val() == "") {
                    ShowFailTip("请输入正确的课程价格！");
                    return false;
                }
                if (!reg.test($("[id$='txtCoursePrice']").val())) {
                    ShowFailTip("请输入正确的课程价格！");
                    return false;
                }
            });

        });
    </script>

    
    <!--SWF图片上传开始-->
    <link href="/js/jquery/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet"
        type="text/css" />
    <script src="/js/jquery/jquery.uploadify-v2.1.0/swfobject.js" type="text/javascript"></script>
    <script src="../Admin/js/jquery.uploadify/uploadify-v2.1.0/jquery.uploadify.v2.1.0.js"
        type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $("[id$='lnkDelete']").hide();
        $("#uploadify").uploadify({
            'uploader': '/admin/js/jquery.uploadify/uploadify-v2.1.0/uploadify.swf',
            'script': '/CourseHandle.aspx?action=uploadico',
            'cancelImg': '/admin/js/jquery.uploadify/uploadify-v2.1.0/cancel.png',
            'buttonImg': '/admin/images/uploadfile.png',
            'folder': 'UploadFile',
            'queueID': 'fileQueue',
            'auto': true,
            'multi': true,
            'fileExt': '*.jpg;*.gif;*.png;*.bmp',
            'fileDesc': 'Image Files (.JPG, .GIF, .PNG)',
            'queueSizeLimit': 1,
            'sizeLimit': 1024 * 1024 * 10,
            'onInit': function () {
            },

            'onSelect': function (e, queueID, fileObj) {
            },
            'onComplete': function (event, queueId, fileObj, response, data) {
                var jsonData = eval("(" + response.split('|')[1] + ")");
                switch (jsonData.Status) {
                    case "OK":
                        //将获取的值放在隐藏隐藏域中，供后台调用
                        $("[id$='imgURL']").attr("src", jsonData.SavePath);
                        $("[id$='HiddenField_ICOPath']").val(jsonData.SavePath);
                        break;
                    case "Failed":
                        alert(jsonData.ErrorMessage);
                        break;
                }
            }
        });
    });
</script>
    <!--SWF图片上传结束-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hfTypes" value="" runat="server">
    <input type="hidden" id="hfCourseId" value="" runat="server">
    <input type="hidden" id="hfty1" value="" runat="server">
<input type="hidden" id="pageInfo" value="8" />
<!-- start main -->
<div class="main">

<!-- start input9 -->
<div class="input9 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>线下课程</strong> > <strong>填写课程简介</strong></div>
<h2>填写课程简介</h2>
<div class="padding">
<ul>
<li><span>课程分类：
    </span><uc1:Categories ID="Categories2" runat="server" /></li>
<li><span>课程标题：</span> <asp:TextBox ID="txtTitle" runat="server" CssClass="txt04" MaxLength="300" Width="290px"></asp:TextBox></li>
<li style="height:auto;"><span>课程图片：</span> <asp:HiddenField ID="HiddenField_ICOPath" runat="server" /><input type="file" name="uploadify" id="uploadify" style="margin-left:70px;"/></li>
<li style="margin-top:-20px;height:auto;"><div id="fileQueue" style="margin-left:70px;height:auto;"></div></li>
<li><img id="imgURL" style="width: 120px; height: 120px;margin-left:70px;" runat="server"/></li>
<li><span>课程简介：</span><textarea id="txtDec" runat="server" rows="10" cols="20" style="width: 420px; height: 180px;"></textarea></li>
<li><span>课程标签：</span><input type="text" id="txtTag" runat="server" class="txt04" value="空格分隔，最多为10个，每个标签不超过10个字" style="width:290px;"/></li>
<li><span>开课时间：</span><input type="text" id="txtStartTime" runat="server" class="txt04"  style="width:180px;"  onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'%y-%M-{%d+1}'})"/>--<input type="text" id="txtEndTime" runat="server" class="txt04"  style="width:180px;"  onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'%y-%M-{%d+1}'})"/></li>
<li><span>开课地点：</span><MaticSoft:RegionAjax ID="RegionAjax1" runat="server"/></li>
<li><span>详细地址：</span><input type="text" id="txtAddress" runat="server" class="txt04"  style="width:290px;"/></li>
<li><span>预计价格：</span><input type="text" id="txtCoursePrice" runat="server" class="txt04" value="" /> 元</li>
<li><span>&nbsp;</span><asp:Button ID="btnNext" runat="server" CssClass="button14" onclick="btnNext_Click"/><asp:ImageButton ID="btnModify" runat="server" ImageUrl="../Images/xgwc.jpg" OnClick="btnModify_Click" /></li>
</ul>
</div>
<div class="soild"></div>

</div>
</div>
</div>
</div>
</div>
<!-- end input9 -->

</div>
<!-- end main -->
</asp:Content>
