<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Ms.Enterprise.Show" Title="显示页" %>

<%@ Register Src="~/Controls/RegionDropList.ascx" TagName="RegionDropList"
    TagPrefix="uc1" %>
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
                                <asp:Literal ID="Literal1" runat="server" Text="详细信息" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="100">
                                        <a href="list.aspx" target="">
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
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr style="display: none">
                        <td height="25" width="30%" align="right">
                            企业编号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEnterpriseID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LOGO ：
                        </td>
                        <td height="40" width="*" align="left">
                            <%= strImgUrlLogo%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            公司性质：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCompanyType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            企业名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            企业介绍 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblIntroduction" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            营业执照 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <%= strImgUrlBusinessLicense%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            税务登记 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblTaxNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            企业等级 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEnteRank" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            企业分类 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEnteClassID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            法人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblArtiPerson" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            用户名 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            联系人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblContact" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开户银行 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblAccountBank" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            账号信息 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblAccountInfo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            注册资本 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblRegisteredCapital" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            成立时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEstablishedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            注册地 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblEstablishedCity" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            省/市 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <uc1:RegionDropList ID="RegionDropList1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            详细地址 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            邮编 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblPostCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            主页 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblHomePage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            电话 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblTelPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            手机 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCellPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            联系邮箱 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblContactMail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            传真 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblFax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            QQ ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblQQ" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            MSN ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblMSN" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            客服电话 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblServicePhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            状态 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            创建日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            创建用户 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblCreatedUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            更新日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUpdatedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            更新用户 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUpdatedUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            代理商ID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblAgentID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            备注 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
