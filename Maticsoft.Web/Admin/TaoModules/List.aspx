<%@ Page Title="章节表" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.TaoModules.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Title -->
    <!--Title end -->
    <!--Add  -->
    <!--Add end -->
    <!--Search -->
    <!--Search end-->
    <br />
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="ModuleID">
        <Columns>
            <asp:BoundField DataField="ModuleName" HeaderText="章节名称" SortExpression="ModuleName"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Description" HeaderText="章节描述" SortExpression="Description"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="TimeDuration" HeaderText="章节时长" SortExpression="TimeDuration"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="状态" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#GetCourseStatus(Eval("Status"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Tags" HeaderText="关键字" SortExpression="Tags" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="视频截图" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%# GetImage(Eval("ImageUrl"),45,45)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="视频类型" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#GetTypeName(Eval("Type"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="VideoContent" HeaderText="视频" SortExpression="VideoContent"
                Visible="false" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="CreatedDate" HeaderText="创建时间" SortExpression="CreatedDate"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="创建者" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#GetUserName(Eval("CreatedUserID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="PV" HeaderText="浏览量" SortExpression="PV" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Sequence" HeaderText="顺序" SortExpression="Sequence" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Attachment" HeaderText="附件" SortExpression="Attachment"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="UpdatedDate" HeaderText="更新时间" SortExpression="UpdatedDate"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
        </Columns>
    </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                    <asp:ListItem Value="0">未完成</asp:ListItem>
                    <asp:ListItem Value="1">完成待审核</asp:ListItem>
                    <asp:ListItem Value="2">审核通过</asp:ListItem>
                    <asp:ListItem Value="3">审核并发布上架</asp:ListItem>
                    <asp:ListItem Value="4">审核未通过</asp:ListItem>
                    <asp:ListItem Value="5">下架</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnUpdate" runat="server" Text="批量处理" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>