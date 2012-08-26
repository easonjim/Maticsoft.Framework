<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="OfflineCourse.aspx.cs" Inherits="Maticsoft.Web.PubCourse.OfflineCourse" EnableEventValidation="false" EnableViewState="false"   %>
<%@ Register Src="../Controls/UnFinshOffLineCourse.ascx" TagPrefix="uc" TagName="UnFinshOffLineCourse" %>
<%@ Register Src="../Controls/OffLineCourseDetailInfo.ascx" TagPrefix="uc" TagName="OffLineCourseDetailInfo" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/UnFinshCourse.ascx" TagPrefix="uc" TagName="UnFinshCourse" %>
<%@ Register src="../Controls/CourseDetailInfo.ascx" tagname="CourseDetailInfo" tagprefix="uc1" %>
<%@ Register src="../Controls/ISPublishCourse.ascx" tagname="ISPublishCourse" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/tabmenu.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<input type="hidden" id="pageInfo" value="10" />
<!-- start main -->
<div class="main">

<!-- start input8 -->
<div class="input8 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>线下课程</strong> > <strong>已开课程</strong></div>
<h2>已开课程</h2>
<div class="class_table">
<div class="tabs"><a href="javascript:void(0);" class="link">审核已上架</a><a href="javascript:void(0);">审核未上架</a><a href="javascript:void(0);">已发布，未审核课程</a><a href="javascript:void(0);">未完成的课程</a></div>
<div class="balancecontentin">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<%--<uc1:CourseDetailInfo ID="CourseDetailInfo1" runat="server" />--%>
<uc:OffLineCourseDetailInfo runat="server" ID="ucOffLineCourseDetailInfo" />
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div class="balancexq">


<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate >
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<th width="100">课程图片</th>
<th>课程名称</th>
<th>报名人数</th>
<th>单价</th>
<th>发布时间</th>
<th>更新时间</th>
<th>操作</th>
</tr>
<asp:Repeater ID="Repeater_PubCourse" runat="server"   onitemcommand="Repeater_PubCourse_ItemCommand"  onitemdatabound="Repeater_PubCourse_ItemDataBound"  >
<ItemTemplate>
<tr>
<td align="center" valign="middle" class="b1" ><a href="#" title='<%#Eval("CourseName")%>'><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\"width:90px;height:70px;\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></a></td>
<td align="left" valign="middle" style="width:100px;"><a href="#" title='<%#Eval("CourseName")%>'  style="color:#004986;" ><%#HttpUtility.HtmlEncode(Eval("CourseName").ToString())%><br /></a></td>
<td align="center" valign="middle" class="b2">
<asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
<%--<asp:Label ID="labCount" runat="server" Text=""></asp:Label>--%>
<%#Eval("BookCount")%>
</td>
<td align="center" valign="middle" class="b2"><%#Eval("CoursePrice", "{0:C}")%></td>
<td align="center" valign="middle" class="b1"><%#Eval("CreatedDate")%></td>
<td align="center" valign="middle" class="b1"> <%#Eval("CreatedDate")%></td>
<td align="center" valign="middle" class="b4">
<asp:Button ID="btnEdit" runat="server" CommandArgument="btnEditInfo" Text="编辑" />&nbsp;
<asp:Button ID="btnPublish" runat="server" CommandArgument="btnPub" Text="发布"  />
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table> 
<asp:Label ID="ErrorMsg2" runat="server" Text='暂时没有课程信息！' ForeColor="Red"   Visible="False"></asp:Label>
<span>
<webdiyer:AspNetPager ID="AspNetPager2" runat="server" CurrentPageButtonPosition="Center"
CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
CssClass="pages" CurrentPageButtonClass="cpb" 
HorizontalAlign="Center" PageSize="10"
OnPageChanged="AspNetPager2_PageChanged" AlwaysShow="false"
NumericButtonCount="3">
</webdiyer:AspNetPager>
</span>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger  ControlID="AspNetPager2"/>
</Triggers>
</asp:UpdatePanel>
</div>


<div class="<%=divClass2 %>">
<div class="opentableBox">									
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
<%--<uc:UnFinshCourse runat="server" ID="ucUnFinshCourse" />--%>
<uc:UnFinshOffLineCourse runat="server" ID="ucUnFinshOffLineCourse" />
</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
<div class="balancexq">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<uc:UnFinshOffLineCourse runat="server" ID="ucUnFinshOffLineCourse1" />
</ContentTemplate>
</asp:UpdatePanel>
</div>

</div>

<div class="soild"></div>

</div>
</div>
</div>
</div>
</div>
<!-- end input8 -->

</div>
<!-- end main -->
</asp:Content>
