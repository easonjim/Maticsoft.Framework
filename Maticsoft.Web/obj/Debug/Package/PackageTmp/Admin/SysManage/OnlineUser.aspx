<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="OnlineUser.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.OnlineUser" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <asp:Literal ID="Literal1" runat="server" Text="在线人员" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        &nbsp;
                                    </td>
                                    <td width="80">
                                        &nbsp;
                                    </td>
                                    <td width="100">
                                        <%--<a href="list.aspx">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>--%>
                                    </td>
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
            <td class="tdbg">
                &nbsp;
            </td>
            <td class="tdbg">
            </td>
        </tr>
    </table>
    <!--Search end-->
    <br />
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gridView1" AutoGenerateColumns="false" runat="server" AllowPaging="True"
                    Width="500px" CellPadding="3" BorderWidth="1px" DataKeyNames="SessionID" RowStyle-HorizontalAlign="Center"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="序号" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <%# gridView1.PageIndex*gridView1.PageSize+ Container.DataItemIndex+1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SessionID" HeaderText="Session编号" SortExpression="SessionID"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UserIP" HeaderText="用户IP" SortExpression="UserIP"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Browser" HeaderText="浏览器" SortExpression="Browser"
                            ItemStyle-HorizontalAlign="Center" />
                             <asp:BoundField DataField="OSName" HeaderText="操作系统" SortExpression="OSName"
                            ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                    <RowStyle HorizontalAlign="Center"></RowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
