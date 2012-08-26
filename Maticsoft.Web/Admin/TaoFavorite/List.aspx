<%@ Page Title="Tao_Favorite" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoFavorite.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Title -->
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="收藏夹" /></span>
                        </td>
                        <td align="middle">
                            <%--<table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="add.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="list.aspx">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>
                                    </td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--Title end -->
    <!--Add  -->
    <!--Add end -->
    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="left" class="tdbg">
                <b>
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblSearch%>" />：</b>
            </td>
            <td class="tdbg">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>"
                    OnClick="btnSearch_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
            <td class="tdbg">
            </td>
        </tr>
    </table>
    <!--Search end-->
    <br />
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="FavoriteID">
        <Columns>
             <asp:TemplateField ControlStyle-Width="50" HeaderText="课程" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%# GetCourseName(Eval("CourseID"))%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="50" HeaderText="章节" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%# GetModuleName(Eval("ModuleID"))%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="50" HeaderText="用户" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="10%">
                <ItemTemplate>
                    <%# GetUserName(Eval("UserID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="真实姓名" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="UserID" runat="server" Text='<%# GetUserTrueName(Eval("UserID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField ControlStyle-Width="50" HeaderText="关键字" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%# Eval("Tags")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="50" HeaderText="备注" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%# Eval("Remark") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnDetailText %>" ControlStyle-Width="50"
                DataNavigateUrlFields="FavoriteID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                Text="<%$ Resources:Site, btnDetailText %>" ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="50"
                DataNavigateUrlFields="FavoriteID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                Text="<%$ Resources:Site, btnEditText %>" ItemStyle-HorizontalAlign="Center"  Visible="false" />
            <asp:TemplateField ControlStyle-Width="50" HeaderText="<%$ Resources:Site, btnDeleteText %>"
                Visible="false" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle Height="25px" HorizontalAlign="Right" />
        <HeaderStyle Height="25px" />
        <PagerStyle Height="25px" HorizontalAlign="Right" />
        <SortTip AscImg="~/Images/up.JPG" DescImg="~/Images/down.JPG" />
        <RowStyle Height="25px" />
        <SortDirectionStr>DESC</SortDirectionStr>
    </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click"  Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
