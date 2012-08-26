<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UpdatePwd.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UpdatePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$='btnSubmit']").click(function () {
                if (!$.trim($("[id$='txtOldpws']").val())) {
                    ShowFailTip('请输入旧密码', 2000);
                    return false;
                }
                if (!$.trim($("[id$='txtNewPwd']").val())) {
                    ShowFailTip('请输入新密码', 2000);
                    return false;
                }
                if ($.trim($("[id$='txtNewPwd']").val()).length < 6 || $.trim($("[id$='txtNewPwd']").val()).length>16) {
                    ShowFailTip('密码需由6-16个字符，区分大小写', 2000);
                    return false;
                }
                if ($.trim($("[id$='txtSurePwd']").val()) != $.trim($("[id$='txtNewPwd']").val())) {
                    ShowFailTip('两次输入密码不一致', 2000);
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start main -->
<div class="main">

<input type="hidden" id="pageInfo" value="9" />
<!-- start editpassword -->
<div class="editpassword border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">个人信息</a> > <strong>修改密码</strong></div>
<h2>修改密码</h2>
<ul>
<li><span>请输入旧密码：</span><input name="" type="password" class="txt04" id="txtOldpws" runat="server"/></li>
<li><span>请输入新密码：</span><input name="" type="password" class="txt04"  id="txtNewPwd"  runat="server"/></li>
<li><span>再次输入密码：</span><input name="" type="password" class="txt04"  id="txtSurePwd"   runat="server"/></li>
<li><span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" class="button04" 
        onclick="btnSubmit_Click" /></li>
</ul>
</div>
</div>
</div>
</div>
</div>
<!-- end editpassword -->

</div>
<!-- end main -->

</asp:Content>
