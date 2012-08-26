<%@ Page Language="c#" CodeBehind="search.aspx.cs" AutoEventWireup="True" Inherits="Maticsoft.Web.SysManage.search" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CopyRight" Src="~/Controls/copyright.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>search</title>
    <link href="../../style.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td height="22">
                <div align="right">
                    [ <a href="treelist.aspx">返回</a> ]
                </div>
            </td>
        </tr>
    </table>
    <table width="600" border="0" align="center" cellpadding="5" cellspacing="0">
        <tr>
            <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                <table width="100%" border="1" cellpadding="5" cellspacing="0" bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'
                    bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'>
                    <tr bgcolor="#e4e4e4">
                        <td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'>
                            信息检索，您可以有选择的选取相应条件进行检索，不填写表示不加以限制。
                        </td>
                    </tr>
                    <tr>
                        <td height="22">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="150" height="22">
                                        <div align="right">
                                            <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                            编号：</div>
                                    </td>
                                    <td height="22" align="left">
                                        <asp:TextBox ID="txtID" runat="server" Width="200px" ToolTip="菜单编号"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150" height="22">
                                        <div align="right">
                                            <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                            名称：</div>
                                    </td>
                                    <td height="22" align="left">
                                        <asp:TextBox ID="txtName" runat="server" Width="200px" ToolTip="菜单名称关键字"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150" height="15" style="height: 15px">
                                        <div align="right">
                                            <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                            父类：</div>
                                    </td>
                                   <td height="22" align="left">
                                        <asp:DropDownList ID="listTarget" runat="server" Width="200px">
                                            <asp:ListItem Value="0" Selected="True">根目录</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150" height="22">
                                        <div align="right">
                                            权限：</div>
                                    </td>
                                    <td height="22" align="left">
                                        <asp:DropDownList ID="listPermission" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150" height="22">
                                        <div align="right">
                                            说明：</div>
                                    </td>
                                    <td height="22" align="left">
                                        <asp:TextBox ID="txtDescription" runat="server" Width="300px" ToolTip="菜单说明的关键字"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="22">
                            <div align="center">
                                &nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="· 查询 ·" OnClick="btnSearch_Click">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click">
                                </asp:Button>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc1:CopyRight ID="CopyRight1" runat="server"></uc1:CopyRight>
    <uc1:CheckRight ID="CheckRight1" runat="server"></uc1:CheckRight>
    </form>
</body>
</html>
