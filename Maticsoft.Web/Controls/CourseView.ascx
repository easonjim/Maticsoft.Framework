<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseView.ascx.cs" Inherits="Maticsoft.Web.Controls.CourseView" %>
<ul>
<asp:Repeater ID="Repeater_CourseView" runat="server">
    <ItemTemplate>
        <li>
			<span><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif'/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:70px\"/>"%></span>
			<span class="teaBText">
			<h4><a href="../Videoshow.aspx?id=<%#Eval("CourseID") %>" style="color:#004986;margin-left:8px;">
            <%#HttpUtility.HtmlEncode(Eval("CourseName").ToString()) %>
            </a></h4>
			</span>
		</li>
    </ItemTemplate>
</asp:Repeater>
</ul>
<%=isMore%>


