<%@ Page Title="邮件配置" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="MailConfiglist.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.MailConfiglist" %>
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
                                        <asp:Literal ID="Literal1" runat="server" Text="邮件配置" /></span>
                                </td>
                                <td align="middle">
                                   <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="MailConfigadd.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>                                    
                                    <td width="100">
                                        <a href="MailConfiglist.aspx">
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
            
             <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
                        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
                        Width="90%" PageSize="10" DataKeyNames="ID" ShowExportExcel="false" ShowExportWord="False"
                        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px" ShowCheckAll="false"
                        >
                        <Columns>                            
                            <asp:BoundField DataField="Mailaddress" HeaderText="邮件地址" SortExpression="Mailaddress" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Username" HeaderText="用户名" SortExpression="Username"
                                ItemStyle-HorizontalAlign="center" />
                             <asp:BoundField DataField="SMTPServer" HeaderText="SMTPServer" SortExpression="SMTPServer"/>
                             <asp:BoundField DataField="SMTPPort" HeaderText="SMTPPort" SortExpression="SMTPPort" />
                             <asp:BoundField DataField="POPServer" HeaderText="POPServer" SortExpression="POPServer" />
                             <asp:BoundField DataField="POPPort" HeaderText="POPPort" SortExpression="POPPort" />
                            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="35" DataNavigateUrlFields="ID" Visible="false"
                                DataNavigateUrlFormatString="Modify.aspx?id={0}" Text="<%$ Resources:Site, btnEditText %>" />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="<%$ Resources:Site, btnDeleteText %>" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick='return confirm("你确认要删除吗?")' Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
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

                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td>
                        <%--<asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnDelete_Click"/>   --%>                    
                    </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
