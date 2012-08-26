<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Tao.UsersApprove.Show" Title="显示页" %>

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
                                <asp:Literal ID="Literal1" runat="server" Text="认证信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="middle">
                                    <td width="100">
                                        <a href="modify.aspx?id=<%=strid%>">
                                            <img title="编辑" src="/admin/images/edit.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="list.aspx">
                                            <img title="显示" src="/admin/images/view.gif" border="0" alt="" /></a>
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
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            编号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            用户名 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            认证资料类型 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblApproveType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            认证资料 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Image ID="imgUrl" runat="server" Width="45" Height="45" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            申请时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            审核状态 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            审核时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblApprovedTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            审核人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblApprovedUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>