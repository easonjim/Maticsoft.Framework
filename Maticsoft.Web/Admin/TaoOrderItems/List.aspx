<%@ Page Title="Tao_OrderItems" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoOrderItems.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Quantity(q) {
            var quantity = q.value;

            if (isNaN(quantity) || quantity == "") {
                alert("请填写正确的金额");
                q.value = 1;
            }
            if (quantity.length > 5) {
                alert("填写的金额不能超过99999!");
                q.value = 1;
            }
            if ((quantity + 0) <= 0) {
                alert("商品金额不能为0或者负数");
                q.value = 1;
            }
        }
    </script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="订单详细信息" /></span>
                        </td>
                        <td align="middle">
                            <%--<table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="add.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="list.aspx">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>
                                    </td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--Title end -->
    <!--Add  -->
    <!--Add end -->
    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="left" class="tdbg">
                <b>
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblSearch%>" />：</b>
            </td>
            <td class="tdbg">
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
    <asp:HiddenField ID="hfOrderID" runat="server" />
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="ItemID">
        <Columns>
            <asp:TemplateField HeaderText="编号" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%"
                Visible="false">
                <ItemTemplate>
                    <asp:Label ID="ItemID" runat="server" Text='<%#Eval("ItemID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单编号" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="OrderID" runat="server" Text='<%#Eval("OrderID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程名称" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="CourseID" runat="server" Text='<%# GetCourseName( Eval("CourseID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="章节名称" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="ModuleID" runat="server" Text='<%# GetModuleName(Eval("ModuleID")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="Price" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Price") %>' onkeyup="Quantity(this)"
                        Width="30px"></asp:TextBox>
                    <asp:LinkButton ID="lkbUpdate" Width="30" CssClass="SmallCommonTextButton" runat="server"
                        CommandName="Update" Text="更新" ValidationGroup="Update"></asp:LinkButton>
                    <asp:LinkButton ID="lkbCancel" Width="30" CssClass="SmallCommonTextButton" runat="server"
                        CommandName="Cancel" Text="取消"></asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程描述" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="ItemDescription" runat="server" Text='<%#Eval("ItemDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="图片" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                <ItemTemplate>
                    <asp:Image ID="ImageUrl" runat="server" ImageUrl='<%#Eval("ImageUrl") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="购买备注" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="Remark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="操作" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="hlinkOrderDetail" runat="server" Target="_self" NavigateUrl='<%#Eval("ItemID", "Show.aspx?ItemID={0}")%>'
                        Text="详细信息" />
                    <asp:HyperLink ID="hlinkmodify" CssClass="SmallCommonTextButton" runat="server" Target="_self"
                        NavigateUrl='<%#Eval("ItemID", "Modify.aspx?ItemID={0}")%>' Text="编辑" Visible="false" />
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>" Visible="false"></asp:LinkButton>
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
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click" Visible="false" />
                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>