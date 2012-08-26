<%@ Page Title="<%$ Resources:Site, ptUserInfo%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="UserModify.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.UserModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptUserUpdate%>" /></span>
                        </td>
                        <td align="left">
                            <table align="center" id="table3">
                                <tr valign="top" align="left">                                   
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, fieldUserName%>" />:
                        </td>
                        <td height="25">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Site, fieldTrueName%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtTrueName" TabIndex="4" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Not Null"
                                Display="Dynamic" ControlToValidate="txtTrueName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                   
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Site, fieldEmail%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>                   
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>               
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
