<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoCategories.Show" Title="显示页" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="类别信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left"  id="table3">
                                <tr valign="top" align="middle">
                                   
                                    <td width="100">
                                                <a href="modify.aspx?CategoryId=<%=strid%>">
                                                    <img title="编辑" src="/admin/images/edit.gif" border="0" alt=""/></a>
                                            </td>
                                           <%-- <td width="100">
                                                <a href="delete.aspx?id=<%=strid%>">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>
                                            </td>--%>
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
		类别编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCategoryId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		类别名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		顺序
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSequence" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		父类别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParentCategoryId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		层级
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDepth" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		类别路径
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPath" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		类别描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		类别图片
	：</td>
	<td height="25" width="*" align="left">
       <%= strIconUrl%>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right" style="display:none">
		状态
	：</td>
	<td height="25" width="*" align="left" style="display:none">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreatedDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建者
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreatedUserID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		重写名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRewriteName" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>




