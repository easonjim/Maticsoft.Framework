<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true"
    CodeBehind="OnlineBook.aspx.cs" Inherits="Maticsoft.Web.OnlineBook" enableEventValidation="false" %>

<%@ Register Src="~/Controls/RegionAjax.ascx" TagPrefix="uc" TagName="RegionAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/regcss.css" rel="stylesheet" type="text/css" />
    <script src="js/regionjs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$='btnSubmit']").click(function () {
                if (!$("[id$='txtUserName']").val()) {
                    ShowFailTip("请输入您的姓名！");
                    return false;
                }
                if (!$("[id$='txtPhone']").val()) {
                    ShowFailTip("请输入您的手机号码！");
                    return false;
                }
                if ($("[id$='txtPhone']").val().length < 11) {
                    ShowFailTip("请输入正确的手机号码！");
                    return false;
                }
                var inputEmail = $("[id$='txtMail']").val();
                if (!inputEmail) {
                    ShowFailTip("输入邮箱格式不正确！");
                    return false;
                } else if (!isEmail(inputEmail)) {
                    ShowFailTip("输入邮箱格式不正确！");
                    return false;
                } else {
                    return true;
                }
            });
        });

        function isEmail(value) {
            var patrn = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/; //
            if (!patrn.exec(value)) {
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start content -->
    <div id="content">
        <!-- start register -->
        <div class="register border">
            <div class="bg01">
                <div class="bg02">
                    <div class="bg03">
                        <div class="bg_r">
                        </div>
                        <div class="bg_l">
                        </div>
                        <div class="con">
                            <h2>
                                线下课程-在线报名</h2>
                            <ul>
                                <li style="height: 36px;"><span style="padding-top: 6px;">姓名：</span><input name=""
                                    type="text" class="txtreg" id="txtUserName" runat="server" />
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">性别：</span><div style="vertical-align: bottom;
                                    margin-top: 10px;">
                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="sex" Checked="true" />男&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                        ID="RadioButton2" runat="server" GroupName="sex" />女</div>
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">手机号码：</span><input name=""
                                    type="text" class="txtreg" id="txtPhone" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') "
                                    onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">电子信箱：</span>
                                    <input name="" type="text" class="txtreg" runat="server" id='txtMail' />
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">QQ号码：</span>
                                    <input name="" type="text" class="txtreg" runat="server" id='txtQQ'  onkeyup="value=value.replace(/[^\d]/g,'') "
                                    onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">所在省市：</span><div style="vertical-align: bottom;
                                    margin-top: 10px;">
                                    <uc:RegionAjax runat="server" ID="ucRegionAjax" /></div>
                                </li>
                                <li style="height: 36px;"><span style="padding-top: 6px;">联系地址：</span>
                                    <input name="" type="text" class="txtreg" runat="server" id='txtAddress' />
                                </li>
                                <li></li>
                                <li><span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" Text="" class="button24"
                                    OnClick="btnSubmit_Click" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end register -->
    </div>
    <!-- end content -->
</asp:Content>
