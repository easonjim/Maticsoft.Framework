<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Maticsoft.Web.index" EnableViewState="false" %>

<%@ Register src="Controls/NTaoCopyRight.ascx" tagname="NTaoCopyRight" tagprefix="MaticSoft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>淘老师-三人行必有我师</title>
	<link href="css/TLaoShi.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="css/nivo-slider.css" type="text/css" media="screen" />
<link rel="stylesheet" href="css/banner.css" type="text/css" media="screen" />
	<script src="js/jquery-1.5.1.min.js" type="text/javascript"></script>
	<script src="js/base.js" type="text/javascript"></script>
	<script src="js/indexajax.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.nivo.slider.pack.js"></script>
<script type="text/javascript">
	$(window).load(function() {
		$('#slider').nivoSlider();
	});
</script>
</head>
<body id="study">
	<form id="form1" runat="server">

<!-- start header -->
<div id="header">
<div class="acc"><%=loginInfo%></div>
<a href="index.aspx" title="淘老师 淘好老师，做好老师"><h1>淘老师 淘好老师，做好老师</h1></a>
<div class="menu">
<a href="#" class="act_list">全部课程分类</a><a href="index.aspx" class="index">首页</a><div class="teach"><a href="courselist.aspx" class="a">我要学</a><a href="learn.aspx" class="b">我要教</a></div><div class="search"><input name="input" type="text"  onkeyup="showIntelliSense()" id="txtSearchword" value="  搜课程 找老师" onblur="if(!this.value) {this.value='  搜课程 找老师';this.style.color='#b2b2b2';}" ;="" onfocus="if(this.value=='  搜课程 找老师') this.value='';this.style.color='#272727'" style="color: rgb(178, 178, 178); " class="txt01"/><div id="divsearch" style="position: absolute; margin-top: 4px; margin-left: 2px; z-index: 100; display: none; "></div><input name="" type="button" class="button01" /></div><div id='hotkey' class="more"></div>
</div>
</div>
<!-- end header -->

<!-- start content -->
<div id="content">

<!-- start study -->
<div class="study">

<div class="wangluo"><img src="imagesN/TLaoShi_bg083.gif" width="172" height="328" /></div>
<div class="my_left_category">
 <div class="my_left_cat_list">
 
<asp:Repeater ID="Repeater_One" runat="server" OnItemDataBound="Repeater_One_ItemDataBound">
<ItemTemplate>
<%#resturnDiv(Eval("CategoryId").ToString())%>
<p> <asp:Label ID="labCid" runat="server" Text='<%#Eval("CategoryId") %>' Visible="false"></asp:Label><a href="courselist.aspx?CategoryId=<%#Eval("CategoryId") %>"> <%#Eval("Name") %></a></p>
				
<div class="h3_cat">
<div class="shadow">
<div class="shadow_border">
<asp:Repeater ID="Repeater_Two" runat="server" OnItemDataBound="Repeater_Two_ItemDataBound">
<ItemTemplate>
<div class="subitem">
<dl class="fore">
<dt>
<asp:Label ID="labCCid" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
<strong><a href="courselist.aspx?CategoryId=<%#Eval("CategoryId") %>"> <%# Eval("Name")%></a> </strong> </dt>
<dd>
<asp:Repeater ID="Repeater_Three" runat="server">
<ItemTemplate>
<em><a href="courselist.aspx?CategoryId=<%#Eval("CategoryId") %>"> <%# Eval("Name")%></a></em>
</ItemTemplate>
</asp:Repeater>
</dd>
</dl>
</div>
</ItemTemplate>
</asp:Repeater>
</div>
</div>
</div>
</div>
</ItemTemplate>
</asp:Repeater>
</div>
</div>
<div class="show" style="z-index:-1;">
 <div id="wrapper">
        <div id="slider-wrapper">
            <div id="slider" class="nivoSlider">
                <img src="imagesN/banner0.gif" alt="" width="581" height="333" />
                <img src="imagesN/banner1.gif" alt="" width="581" height="333" />
                <img src="imagesN/banner2.gif" alt="" width="581" height="333" />
                
            </div>
        </div>
</div>
</div>

<div style="clear:both;"></div>

