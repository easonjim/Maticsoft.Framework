<%@ Page Title="清除缓存" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="ClearCache.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.ClearCache" %>
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
                                        清除缓存</span>
                                </td>
                                <td align="middle">
                                   
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                        <b>清除缓存：</b>
                    </td>
                    <td class="tdbg" align="left">                    
                    <asp:Button ID="btnClear" runat="server" Text="清除缓存" OnClick="btnClear_Click"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" />                        
                    </td>                    
                </tr>
                 <tr>
                  <td style="width: 80px" align="right" class="tdbg">
                        
                    </td>
                    <td style="text-align:left; padding-left:20px" class="tdbg">
                <asp:Label ID="Label1" runat="server" ForeColor="Green"></asp:Label>
                </td>
                </tr>
            </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
