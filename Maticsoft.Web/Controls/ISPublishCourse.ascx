<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ISPublishCourse.ascx.cs" Inherits="Maticsoft.Web.Controls.ISPublishCourse" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
        <asp:Label ID="ErrorMsg" runat="server" Text='暂时没有课程信息！' ForeColor="Red" Visible="false"></asp:Label>
<ol>
    <asp:Repeater ID="Repeater_View" runat="server" OnItemDataBound="Repeater_View_ItemDataBound">
    <ItemTemplate>
        <li>
			<span class="openImg"><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif'/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:90px;width:70px\"/>"%><%--<img src='<%#Eval("ImageUrl") %>'/>--%></span>
			<span class="openText">
                <h3><a href="#" style="color:#004986;"><%#Eval("CourseName") %></a></h3>
			</span>
			<span class="openBotton">
                    <%--<asp:ImageButton ID="btnContiue" runat="server" ImageUrl="../images/djjx.jpg" DescriptionUrl="#" />--%>
                <asp:Button ID="btnContiue" runat="server" Text="编辑" />
			</span>            
			<span class="openBotton">
                    <asp:Button ID="Button1" runat="server" Text="发布" />
			</span>
		</li>
    </ItemTemplate>
</asp:Repeater>
</ol>
<%--<div class="openPage">--%>
	<span>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="2"
            OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
	</span>
<%--</div>--%>

