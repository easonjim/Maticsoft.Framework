<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="userRecharge3.aspx.cs" Inherits="Maticsoft.Web.MyAccount.userRecharge3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnCompeled").click(function () {
                window.location.href = 'UserAccount.aspx';
            });
            $("#btnQue").click(function () {
                window.location.href = 'userRecharge1.aspx';
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="pageInfo" value="2" />
<!-- start main -->
<div class="main">

<!-- start recharge -->
<div class="recharge border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的帐户</a> > <strong>我要充值</strong> > <strong>完成充值</strong></div>
<h2>我要充值</h2>
<div class="one">
<div class="img"><img src="/imagesN/TLaoShi_bg054.gif" width="659" height="23" /></div>
<ul>
<li>请在新打开的页面上完成付款（完成前不要关闭此窗口）</li>
<li><input name="" type="button" class="button12" id="btnCompeled"/>　<input name="" type="button" class="button13" id="btnQue"/></li>
<li></li>
</ul>
</div>
</div>
</div>
</div>
</div>
</div>
<!-- end recharge -->

</div>
<!-- end main -->

</asp:Content>
