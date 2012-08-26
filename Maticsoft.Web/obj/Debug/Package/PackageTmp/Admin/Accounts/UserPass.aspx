<%@ Page Title="<%$ Resources:Site, ptUserInfo%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="UserPass.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.UserPass" %>
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
                                    <%--<td width="80">
                                        <a href="adduser.aspx">
                                            <img title="添加" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                                <a href="temp.htm">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>
                                            </td>
                                    <td width="100">
                                        <a href="useradmin.aspx">
                                            <img title="显示" src="/admin/images/view.gif" border="0" alt="" /></a>--%>
                                    </td>
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
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Site, fieldOldPassword%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtOldPassword" TabIndex="2" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>                
                   <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, fieldPassword%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtPassword" TabIndex="2" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
					ErrorMessage="请输入密码" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Site, fieldConfirmationPassword%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtPassword1" TabIndex="3" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove" TextMode="Password"></asp:TextBox>
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
