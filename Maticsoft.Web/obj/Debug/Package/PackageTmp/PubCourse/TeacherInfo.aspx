<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="TeacherInfo.aspx.cs" Inherits="Maticsoft.Web.PubCourse.TeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="/js/jquery/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet"
        type="text/css" />
    <script src="/js/jquery/jquery.uploadify-v2.1.0/swfobject.js" type="text/javascript"></script>
    <script src="/js/jquery/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"   type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#uploadify").uploadify({
            'uploader': '/js/jquery/jquery.uploadify-v2.1.0/uploadify.swf',
            'script': '/HomeIndex.aspx?Action=uploadico',
            'cancelImg': '/js/jquery/jquery.uploadify-v2.1.0/cancel.png',
            'buttonImg': '/imagesN/uploadfile.png',
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
                        $("[id$='imgLogo']").attr("src", jsonData.SavePath);
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

    <input type="hidden" id="hfCourseID" value="" runat="server">
    <input type="hidden" id="hfRuturnUrl" value="" runat="server">
<input type="hidden" id="pageInfo" value="1" />
<!-- start main -->
<div class="main">

<!-- start input2 -->
<div class="input2 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>公开课</strong> > <strong>教师简介</strong></div>
<h2>教师简介</h2>
<div class="padding">
<ul>
<li><span>教师名称：</span><asp:TextBox ID="txtName" runat="server" CssClass="txt04" Width="260"></asp:TextBox></li>
<li><span>照片预览：</span><img src="/imagesN/006.gif" width="63" height="66" runat="server" id="imgLogo" /></li>
<%--span>教师照片：</span>--%>
<div style="margin-left:70px;">
<asp:HiddenField ID="HiddenField_ICOPath" runat="server" />
<div id="fileQueue" >
</div>
<input type="file" name="uploadify" id="uploadify" /></div>
<li><span>教师简介：</span><textarea  id="txtDec" runat="server" rows="10" cols="20" style="width: 350px; height: 180px;" class="areaBox"></textarea></li>
<li><span>机构名称：</span><input name="" type="text" class="txt04" size="40" runat="server" style="width:260px;" id="txtDepartmentName"  readonly="readonly"/></li>
<li><span>&nbsp;</span><asp:Button ID="btnBack" runat="server" class="button15" 
        onclick="btnBack_Click"/>　
    <asp:Button ID="btnNext" runat="server" class="button14" 
        onclick="btnNext_Click" /></li>
</ul>
</div>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input2 -->

</div>
<!-- end main -->
</asp:Content>
