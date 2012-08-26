<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="Maticsoft.Web.TaoEnterprise.Enterprise.Modify" Title="编辑页"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Controls/RegionDropList.ascx" TagName="RegionDropList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <!--Kindeditor富文本编辑器样式和脚本开始-->
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
     <script language="javascript" type="text/javascript">
         KindEditor.ready(function (K) {
             //[textarea] 加载类型, 这里为[textarea]的第一个元素, 建议页面中只使用一个[textarea]作为文本框编辑器
             var editor1 = K.create('#ctl00_ContentPlaceHolder1_txtIntroduction', {
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
         KindEditor.ready(function (F) {
             //[textarea] 加载类型, 这里为[textarea]的第一个元素, 建议页面中只使用一个[textarea]作为文本框编辑器
             var editor1 = F.create('#ctl00_ContentPlaceHolder1_txtRemark', {
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
                     F.ctrl(document, 13, function () {
                         self.sync();
                         F('form')[0].submit();
                     });
                     F.ctrl(self.edit.doc, 13, function () {
                         self.sync();
                         F('form')[0].submit();
                     });
                 }
             });
             prettyPrint();
         });
        $(function () {
            $("[id$='ddlArea']").change(function () {
                $("[id$='hfRegionID']").val($("[id$='ddlArea']").val());
            });
        });
    </script>
    <!--Kindeditor富文本编辑器样式和脚本结束-->
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
                                <asp:Literal ID="Literal1" runat="server" Text="编辑企业" /></span>
                        </td>
                        <td align="left">
                            <table align="left" id="table3">
                                <tr valign="top" align="middle">
                                    <td width="80">
                                        <a href="List.aspx">
                                            <img title="浏览" src="/admin/images/view.gif" border="0" alt="" /></a>
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
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            公司性质：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:HiddenField ID="hfEnterpriseID" runat="server" />
                            <asp:DropDownList ID="ddlCompanyType" runat="server" Width="305px">
                                <asp:ListItem Value="0" Text="个体工商"></asp:ListItem>
                                <asp:ListItem Value="1" Text="私营独资企业"></asp:ListItem>
                                <asp:ListItem Value="2" Text="国营企业"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            Logo ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:FileUpload ID="FileUploadLogo" runat="server" Width="305" />
                            <asp:HiddenField ID="hfImgUrlLogo" runat="server" />
                            <%= strImgUrlLogo%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            企业名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*企业名称不能为空！" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" width="30%" align="right">
                            企业介绍 ：
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                        </td>
                        <td height="25" width="*" align="left">
                                                    <asp:HiddenField ID="hfCreatedDate" runat="server" />
                            <asp:HiddenField ID="hfCreatedUserID" runat="server" />
                            <asp:TextBox ID="txtIntroduction" runat="server" Width="403px" Height="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            营业执照 ：
                        </td>
                        <td height="25" width="*" align="left">
                             <asp:FileUpload ID="FileUploadBusinessLicense" runat="server" Width="305" />
                             <asp:HiddenField ID="hfImgUrlBusinessLicense" runat="server" />
                             <%= strImgUrlBusinessLicense%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            税务登记 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtTaxNumber" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td height="25" width="30%" align="right">
                            企业等级 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEnteRank" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td height="25" width="30%" align="right">
                            企业分类 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEnteClassID" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            法人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtArtiPerson" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            用户名 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtUserName" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*用户名不能为空！" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            联系人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtContact" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开户银行 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAccountBank" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            账号信息 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAccountInfo" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td height="25" width="30%" align="right">
                            注册资本 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtRegisteredCapital" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            成立时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEstablishedDate" runat="server" Width="300px" onfocus="setday(this)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEstablishedDate" runat="server" ErrorMessage="*成立时间不能为空！"
                                ControlToValidate="txtEstablishedDate" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            注册地 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtEstablishedCity" runat="server" Width="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            省/市 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:HiddenField ID="hfRegionID" runat="server" />
                            <uc1:RegionDropList ID="RegionDropList1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            详细地址 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            主页 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtHomePage" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            电话 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtTelPhone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            手机 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtCellPhone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            联系邮箱 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtContactMail" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            传真 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtFax" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            邮编 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPostCode" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            QQ ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtQQ" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            MSN ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtMSN" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            客服电话 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtServicePhone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            状态：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="305px">
                                <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                                <asp:ListItem Value="1" Text="正常"></asp:ListItem>
                                <asp:ListItem Value="2" Text="冻结"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            备注 ：
                        </td>
                        <td height="25" width="*" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                        </td>
                        <td height="25" width="*" align="left">
                             <asp:TextBox ID="txtRemark" runat="server" Width="403px" Height="150"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <script src="/js/calendar1.js" type="text/javascript"></script>
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" />
                <asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" ValidationGroup="B" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
