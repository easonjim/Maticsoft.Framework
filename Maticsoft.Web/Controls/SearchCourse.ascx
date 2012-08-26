<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchCourse.ascx.cs" Inherits="Maticsoft.Web.Controls.SearchCourse" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Repeater ID="DataList_Course" runat="Server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>                    
        <li>
            <asp:Image ID="imgCourse" runat="Server" Width="80px" Height="80px" ImageUrl='<%# Eval("ImageUrl") %>' DescriptionUrl='~/Admin/CourseDetail.aspx?CourseID=<%# Eval("CourseID") %>&ModuleID=<%# Eval("ModuleID") %>'/>                                     
        </li>
        <li>
            <asp:HyperLink ID="CourseName" runat="Server" Text='<%#Eval("CourseName") %>' NavigateUrl='<%# "~/Admin/CourseDetail.aspx?CourseID=" + Eval("CourseID") + "&ModuleID=" +  Eval("ModuleID")%>'></asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<webdiyer:AspNetPager ID="AspNetPager1" HorizontalAlign="Center"  runat="server" CssClass="pages" CurrentPageButtonClass="cpb" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="末页" 
     SubmitButtonText="确定" ShowMoreButtons="true" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" TextAfterPageIndexBox="页" PageSize="24"
     TextBeforePageIndexBox="转到" ></webdiyer:AspNetPager>