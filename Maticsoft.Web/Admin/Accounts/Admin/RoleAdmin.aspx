<%@ Page Title="<%$ Resources:Site, ptRoleAdmin%>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master" AutoEventWireup="true"
    CodeBehind="RoleAdmin.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.RoleAdmin" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptRoleAdmin%>" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <b><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblAddRole%>" />：</b>
    <asp:TextBox ID="txtRoleName" runat="server" class="inputtext" 
        meta:resourcekey="txtRoleNameResource1"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
        onmouseout="this.className='inputbutton'" OnClick="btnSave_Click" 
        meta:resourcekey="btnSaveResource1" />
    <asp:Label ID="lblToolTip" runat="server" 
        meta:resourcekey="lblToolTipResource1"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    
    <center>
        <asp:DataList ID="RoleList" runat="server" RepeatColumns="3" CellPadding="4" 
            Width="90%" ItemStyle-HorizontalAlign="Left"  
            meta:resourcekey="RoleListResource1" >
            <ItemTemplate   >
                [<a href='EditRoleC.aspx?RoleID=<%# DataBinder.Eval(Container.DataItem, "RoleID") %>'><%# DataBinder.Eval(Container.DataItem, "Description") %></a>]<br />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:DataList></center>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
