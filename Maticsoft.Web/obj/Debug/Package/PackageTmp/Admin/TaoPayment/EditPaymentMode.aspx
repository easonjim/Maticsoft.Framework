<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="EditPaymentMode.aspx.cs" Inherits="Maticsoft.Web.Admin.EditPaymentMode" %>

<%@ Register TagPrefix="Maticsoft" Namespace="Maticsoft.Web.Controls" Assembly="Maticsoft.Web.Controls" %>
<%@ Register TagPrefix="Maticsoft" Namespace="Maticsoft.Web.Validator" Assembly="Maticsoft.Web.Validator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../js/validate/pagevalidator.css" type="text/css" />
    <link rel="stylesheet" href="../css/Maticsoftv5.css" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/pagevalidator.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Maticsoftv5.js"></script>
    <!--Kindeditor富文本编辑器样式和脚本开始-->
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript" language="javascript">
        KindEditor.ready(function (K) {
            //[textarea] 加载类型, 这里为[textarea]的第一个元素, 建议页面中只使用一个[textarea]作为文本框编辑器
            var editor1 = K.create('#ctl00_ContentPlaceHolder1_fcContent', {
                cssPath: '../kindeditor/plugins/code/prettify.css',
                uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                //是否过滤HTML样式
                filterMode: false,
                //禁止调整宽度
                resizeType: 1,
                //设置可用项目
                items: ['fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', 'removeformat', '|', 'ustifyleft', 'justifycenter', 'justifyright', '|', 'emoticons', 'image', 'link'],
                //允许上传图片
                allowImageUpload: true,
                //禁止上传Flash
                allowFlashUpload: false,
                //禁止上传视频
                allowMediaUpload: false,
                //禁止上传文件
                allowFileManager: false,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
    <!--Kindeditor富文本编辑器样式和脚本结束-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="PageTitleArea">
            <div class="PageTitle">
                <asp:Literal ID="lblPageTitle" runat="server" Text="<%$ Resources:EditPaymentMode, IDS_PageTitle %>"></asp:Literal>
            </div>
            <div style="width: 80%;">
                <asp:Literal ID="lblPageDesc" runat="server" Text="<%$ Resources:EditPaymentMode, IDS_PageDesc %>"></asp:Literal>
            </div>
        </div>
        <Maticsoft:StatusMessage ID="statusMessage" runat="server" Visible="False" />
        <!-- 支付方式名称-->
        <table style="width: 100%" cellspacing="0" cellpadding="0" class="formTableList">
            <tr>
                <td class="leftTD">
                    <asp:Label ID="lblName" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblName %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <asp:TextBox ID="txtName" runat="server" Columns="40" MaxLength="200">
                    </asp:TextBox>
                </td>
                <td class="rightTD">
                    <div id="txtNameTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="ValidateTargetName" runat="server" Description="<%$ Resources:PaymentModeView, IDS_Message_Name_Description %>"
                        ControlToValidate="txtName" ContainerId="ValidatorContainer">
                        <Validators>
                            <Maticsoft:InputStringClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_Message_Name_Description %>"
                                LowerBound="1" UpperBound="50" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
            <tr>
                <td class="leftTD">
                    <asp:Label ID="lblGateway" runat="server" Text="<%$ Resources:PaymentModeView,IDS_FormField_lblGateway %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <Maticsoft:PayInterfaceDropDownList ID="dropPayInterface" runat="server" AllowNull="true"
                        NullToDisplay="<%$ Resources:PaymentModeView, IDS_FormField_nullToDisplay %>"
                        AutoPostBack="true">
                    </Maticsoft:PayInterfaceDropDownList>
                    <br />
                    <asp:HyperLink ID="hlinkImage" runat="server" Target="_blank">
                        <asp:Label ID="lblimage" runat="server"></asp:Label>
                    </asp:HyperLink>
                </td>
                <td class="rightTD">
                    <div id="dropPayInterfaceTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="ValidateTargetPayInterface" runat="server" ContainerId="ValidatorContainer"
                        Description="<%$ Resources:PaymentModeView, IDS_Message_PayInterface_Description %>"
                        ControlToValidate="dropPayInterface">
                        <Validators>
                            <Maticsoft:DropDownListClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_Message_PayInterface_Description %>" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
            <tr id="tblrMerchantCode" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblMerchantCode" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblMerchantCode %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <asp:TextBox ID="txtMerchantCode" runat="server" Columns="40" MaxLength="200">
                    </asp:TextBox>
                </td>
                <td class="rightTD">
                    <div id="txtMerchantCodeTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="ValidateTargetMerchantCode" runat="server" Description="<%$ Resources:PaymentModeView, IDS_Message_MerchantCode_Description %>"
                        ControlToValidate="txtMerchantCode" ContainerId="ValidatorContainer">
                        <Validators>
                            <Maticsoft:InputStringClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_Message_MerchantCode_Description %>"
                                LowerBound="1" UpperBound="300" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
            <!-- 显示隐藏容器 邮件地址 -->
            <tr id="tblrImage" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblEmailAddress" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblEmailAddress %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtEmailAddress" runat="server" Columns="40" MaxLength="200">
                        </asp:TextBox>
                    </label>
                </td>
                <td class="rightTD">
                    <div id="txtEmailAddressTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="validatetxtEmailAddress" ContainerId="ValidatorContainer"
                        runat="server" ControlToValidate="txtEmailAddress" Description="电子邮件地址的长度在200个字符以内"
                        Nullable="false">
                        <Validators>
                            <Maticsoft:InputStringClientValidator ErrorMessage="<%$ Resources:EmailSettings, IDS_EmailAddress_Error%>"
                                LowerBound="1" UpperBound="200" Regex="([a-zA-Z\\.0-9_-])+@([a-zA-Z0-9_-])+((\\.[a-zA-Z0-9_-]{2,3}){1,2})" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
            <!-- 显示隐藏容器 商户密钥 -->
            <tr id="tblrSecretKey" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblSecretKey" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblSecretKey %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtSecretKey" runat="server" Columns="40" MaxLength="200">
                        </asp:TextBox>
                    </label>
                </td>
                <td class="rightTD">
                    <div class="msgNormal">
                        <asp:Literal ID="lblHelpSecret" runat="server" Text="<%$ Resources:PaymentModeView, IDS_PaymnetMode_SecondKey_Description %>"></asp:Literal>
                    </div>
                </td>
            </tr>
            <!-- 显示隐藏容器 第二密钥 -->
            <tr id="tblrSecondKey" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblSecondKey" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblSecondKey %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtSecondKey" runat="server" Columns="40" MaxLength="200">
                        </asp:TextBox>
                    </label>
                </td>
                <td class="rightTD">
                </td>
            </tr>
            <!-- 显示隐藏容器 商户密码 -->
            <tr id="tblrPassword" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblPassWord" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblPassWord %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtPassword" runat="server" Columns="40" MaxLength="200" TextMode="Password">
                        </asp:TextBox>
                    </label>
                </td>
                <td class="rightTD">
                    <div class="msgNormal">
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_PassWord_Description %>"></asp:Literal>
                    </div>
                </td>
            </tr>
            <!-- 显示隐藏容器 合作伙伴 -->
            <tr id="tblrPartner" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblPartner" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblPartner %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtPartner" runat="server" Columns="40" MaxLength="200">
                        </asp:TextBox>
                    </label>
                </td>
                <td class="rightTD">
                </td>
            </tr>
            <tr id="tblrCurrencys" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblCurrencys" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblCurrencys %>"></asp:Label>
                </td>
                <td class="rightTD" style="width: 37%">
                    <label>
                        <asp:CheckBoxList ID="chkCurrencysList" runat="server" RepeatDirection="Horizontal"
                            RepeatColumns="4">
                        </asp:CheckBoxList>
                    </label>
                </td>
                <td class="rightTD">
                    <div class="msgNormal">
                        <asp:Literal ID="lblCurrencyHelp" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblCurrencyHelp %>"></asp:Literal>
                    </div>
                </td>
            </tr>
            <tr id="tblCharge" runat="server">
                <td class="leftTD">
                    <asp:Label ID="lblCharge" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblCharge %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <asp:TextBox ID="txtCharge" runat="server" Text="0">
                        </asp:TextBox>
                        <asp:CheckBox ID="chkIsPercent" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_chkIsPercent %>" />
                    </label>
                </td>
                <td class="rightTD">
                    <div id="txtChargeTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="ValidateTargetCharge" runat="server" ContainerId="ValidatorContainer"
                        Nullable="true" ControlToValidate="txtCharge" Description="<%$ Resources:PaymentModeView, IDS_Message_Charge_Description %>">
                        <Validators>
                            <Maticsoft:InputMoneyClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_Message_Charge_Description %>" />
                            <Maticsoft:NumberRangeClientValidator ErrorMessage="支付手续费必须大于0" MinValue="0" MaxValue="99999999" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
            <tr>
                <td class="leftTD">
                    <asp:Label ID="Label1" runat="server" Text="是否支持在线充值"></asp:Label>
                </td>
                <td class="rightTD">
                    <label>
                        <Maticsoft:YesNoRadioButtonList ID="radAllowRecharge" runat="server">
                        </Maticsoft:YesNoRadioButtonList>
                    </label>
                </td>
                <td class="rightTD">
                    <div class="msgNormal">
                        <asp:Literal ID="Literal2" runat="server" Text="是否允许使用此支付方式给账户在线充值" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="leftTD">
                    <asp:Label ID="lblDisplaySequence" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblDisplaySequence %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <asp:TextBox ID="txtDisplaySequence" runat="server" Text="1" Columns="5">
                    </asp:TextBox>
                </td>
                <td class="rightTD">
                    <div id="txtDisplaySequenceTip" runat="server">
                    </div>
                    <Maticsoft:ValidateTarget ID="ValidateTargetSequence" runat="server" ContainerId="ValidatorContainer"
                        ControlToValidate="txtDisplaySequence" Description="<%$ Resources:PaymentModeView, IDS_Message_DisplaySequence_Description %>">
                        <Validators>
                            <Maticsoft:InputNumberClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_Message_DisplaySequence_Description %>" />
                            <Maticsoft:NumberRangeClientValidator ErrorMessage="<%$ Resources:PaymentModeView, IDS_ErrorMessage_DisplaySequence %>"
                                MinValue="1" MaxValue="65535" />
                        </Validators>
                    </Maticsoft:ValidateTarget>
                </td>
            </tr>
        </table>
        <table style="width: 100%" cellspacing="0" cellpadding="0" class="formTableList">
            <tr>
                <td class="leftTD">
                    <asp:Label ID="lblDescription" runat="server" Text="<%$ Resources:PaymentModeView, IDS_FormField_lblDescription %>"></asp:Label>
                </td>
                <td class="rightTD">
                    <textarea id="fcContent" enableviewstate="true" cols="100" rows="8" style="width: 700px;
                        height: 200px; visibility: hidden;" runat="server"></textarea>
                </td>
                <td class="rightTD">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table style="width: 100%" cellspacing="0" cellpadding="0" class="formTableList">
            <tr>
                <td class="bottonLeftTD">
                    &nbsp;
                </td>
                <td class="rightTD">
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:EditPaymentMode, IDS_Button_Update %>"
                                    OnClientClick="return PageIsValid()" CssClass="inp_L1" />
                            </td>
                            <td>
                                <div class="return_inp">
                                    <a href='PaymentModes.aspx'>
                                        <asp:Literal ID="litReturn" runat="server" Text="<%$ Resources:EditPaymentMode, IDS_FromField_lblReturn %>"></asp:Literal>
                                    </a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="rightTD">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <Maticsoft:ValidatorContainer runat="server" ID="ValidatorContainer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>