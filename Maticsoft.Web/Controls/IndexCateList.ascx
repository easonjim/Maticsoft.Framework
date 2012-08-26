<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexCateList.ascx.cs" Inherits="Maticsoft.Web.Controls.IndexCateList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<div class="slideUL">
	<ol>
        <asp:Repeater ID="Repeater_Last" runat="server">
            <ItemTemplate>
                <li style="width: 171px; float: left; margin-left: 10px; margin-bottom: 10px;"><a
                    href="/Videoshow.aspx?id=<%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'>
                    <%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='images/imgbox.jpg' style=\"width:160px;height:120px;overflow:hidden;\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\"width:160px;height:120px;overflow:hidden;\"/>"%>
                </a><span><a href="/Videoshow.aspx?id=<%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'>
                    <h3 style="margin-top: 5px; color: #004986;">
                        <%#SubCourseName(Eval("CourseName"))%></h3>
                </a>
                        <p class="xr" title="发布者">
                            老师:<%#Eval("TrueName")%></p>
                    <%# string.IsNullOrEmpty(Eval("Name").ToString()) ? "" : "<h3 style=\"clear: both;font-weight:normal;\">机构名称: " + Eval("Name").ToString() + "</h3>"%>
                    <h3 style="clear: both;font-weight:normal;"><%--color: #004986;--%>
                        价格：<%# Eval("Price").ToString().Equals("0.00") ? "免费" :Eval("Price", "{0:C}") %></h3>
                    <p>
                        <p class="cl" title="时长">
                            时长:<%#ConvertTimme(Eval("TimeDuration"))%></p>
                        <p class="cr" title="浏览量">
                            人气:<%#Eval("PV") %></p>
                    </p>
                </span></li>
            </ItemTemplate>
        </asp:Repeater>
	</ol>
</div>
<span >
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
        LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
        CssClass="page" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="3"
        OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="3">
    </webdiyer:AspNetPager>
</span>