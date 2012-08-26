<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- start main -->
<div class="main">

<input type="hidden" id="pageInfo" value="0" />
<!-- start inforcenter -->
<div class="inforcenter border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的帐户</a> > <strong>个人中心</strong></div>
<h2>个人中心</h2>
<ul>
<li><span>您好，</span><asp:Literal  ID="litName" runat="server"></asp:Literal></li>
<li><input name="" type="button" class="button08" /></li>
<li>
<asp:Repeater ID="rpt_trade" runat="server">
<ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><span>总消费额：</span><%#Eval("Pay", "{0:C}")%></td>
    <td><span>共购买课程次数：</span><%#Eval("Buycourse")%>门</td>
  </tr>
  <tr>
    <td><span>总收入额：</span><%#Eval("Income", "{0:C}")%></td>
    <td><span>共出售课程次数：</span><%#Eval("SellCount")%>门 </td>
  </tr>
  <tr>
    <td><span>总充值额：</span><%#Eval("Recharge", "{0:C}")%></td>
    <td><span>共充值次数：</span><%#Eval("Count")%>次</td>
  </tr>
  <tr>
    <td><span>帐户余额：</span><%#Eval("Blance", "{0:C}")%></td>
    <td>&nbsp;</td>
  </tr>
</table>
</ItemTemplate>
</asp:Repeater>
</li>
</ul>
<div class="img"><img src="/imagesN/001.gif" width="157" height="179" id="imgGravatar" runat="server"/><input name="" type="button" class="button09" /></div>
</div>
</div>
</div>
</div>
</div>
<!-- end inforcenter -->

</div>
<!-- end main -->
</asp:Content>
