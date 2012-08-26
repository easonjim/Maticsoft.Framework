<%@ Page Title="<%$ Resources:Site, ptUserUpdate%>" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="UserUpdate.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.UserUpdate" %>

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
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptUserUpdate%>" /></span>
                        </td>
                        <td align="left">
                            <table align="center" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="adduser.aspx">
                                            <img title="添加" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <%--<td width="100">
                                                <a href="temp.htm">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>
                                            </td>--%>
                                    <td width="100">
                                        <a href="useradmin.aspx">
                                            <img title="显示" src="/admin/images/view.gif" border="0" alt="" /></a>
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
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, fieldUserName%>" />:
                        </td>
                        <td height="25">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, fieldPassword%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtPassword" TabIndex="2" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove" TextMode="Password"></asp:TextBox>(留空将不改变原密码)
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Site, fieldConfirmationPassword%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtPassword1" TabIndex="3" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Site, fieldTrueName%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtTrueName" TabIndex="4" runat="server" Width="249px" MaxLength="20"
                                BorderStyle="Groove"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*不能为空！"
                                Display="Dynamic" ControlToValidate="txtTrueName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:Site, fieldSex%>" />:
                        </td>
                        <td height="25">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="optSex" Checked="True"
                                Text="<%$ Resources:Site, fieldSexM%>"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton2"
                                    runat="server" GroupName="optSex" Text="<%$ Resources:Site, fieldSexF%>"></asp:RadioButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:Site, fieldTelphone%>" />:
                        </td>
                        <td style="height: 3px" height="3">
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Site, fieldEmail%>" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal10" runat="server" Text="员工编号" />:
                        </td>
                        <td height="25">
                            <asp:TextBox ID="txtEmployeeID" runat="server" Width="200px"></asp:TextBox>
                            <asp:RangeValidator ControlToValidate="txtEmployeeID" ID="RangeValidator2" runat="server"  Display="Dynamic" 
 Type="Integer" MinimumValue="1" MaximumValue="999999999" ErrorMessage="<%$ Resources:Site, TooltipFormatErr %>"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:Site, fieldUserType%>" />:
                        </td>
                        <td height="25">
                            <asp:DropDownList ID="dropUserType" runat="server" Width="200px">
                                <asp:ListItem Value="AA" Selected="True">管理员</asp:ListItem>
                                <asp:ListItem Value="UU" >员工</asp:ListItem>                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="25">
                            状态:
                        </td>
                        <td height="25">
                            <asp:CheckBox ID="chkActive" runat="server" Text="冻结帐号" Checked="false" />
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
