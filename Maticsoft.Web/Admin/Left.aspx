<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Maticsoft.Web.Admin.Left" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" type="text/css" rel="stylesheet">
</head>
<body bgcolor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>' text="#000000"
    leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <form id="Form1" method="post" runat="server">
    <table width="204" style="height:100%;" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="27">
                <img src='<%=Application[Session["Style"].ToString()+"xleft1_bgimage"]%>' width="200"
                    height="27">
            </td>
            <td rowspan="3" bgcolor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>'>
            </td>
        </tr>
        <tr>
            <td style="height:100%;" valign="top" background='<%=Application[Session["Style"].ToString()+"xleftbj_bgimage"]%>'>
                <div align="left">
                    <font color="#314a72">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= strWelcome %></font></div>
                <br />
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="true" ShowExpandCollapse="true"  
                    >
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td height="19">
                <img src='<%=Application[Session["Style"].ToString()+"xleft2_bgimage"]%>' width="200"
                    height="19">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
