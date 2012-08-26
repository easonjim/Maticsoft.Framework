<%@ Page Title="<%$ Resources:SysManage, ptMenuManage%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="Treelist.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.Treelist" %>
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
                                        菜单管理</span>
                                </td>
                                <td align="middle">
                                    <table align="left" id="table3">
                                        <tr valign="top" align="middle">
                                            <td width="80">
                                                <a href="add.aspx">
                                                    <img title="添加" src="/admin/images/add.gif" border="0" alt=""/></a>
                                            </td>
                                            <%--<td width="100">
                                                <a href="modify.aspx">
                                                    <img title="编辑" src="/admin/images/edit.gif" border="0" alt=""/></a>
                                            </td>
                                            <td width="100">
                                                <a href="delete.aspx">
                                                    <img title="删除" src="/admin/images/delete.gif" border="0" alt=""/></a>
                                            </td>
                                            <td width="100">
                                                <a href="index.aspx">
                                                    <img title="显示" src="/admin/images/view.gif" border="0" alt=""/></a>
                                            </td>--%>
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
                    <td style="width: 130px" align="right" class="tdbg">
                         <b>按父级菜单位置：</b>
                    </td>
                    <td class="tdbg">
                        <asp:DropDownList ID="listTarget" runat="server" Width="200px">                        
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>" OnClick="btnSearch_Click"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <br />
            <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
                        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
                        Width="100%" PageSize="15" DataKeyNames="NodeID" ShowExportExcel="false" ShowExportWord="False"
                        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px" ShowCheckAll="true">
                        <Columns>                        
                            <asp:BoundField DataField="NodeID" HeaderText="<%$ Resources:SysManage, fieldNodeID %>" SortExpression="NodeID" ControlStyle-Width="40px" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="OrderID" HeaderText="<%$ Resources:SysManage, fieldOrderID %>" SortExpression="OrderID" ControlStyle-Width="40"  ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:HyperLinkField HeaderText="<%$ Resources:SysManage, fieldText %>" DataTextField="TreeText" DataNavigateUrlFields="NodeID"
                                DataNavigateUrlFormatString="show.aspx?id={0}" Text="TreeText" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Url" HeaderText="<%$ Resources:SysManage, fieldUrl %>" SortExpression="Url" ItemStyle-HorizontalAlign="Left"  />
                            <asp:BoundField DataField="comment" HeaderText="<%$ Resources:SysManage, fieldcomment %>" SortExpression="comment" ItemStyle-HorizontalAlign="Left"  />                            
                            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="50" DataNavigateUrlFields="NodeID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="<%$ Resources:Site, btnEditText %>"  ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ControlStyle-Width="50px" HeaderText="<%$ Resources:Site, btnDeleteText %>" ItemStyle-HorizontalAlign="Center" >
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
                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnDelete_Click"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnMoveTo" runat="server" Text="<%$ Resources:Site, btnMoveToText %>" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnMoveTo_Click"/>
                     <asp:DropDownList ID="listTarget2" runat="server" Width="200px">                        
                    </asp:DropDownList>
                       
                    </td>
                </tr>
            </table>
            
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
