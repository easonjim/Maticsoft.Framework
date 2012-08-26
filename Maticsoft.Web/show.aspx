<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Maticsoft.Web.show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="js/tabmenu.js" type="text/javascript"></script>
<script src="js/videoshow.js" type="text/javascript"></script>
<%--<link href="css/VideoShowStyle.css" rel="stylesheet" type="text/css" />--%>
<script src="js/flowplayer-3.2.6.min.js" type="text/javascript"></script>
<link href="css/videoCss.css" rel="stylesheet" type="text/css" />

<script src="js/killScriptErrors.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="content">

  <asp:HiddenField ID="hfCurrent" runat="server" />
<input type="hidden" id="hfTid" runat="server"  />
<input type="hidden" id="hfUid" runat="server"  />
<input type="hidden" id="CommentType" value="0" />
<asp:HiddenField ID="hfCourseID" runat="server" />
<asp:HiddenField ID="hfModuleID" runat="server" />
<div class="zhuanti_nav"><strong><a href="index.aspx">我要学</a></strong> <%=strSiteNav%></div>
<div style="clear:both;"></div>

<!-- start video -->
<div class="border4 video">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<div class="txt">
<div class="nav"><a href="javascript:void(0);" class="link">基本信息</a><a href="javascript:void(0);">课程介绍</a><a href="javascript:void(0);">我的笔记</a></div>
<div class="balancecontentin">
<ul>
<li><strong><a href="#"><asp:Literal ID="litCourseName" runat="server"></asp:Literal></a></strong></li>
<li><b>分类：</b><a href="index.aspx">我要学</a><asp:Literal ID="litCate" runat="server"></asp:Literal></li>
<li><b>标签：</b><asp:Literal ID="litTags" runat="server"></asp:Literal></li>
<li><b>时长：</b><asp:Literal  ID="litTime" runat="server"></asp:Literal></li>
<li><b>地点：</b>网络课程 </li>
<li><b>老师：</b><asp:Literal ID="litTeachers" runat="server"></asp:Literal> </li>
<li><b>价格：</b><a href="#"><asp:Literal ID="litePrice" runat="server"></asp:Literal></a></li>
<li><b>销售量：</b><a href="#"><asp:Literal ID="litSell" runat="server"></asp:Literal></a></li>
<li><b>浏览量：</b><a href="#"><asp:Literal ID="lblPV" runat="server"></asp:Literal></a></li>
<li><b>分享到：</b>
<!-- JiaThis Button BEGIN -->
<div id="ckepop">
<span class="jiathis_txt"></span> <a class="jiathis_button_icons_1"></a><a class="jiathis_button_icons_2">
</a><a class="jiathis_button_icons_3"></a><a class="jiathis_button_icons_4"></a>
<a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a><a class="jiathis_counter_style"></a>
</div>
<script type="text/javascript" src="http://v2.jiathis.com/code/jia.js"></script>
<!-- JiaThis Button END --></li><br /><br /><br /><br />
<li style="line-height:20px;padding-top:5px;"><a href="javascript:void(0);">
                                <img id="btnAddFavorites" src="imagesN/TLaoShi_bt029.gif" style="margin-top: 2px;" />
                                <img id="btnDelFavorites" src="imagesN/qx.gif" style="margin-top: 2px;" /><%--<img src="imagesN/TLaoShi_bt029.gif"  id="Attention" />--%></a> 
    <asp:Literal ID="litNoBuy" runat="server"></asp:Literal></li>
