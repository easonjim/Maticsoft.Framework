<%@ Page Title="Tao_Comment" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoComment.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
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
                                <asp:Literal ID="Literal1" runat="server" Text="评论管理" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <%-- <td width="80">
                                        <a href="add.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>--%>
                                    <td width="100">
                                        <a href="list.aspx">
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
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" ShowExportExcel="False" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="CommentID"
        SelectedRowStyle-BackColor="#FBFBF4">
        <Columns>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="课程名称" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="15%">
                <ItemTemplate>
                    <%#GetCourseName(Eval("CourseID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="所属节次" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="15%">
                <ItemTemplate>
                    <%#GetModuleName(Eval("ModuleID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="评论人" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="10%">
                <ItemTemplate>
                    <%# GetUserName(Eval("UserID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="评论内容" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-Width="30%">
                <ItemTemplate>
                    <%#GetCourseDec(Eval("Comment"),30) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="评论时间" ItemStyle-HorizontalAlign="Right"
                HeaderStyle-Width="10%">
                <ItemTemplate>
                    <%#Eval("CommentDate") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="状态" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-Width="5%">
                <ItemTemplate>
                    <%#GetStatus(Eval("Status"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="评论分值" ItemStyle-HorizontalAlign="Right"
                HeaderStyle-Width="5%" Visible="false">
                <ItemTemplate>
                    <%#Eval("Score") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="50" HeaderText="操作" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-Width="15%">
                <ItemTemplate>
                    <asp:HyperLink ID="hlinkCommDetail" runat="server" Target="_self" NavigateUrl='<%#Eval("CommentID", "~/admin/TaoComment/Show.aspx?id={0}")%>'
                        Text="详细信息" />
                    <%-- <asp:HyperLink  ID="hlkEdit" runat="server" Text="编辑"
                        NavigateUrl='<%#Eval("CommentID","Modify.aspx?id={0}")%>'></asp:HyperLink>--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
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
                    OnClick="btnDelete_Click" />
                <asp:Button ID="btnApprove" runat="server" Text="批量审核" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" onclick="btnApprove_Click" />
                <asp:Button ID="btnInverseApprove" runat="server" Text="批量未审核" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" 
                    onmouseout="this.className='inputbutton'" onclick="btnInverseApprove_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
