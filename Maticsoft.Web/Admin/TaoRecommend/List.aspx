<%@ Page Title="课程表" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.TaoRecommend.List" %>

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
                                <asp:Literal ID="Literal1" runat="server" Text="推荐课程设置" /></span>
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
                <%--<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>--%>
                <asp:DropDownList runat="server" Width="120px" ID="ddlSearch">
                    <asp:ListItem Text="请选择" Value="-1" />
                    <asp:ListItem Text="所有课程" Value="0" />
                    <asp:ListItem Text="已推荐课程" Value="1" />
                    <asp:ListItem Text="未推荐课程" Value="2" />
                    <%--<asp:ListItem Text="热卖课程" Value="2" />
                    <asp:ListItem Text="特价课程" Value="3" />--%>
                </asp:DropDownList>
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
            <asp:TemplateField HeaderText="课程章节" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <a href="javascript:;" onclick="View('../TaoModules/List.aspx?CourseID=<%# Eval("CourseID") %>&type=1');">
                        查看章节</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属类别" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <%#GetCategoriesName(Eval("CategoryId"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课时总数" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("ModuleNum") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课时时长" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#ConvertTimme(Eval("TimeDuration"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程价格" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("Price","{0:C}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程简介" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200px"
                Visible="false">
                <ItemTemplate>
                    <%# HttpUtility.HtmlEncode(GetCourseDec(Eval("ShortDescription"), 30))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否推荐" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#GetRecomStatus(Eval("Recommended"))%>
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
            <asp:TemplateField HeaderText="浏览量" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("PV") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售量" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="35px">
                <ItemTemplate>
                    <%#Eval("SalesVolume") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="更新时间" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <%#Eval("UpdatedDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnDetailText %>" ControlStyle-Width="50"
                DataNavigateUrlFields="CourseID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                Text="<%$ Resources:Site, btnDetailText %>" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:TemplateField ControlStyle-Width="50" HeaderText="<%$ Resources:Site, btnDeleteText %>"
                Visible="false" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
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
                <asp:DropDownList runat="server" Width="120px" ID="ddlModfy">
                    <asp:ListItem Text="请选择" Value="-1" />
                    <asp:ListItem Text="设为推荐" Value="0" />
                    <asp:ListItem Text="取消推荐" Value="1" />
                    <%--<asp:ListItem Text="特价课程"  Value="2" />
                    <asp:ListItem Text="取消特价"  Value="3" />
                    <asp:ListItem Text="热卖课程"  Value="4" />
                    <asp:ListItem Text="取消热卖"  Value="5" />--%>
                </asp:DropDownList>
                <asp:Button ID="btnUpdate" runat="server" Text="批量处理" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>