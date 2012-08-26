<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/tabmenu.js" type="text/javascript"></script>
<script src="../js/trade.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- start main -->
<div class="main">

<input type="hidden" id="pageInfo" value="1" />
<input type="hidden" id="hfUid" runat="server" />
<!-- start balance -->
<div class="balance border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的帐户</a> > <strong>帐户余额</strong></div>
<h2>帐户余额</h2>
<div class="class_table">
<h3>当前您的帐户余额：<strong id='bala'></strong>元</h3>
<div class="tabs">
<a href="#" class="link" id='tabA'>本月记录</a>
<a href="#" id='tabB'>全部记录</a></div>

<div class="balancecontentin">
<table width="100%" border="0" cellspacing="0" cellpadding="0" id='currentMon'>
<tr>
<th>时间</th>
<th>存入</th>
<th>支出</th>
<th>余额</th>
<th>备注</th>
</tr>
</table>
</div>

<div class="balancexq">
<table width="100%" border="0" cellspacing="0" cellpadding="0" id='allMon'>
<tr>
<th>时间</th>
<th>存入</th>
<th>支出</th>
<th>余额</th>
<th>备注</th>
</tr>
</table>
</div>
</div>

<div class="pages"></div>
</div>
</div>
</div>
</div>
</div>
<!-- end balance -->

</div>
<!-- end main -->
</asp:Content>
