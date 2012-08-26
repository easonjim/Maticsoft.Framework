<%@ Page Title="<%$ Resources:SysManage, ptErrorlog%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="ErrorLog.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.ErrorLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
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
                                        用户日志</span>
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
                    <td style="width: 160px" align="right" class="tdbg">
                        <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>" OnClick="btnSearch_Click"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    >
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
                        Width="100%" PageSize="10" DataKeyNames="ID" ShowExportExcel="false" ShowExportWord="False"
                        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px" ShowCheckAll="true">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"  ControlStyle-Width="40"/>
                            <asp:BoundField DataField="OPTime" HeaderText="时间" SortExpression="OPTime" ControlStyle-Width="40"/>
                            <asp:BoundField DataField="Loginfo" HeaderText="错误信息" SortExpression="Loginfo" />
                            <%--<asp:HyperLinkField HeaderText="Loginfo" DataTextField="Loginfo" DataNavigateUrlFields="ID"
                                DataNavigateUrlFormatString="show.aspx?id={0}" Text="Loginfo" ItemStyle-HorizontalAlign="Left" />    --%>                        
                            <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" ItemStyle-HorizontalAlign="Left"  />                            
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick='return confirm("你确认要删除这条记录吗?")' Text="Delete"></asp:LinkButton>
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
                        <asp:Button ID="btnDelete" runat="server" Text="批量删除" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnDelete_Click"/>
                    <asp:Button ID="Button1" runat="server" Text="删除此日期之前:" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnDeleteAll_Click"/>
                            <asp:TextBox ID="txtDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
                       
                    </td>
                </tr>
            </table>
             <script src="/js/calendar1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