<div class="xianxia">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<a href="#" class="more"></a>
<h2>线下课程 <span>(实地课程，活动）</span></h2>
<ul id="offline">
<%--<li><a href="#" class="img"><img src="imagesN/011.gif" width="129" height="86" /></a>
<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>
<a href=""# class="tit">商业谈判实战技巧...</a>
<p>时间：2012-12-22<br />
地点：北京国贸三期...<br />
讲师：林天伦<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" /></p></li> 
<li><a href="#" class="img"><img src="imagesN/011.gif" width="129" height="86" /></a>
<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>
<a href=""# class="tit">商业谈判实战技巧...</a>
<p>时间：2012-12-22<br />
地点：北京国贸三期...<br />
讲师：林天伦<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" /></p></li> 

<li style="position:relative;top:-35px;margin:10px 0 -35px 10px;height:255px;"><img src="imagesN/TLaoShi_bg084.gif" width="172" height="231" /></li> 

<li><a href="#" class="img"><img src="imagesN/011.gif" width="129" height="86" /></a>
<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>
<a href=""# class="tit">商业谈判实战技巧...</a>
<p>时间：2012-12-22<br />
地点：北京国贸三期...<br />
讲师：林天伦<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" /></p></li> 
<li><a href="#" class="img"><img src="imagesN/011.gif" width="129" height="86" /></a>
<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>
<a href=""# class="tit">商业谈判实战技巧...</a>
<p>时间：2012-12-22<br />
地点：北京国贸三期...<br />
讲师：林天伦<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" /></p></li>
<li><a href="#" class="img"><img src="imagesN/011.gif" width="129" height="86" /></a>
<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>　<a href=""#><img src="imagesN/TLaoShi_bg086.gif" width="58" height="18" /></a>
<a href=""# class="tit">商业谈判实战技巧...</a>
<p>时间：2012-12-22<br />
地点：北京国贸三期...<br />
讲师：林天伦<img src="imagesN/TLaoShi_bg089.gif" width="19" height="11" /></p></li> --%>
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>


<%--<div class="border3 tuijian">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>推荐课程<span> (最新教师上传展示课程）</span></h2>
<a href="searchCourse.aspx" target="_blank" class="more"></a>
<ul id="offline">
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>--%>




<div class="border3 tuijian">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>推荐课程<span> (最新教师上传展示课程）</span></h2>
<a href="searchCourse.aspx" target="_blank" class="more"></a>
<ul id="rec">
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 mingshi">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>名师推荐<span> (知名学者、教授）</span></h2>
<a href="#" class="more"></a>
<ul id='teacher'>
<li><a href=""#><img src="imagesN/012.gif" width="100" height="113" />姓名：Henry </a>
<p>标签：艺术历史<br />
行业：职业教师 <br />
课程：<img src="imagesN/TLaoShi_bg092.gif" width="19" height="11" /> </p></li> 
<li><a href=""#><img src="imagesN/012.gif" width="100" height="113" />姓名：Henry </a>
<p>标签：艺术历史<br />
行业：职业教师 <br />
课程：<img src="imagesN/TLaoShi_bg092.gif" width="19" height="11" /> </p></li> 
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="border3 gongkai">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>公开课程<span> (各类公开课程集合）</span></h2>
<a href="courselist.aspx?CategoryId=34" target="_blank" class="more"></a>
<ul id='pub'>
</ul>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 right">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>商业职场<span> (商业管理、营销）</span></h2>
<a href="courselist.aspx?CategoryId=8" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='trader'></div>
<div id='tradel'></div>
<ul id='trade'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="border3 left">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>生活<span> (各类专业资格认证）</span></h2>
<a href="courselist.aspx?CategoryId=23" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='r'></div>
<div id='l'></div>
<ul id='life'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 right">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>计算机与网络<span> ( Internet 知识）</span></h2>
<a href="courselist.aspx?CategoryId=16" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='computer'></div>
<div id='computel'></div>
<ul id='compute'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="border3 left">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>艺术<span> (艺术视频、书法）</span></h2>
<a href="courselist.aspx?CategoryId=63" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='artr'></div>
<div id='artl'></div>
<ul id='art'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 right">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>语言<span> (商业管理、营销）</span></h2>
<a href="courselist.aspx?CategoryId=30" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='laur'></div>
<div id='laul'></div>
<ul id='lau'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="border3 left">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>中小学教育<span> (辅导课程）</span></h2>
<a href="courselist.aspx?CategoryId=65" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='stur'></div>
<div id='stul'></div>
<ul id='stu'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 right">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>体育<span> (体育课程、锻炼）</span></h2>
<a href="courselist.aspx?CategoryId=64" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='sportsr'></div>
<div id='sportsl'></div>
<ul id='sports'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="border3 left">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con">
<h2>职业认证<span>（各类专业资格认证）</span></h2>
<a href="courselist.aspx?CategoryId=1" target="_blank" class="more"></a>
<div style="height:100%;overflow:hidden;">
<div id='profr'></div>
<div id='profl'></div>
<ul id='prof'>
</ul>

</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

<div class="clear"></div>

<div class="border3 dianping">
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="con" style="width:978px;margin-bottom:25px;">
<h2>最新点评<span> (教学点评、回复）</span></h2>
<ul id="comInfo">
</ul>
<div class="pages"></div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
</div>

</div>
<!-- end study -->

</div>
<!-- end content -->

<!-- start footer -->
<MaticSoft:NTaoCopyRight ID="NTaoCopyRight1" runat="server" />
<!-- end footer -->
	</form>
</body>
</html>
