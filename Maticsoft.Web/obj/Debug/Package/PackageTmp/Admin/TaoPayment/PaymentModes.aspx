<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="PaymentModes.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoPayment.PaymentModes" %>

<%@ Register TagPrefix="Maticsoft" Namespace="Maticsoft.Web.Controls" Assembly="Maticsoft.Web.Controls" %>
<%@ Register TagPrefix="Maticsoft" Namespace="Maticsoft.Web.Validator" Assembly="Maticsoft.Web.Validator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../js/validate/pagevalidator.css" type="text/css" />
    <link rel="stylesheet" href="../css/Maticsoftv5.css" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/validate/pagevalidator.js"></script>
    <script type="text/javascript" src="../js/Maticsoftv5.js"></script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="支付方式" /></span>
                        </td>
                        <td align="middle">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--Title end -->
    <Maticsoft:StatusMessage ID="statusMessage" runat="server" Visible="False" />
    <div class="grdGroupFormList">
        <div class="grdHeaderStyle">
            <ul>
                <li class="userGroupAddadmin" style="padding-top: 7px"><a href='AddPaymentMode.aspx'>
                    <asp:Literal ID="lblAdd" runat="server" Text="<%$ Resources:PaymentModes, IDS_FromField_lblAddPaymentMode %>"></asp:Literal></a>
                </li>
                <li class="spirtLines">|</li>
                <li class="userGroupCheckAll" style="padding-top: 7px"><a href="#" onclick="CheckClickAll()">
                    <asp:Label ID="lblCheckAll" runat="server" Text="<%$ Resources:Resources, IDS_Label_CheckAll %>"></asp:Label></a></li>
                <li class="spirtLines">|</li>
                <li class="userGroupReverseCheck" style="padding-top: 7px"><a href="#" onclick="CheckReverse()">
                    <asp:Label ID="lblCheckReverse" runat="server" Text="<%$ Resources:Resources, IDS_Label_CheckReverse %>"></asp:Label></a></li>
                <li class="spirtLines">|</li>
                <li class="userGroupDelCheck" style="padding-top: 7px">
                    <Maticsoft:DeleteImageLinkButton ID="lkbDelectCheck" runat="server" Text="<%$ Resources:Resources, IDS_Button_DeleteCheck %>" /></li>
            </ul>
        </div>
        <asp:GridView ID="grdPaymentMode" runat="server" AutoGenerateColumns="false" ShowHeader="true"
            DataKeyNames="ModeId" Width="100%" CellPadding="5" BackColor="White">
            <Columns>
                <Maticsoft:CheckBoxColumn />
                <asp:TemplateField HeaderText="<%$ Resources:PaymentModes, IDS_Header_Name %>" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="lblModeName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="merchantCode" HeaderText="<%$ Resources:PaymentModes, IDS_Header_merchantCode %>">
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:PaymentModes, IDS_Header_Gateway %>">
                    <ItemTemplate>
                        <asp:Label ID="lblGatawayType" runat="server" Text='<%# Eval("Gateway") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <Maticsoft:SortImageColumn HeaderText="<%$ Resources:PaymentModes,IDS_Header_DisplaySequence %>" />
                <asp:TemplateField HeaderText="<%$ Resources:Resources, IDS_Header_Options %>">
                    <ItemStyle Width="100px" />
                    <ItemTemplate>
                        <a href='EditPaymentMode.aspx?modeId=<%# Eval("ModeId") %>' class="SmallCommonTextButton">
                            <asp:Literal ID="lblManagerText" runat="server" Text="<%$ Resources:Resources, IDS_Button_Edit %>"></asp:Literal></a>
                        <Maticsoft:DeleteImageLinkButton runat="server" CssClass="SmallCommonTextButton"
                            ID="Delete" Text="<%$ Resources:Resources, IDS_Button_Delete %>" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <Maticsoft:ValidatorContainer runat="server" ID="ValidatorContainer" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>