<%@ Page Title="<%$ Resources:SysManage, ptMenuAdd%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.add" %>
<%@ Register src="~/Controls/UCDroplistPermission.ascx" tagname="UCDroplistPermission" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        function imgchang() {
            if (document.Form1.imgsel.selectedIndex != 0) {
                document.Form1.imgview.src = '../' + document.Form1.imgsel.options[document.Form1.imgsel.selectedIndex].value;
                document.Form1.hideimgurl.value = document.Form1.imgsel.options[document.Form1.imgsel.selectedIndex].value;
            }
            else {
                document.Form1.imgview.src = '../Images/MenuImg/folder16.gif';
                document.Form1.hideimgurl.value = 'Images/MenuImg/folder16.gif';
            }
        }
    </script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:SysManage, ptMenuAdd%>" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="middle">
                                    <td width="80">
                                        <a href="treelist.aspx">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>
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
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                   
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:SysManage, fieldNodeName%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtName" runat="server" Width="200px" MaxLength="20"></asp:TextBox>                                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:SysManage, fieldParent%>" />:
                        </td>
                        <td height="25">
                            <asp:DropDownList ID="listTarget" runat="server" Width="200px">
                                <asp:ListItem Value="0" Selected="True">Root</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:SysManage, fieldOrder%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtOrderid" runat="server" MaxLength="5" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            页面地址:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtUrl" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            图标(16x16):
                        </td>
                        <td style="height: 3px" height="3">
                        <asp:TextBox ID="txtImgUrl" runat="server" Width="10px" MaxLength="100" Visible="False">Images/folder16.gif</asp:TextBox>
                            <select id="imgsel" onchange="imgchang()" runat="server" name="imgsel">
                                <option selected></option>
                            </select>
                            <img id="imgview" src="../Images/MenuImg/folder16.gif" border="0" runat="server">
                            <input id="hideimgurl" style="width: 24px; height: 22px" type="hidden" size="1" runat="server"
                                name="hideimgurl" value="Images/MenuImg/folder16.gif">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:SysManage, fieldPermission%>" />:
                        </td>
                        <td height="25">
                            <uc1:UCDroplistPermission ID="UCDroplistPermission1" runat="server" />
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="<%$ Resources:SysManage, TooltipCreatSamePerm%>"
                                                ToolTip="选择该选项,将创建同名权限,并自动绑定.注意:如果父类为根目录则不能使用该设置" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:SysManage, fieldDescription%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtDescription" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                           
                        </td>
                        <td height="25">
                            <asp:CheckBox ID="chkAddContinue" runat="server" Text="<%$ Resources:SysManage, TooltipAddContinue%>"></asp:CheckBox> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>      
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" CausesValidation="false"  Text="<%$ Resources:Site, btnCancleText %>"
                    OnClientClick="javascript:history.go(-1);return false;" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
