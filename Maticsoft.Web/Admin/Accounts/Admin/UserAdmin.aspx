<%@ Page Title="<%$ Resources:Site, ptUserAdmin %>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.UserAdmin" %>
<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
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
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, ptUserAdmin%>" /></span>
                                </td>
                                <td align="left">
                                    <table align="left" id="table3">
                                        <tr valign="top" align="middle">
                                            <td width="80">
                                                <a href="adduser.aspx">
                                                    <img title="" src="/admin/images/add.gif" border="0" alt=""/></a>
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
                    <td style="width: 80px" align="right" class="tdbg">
                        <b><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblSearch%>" />：</b>
                    </td>
                    <td class="tdbg">
                       <asp:DropDownList ID="DropUserType" runat="server">
                                                <asp:ListItem Value="" Selected="True">全部</asp:ListItem>                                                
                                                <asp:ListItem Value="AA" >系统管理员</asp:ListItem>
                                                <asp:ListItem Value="UU" >用户</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:Label ID="Label1" runat="server"><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, lblKeyword%>" />:</asp:Label>
                                            <asp:TextBox ID="txtKeyword" runat="server" Width="100px" ></asp:TextBox>                                          
                                           &nbsp;&nbsp; 
                                           <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>" 
                                            class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" 
                                            OnClick="btnSearch_Click"/>    
                   
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <br />
            <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
                        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
                        Width="100%" PageSize="10" DataKeyNames="UserID" ShowExportExcel="false" ShowExportWord="False"
                        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px">
                        <Columns>                            
                            <asp:TemplateField HeaderText="<%$ Resources:Site, fieldUserName %>" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href='RoleAssignment.aspx?UserID=<%#Eval("UserID") %>' > 
                                                <%# Eval("UserName")%>  
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="TrueName" HeaderText="<%$ Resources:Site, fieldTrueName %>" SortExpression="TrueName" ControlStyle-Width="40" ItemStyle-HorizontalAlign="center"/>                            
                            <asp:BoundField DataField="Phone" HeaderText="<%$ Resources:Site, fieldTelphone %>" SortExpression="Phone" ItemStyle-HorizontalAlign="center"  /> 
                            <asp:BoundField DataField="Email" HeaderText="<%$ Resources:Site, fieldEmail %>" SortExpression="Email" ItemStyle-HorizontalAlign="center"  /> 
                            <asp:BoundField DataField="EmployeeID" HeaderText="员工编码" SortExpression="EmployeeID" ItemStyle-HorizontalAlign="center"  />                                    
                            
                            <asp:TemplateField HeaderText="是否生效" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                            <%# GetboolText(Eval("Activity"))%></ItemTemplate>
                           </asp:TemplateField>
                            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="50" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserUpdate.aspx?userid={0}"
                                Text="<%$ Resources:Site, btnEditText %>"  ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="<%$ Resources:Site, btnDeleteText %>" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick='return confirm("你确认要删除这条记录吗?")' Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle Height="25px" HorizontalAlign="Right" />
                        <HeaderStyle Height="25px" />
                        <PagerStyle Height="25px" HorizontalAlign="Right" />
                        <SortTip AscImg="~/Images/up.JPG" DescImg="~/Images/down.JPG" />
                        <RowStyle Height="25px" />
                        <SortDirectionStr>DESC</SortDirectionStr>
                    </cc1:GridViewEx>            
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
