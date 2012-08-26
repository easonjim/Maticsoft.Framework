<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoComment.Show" Title="显示页" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="评论信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left"  id="table3">
                                <tr valign="top" align="middle">
                                            <%--<td width="100">
                                                <a href="delete.aspx?id=<%=id%>"></a>
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/>--%>
                                            </td>
                                             <td width="100">
                                                <a href="list.aspx">
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
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		评论编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCommentID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评论课程
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCourseName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		所属节次
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblModuleName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评论人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评论内容
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblComment" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		评论时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCommentDate" runat="server"></asp:Label>
	</td></tr>
    	<tr style="display:none">
	<td height="25" width="30%" align="right">
		状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr style="display:none">
	<td height="25" width="30%" align="right">
		评论分值
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScore" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>




