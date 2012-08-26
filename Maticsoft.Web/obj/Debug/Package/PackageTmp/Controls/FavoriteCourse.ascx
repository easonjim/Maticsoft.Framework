<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavoriteCourse.ascx.cs"  Inherits="Maticsoft.Web.Controls.FavoriteCourse"  %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<ul>		
<asp:Repeater ID="Repeater_Fav" runat="server" 
    onitemdatabound="Repeater_Fav_ItemDataBound" 
        onitemcommand="Repeater_Fav_ItemCommand">
    <ItemTemplate>
            <li><span style="width:119px;">
                <%# Eval("Price").ToString().Equals("0.00") ? "<a href=\"../show.aspx?cid=" + Eval("CourseID") + "\" style='font-size:12px;background:none;padding-left:0px;font-weight:normal'>观看</a>" : "<a href=\"../shoppingCart.aspx?courseId=" + Eval("CourseID") + "&mid=0\"  target=\"_blank\"><img src=\"../imagesN/TLaoShi_bt020.gif\"/></a>"%><br /><br /> <asp:Label ID="labCid" runat="server" Text='<%#Eval("FavoriteID") %>' Visible="false"></asp:Label>
                <asp:Button ID="btnCancle" runat="server" class="button21"  CommandArgument="Fav"/></span><a href="../show.aspx?cid=<%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif'  style=\" height:63px;width:95px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:63px;width:95px\"/>"%><%#Eval("CourseName")%></a>
<p><strong>时间：</strong><%#ConvertTimme(Eval("TimeDuration")) %>  |  <strong>教师：</strong><%#getTeacherCount(Eval("CourseID"), Eval("CreatedUserID"))%>(共<%#getTeacherCount(Eval("CourseID"))%>人）           |  <strong>已选/关注：</strong><%#GetBuyNums(Eval("CourseID"))%>/<%#Eval("SalesVolume")%> </p>
<p><strong>分类：</strong><%#NavInfo(Eval("CategoryId"))%> |  <strong>价格：</strong><%# Eval("Price").ToString().Equals("0.00") ? "免费" :Eval("Price", "{0:C}") %></p></li>
    </ItemTemplate>
</asp:Repeater>	
</ul>
	<div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10"
            OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
	</div>
	
