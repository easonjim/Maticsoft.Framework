<%@ Page Title="<%$ Resources:SysManage, ptMenuShow%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.show" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:SysManage, ptMenuShow%>" /></span>
                        </td>
                        
                        
                        <td align="middle">

                            <table align="center" id="table3">
                                <tr valign="top" align="middle">
                                   
                                    <td width="100">
                                                <a href="modify.aspx?id=<%=id%>">
                                                    <img title="编辑" src="/admin/images/edit.gif" border="0" alt=""/></a>
                                            </td>
                                            <td width="100">
                                            </td>
                                             <td width="100">
                                                <a href="treelist.aspx">
                                                    <img title="显示" src="/admin/images/view.gif" border="0" alt=""/></a>
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
                                        <td align="right" height="25">
                                                ID:
                                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblID" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="25">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:SysManage, fieldNodeName%>" />:
                                        </td>
                                       <td height="22" align="left">
                                            <asp:Label ID="lblName" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="25">
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:SysManage, fieldParent%>" />:
                                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblTarget" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td align="right" height="25">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:SysManage, fieldOrder%>" />:
                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblOrderid" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                       <td align="right" height="25">
                            LinkUrl:
                        </td>
                                       <td height="22" align="left">
                                            <asp:Label ID="lblUrl" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="25">
                            ICO(16x16):
                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblImgUrl" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                       <td align="right" height="25">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:SysManage, fieldPermission%>" />:
                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblPermission" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="25">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:SysManage, fieldDescription%>" />:
                        </td>
                                        <td height="22" align="left">
                                            <asp:Label ID="lblDescription" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                             </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
