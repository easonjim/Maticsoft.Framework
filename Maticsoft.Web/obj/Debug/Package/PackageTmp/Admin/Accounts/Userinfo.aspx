<%@ Page Title="<%$ Resources:Site, ptUserInfo%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="Userinfo.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Userinfo" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptUserInfo%>" /></span>
                        </td>
                        <td align="left">
                            <table align="center" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="UserModify.aspx">
                                            <img title="" src="/admin/images/edit.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                                <%--<a href="temp.htm">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>--%>
                                            </td>
                                    <td width="100">
                                       <%-- <a href="useradmin.aspx">
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
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Site, fieldTrueName%>" />:
                        </td>
                        <td height="25">
                            <asp:Label id="lblTruename" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:Site, fieldSex%>" />:
                        </td>
                        <td height="25">
                           <asp:Label id="lblSex" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:Site, fieldTelphone%>" />:
                        </td>
                        <td style="height: 3px" height="3">
                            <asp:Label id="lblPhone" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Site, fieldEmail%>" />:
                        </td>
                        <td height="25">
                           <asp:Label id="lblEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            UserIP:
                        </td>
                        <td height="25">
                            <asp:Label id="lblUserIP" runat="server"></asp:Label>
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
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
