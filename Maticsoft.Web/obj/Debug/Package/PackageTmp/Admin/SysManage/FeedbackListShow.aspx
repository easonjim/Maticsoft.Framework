<%@ Page Title="显示页" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="FeedbackListShow.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.FeedbackListShow" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="客户反馈信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left"  id="table3">
                                <tr valign="top" align="middle">
                                   
                                    <td width="100">
                                                &nbsp;<a href="FeedbackList.aspx"><img title="显示" src="/admin/images/view.gif" border="0" alt=""/></a></td>
                                            <td width="100">
                                            </td>
                                             <td width="100">
                                                &nbsp;</td>      
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
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_iID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_cUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_cPhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		公司
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_cCompany" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		邮箱
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_cMail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		反馈内容
	：</td>
	<td height="25" width="*" align="left">
            	<asp:Label id="lbltxtFeedback_cContent" runat="server" Width="350px"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		提交时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_dateCreate" runat="server"></asp:Label>
	</td></tr>
    <tr>
    <td height="25" width="30%" align="right">
		IP ：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedback_cUserIP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否已经解决
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label ID="lblFeedback_bSolved" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		解决结果
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtFeedback_cResult" runat="server" Height="176px" 
            TextMode="MultiLine" Width="255px"></asp:TextBox>
        <asp:Label ID="lblFeedback_cResult" runat="server" Width="350px"></asp:Label>
	</td></tr>
	
</table>

                    </td>
                </tr>
                  <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSolve" runat="server" Text="解决" onclick="btnSolve_Click" 
                    Width="57px" />
                    </td>
                    </tr>
            </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
