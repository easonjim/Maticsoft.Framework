<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="Maticsoft.Web.TeacherList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/220478128.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<input  type="hidden" id="HfcourseType" value="0"/>
<input  type="hidden" id="hfDate"  value="0"/>
<input  type="hidden" id="hfSortType" value="0"/>
<!-- start content -->
<div id="content">

<!-- start main -->
<div class="main">

<!-- start act_list -->
<div class="act_list border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><strong><a href="index.aspx">我要学</a></strong> <%=strSiteNav%></div>
<h2>课程列表</h2>
<div class="padding">
<div class="select">
<%--<div class="img"><a href="/PubCourse/NewPubCourse.aspx" target="_blank"><img src="imagesN/TLaoShi_bg101.gif" width="158" height="24" /></a><br /><br /><a href="#"><img src="imagesN/TLaoShi_bg102.gif" width="158" height="24" /></a></div>--%>
<ul>
<li><a href="/PubCourse/NewPubCourse.aspx" target="_blank"><img src="imagesN/TLaoShi_bg101.gif" width="158" height="24" /></a><a href="#"><img src="imagesN/TLaoShi_bg102.gif" width="158" height="24" /></a></li>
<%--<div id='courseType'><li><a href="javascript:void(0);" id='allCourse' class="link" >全部课程</a>|<a href="javascript:void(0);"id='onlineCourse'>网络课程</a>|<a href="javascript:void(0);" id='nonet'>线下课程</a></li></div> 
<div id='positionC' style="display:none;"><li><a href="#" class="link">全部地点</a>|<select name="" class="txt04"><option>选择城市</option></select></li></div>
<div id='pubtime'><li><a href="#" class="link">默认所有</a>|<a href="#">今天</a>|<a href="#">明天</a>|<a href="#">周末</a>|<a href="#">最近一周</a>|<a href="#">选择日期</a></li></div>
<div id='timeSe' style="display:none;"><li><input id="txtDate" type="text" style="width:180px;" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" readonly="readonly"/></li></div>
<div id='sort'><li><a href="#" class="link">默认排序</a>|<a href="#" >按时间</a>|<a href="#">按人气</a>|<a href="#">按价格</a></li></div>--%>
</ul>
</div>
<div class="wsh">
<ul id="modInfo">
</ul>
</div>
<div class="pages"></div>
</div>

</div>
</div>
</div>
</div>
</div>
<!-- end act_list -->

</div>
<!-- end main -->

<!-- start side -->
<div class="side">

<!-- start list2 -->
<div class="list2 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<img src="imagesN/TLaoShi_bg098.gif" width="172" height="111" />

<div class="search">
<select name="" class="txt05" id="cType"><option value="">请选择课程类别</option><option value="0">网络课程</option><option value="1">线下课程</option></select>

<asp:DropDownList ID="ddlEnter" runat="server" class="txt05">
<asp:ListItem>请选择所属机构</asp:ListItem>
</asp:DropDownList>
<%--<select name="" class="txt05"><option>请选择授课经验</option></select>--%>
<div  style="display:none;"  id="cPro"><select name="" class="txt06"><option>省份</option></select> <select name="" class="txt06"><option>城市</option></select></div>
<input name="" type="text" id="txtKey" />
<input name="" type="button" class="button28" id='btnSearch'/>
</div>

<a href="#"><img src="imagesN/TLaoShi_bg099.gif" width="172" height="340" /></a><br /><br />
<a href="#"><img src="imagesN/TLaoShi_bg100.gif" width="189" height="280" /></a>

</div>
</div>
</div>
</div>
</div>
<!-- end list2 -->

</div>
<!-- end side -->

</div>
<!-- end content -->
</asp:Content>
