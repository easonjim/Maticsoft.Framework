<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesList.ascx.cs" Inherits="Maticsoft.Web.Controls.CoursesList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:DataList ID="DataList_Course" runat="Server" ForeColor="#333333" 
    onitemdatabound="DataList_Course_ItemDataBound" >
    <HeaderTemplate>
        <tr>
    </HeaderTemplate>
    <ItemTemplate>                    
        <td style="width:80px">      
            <asp:Image ID="imgCourse" runat="Server" Width="80px" Height="80px" ImageUrl='<%# Eval("ImageUrl") %>' DescriptionUrl='~/Admin/CourseDetail.aspx?CourseID=<%# Eval("CourseID") %>&ModuleID=<%# Eval("ModuleID") %>'/>                                     
        </td>
        <td>
            <asp:HyperLink ID="CourseName" runat="Server" Text='<%#Eval("CourseName") %>' NavigateUrl='<%# "~/Admin/CourseDetail.aspx?CourseID=" + Eval("CourseID") + "&ModuleID=" +  Eval("ModuleID")%>'></asp:HyperLink>
        </td>            
    </ItemTemplate>
    <FooterTemplate>
        </tr>
    </FooterTemplate>
</asp:DataList>
<webdiyer:AspNetPager ID="AspNetPager1" HorizontalAlign="Center"  runat="server" CssClass="pages" CurrentPageButtonClass="cpb" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="末页" 
     SubmitButtonText="确定" ShowMoreButtons="true" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" TextAfterPageIndexBox="页" PageSize="2"
     TextBeforePageIndexBox="转到" ></webdiyer:AspNetPager>