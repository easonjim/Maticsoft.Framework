<%@ Page Title="<%$ Resources:Site, ptAddUser %>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.AddUser" %>
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
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptAddUser%>" /></span>
                                </td>
                                <td align="middle">
                                    <table align="left" id="table3">
                                        <tr valign="top" align="left">
                                            <td width="80">
                                                <a href="useradmin.aspx">
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
                       <table cellSpacing="0" cellPadding="3" width="100%" border="0">
											<tr>
												<td align="right" height="25">											
													<asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, fieldUserName%>" />:
												</td>
												<td height="25">
													<asp:textbox id="txtUserName" tabIndex="1" runat="server" Width="249px" MaxLength="20" BorderStyle="Groove"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*不能为空" Display="Dynamic"
														ControlToValidate="txtUserName"></asp:requiredfieldvalidator></td>
											</tr>
											<tr>
												<td align="right" height="25">										
													<asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, fieldPassword%>" />:
												</td>
												<td height="25">
													<asp:textbox id="txtPassword" tabIndex="2" runat="server" Width="249px" MaxLength="20" BorderStyle="Groove"
														TextMode="Password" ></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*不能为空" Display="Dynamic"
														ControlToValidate="txtPassword"></asp:requiredfieldvalidator></td>
											</tr>
											<tr>
												<td align="right" height="25">												
													<asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Site, fieldConfirmationPassword%>" />:
												</td>
												<td height="25">
													<asp:textbox id="txtPassword1" tabIndex="3" runat="server" Width="249px" MaxLength="20" BorderStyle="Groove"
														TextMode="Password"></asp:textbox>
													<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="两次密码输入不符" Display="Dynamic"
														ControlToValidate="txtPassword1" ControlToCompare="txtPassword"></asp:comparevalidator></td>
											</tr>
											<tr>
												<td align="right" height="25">													
													<asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Site, fieldTrueName%>" />:
												</td>
												<td height="25">
													<asp:textbox id="txtTrueName" tabIndex="4" runat="server" Width="249px" MaxLength="20" BorderStyle="Groove"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*不能为空" Display="Dynamic"
														ControlToValidate="txtTrueName"></asp:requiredfieldvalidator></td>
											</tr>
											<%--<tr>
												<td align="right" height="25">
												
												<asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:Site, fieldSex%>" />:
												</td>
												<td height="25"><asp:radiobutton id="RadioButton1" runat="server" GroupName="optSex" Checked="True" Text="男">
												</asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioButton2" runat="server" GroupName="optSex" Text="女"></asp:radiobutton>
												</td>
											</tr>--%>
											<tr>
												<td align="right" height="25">													
													<asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:Site, fieldTelphone%>" />:
												</td>
												<td style="HEIGHT: 3px" height="3">
													<asp:TextBox id="txtPhone" runat="server" Width="200px"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td align="right" height="25">													
													<asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Site, fieldEmail%>" />:
												</td>
												<td height="25"><asp:textbox id="txtEmail" runat="server" Width="200px"></asp:textbox></td>
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
											
											<%--<tr>
												<td align="right" height="25">Style:
												</td>
												<td style="HEIGHT: 5px" height="5"><asp:dropdownlist id="dropStyle" runat="server" Width="200px">
														<asp:ListItem Value="1">DefaultBlue</asp:ListItem>
														<asp:ListItem Value="2">Olive</asp:ListItem>
														<asp:ListItem Value="3">Red</asp:ListItem>
														<asp:ListItem Value="4">Green</asp:ListItem>
													</asp:dropdownlist></td>
											</tr>--%>
											
											<tr>
												<td colSpan="2"><asp:label id="lblMsg" runat="server" ForeColor="Red"></asp:label></td>
											</tr>
										</table>                   
                    </td>                    
                </tr>
                <tr>
                 <td class="tdbg" align="center" valign=bottom>
                 <asp:button id="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>" onclick="btnSave_Click"
                 class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" 
                 ></asp:button>
                 <asp:Button ID="btnCancle" runat="server" CausesValidation="false"  Text="<%$ Resources:Site, btnCancleText %>" onclick="btnCancle_Click"
                 class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" 
                 ></asp:button>
											
                 
                 </td>
                </tr>
            </table>
            <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
