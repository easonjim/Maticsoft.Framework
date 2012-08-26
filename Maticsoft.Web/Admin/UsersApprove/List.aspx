<%@ Page Title="Accounts_UsersApprove" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Tao.UsersApprove.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="认证信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
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
                            </table>
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
            <td style="width: 80px" align="right" class="tdbg">
                <b>关键字：</b>
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
        Width="100%" PageSize="10" ShowExportExcel="False" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="用户名" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#GetUserName(Eval("UserID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户真实姓名" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#GetUserTrueName(Eval("UserID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="认证资料类型名称" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%# GetApproveName(Eval("ApproveType")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="认证资料" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%# GetImage(Eval("ImgURL"), 45, 45)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreatedDate" HeaderText="申请时间" SortExpression="CreatedDate"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="审核状态" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%# GetStatus(Eval("Status"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ApprovedTime" HeaderText="审核时间" SortExpression="ApprovedTime"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="审核人" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%# GetUserName(Eval("ApprovedUserID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkLook" runat="server" Text="详细"
                        NavigateUrl='<%#Eval("ID","Show.aspx?id={0}")%>' Visible="false"></asp:HyperLink>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkEdit" runat="server" Text="编辑"
                        NavigateUrl='<%#Eval("ID","Modify.aspx?id={0}")%>'></asp:HyperLink>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td align="left">
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click" />
                <asp:Button ID="btnApproveList" runat="server" Text="<%$ Resources:Site, btnApproveListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnApproveList_Click" />
                <asp:Button ID="btnInverseApprove" runat="server" Text="批量未审核" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnInverseApprove_Click" />
                <asp:Button ID="btnUpdateState" runat="server" Text="批量认证失败" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnUpdateState_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>