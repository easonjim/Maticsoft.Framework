<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoCourses.Modify"
    Title="修改页" %>

<%@ Register Src="~/Controls/UCDroplistPermission.ascx" TagName="UCDroplistPermission"
    TagPrefix="uc2" %>
<%@ Register Assembly="Maticsoft.Web.Validator" Namespace="Maticsoft.Web.Validator"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <!--Kindeditor富文本编辑器样式和脚本开始-->
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript" language="javascript">
        KindEditor.ready(function (K) {
            //[textarea] 加载类型, 这里为[textarea]的第一个元素, 建议页面中只使用一个[textarea]作为文本框编辑器
            var editor1 = K.create('#ctl00_ContentPlaceHolder1_txtShortDescription', {
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
            var editor1 = F.create('#ctl00_ContentPlaceHolder1_txtContent', {
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
    </script>
    <!--Kindeditor富文本编辑器样式和脚本结束-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfCourseID" runat="server" />
    <asp:HiddenField ID="hfCreatedDate" runat="server" />
    <asp:HiddenField ID="hfUrl" runat="server" />
    <asp:HiddenField ID="hfViewCount" runat="server" />
    <asp:HiddenField ID="hfPV" runat="server" />
    <asp:HiddenField ID="hfCourseSpan" runat="server" />
    <asp:HiddenField ID="hfCourseTypes" runat="server" />
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="课程信息修改" /></span>
                        </td>
                        <td align="left">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="add.aspx">
                                            <img title="添加" src="/admin/images/add.gif" border="0" alt="" /></a>
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
    <table style="width: 100%;" cellpadding="1" cellspacing="1" class="border">
        <tr>
            <td>
                <table style="width: 100%" cellspacing="0" cellpadding="0" class="formTableList">
                    <!-- 课程分类 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            课程分类：
                        </td>
                        <td class="rightTD" style="width: 200px" align="left">
                            <asp:DropDownList ID="listTarget" runat="server" Width="280px" CssClass="input_short">
                                <asp:ListItem Value="0" Selected="True">Root</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="rightTD">
                            <label class="msgNormal" style="width: 200px">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <!-- 课程名称 -->
                        <td class="leftTD" style="width: 130px">
                            课程名称：
                        </td>
                        <td class="rightTD" style="width: 300px" align="left">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtCourseName" Width="280px" />
                            <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ErrorMessage="*不能为空！"
                                ControlToValidate="txtCourseName" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td class="rightTD">
                            <div id="dropCategoriesTip" runat="server" style="width: 200px">
                            </div>
                        </td>
                    </tr>
                    <!-- 课程图片 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            课程图片：
                        </td>
                        <td class="rightTD" style="width: 200px">
                        <asp:HiddenField ID="hfImgUrl" runat="server" />
                            <%= strImgUrl%>
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                        <!--上传课程图片-->
                        <tr>
                            <td class="leftTD" style="width: 130px">
                                课程图片：
                            </td>
                            <td class="rightTD" style="width: 208px">
                                <asp:FileUpload ID="fileImageUrl" CssClass="input_longest" runat="server" />
                            </td>
                            <td class="rightTD">
                                &nbsp;
                            </td>
                        </tr>
                    <!-- 课程简介 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            课程简介：
                        </td>
                        <td class="rightTD" style="width: 200px;" align="left">
                            <asp:TextBox runat="server" CssClass="SingleText" ID="txtShortDescription" TextMode="MultiLine"
                                Width="430px" Height="200" />
                        </td>
                        <td class="rightTD">
                            <label class="msgNormal" style="width: 200px">
                            </label>
                        </td>
                    </tr>
                    <!-- 总结数-->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            总节数：
                        </td>
                        <td class="rightTD" style="width: 200px" align="left">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtModuleCount" Width="280px"
                                Style="text-align: right" />
                            <asp:RequiredFieldValidator ID="rfvModuleCount" runat="server" ErrorMessage="*不能为空！"
                                ControlToValidate="txtModuleCount" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revModuleCount" runat="server" ControlToValidate="txtModuleCount"
                                ErrorMessage="*格式错误" ValidationExpression="^[+-]?\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <!-- 课程描述 -->
                        <td class="leftTD" style="width: 130px">
                            课程描述：
                        </td>
                        <td class="rightTD" style="width: 200px" align="left">
                            <asp:TextBox runat="server" CssClass="SingleText" ID="txtContent" TextMode="MultiLine"
                                Width="430px" Height="200" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <!-- 是长 -->
                        <td class="leftTD" style="width: 130px">
                            时长：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <span class="Tlmar">课程时长：</span>
                                            <input id="txtTimeHour" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtMinute" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtSeconds" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />(时、分、秒)
                        </td>
                        <td class="rightTD">
                            <div id="Div2" runat="server" style="width: 200px">
                            </div>
                        </td>
                    </tr>
                    <!-- 有效期 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            有效期：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtExpiryDate" Width="280px"
                                onfocus="setday(this)" />
                            <asp:RequiredFieldValidator ID="rfvExpiryDate" runat="server" ErrorMessage="*不能为空！"
                                ControlToValidate="txtExpiryDate" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td class="rightTD">
                            <div id="Div3" runat="server" style="width: 200px">
                            </div>
                        </td>
                    </tr>
                    <!-- 课程状态 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            课程状态：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="286px" CssClass="SingleText">
                                <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                <%--<asp:ListItem Value="0">未完成</asp:ListItem>
                                <asp:ListItem Value="1">完成待审核</asp:ListItem>--%>
                                <asp:ListItem Value="2">审核通过不上架</asp:ListItem>
                                <asp:ListItem Value="3">审核并发布上架</asp:ListItem>
                                <asp:ListItem Value="4">审核未通过</asp:ListItem>
                                <asp:ListItem Value="2">下架</asp:ListItem>
                            </asp:DropDownList>
                            <td class="rightTD">
                                <div id="Div4" runat="server" style="width: 200px">
                                </div>
                            </td>
                    </tr>
                    <!-- 关键字 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            标签：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtTags" Width="280px" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="leftTD" style="width: 130px">
                            发布人：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:HiddenField ID="hfCreatedUserID" runat="server" />
                            <asp:Label ID="lblCreatedUserID" runat="server"></asp:Label>
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <!-- 是否推荐 -->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            是否推荐：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:RadioButton ID="rbRec" runat="server" GroupName="Recommend" Text="是" />
                            <asp:RadioButton ID="rbNoREc" runat="server" GroupName="Recommend" Text="否" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <!-- 是否最新-->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            是否最新:
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:RadioButton ID="rbNew" runat="server" GroupName="New" Text="是" />
                            <asp:RadioButton ID="rbNo" runat="server" GroupName="New" Text="否" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <!-- 是否热卖-->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            是否热卖：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:RadioButton ID="rbHot" runat="server" GroupName="Hot" Text="是" />
                            <asp:RadioButton ID="rbNormal" runat="server" GroupName="Hot" Text="否" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <!-- 是否特价-->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            是否特价：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:RadioButton ID="rbCheap" runat="server" GroupName="Cheap" Text="是" />
                            <asp:RadioButton ID="rbN" runat="server" GroupName="Cheap" Text="否" />
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <!-- 价格-->
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            价格：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtPrince" Width="280px" Style="text-align: right" />
                            <asp:RequiredFieldValidator ID="rfvPrince" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtPrince"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="leftTD" style="width: 130px">
                            顺序：
                        </td>
                        <td class="rightTD" style="width: 200px">
                            <asp:TextBox CssClass="SingleText" runat="server" ID="txtOrder" Width="280px" Style="text-align: right" />
                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtOrder"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOrder" runat="server" ControlToValidate="txtOrder"
                                ErrorMessage="*格式错误" ValidationExpression="^[+-]?\d+$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="rightTD">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <script src="../../js/calendar1.js" type="text/javascript"></script>
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="返回列表" OnClick="btnCancle_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    ValidationGroup="B"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
