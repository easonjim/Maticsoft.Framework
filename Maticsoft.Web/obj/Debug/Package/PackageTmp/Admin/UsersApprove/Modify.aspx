<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="Maticsoft.Web.Tao.UsersApprove.Modify"
    Title="修改页" %>

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
                                <asp:Literal ID="Literal1" runat="server" Text="认证修改" /></span>
                        </td>
                        <td align="left">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="add.aspx">
                                            <img title="添加" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <%--<td width="100">
                                                <a href="temp.htm">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>
                                            </td>--%>
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
                            <asp:DropDownList ID="ddlUserID" runat="server" Width="203px">
                            </asp:DropDownList>
                            <asp:Label ID="lblUserID" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            认证资料类型 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddlApproveType" runat="server" Width="203px">
                            </asp:DropDownList>
                            <asp:Label ID="lblApproveType" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            认证资料 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:FileUpload ID="fileImgURL" runat="server" />
                            <%=strImgUrlLogo%>
                            <asp:HiddenField ID="hfImgUrlLogo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            审核状态 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="203px">
                                <asp:ListItem Value="-1">请选择</asp:ListItem>
                                <asp:ListItem Value="0">未审核</asp:ListItem>
                                <asp:ListItem Value="1">审核通过</asp:ListItem>
                                <asp:ListItem Value="2">认证失败</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <script src="/js/calendar1.js" type="text/javascript"></script>
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    ValidationGroup="A"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>