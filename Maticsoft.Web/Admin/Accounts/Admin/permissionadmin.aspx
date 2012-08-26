﻿<%@ Page Title="<%$ Resources:Site, ptPermissionAdmin%>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master"
    AutoEventWireup="true" CodeBehind="permissionadmin.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.permissionadmin" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, ptPermissionAdmin%>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
    <tr>
    <td align="right"> 增加权限类别: </td>
    <td align="left"> <asp:TextBox ID="CategoriesName" runat="server" Width="156"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSaveCategories" runat="server" Text="<%$ Resources:Site, btnSaveText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
        onmouseout="this.className='inputbutton'" OnClick="btnSaveCategories_Click" />
    <asp:Label ID="lbltip1" runat="server" ForeColor="Red"></asp:Label> </td>
    </tr>
    <tr>
    <td align="right"> 选择权限类别:</td>
    <td align="left"> <asp:DropDownList ID="ClassList" runat="server" Width="156px" AutoPostBack="True"
        OnSelectedIndexChanged="ClassList_SelectedIndexChanged">
    </asp:DropDownList> </td>
    </tr>
    <tr>
    <td align="right"> 增加权限数据:</td>
    <td align="left"><asp:TextBox ID="PermissionsName" runat="server" Width="156"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSavePermissions" runat="server" Text="<%$ Resources:Site, btnSaveText %>" class="inputbutton"
        onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="btnSavePermissions_Click" />
    <asp:Label ID="lbltip2" runat="server" ForeColor="Red"></asp:Label>  </td>
    </tr>
    </table>   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="False" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowCancelingEdit="gridView_RowCancelingEdit"
        OnRowEditing="gridView_RowEditing" OnRowUpdating="gridView_RowUpdating" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" DataKeyNames="PermissionID" ShowExportExcel="false" ShowCheckAll="true"
        ShowExportWord="False" ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="PermissionID" HeaderText="PermissionID" ReadOnly="true"
                SortExpression="PermissionID"  ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"/>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TBDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:Site, lblOperation %>" ShowHeader="False" ControlStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="<%$ Resources:Site, btnUpdateText %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="<%$ Resources:Site, btnCancleText %>"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="<%$ Resources:Site, btnEditText %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                        Visible="false" Text="<%$ Resources:Site, btnDeleteText  %>"></asp:LinkButton>
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
                    <asp:Button ID="btnMoveTo" runat="server" Text="<%$ Resources:Site, btnMoveToText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnMoveTo_Click"/>
                     <asp:DropDownList ID="droplistCategories" runat="server" Width="200px">                        
                    </asp:DropDownList>
                       
                    </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
