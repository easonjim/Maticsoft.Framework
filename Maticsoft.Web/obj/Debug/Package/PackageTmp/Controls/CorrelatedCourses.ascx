<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CorrelatedCourses.ascx.cs" Inherits="Maticsoft.Web.Controls.CorrelatedCourses" %>
<asp:DataList ID="DataList_RecommendedList" runat="Server" DataKeyField="CourseID" Width="98%">
    <HeaderTemplate>
        <center><h4>相关课程推荐</h4></center>
    </HeaderTemplate>
    <ItemTemplate>
        <table style="width:98%; text-align:center" >
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" Width="80px" Height="80px" ImageUrl='<%# Eval("ImageUrl") %>' DescriptionUrl='~/Admin/CourseDetail.aspx?CourseID=<%# Eval("CourseID") %>&ModuleID=<%# Eval("ModuleID") %>'/>
                </td>
            </tr>
            <tr>
                <td>
                    <stong><asp:Label ID="lblCourseName" runat="Server" Text='<%# Eval("CourseName") %>'></asp:Label></stong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDepartmentID" runat="Server" Text='<%# Eval("EnterpriseName") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="Server" Text='<%# Eval("UserName") %>'></asp:Label>  
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>