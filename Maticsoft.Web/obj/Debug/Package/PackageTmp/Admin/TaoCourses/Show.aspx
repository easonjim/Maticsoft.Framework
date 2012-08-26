<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoCourses.Show" Title="显示页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
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
                                <asp:Literal ID="Literal1" runat="server" Text="课程信息浏览" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="middle">
                                    <td width="100">
                                        <a href="Modify.aspx?CourseId=<%= strid %>">
                                            <img title="编辑" src="/admin/images/edit.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="list.aspx">
                                            <img title="显示" src="/admin/images/view.gif" border="0" alt="" /></a>
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
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="ShowTableList">
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程编号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCourseID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程类别 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblCategoryId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程图片 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Image ID="imgImageUrl" runat="server" Width="45" Height="45" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程简介 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Literal ID="ltlShortDescription" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程描述 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
                        </td>
                        <td width="50%">
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            总节数 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblModuleNum" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            时长 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblTimeDuration" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程标价 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblPrice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            截止日期：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblExpiryDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程状态 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            关键字 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblTags" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            发布时间 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            发布人 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblCreatedUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            是否推荐 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblRecommended" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            是否最新 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblLatest" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            是否热卖 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblHotsale" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            是否特价 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblSpecialOffer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            浏览量 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblPV" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            销售量 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblSalesVolume" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            课程排名 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblSequence" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            更新时间 ：
                        </td>
                        <td height="25" width="*" align="left" class="rightTD">
                            <asp:Label ID="lblUpdatedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
