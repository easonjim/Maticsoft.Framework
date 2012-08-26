<%@ Page Title="TaoEntryForm" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.TaoEntryForm.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Title -->
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="报名管理" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                   <%-- <td width="80">
                                        <a href="Add.aspx" target="">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="List.aspx" target="">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--Title end -->
    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="right" class="tdbg">
                <b>关键字：</b>
            </td>
            <td class="tdbg">
                <asp:DropDownList ID="dropState" runat="server">
                    <asp:ListItem Value="" Text="选择全部"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
                    <asp:ListItem Value="1" Text="已处理"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>"
                    OnClick="btnSearch_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
            <td class="tdbg">
            </td>
        </tr>
    </table>
    <!--Search end-->
    <br />
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
            ShowToolBar="false" AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
            OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
            Width="100%" PageSize="10" ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1"
            CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="用户姓名"
                    SortExpression="UserName" ItemStyle-HorizontalAlign="Left" />
                <%--<asp:BoundField DataField="Age" HeaderText="<%$Resources:Site,Age%>" SortExpression="Age"
                    ItemStyle-HorizontalAlign="Left" />--%>
                <asp:BoundField DataField="Email" HeaderText="邮箱" SortExpression="Email"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="TelPhone" HeaderText="手机"
                    SortExpression="TelPhone" ItemStyle-HorizontalAlign="Left" />
                <%--<asp:BoundField DataField="HouseAddress" HeaderText="<%$Resources:msEntryForm,lblHouseAddress%>"
                    SortExpression="HouseAddress" ItemStyle-HorizontalAlign="Left" Visible="false" />
                <asp:BoundField DataField="CompanyAddress" HeaderText="<%$Resources:msEntryForm,lblCompanyAddress%>"
                    SortExpression="CompanyAddress" ItemStyle-HorizontalAlign="Left" Visible="false" />--%>
                <asp:TemplateField HeaderText="省/市" ItemStyle-HorizontalAlign="Left"
                    SortExpression="RegionId">
                    <ItemTemplate>
                        <%# GetRegionNameByRID(Eval("RegionId"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别" ItemStyle-HorizontalAlign="Center"
                    SortExpression="Sex">
                    <ItemTemplate>
                        <%# GetSex(Eval("Sex"))%>
                    </ItemTemplate>
                </asp:TemplateField>               
               
                <asp:TemplateField HeaderText="状态" ItemStyle-HorizontalAlign="Center"
                    SortExpression="State">
                    <ItemTemplate>
                        <%# GetState(Eval("State"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnDetailText %>" ControlStyle-Width="50"
                    DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}" Text="详细"
                    ItemStyle-HorizontalAlign="Center" Visible="false"/>
                <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="50"
                    DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}" Text="操作"
                    ItemStyle-HorizontalAlign="Center"  Visible="false"/>
                <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"
                    Visible="false" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle Height="25px" HorizontalAlign="Right" />
            <HeaderStyle Height="35px" />
            <PagerStyle Height="25px" HorizontalAlign="Right" />
            <SortTip AscImg="~/Images/up.JPG" DescImg="~/Images/down.JPG" />
            <RowStyle Height="25px" />
            <SortDirectionStr>DESC</SortDirectionStr>
        </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>            
                <td style="width: 1px;">
                    <asp:DropDownList ID="dropType" runat="server">
                        <asp:ListItem Value="-1" Selected="True" Text="请选择"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
                        <asp:ListItem Value="1" Text="已处理"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="批处理" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnBatch_Click" />
                    <asp:Button ID="Button2" runat="server" Text="批删除" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" onclick="Button2_Click" />
                </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
