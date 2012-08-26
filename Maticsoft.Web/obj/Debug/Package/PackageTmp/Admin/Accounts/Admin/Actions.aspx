<%@ Page Title="<%$ Resources:Site, ptActions %>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master"
    AutoEventWireup="true" CodeBehind="Actions.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.Actions" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptActions%>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <b>
        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblAdd%>" />:</b>
    <asp:TextBox ID="txtDescription" runat="server" class="inputtext"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="DropListCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropListCategory_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:DropDownList ID="DropListPermissions" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="btnSave_Click" />
    <asp:Label ID="lblToolTip" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <b>
        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, lblSearch%>" />:</b>
    <asp:TextBox ID="txtKeywords" runat="server" class="inputtext"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="btnSearch_Click" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowCancelingEdit="gridView_RowCancelingEdit"
         OnRowDeleting="gridView_RowDeleting" OnRowEditing="gridView_RowEditing" OnRowUpdating="gridView_RowUpdating"
        UnExportedColumnNames="Modify" Width="100%" PageSize="10" DataKeyNames="ActionID"
        ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1" CellPadding="0"
        ShowCheckAll="true" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="ActionID" HeaderText="行为编号" ReadOnly="true" SortExpression="ActionID"
                ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:TextBox ID="TBDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PermissionID" HeaderText="(权限ID)权限名称" ReadOnly="true"
                SortExpression="PermissionID" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="<%$ Resources:Site, lblOperation %>" ShowHeader="False"
                ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="<%$ Resources:Site, btnUpdateText %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="<%$ Resources:Site, btnCancleText  %>"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="<%$ Resources:Site, btnEditText  %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                        CommandArgument='<%# Eval("ActionID")%>' OnClientClick='return confirm("你确认要删除这条记录吗?")'
                        Text="<%$ Resources:Site, btnDeleteText%>"></asp:LinkButton>
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
                <asp:Button ID="btnSetup" runat="server" Text="<%$ Resources:SysManage, btnSetupPerm %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnSetup_Click" />
                <asp:DropDownList ID="DropListCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropListCategory2_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="DropListPermissions2" runat="server">
                </asp:DropDownList>
                <asp:Label ID="lblToolTip2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
