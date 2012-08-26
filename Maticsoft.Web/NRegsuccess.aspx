<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="NRegsuccess.aspx.cs" Inherits="Maticsoft.Web.NRegsuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- start content -->
<div id="content">

<!-- start register_pass -->
<div class="register_pass border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<h2>恭喜您 <asp:Label ID="lblUname" runat="server" Text=""></asp:Label> 注册成功！</h2>
<ul>
<li> <asp:Button ID="btnComplete" runat="server" Text=""  onclick="btnComplete_Click" class="button25" />（完善我的个人资料）</li>
<li><asp:Button ID="btnReturn" runat="server" Text=""   onclick="btnReturn_Click"  class="button26"/>（开始寻找想要学的课程）</li>
<li><asp:Button ID="btnTeach" runat="server" Text=""   onclick="btnTeach_Click"  class="button27" />（看看当来是如何开课）</li>
</ul>
</div>
</div>
</div>
</div>
</div>
<!-- end register_pass -->

</div>
<!-- end content -->
</asp:Content>
