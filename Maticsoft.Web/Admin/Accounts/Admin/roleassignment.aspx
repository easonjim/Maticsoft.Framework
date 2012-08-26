<%@ Page Title="<%$ Resources:Site, ptRoleAssignment%>" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="roleassignment.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.roleassignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptRoleAssignment%>" />
                            </span>
                        </td>
                        <td align="middle">
                            <table align="center" id="table3">
                                <tr valign="top" align="middle">
                                    <td width="80">
                                        <a href="useradmin.aspx">
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
    <br />
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="5" width="100%" border="0" class="tdbg">
                    <tr>
                        <td align="left" height="25">
                             <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:SysManage, TooltipRoleAssignForuser%>" />
                            <asp:Label ID="lblUserID"  runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="22">
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3" Width="100%">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                                class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                                OnClick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCancle" runat="server" CausesValidation="false"  Text="<%$ Resources:Site, btnCancleText %>"
                    OnClientClick="javascript:history.go(-1);return false;" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
