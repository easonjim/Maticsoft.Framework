<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="NewPubCourse.aspx.cs" Inherits="Maticsoft.Web.PubCourse.NewPubCourse"  EnableEventValidation="false" %>
<%@ Register src="../Controls/Categories.ascx" tagname="Categories" tagprefix="MaticSoft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
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

            $("[id$='btnSubmit']").click(function () {
                if (!$("[id$='ddlCate2']").val() && !$("[id$='ddlCate1']").val()) {
                    ShowFailTip("请输选择课程分类！");
                    return false;
                }
                if (!$("[id$='txtTitle']").val()) {
                    ShowFailTip("请输入课程标题！");
                    return false;
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="hfTypes" value="" runat="server">
    <input type="hidden" id="hfty1" value="" runat="server">
<input type="hidden" id="pageInfo" value="0" />
<!-- start main -->
<div class="main">

<!-- start input1 -->
<div class="input1 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>公开课</strong> > <strong>填写课程简介</strong></div>
<h2>填写课程简介</h2>
<div class="padding">
<ul>
<li><span>课程分类：</span><MaticSoft:Categories ID="Categories1" runat="server" /></li>
<li><span>课程标题：</span> <asp:TextBox ID="txtTitle" runat="server" CssClass="txt04" MaxLength="300" Width="290px"></asp:TextBox></li>
<li><span>课程简介：</span><textarea id="txtDec" runat="server" rows="10" cols="20" style="width: 420px; height: 180px;"></textarea></li>
<li><span>课程标签：</span><input type="text" id="txtTag" runat="server" class="txt04" value="空格分隔，最多为10个，每个标签不超过10个字" style="width:290px;"/></li>
<li><span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" CssClass="button14" onclick="btnSubmit_Click"/></li>
</ul>
</div>
<div class="soild"></div>

</div>
</div>
</div>
</div>
</div>
<!-- end input1 -->

</div>
<!-- end main -->
</asp:Content>
