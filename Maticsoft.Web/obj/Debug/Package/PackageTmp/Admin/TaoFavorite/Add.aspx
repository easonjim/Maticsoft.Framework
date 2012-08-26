<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoFavorite.Add" Title="增加页" %>
<%@ Register src="~/Controls/UCDroplistPermission.ascx" tagname="UCDroplistPermission" tagprefix="uc2" %>
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
                                        <asp:Literal ID="Literal1" runat="server" Text="增加Tao_Favorite" /></span>
                                </td>
                                <td align="middle">
                                    <table align="left" id="table3">
                                        <tr valign="top" align="left">
                                            <td width="80">
                                                <a href="list.aspx">
                                                    <img title="" src="/admin/images/view.gif" border="0" alt=""/></a>
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
		课程
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCourseID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		节次
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtModuleID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		关键字
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTags" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

                    </td>                    
                </tr>
                <tr>
                 <td class="tdbg" align="center" valign=bottom>
                 <asp:button id="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>" onclick="btnSave_Click"
                 class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" 
                 ></asp:button>
                 <asp:button id="btnCancle" runat="server" Text="<%$ Resources:Site, btnCancleText %>" onclick="btnCancle_Click"
                 class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" 
                 ></asp:button>
											
                 
                 </td>
                </tr>
            </table>
            <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>

