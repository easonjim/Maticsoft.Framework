<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="OnLineCourse.aspx.cs" Inherits="Maticsoft.Web.OnLineCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/videoshow.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:HiddenField ID="hfCurrent" runat="server" />
<input type="hidden" id="hfTid" runat="server"  />
<input type="hidden" id="hfUid" runat="server"  />
<input type="hidden" id="CommentType" value="0" />
<asp:HiddenField ID="hfCourseID" runat="server" />
<asp:HiddenField ID="hfModuleID" runat="server" />
<!-- start content -->
<div id="content">

<div class="zhuanti_nav"><strong><a href="index.aspx">我要学</a></strong> <%=strSiteNav%></div>
<div class="clear"></div>

<!-- start hot -->
<div class="border4 hot">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<div class="try">
    <asp:Literal ID="litMore" runat="server"></asp:Literal>
<strong>课程试听章节：</strong>

    <asp:Image ID="imgListen" runat="server" width="244" height="181" /></div>
    <asp:Literal ID="litCInfo" runat="server"></asp:Literal>
<%--<a href="#" class="img">
    <asp:Image ID="imgCourse" runat="server"  width="334" height="224" /><asp:Literal ID="litCourseName" runat="server"></asp:Literal></a>--%>
<ul>
<li><strong>分类：</strong><a href="index.aspx">我要学</a><asp:Literal ID="litCate" runat="server"></asp:Literal></li>
<li><strong>标签：</strong><asp:Literal ID="litTags" runat="server"></asp:Literal></li>
<li><strong>时间：</strong><asp:Literal  ID="litTime" runat="server"></asp:Literal></li>
<li><strong>地点：</strong>网络课程</li>
<li><strong>老师：</strong><asp:Literal ID="litTeachers" runat="server"></asp:Literal> </li>
<li><strong>价格：</strong><asp:Literal ID="litePrice" runat="server"></asp:Literal></li>
<li><strong>分享课程：</strong>
<!-- JiaThis Button BEGIN -->
<div id="ckepop">
<span class="jiathis_txt"></span> <a class="jiathis_button_icons_1"></a><a class="jiathis_button_icons_2">
</a><a class="jiathis_button_icons_3"></a><a class="jiathis_button_icons_4"></a>
<a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a><a class="jiathis_counter_style"></a>
</div>
<script type="text/javascript" src="http://v2.jiathis.com/code/jia.js"></script>
<!-- JiaThis Button END --></li>
<li style="line-height:20px;">
<img id="btnAddFavorites" src="imagesN/TLaoShi_bt029.gif" style="margin-left:10px;" />
                                <img id="btnDelFavorites" src="imagesN/qx.gif" style="margin-left:10px;" />
</li>
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>
<!-- end hot -->

<!-- start zhuanti -->
<div class="zhuanti border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<!-- start right -->
<div class="right">

<!-- start yixuan -->
<%--<div class="yixuan">
已有150人选择此课程：
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
</div>--%>
<!-- end yixuan -->

<!-- start jieshao2 -->
<div class="jieshao2 border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>教师介绍</h3>
<div class="img">
<a href="#"><asp:Image ID="imgUserAvatar" runat="server" width="88" height="99" style="float:left;margin-right:10px;"/></a>
<strong><a href="#">主讲：<asp:Literal ID="litUName" runat="server"></asp:Literal></a></strong>
<%--来自北京朝阳区--%>
<a href="#"><img src="imagesN/TLaoShi_bt033.gif" width="101" height="27"  style="position:relative;top:33px;" /></a></div>
<p><strong>标签：</strong><asp:Literal ID="litTeacherTags" runat="server"></asp:Literal> </p>
<p><strong>描述：</strong><asp:Literal ID="litTeacherInfo" runat="server"></asp:Literal><asp:Literal  ID="litdet" runat="server"></asp:Literal></p>
<ul>
<li><img src="imagesN/TLaoShi_bg109.gif" />已发布课程：<asp:Literal ID="litPubCourse" runat="server"></asp:Literal>门</li>
<li><img src="imagesN/TLaoShi_bg110.gif" />已参加人次：<asp:Literal ID="litPeople" runat="server"></asp:Literal>人</li>
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end jieshao -->

<!-- start xinyong -->
<div class="xinyong border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>信用网络</h3>
<ol>
<li><img src="imagesN/TLaoShi_bg111.gif" />325人</li>
<li><img src="imagesN/TLaoShi_bg112.gif" />5643条</li>
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
<!-- end xinyong -->

<!-- start dayi -->
<div class="dayi border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>教师答疑</h3>
<a href="#"><img src="imagesN/TLaoShi_bt032.gif" width="151" height="24" /></a>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：专访，无论写的是谁，篇幅有多长，基本都可以总结成她拍戏特别拼，上刀山下。</span></p>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：专访，无论写的是谁，篇幅有多长，基本都可以总结成她拍戏特别拼，上刀山下。</span></p>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：专访，无论写的是谁，篇幅有多长，基本都可以总结成她拍戏特别拼，上刀山下。</span></p>
<p>问：获亚历山大阿道夫冯洪堡奖？<span>答：专访，无论写的是谁，篇幅有多长，基本都可以总结成她拍戏特别拼，上刀山下。</span></p>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end dayi -->


</div>
<!-- end right -->

<!-- start left -->
<div class="left">

<!-- start jieshao -->
<div class="jieshao border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>课程描述</h3>
<p><asp:Literal ID="litDes" runat="server"></asp:Literal></p>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end jieshao -->

<!-- start jieshao_list -->
<div class="jieshao_list">
<table width="100%" border="0" cellspacing="0" cellpadding="0"  id='modInfo'>
  <tr>
    <th>序号</th>
    <th>小节名称</th>
    <th>教师</th>
    <th>时长</th>
    <th>价格</th>
  </tr></table><div class="pages"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" id='Table1'>
<tr>
<td colspan="5">
<ul>
<%=strCourseMaterial %>
</ul>
</td>
</tr>
</table>
</div>
<!-- end jieshao_list -->

<!-- start pinglun -->
<div class="pinglun border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h2>此课程最新热门评论</h2>
<div id="divComm">
</div>
<div class="cpages" style="text-align:center;"></div>

</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end pinglun -->

</div>
<!-- end left -->

<div class="clear"></div>

<!-- start xiangguan -->
<div class="xiangguan border5">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>相关课程</h3>
<div style="height:100%;overflow:hidden;">
<div id='r'></div>
<div id='l'></div>
<ul id='releate'>
</ul>
</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end xiangguan -->

</div>
</div>
</div>
</div>
</div>
<!-- end zhuanti -->

</div>
<!-- end content -->
</asp:Content>
