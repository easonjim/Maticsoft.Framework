<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="returnpay.aspx.cs" Inherits="Maticsoft.Web.Pay.returnpay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function countDown(secs, surl) {
            tiao.innerText = secs; 
            if (--secs > 0) {
                setTimeout("countDown(" + secs + ",'" + surl + "')", 1000); //设定超时时间
            }
            else {
                location.href = surl; //跳转页面
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <span id="tiao">30</span>秒后将自动跳转到网站首页
    </div>
    </form>
</body>
</html>