</ul>
</div>
<div class="balancexq">
<div style="height: 480px; line-height: 180%; overflow-y: auto;white-space: normal;">
<ul>
<li><strong><a href="#">课程简介</a></strong></li>
<li><asp:Literal ID="litDes" runat="server"></asp:Literal></li>
</div>
</div>
<div class="balancexq">
<%--<div style="height: 480px; line-height: 180%; overflow-y: auto;white-space: normal;">
<ul>
<li><strong><a href="#">欧洲历史文学简理论导论</a></strong></li>
<li><strong>欧洲金融概述 第一节</strong></li>
<li><b>分类：</b>商业职场 > 金融 > 国际贸易 > 运输</li>
<li><b>标签：</b>英语 口语学习 英语语音 翻译</li>
<li><b>时间：</b>4小时23分钟/课时 共5课时 3小时2分钟</li>
<li><b>地点：</b>网络课程 </li>
<li><b>老师：</b>Theory </li>
<li><b>价格：</b><a href="#">￥20/课程</a></li>
<li>可观看时限：永久</li>
<li>可点击次数：100</li>
</ul>
</div>--%>

<div style="height: 450px; padding: 15px 20px 0px 20px; line-height: 220%; overflow-y: auto;white-space: normal;">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<%=strCourseNotes%>
<div class="note-history">
<asp:Label ID="labNID" runat="server" Text='' Visible="false" ></asp:Label>
<asp:Repeater ID="rptCourseNotes" runat="server"     onitemcommand="rptCourseNotes_ItemCommand">
<ItemTemplate> 
<span class="colRxm1">
<p><%#Eval("Updatetime")%></p> <p style="margin-top:-22px;">
<asp:ImageButton ID="ImageButton2" runat="server" ToolTip="编辑" CommandArgument="editC" ImageUrl="~/Images/edit.png" CssClass="edit" />
<asp:ImageButton ID="ImageButton1" runat="server" ToolTip="删除" CommandArgument="delC" ImageUrl="~/Images/cha.gif" /></p>
</span>

<span class="colBTextm">
<p style="margin-top:-10px;line-height: 180%"> <%# HttpUtility.HtmlEncode(Eval("Contents").ToString()) %></p>
<asp:Label ID="labontent" runat="server" Text='<%# Eval("Contents")%>' Visible="false"></asp:Label>
</span>


<span class="colRxmm">
<asp:Label ID="labNoteId" runat="server" Text='<%#Eval("NoteID") %>' Visible="false"></asp:Label>
<asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label>
<asp:Label ID="labMid" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
</span>

<span><div style="border:1px solid #e7e7e7;border-bottom:none;border-left:none;border-right:none;margin-top:5px;width:240px;"></div></span>

</ItemTemplate>
</asp:Repeater>
</div>
            
<div style="display: block;" class="note-enter" id="operationArea">
<textarea class="note-textarea" name="NotebookArea" id="NotebookArea" rows="5" runat="server"></textarea>
<div align="right">
<asp:ImageButton ID="btnAddCourseNotes" runat="server" ImageUrl="images/submit.jpg" onclick="btnAddCourseNotes_Click"  CssClass="tj" />
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</div>



</div>

</div>
<div class="show"><%= strVideoHtmlCode%><%--<img src="imagesN/019.gif" width="600" height="423" />--%></div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>
<!-- end video -->

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
<div class="yixuan">

<asp:Literal ID="litHaveChose" runat="server"></asp:Literal>人选此课程 | 
<asp:Literal ID="litFav" runat="server"></asp:Literal>人关注此课
<ul style="display:none;">
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
<p><strong>标签：</strong><asp:Literal ID="litTeacherTags" runat="server"></asp:Literal></p>
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
<p><asp:Literal ID="LitDesc" runat="server"></asp:Literal></p>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>
<!-- end jieshao -->

<!-- start jieshao_list -->
<div class="jieshao_list">
<table width="100%" border="0" cellspacing="0" cellpadding="0" id='modInfo'>
<tr>
<th>序号</th>
<th>小节名称</th>
<th>教师</th>
<th>时长</th>
<th>价格</th>
</tr>
</table><div class="pages"></div>
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
<div class="content" id='ComM'>
<h2>此课程最新热门评论</h2>

<ul class="fabiao">
<%--<li><span>标题：</span><input name="" type="text"  class="txt07"/></li>--%>
<li><span>评论：</span><textarea  class="textarea03"></textarea></li>
<li><input name="" type="button" class="button29" /></li>
</ul>
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
