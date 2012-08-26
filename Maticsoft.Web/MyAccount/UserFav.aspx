<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserFav.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserFav" EnableEventValidation="false" EnableViewState="false" %>
<%@ Register src="../Controls/FavoriteCourse.ascx" tagname="FavoriteCourse" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<input type="hidden" id="pageInfo" value="4" />
<!-- start main -->
<div class="main">

<!-- start shoucang -->
<div class="shoucang border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="Userbuycourse.aspx">学习管理</a> > <strong>收藏课程</strong></div>
<h2>收藏课程</h2>
<div class="padding">
<div class="wsh">    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        
<uc1:FavoriteCourse ID="FavoriteCourse1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>
<%--<ul>
<li><span><input name="" type="button" class="button20" /><br /><br /><input name="" type="button" class="button21" /></span><a href="#"><img src="images/004.gif" width="95" height="63" />欧洲历史文学简理论导论..</a>
<p><strong>时间：</strong>共3小时2分钟  |  <strong>教师：</strong>黄天霸 (共3人）  |  <strong>已选/关注：</strong>269/62 </p>
<p><strong>分类：</strong>全部课程 > 公开课 > 社会科学  |  <strong>价格：</strong>50元</p></li>
<li><span><input name="" type="button" class="button20" /><br /><br /><input name="" type="button" class="button21" /></span><a href="#"><img src="images/004.gif" width="95" height="63" />欧洲历史文学简理论导论..</a>
<p><strong>时间：</strong>共3小时2分钟  |  <strong>教师：</strong>黄天霸 (共3人）  |  <strong>已选/关注：</strong>269/62 </p>
<p><strong>分类：</strong>全部课程 > 公开课 > 社会科学  |  <strong>价格：</strong>50元</p></li>
<li><span><input name="" type="button" class="button20" /><br /><br /><input name="" type="button" class="button21" /></span><a href="#"><img src="images/004.gif" width="95" height="63" />欧洲历史文学简理论导论..</a>
<p><strong>时间：</strong>共3小时2分钟  |  <strong>教师：</strong>黄天霸 (共3人）  |  <strong>已选/关注：</strong>269/62 </p>
<p><strong>分类：</strong>全部课程 > 公开课 > 社会科学  |  <strong>价格：</strong>50元</p></li>
</ul>--%>
</div>


<div class="soild" ></div>
</div>


</div>
</div>
</div>
</div>
</div>
<!-- end shoucang -->

</div>
<!-- end main -->
</asp:Content>
