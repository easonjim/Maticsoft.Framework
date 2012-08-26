<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="TeacherDes.aspx.cs" Inherits="Maticsoft.Web.TeacherDes" %>
<%@ Register Src="~/Controls/OffLineCourseInfo1.ascx" TagPrefix="uc" TagName="OffLineCourseInfo1" %>
<%@ Register Src="~/Controls/OffLineCourseInfo.ascx" TagPrefix="uc" TagName="OffLineCourseInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/teacher.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<!-- start content -->
<div id="content">

<div class="zhuanti_nav"><strong>教师简介<%--<a href="#">显示实际路径</a></strong> &gt; 个人主页--%></div>
<div class="clear"></div>

<!-- start main -->
<div class="main" style="top:0px;">

<!-- start jieshao -->
<div class="jieshao border3">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>个人简介</h3>
<asp:Literal ID="litDescrit" runat="server"></asp:Literal>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end jieshao -->

<!-- start opened2 -->
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<uc:OffLineCourseInfo runat="server" ID="ucOffLineCourseInfo" />
</ContentTemplate>
</asp:UpdatePanel>
<!-- end opened2 -->

<!-- start opened3 -->

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<uc:OffLineCourseInfo1 runat="server" ID="ucOffLineCourseInfo1" />
</ContentTemplate>
</asp:UpdatePanel>
<!-- end opened2 -->

<!-- start opened2 -->
<div class="opened2 border3">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>网络课程</h3>
<div class="wsh">
<ul id="modInfo">
</ul>
</div>
<div class="pages"></div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end opened2 -->

<%--<!-- start map -->
<div class="map border3">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h2>sunyupeng的学习地图</h2>
<div class="map_list">

<dl>
<dt><a href="#">老师：池本庆</a></dt>
<dd>
<ul>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg131.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />学习：23小时</a></li>
</ul>
</dd>
</dl>

<dl>
<dt></dt>
<dd>
<ol>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg133.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg134.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg134.gif" width="18" height="18" />学习：23小时</a></li>
</ol>
</dd>
</dl>

<dl>
<dt><a href="#">老师：池本庆</a></dt>
<dd>
<ul>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg131.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />学习：23小时</a></li>
</ul>
</dd>
</dl>

<dl>
<dt><a href="#">老师：池本庆</a></dt>
<dd>
<ul>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="images/TLaoShi_bg131.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="images/TLaoShi_bg132.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="images/TLaoShi_bg132.gif" width="18" height="18" />学习：23小时</a></li>
</ul>
</dd>
</dl>

<dl>
<dt><a href="#">老师：池本庆</a></dt>
<dd>
<ul>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg131.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />学习：23小时</a></li>
</ul>
</dd>
</dl>

<dl>
<dt><a href="#">老师：池本庆</a></dt>
<dd>
<ul>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg131.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg132.gif" width="18" height="18" />学习：23小时</a></li>
</ol>
</dd>
</dl>

<dl>
<dt></dt>
<dd>
<ol>
<li><a href="#">公开课</a></li>
<li><a href="#">人文学</a></li>
<li><a href="#">人文类哲学</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg133.gif" width="18" height="18" />关注：219门</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg134.gif" width="18" height="18" />授课：72小时</a></li>
<li><a href="#" style="padding-left:25px;"><img src="imagesN/TLaoShi_bg134.gif" width="18" height="18" />学习：23小时</a></li>
</ul>
</dd>
</dl>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end map -->
--%>
<!-- start dayi2 -->
<div class="dayi2 border3">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>提问回答</h3>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：纵观各类杂志近些年的女有时候买了一堆衣服，可是挑来挑去还是穿回经常穿的几套！！！其他衣服都不知道买回来干嘛了大都行！</span><a href="#"><img src="imagesN/TLaoShi_bg135.gif" width="113" height="23" /></a></p>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：纵观各类杂志近些年的女有时候买了一堆衣服，可是挑来挑去还是穿回经常穿的几套！！！其他衣服都不知道买回来干嘛了大都行！</span><a href="#"><img src="imagesN/TLaoShi_bg135.gif" width="113" height="23" /></a></p>
<a href="#" style="float:right;">展开查看全部&gt;&gt;</a>
<div class="clear"></div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end dayi2 -->


</div>
<!-- end main -->

<!-- start side -->
<div class="side">

<!-- start card -->
<div class="border4 card">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">

<div class="name" style="height:auto;"><strong><asp:Literal ID="litName" runat="server"></asp:Literal><%=isTrueName %></strong>来自<asp:Literal ID="litProvice" runat="server"></asp:Literal></div>
<div class="img"><img src="images/021.gif" id="imgGravatar" runat="server" /></div>
<p><%--微世界教育协会CEO，发起人艾德睿智华东区运营总监。--%></p>
<div class="img2"><a href="#"><img src="imagesN/TLaoShi_bt039.gif" /></a></div>
<p><strong>认证：</strong><asp:Literal ID="litRz" runat="server"></asp:Literal></p>
<p><strong>标签：</strong><asp:Label ID="labTag" runat="server" Text="" CssClass="tags"></asp:Label> </p>

</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>
<!-- end card -->

<!-- start time2 -->
<%--<div class="time2">
<p>操作时间<strong>72小时</strong></p>
<p>学习时间<strong>46小时</strong></p>
</div>--%>
<!-- end time2 -->

<!-- start xinyong2 -->
<div class="xinyong2 border3">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>信用网络</h3>
<ol>
<li><img src="imagesN/TLaoShi_bg138.gif" />325人</li>
<li><img src="imagesN/TLaoShi_bg139.gif" />5643条</li>
</ol>
<ul>
<li><img src="imagesN/TLaoShi_bg113.gif" />328粉丝</li>
<li><img src="imagesN/TLaoShi_bg114.gif" />473粉丝</li>
<li><img src="imagesN/TLaoShi_bg115.gif" />328粉丝</li>
<li><img src="imagesN/TLaoShi_bg116.gif" />473粉丝</li>
<li><img src="imagesN/TLaoShi_bg117.gif" />328粉丝</li>
<li><img src="imagesN/TLaoShi_bg118.gif" />473粉丝</li>
<li><img src="imagesN/TLaoShi_bg119.gif" />328粉丝</li>
<li><img src="imagesN/TLaoShi_bg120.gif" />473粉丝</li>
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end xinyong2 -->

<!-- start yixuan -->
<div class="yixuan">
<strong><a href="#">更多站内粉丝&gt;&gt;</a></strong>
<ul>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
<li><a href="#"><img src="imagesN/016.gif" width="48" height="49" /></a></li>
</ul>
</div>
<!-- end yixuan -->

</div>
<!-- end side -->

</div>
<!-- end content -->
    </strong>
</asp:Content>
