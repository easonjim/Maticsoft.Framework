<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="NLogin.aspx.cs" Inherits="Maticsoft.Web.NLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$='btnLogin']").click(function () {
                if (!$.trim($("[id$='txtName']").val())) {
                    ShowFailTip("请输入您的登录帐号！", 2000);
                    $("[id$='txtName']").focus();
                    return false;
                }
                if (!$.trim($("[id$='txtPwd']").val())) {
                    ShowFailTip("请输入您的登录密码！", 2000);
                    $("[id$='txtPwd']").focus();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- start content -->
<div id="content">

<!-- start login -->
<div class="login border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<h2>登录淘老师</h2>
<ul>
<li><span>用户名：</span><input name="" type="text" class="txt02"  id="txtName" runat="server"/><a href="NRegister.aspx">免费注册</a></li>
<li><span>密　码：</span><input name="" type="password" class="txt02" id="txtPwd" runat="server"/><a href="#">忘记密码？</a></li>
<li><span>&nbsp;</span><input name="" type="checkbox" value="" id="chkAutoLogin" runat="server" /> 下次自动登录</li>
<li><span>&nbsp;</span><asp:Button ID="btnLogin" runat="server" class="button02" onclick="btnLogin_Click"/></li>
</ul>
</div>
</div>
</div>
</div>
</div>
<!-- end login -->

</div>
<!-- end content -->
</asp:Content>
