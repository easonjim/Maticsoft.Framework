<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Maticsoft.Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>淘老师-系统管理</title>
    <script language="javascript" type="text/javascript">
        function ChangeCode() {
            var date = new Date();
            var myImg = document.getElementById("ImageCheck");
            var GUID = document.getElementById("lblGUID");

            if (GUID != null) {
                if (GUID.innerHTML != "" && GUID.innerHTML != null) {
                    myImg.src = "../ValidateCode.aspx?GUID=" + GUID.innerHTML + "&flag=" + date.getMilliseconds()

                }
            }
            return false;
        }
    </script>
    <link href="images/login1/login.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="js/Common.js" charset="gb2312">

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <table width="620" border="0" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td width="620">
                    <img height="11" src="images/login1/login_p_img02.gif" width="650" />
                </td>
            </tr>
            <tr>
                <td align="center" background="images/login1/login_p_img03.gif">
                    <br>
                    <table width="570" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="570" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="245" height="80" align="center" valign="top">
                                                <img height="67" src="images/login1/loginTitle.jpg" width="245">
                                            </td>
                                            <td align="right" valign="top">
                                                <br>
                                                &nbsp;
                                                <img height="9" src="images/login1/point07.gif" width="13" border="0"><a href="#"
                                                    onclick="window.external.addFavorite('http://www.tlaoshi.com/','淘老师')">添加收藏</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/login1/a_te01.gif" width="570" height="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" background="images/login1/a_te02.gif">
                                <table width="520" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="123" height="120">
                                            <img height="95" src="images/login1/login_p_img05.gif" width="123" border="0">
                                        </td>
                                        <td align="center">
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td width="210" height="25" valign="top">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="210">
                                                            <tr>
                                                                <td align="right" width="50">
                                                                    用户名:&nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtUsername" Text="" runat="server" Width="150" BorderStyle="Groove"
                                                                        TabIndex="1">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="80" rowspan="3" align="right" valign="middle">
                                                        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/login1/login_p_img11.gif"
                                                            OnClick="btnLogin_Click"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="bottom" height="12">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="210">
                                                            <tr>
                                                                <td align="right" width="50">
                                                                    密码:&nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPass" TextMode="Password" runat="server" Text="" TabIndex="1"
                                                                        BorderStyle="Groove" Width="150">
                                                                    </asp:TextBox>
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="bottom" height="13">
                                                        <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="70%" align="left">
                                                                    <span style="margin-left: 5px">验证码:</span>&nbsp;<input class="nemo01" id="CheckCode"
                                                                        tabindex="3" maxlength="22" size="8" name="user" runat="server">
                                                                </td>
                                                                <td width="30%" align="left">
                                                                    &nbsp;<asp:Image ID="ImageCheck" runat="server" ImageUrl="../ValidateCode.aspx" ToolTip="">
                                                                    </asp:Image>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#d5d5d5" height="1px">
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <asp:DropDownList ID="dropLanguage" runat="server">
                                    <asp:ListItem Text="简体中文" Value="zh-CN" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="en-US"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="70" align="center">
                                            Copyright(C) 2012 Tlaoshi All Rights Reserved.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img height="11" src="images/login1/login_p_img04.gif" width="650">
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    </form>
</body>
</html>