<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserTeacherHome.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserTeacherHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/teachercourse.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="pageInfo" value="6" />

    <asp:HiddenField ID="hfCid" runat="server" />
<!-- start main -->
<div class="main">

<!-- start Tindex -->
<div class="Tindex border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的账户</a> > <strong>教师主页</strong></div>
<h2>教师主页</h2>
<ul class="mess">
<li><strong><label id="lblUserName" runat="server"></label></strong>（来自<asp:Literal ID="litProvice" runat="server"></asp:Literal>）</li>
<li class="line"></li>
<li><strong>认证：</strong><asp:Label ID="lblCertificate" runat="Server"></asp:Label></li>
<li><strong>标签：</strong><asp:HyperLink ID="hyLabel" runat="server"   ForeColor="#98B6CE"></asp:HyperLink>
                                        <asp:TextBox ID="txtTag" runat="server"></asp:TextBox></li>
<li style="height:35px;"><asp:Button ID="btnEdit" runat="server" class="button05"  onclick="btnEdit_Click"  />
    <asp:Button ID="btnCom" runat="server" class="button0333" 
        onclick="btnCom_Click"   /></li>
</ul>
<div class="img"><img id='imgGravatar' src="../images/tx.gif" runat="server" width="157" height="179" /></div>
<div style="clear:both;"></div>

<div class="border2 profile">
<div class="nbg01">
<div class="nbg02">
<div class="content">
<h3>个人简介</h3>
<asp:Label ID="lblIntroduction" runat="server" ></asp:Label> 
<asp:TextBox ID="txtDesc" runat="server"  Width="615px" Height="100px" TextMode="MultiLine" ></asp:TextBox><%--<a href="#">展开查看全部 >></a>--%>
</div>
</div>
</div>
</div>

<div class="border2 allclass">
<div class="nbg01">
<div class="nbg02">
<div class="content">
<h3>所开课程</h3>
<div id='r'></div>
<div id='l'></div>
<ul id='releate'>
<li><a href="#"><img src="images/002.gif" width="153" height="103" />美女函数程式分析..</a><p>分类：理学>数学函数</p><p>价格：￥60元</p></li>
<li><a href="#"><img src="images/002.gif" width="153" height="103" />美女函数程式分析..</a><p>分类：理学>数学函数</p><p>价格：￥60元</p></li>
<li><a href="#"><img src="images/002.gif" width="153" height="103" />美女函数程式分析..</a><p>分类：理学>数学函数</p><p>价格：￥60元</p></li>
</ul>
</div>
</div>
</div>
</div>

</div>
</div>
</div>
</div>
</div>
<!-- end Tindex -->

</div>
<!-- end main -->

</asp:Content>
