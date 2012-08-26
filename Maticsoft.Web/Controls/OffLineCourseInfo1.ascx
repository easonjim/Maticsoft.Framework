<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OffLineCourseInfo1.ascx.cs" Inherits="Maticsoft.Web.Controls.OffLineCourseInfo1" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<div class="opened3 border3" <%=display %>>
<div class="bg_lt"></div>
<div class="bg_rt"></div>
<div class="content">
<h3>线下已开课程</h3>
<div class="border4">
<div class="bg_lt_post"></div>
<div class="bg_rt_post"></div>
<div class="wsh">
<ul>
<asp:Repeater ID="rpr_offLine" runat="server">
<ItemTemplate>
<li>
<a href="#"><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='images/imgbox.jpg' style=\"width:98-5px;height:63px;overflow:hidden;\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\"width:95px;height:63px;overflow:hidden;\"/>"%> 
<%#SubCourseName(Eval("CourseName"))%></a>
<p><strong>时间：</strong><%#Eval("StartTime")%>|  <strong>地点：</strong><%#Eval("RegionID")%></p>
<p><strong>分类：</strong>全部课程 > 公开课 > 社会科学  |  <strong>已报名：</strong><%#Eval("BookCount")%>|  价格：<%# Eval("CoursePrice").ToString().Equals("0.00") ? "免费" : Eval("CoursePrice", "{0:C}")%></p>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
<div class="pagess">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText=""
        LastPageText="" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
        CssClass="page" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="5"
        OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="3">
    </webdiyer:AspNetPager>
</div>
</div>
<div class="bg_lb_post"></div>
<div class="bg_rb_post"></div>
<div class="clear"></div>
</div>
</div>
<div class="bg_lb"></div>
<div class="bg_rb"></div>
<div class="clear"></div>
</div>