<%@ Page Title="Tao_Courses" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoOffLineCourse.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--asyncbox-->
    <link href="../js/asyncbox/skins/ZCMS/asyncbox.css" rel="stylesheet" type="text/css" />
    <script src="../js/asyncbox/jQuery.v1.4.2.js" type="text/javascript"></script>
    <script src="../js/asyncbox/AsyncBox.v1.4.5.js" type="text/javascript"></script>
    <!--asyncbox-->
    <script type="text/javascript" language="javascript">
        function View(strUrl) {
            asyncbox.open({
                id: 'A_id',
                url: strUrl,
                title: '课程章节管理',
                modal: false,
                drag: false,
                width: 1100,
                height:500,
            });
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
                                <asp:Literal ID="Literal1" runat="server" Text="课程信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <%--<a href="add.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>--%>
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
                分类：
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
                状态：
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                    <%--<asp:ListItem Value="0">未完成</asp:ListItem>--%>
                    <asp:ListItem Value="1">完成待审核</asp:ListItem>
                    <asp:ListItem Value="2">审核通过不上架</asp:ListItem>
                    <asp:ListItem Value="3">审核并发布上架</asp:ListItem>
                    <asp:ListItem Value="4">审核未通过</asp:ListItem>
                    <asp:ListItem Value="2">下架</asp:ListItem>
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
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="10" ShowExportExcel="false" ShowExportWord="False" ExcelFileName="FileName1"
        CellPadding="0" BorderWidth="1px" ShowCheckAll="true" DataKeyNames="CourseID">
        <Columns>
            <asp:TemplateField HeaderText="课程图片" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%# GetImage(Eval("ImageUrl"),45,45)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程名称" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#HttpUtility.HtmlEncode(Eval("CourseName").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属类别" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#GetCategoriesName(Eval("CategoryId"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程价格" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("CoursePrice", "{0:C}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程简介" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200px"
                Visible="false">
                <ItemTemplate>
                    <%# HttpUtility.HtmlEncode(GetCourseDec(Eval("Description"), 30))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#GetCourseStatus(Eval("Status").ToString()) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建时间" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#Eval("CreatedDate") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布人" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#GetUserName(Eval("CreatedUserID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="关注人数" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("PV") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="报名人数" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("BookCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px"
                Visible="false">
                <ItemTemplate>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkLook" runat="server" Text="详细"
                        NavigateUrl='<%#Eval("CourseID","~/admin/TaoCourses/Show.aspx?CourseId={0}")%>'></asp:HyperLink>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkEdit" runat="server" Text="编辑"
                        NavigateUrl='<%#Eval("CourseID","~/admin/TaoCourses/Modify.aspx?CourseId={0}")%>'></asp:HyperLink>
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
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                    <%--<asp:ListItem Value="0">未完成</asp:ListItem>
                    <asp:ListItem Value="1">完成待审核</asp:ListItem>--%>
                    <asp:ListItem Value="2">审核通过不上架</asp:ListItem>
                    <asp:ListItem Value="3">审核并发布上架</asp:ListItem>
                    <asp:ListItem Value="4">审核未通过</asp:ListItem>
                    <%--<asp:ListItem Value="2">下架</asp:ListItem>--%>
                </asp:DropDownList>
                <asp:Button ID="btnUpdate" runat="server" Text="批量处理" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>