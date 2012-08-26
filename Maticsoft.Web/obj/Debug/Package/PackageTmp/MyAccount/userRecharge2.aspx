<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="userRecharge2.aspx.cs" Inherits="Maticsoft.Web.MyAccount.userRecharge2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$='btnNext']").click(function () {
                window.location.href = 'userRecharge3.aspx?total_fee=' + $.getUrlParam('total_fee');
                return true;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- start main -->
<div class="main">

<input type="hidden" id="pageInfo" value="2" />
<!-- start recharge -->
<div class="recharge border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的帐户</a> > <strong>我要充值</strong> > <strong>选择充值方式</strong></div>
<h2>我要充值</h2>
<div class="one">
<div class="img"><img src="/imagesN/TLaoShi_bg053.gif" width="659" height="23" /></div>
<ul>
<li>确认帐号：<strong><asp:Literal  ID="litAccount" runat="server"></asp:Literal></strong></li>
<li>充值数量：<strong><asp:Literal   ID="litNum" runat="server"></asp:Literal></strong>个学币</li>
<li>需要扣除金额<strong>￥<asp:Literal ID="litMoney" runat="server"></asp:Literal></strong>元</li>
<li>
<div class="FsContbox">
<div class="fsCbox">
<div class="fsTop">
<div class="fsP">
<span><img src="../images/tenpay.jpg" title="财付通支付"/></span>
</div>
</div>
</div>
</div></li>
<li><asp:Button ID="btnNext" runat="server" class="button11" 
        onclick="btnNext_Click"  /></li>
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
