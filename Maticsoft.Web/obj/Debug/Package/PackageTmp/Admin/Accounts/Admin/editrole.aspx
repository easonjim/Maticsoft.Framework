﻿<%@ Page Title="<%$ Resources:Site, ptEditRole %>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master" AutoEventWireup="true"
    CodeBehind="editrole.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.editrole" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />    
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, ptEditRole%>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
    <a href="EditRoleC.aspx?RoleID=<%=RoleID%>">风格二</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Site, lblNewRoleName %>" />:
    <asp:TextBox ID="TxtNewname" runat="server" Width="120px"></asp:TextBox>&nbsp;
    <asp:Button ID="BtnUpName" runat="server" Text="<%$ Resources:Site, btnUpdateText %>" OnClick="BtnUpName_Click"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" />
    &nbsp;&nbsp;&nbsp;<asp:Button ID="RemoveRoleButton" runat="server" Text="<%$ Resources:Site, btnDeleteText %>"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="RemoveRoleButton_Click"></asp:Button>
    <asp:Label ID="lblTiptool" runat="server" Text=""></asp:Label>&nbsp;&nbsp;   
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Site, btnBackText %>"  OnClientClick="javascript:history.go(-1);return false;" 
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" />    
<asp:Label ID="lblRoleID" runat="server" Text="" Visible="false"></asp:Label>
        
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <table cellpadding="3" cellspacing="0" border="0" width="100%">
        <tr >
            <td align="center" height="25" >
                <b><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, lblRole%>" />: 
                    <asp:Label ID="RoleLabel" runat="server"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td height="30" valign="middle" >
                <b>
                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, lblCategory%>" />
                </b>:
                <asp:DropDownList ID="CategoryDownList" runat="server"
                    AutoPostBack="True" Width="245px" BackColor="GhostWhite" OnSelectedIndexChanged="CategoryDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td height="22" >
                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                    <tr>
                        <td valign="top" align="center" width="43%">
                            <asp:ListBox ID="CategoryList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue">
                            </asp:ListBox>
                        </td>
                        <td align="center" valign="middle" width="14%">
                            <p>
                                <asp:Button ID="AddPermissionButton" runat="server" Text="<%$ Resources:Site, btnAddPermissionText %>" class="inputbutton"
                                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                                    Width="130" OnClick="AddPermissionButton_Click"></asp:Button></p>
                            <p>
                                <asp:Button ID="RemovePermissionButton" runat="server" Text="<%$ Resources:Site, btnRemovePermissionText %>"
                                    Width="130" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                                    onmouseout="this.className='inputbutton'" OnClick="RemovePermissionButton_Click">
                                </asp:Button></p>
                        </td>
                        <td valign="top" align="center" width="43%">
                            <asp:ListBox ID="PermissionList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue">
                            </asp:ListBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
