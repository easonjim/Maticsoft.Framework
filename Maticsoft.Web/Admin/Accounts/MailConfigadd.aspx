<%@ Page Title="添加配置" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="MailConfigadd.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.MailConfigadd" %>

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
                                <asp:Literal ID="Literal1" runat="server" Text="添加配置" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="MailConfiglist.aspx">
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
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tr>
                                        <td height="25" width="30%" align="right">
                                            Mail address:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtMailaddress" runat="server" Width="400"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            Username:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtUsername" runat="server" Width="400"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            Password:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtPassword" runat="server" Width="400" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                </table>
                
            </td>
        </tr>
        <tr>
            <td class="tdbg">
                
                 <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                <tr>
                                        <td height="25" width="30%" align="right">
                                            SMTP Server:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtSMTPServer" runat="server" Width="400"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            SMTP Port:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtSMTPPort" runat="server" Width="400" Text="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            
                                        </td>
                                        <td height="25" align="left">
                                            <asp:CheckBox ID="chkSMTPSSL" runat="server" Text="Use SSL when sending mail" />
                                        </td>
                                    </tr>
                                </table>
            </td>
        </tr>
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tr>
                                       <td height="25" width="30%" align="right">
                                            POP Server:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtPOPServer" runat="server" Width="400"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            POP Port:
                                        </td>
                                        <td height="25" align="left">
                                            <asp:TextBox ID="txtPOPPort" runat="server" Width="400" Text="110"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right">
                                            
                                        </td>
                                        <td height="25" align="left">
                                            <asp:CheckBox ID="chkPOPSSL" runat="server" Text="Use SSL when retrieving mail" />
                                        </td>
                                    </tr>
                                </table>
                
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" >
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
            </td>
            </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" CausesValidation="false"  Text="<%$ Resources:Site, btnCancleText %>"
                    OnClientClick="javascript:history.go(-1);return false;" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
