<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.images.t" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名:<asp:textbox id="txtUserName" runat="server"></asp:textbox>
    密码:<asp:textbox id="txtPassword" runat="server" TextMode="Password"></asp:textbox>
    确认:<asp:textbox id="txtPassword1" runat="server" TextMode="Password"></asp:textbox>
    <asp:label id="lblMsg" runat="server"></asp:label>
    </div>
    <div align="center"><asp:button id="btnUpdate" runat="server" Text="· 提交 ·" onclick="btnUpdate_Click"></asp:button>
									</div>
    </form>
</body>
</html>
