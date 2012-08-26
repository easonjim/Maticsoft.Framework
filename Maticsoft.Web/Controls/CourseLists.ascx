<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseLists.ascx.cs" Inherits="Maticsoft.Web.Controls.CourseLists" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<ol>
<asp:Repeater ID="Repeater_List" runat="server" 
    onitemdatabound="Repeater_List_ItemDataBound">
    <ItemTemplate>
            <li id='<%#Eval("CourseID","tr{0}") %>'>
				<span class="colImg"> <a href="../Videoshow.aspx?id=<%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\" height:70px;width:70px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:70px\"/>"%><%--<img src='<%#Eval("ImageUrl") %>'/>--%></a></span>
				<span class="colBText">
                    <h6><a href="../Videoshow.aspx?id=<%# Eval("CourseID") %>" style="color:#004986;"><%#Eval("CourseName")%></a></h6>
				</span>
				<span class="colJs">
					<p>教&nbsp;&nbsp;师</p>
					<a href="TeacherDetailInfo.aspx?uid=<%#Eval("CreatedUserID")%>" ><%#getTeacherCount(Eval("CourseID"), Eval("CreatedUserID"))%>       </a>            
				</span>
				<span class="colTime">
					<p style="padding-left:8px;">时长</p>
					<p><%#ConvertTimme(Eval("TimeDuration")) %>&nbsp;</p>
				</span>
				<span class="colRx">
					<p>共<b style="color:#004986;"><%#Eval("SalesVolume")%></b>人选</p>
				</span>
				<span class="colRx">
					<h6><%# Eval("Price").ToString().Equals("0.00") ? "免费" :Eval("Price", "{0:C}") %></h6>
				</span>
				<span class="colgmBotton"><a href="/shoppingCart.aspx?courseId=<%#Eval("CourseID") %>&mid=0" target="_blank"><img id="Buy" src="../Images/gm.jpg" runat="server"/></a>
                <a href="../Videoshow.aspx?id=<%# Eval("CourseID") %>">
                    <asp:Label ID="labView" runat="server" Text="观看"></asp:Label></a></span>
			</li>
    </ItemTemplate>
</asp:Repeater>	
</ol>
<%--<div class="openPage">--%>
	<span>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10"
            OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
	</span>
<%--</div>--%>

