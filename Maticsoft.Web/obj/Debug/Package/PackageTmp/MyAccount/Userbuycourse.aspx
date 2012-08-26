<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="Userbuycourse.aspx.cs" Inherits="Maticsoft.Web.MyAccount.Userbuycourse" %>

<%@ Register Src="../Controls/LearnCourse.ascx" TagName="LearnCourse" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/tabmenu.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<input type="hidden" id="pageInfo" value="3" />

<!-- start main -->
<div class="main">

<!-- start active -->
<div class="active border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="Userbuycourse.aspx">学习管理</a> > <strong>已选课程</strong></div>
<h2>已选课程</h2>
<div class="class_table">
<div class="tabs"><a href="javascript:void(0);" class="link">最近三个月所选课程</a><a href="javascript:void(0);">三个月以前所选课程</a></div>
<div class="balancecontentin">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<%--<uc1:LearnCourse ID="LearnCourseAF" runat="server" />--%>
<div class="setableBox">
<div>
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<%--<th>订单编号</th>--%>
<th style="width:180px;">所选课程名称</th>
<th>教师</th>
<th>价格（元）</th>
<th>购买时间</th>
<%-- <th>打分</th>--%>
<th style="width:200px;">评论</th>
</tr>
<asp:Repeater ID="rptPrice" runat="server" OnItemDataBound="rptPrice_ItemDataBound"   OnItemCommand="rptPrice_ItemCommand">
<ItemTemplate>
<tr class='rptclass'>
<%--<td align="center" valign="middle" class="b2">
<%#Eval("OrderID")%>
                                                        
</td>--%>
<td align="left" valign="middle" class="b5"><asp:Label ID="LabOid" runat="server" Text='<%#Eval("OrderID") %>' Visible="false"></asp:Label>
<a href="../show.aspx?cid=<%# Eval("CourseID") %>&mid=<%#Eval("ModuleID") %>" title='<%#Eval("CourseName")%>' style="color:#034985;">
<p style="margin-left:8px;"><%#Eval("CourseName") %><br /><%#Eval("ModuleName")%></p>
</a>
<asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label>
<asp:Label ID="labMid" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
</td>
<td align="left" valign="middle" class="b2">
<a href="../TeacherDetailInfo.aspx?uid=<%#Eval("CreatedUserID")%>">
<p style="margin-left:8px;"><%#Eval("TrueName") %></p></a>
</td>
<td align="right" valign="middle" class="b2">
<p style="margin-right:8px;"> <%#Eval("Price", "{0:C}")%></p>
</td>
<td align="center" valign="middle" class="b1">
<%#Eval("OrderDate")%>
</td>
<td align="left" valign="middle" class="b4">
<div style="height: 60px; line-height: 220%; overflow-y: auto; white-space: normal;">
<p style="margin-left:8px;"><%#Eval("Comment")%></p>
<br />
<div style="margin-top: -5px;" align="center">
<asp:TextBox ID="txtCom" runat="server" TextMode="MultiLine" Height="50px" style="margin-top:-20px;"></asp:TextBox>
<asp:ImageButton ID="imgBtn" runat="server" CommandArgument="btnCom" ImageUrl="../images/kspl.jpg" CssClass="commenttxt" /></div>
</div>
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
<%--<div class="openPage">--%>
<span>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"  PageIndexBoxType="TextBox" PrevPageText="上一页" CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="false" NumericButtonCount="3">
</webdiyer:AspNetPager>
</span>
</ContentTemplate>
</asp:UpdatePanel>
</div>
<div class="balancexq">

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<%--<uc1:LearnCourse ID="LearnCourseBF" runat="server" />--%>
<div class="setableBox">
<div>
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<%--<th>订单编号</th>--%>
<th style="width:180px;">所选课程名称</th>
<th>教师</th>
<th>价格（元）</th>
<th>购买时间</th>
<%-- <th>打分</th>--%>
<th style="width:200px;">评论</th>
</tr>
<asp:Repeater ID="rptPricebf" runat="server" OnItemDataBound="rptPricebf_ItemDataBound"
OnItemCommand="rptPricebf_ItemCommand">
<ItemTemplate>
<tr class='rptclass'>
<%--<td align="center" valign="middle" class="b2">
<%#Eval("OrderID")%>
                                                        
</td>--%>
<td align="left" valign="middle" class="b5">
<asp:Label ID="LabOid" runat="server" Text='<%#Eval("OrderID") %>' Visible="false"></asp:Label>
<a href="../show.aspx?id=<%# Eval("CourseID") %>&mid=<%#Eval("ModuleID") %>" title='<%#Eval("CourseName")%>' style="color:#034985;">
<p style="margin-left:8px;"> <%#Eval("CourseName") %><br /><%#Eval("ModuleName")%></p></a>
<asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label>
<asp:Label ID="labMid" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
</td>
<td align="left" valign="middle" class="b2">
<p style="margin-left:8px;"><%#Eval("TrueName") %></p>
</td>
<td align="right" valign="middle" class="b2">
<p style="margin-right:8px;"> <%#Eval("Price", "{0:C}")%></p>
</td>
<td align="right" valign="middle" class="b1">
<%#Eval("OrderDate")%>
</td>
<%--    <td align="center" valign="middle" class="b1"><img src="../images/xing.jpg"/></td>--%>
<td align="left" valign="middle" class="b4">
<div style="height: 50px; line-height: 220%; overflow-y: auto; white-space: normal;"><p style="margin-left:8px;"><%#Eval("Comment")%></p><br />
<div style="margin-top: -5px;" align="center">
<asp:TextBox ID="txtCom" runat="server" TextMode="MultiLine"  Height="50px" style="margin-top:-20px;"></asp:TextBox>
<asp:ImageButton ID="imgBtn" runat="server" CommandArgument="btnCom" ImageUrl="../images/kspl.jpg"   CssClass="commenttxt" /></div></div>
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
<span>
<webdiyer:AspNetPager ID="AspNetPager2" runat="server" CurrentPageButtonPosition="Center" 
CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" 
LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页" 
CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10" 
OnPageChanged="AspNetPager2_PageChanged" AlwaysShow="false" NumericButtonCount="3">
</webdiyer:AspNetPager>
</span>
</ContentTemplate>
</asp:UpdatePanel>
</div>

</div>

<%--<div class="pages"><a href="#">&lt;&lt;</a><a href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><a href="#">&gt;&gt;</a></div>--%>
<br/>
<div class="soild"></div>

</div>
</div>
</div>
</div>
</div>
<!-- end active -->

</div>
<!-- end main -->


</asp:Content>
