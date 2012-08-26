<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserAuthen.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserAuthen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/tabmenu.js" type="text/javascript"></script>
    <style type="text/css">
     .Authen{width:750px;overflow:hidden;margin:0;padding:0;}
.Authen .auBox{width:510px;height:300px;overflow:hidden;margin-top:20px;margin-left:8px;}
.auBox .auPbox{width:510px;height:80px;}
.Authen  h3{color:#034985;height:22px;font-size:14px;border-bottom:1px solid #F5F5F5;}
.auUpload p,.auPbox p{margin-bottom:10px;}
.auPbox p span{color:#9BB5CE;margin-left:5px;}
.auBox .auUpload{width:510px;height:120px;margin-top:35px;}
.auUpload p{clear:both;}
.auUpload p.whe{margin-bottom:2px;margin-left:100px;padding-top:10px;}
.auUpload p.whea{margin-left:100px;}
.auUpload p span{display:block;float:left;margin-right:8px;}
.auUpload p span input.uploadName{height:25px;border:1px solid #E7E7E7;}
.auUpload p span.upM{margin-top:5px;*margin-top:8px;}
.auUpload p span.upMw{margin-top:2px;}
.auUpload p.upBotton{padding-left:100px;margin-top:30px;}
    </style>

    <script type="text/javascript">
        $(function () {
            var flags = 0;
            $("[id$='upDoc']").click(function () {
                if ($("[id$='ddlUpType']").val() == "") {
                    ShowFailTip("请选择证书类型！");
                    return false;
                }
                else if ($("[id$='FilePath']").val() == "") {
                    ShowFailTip('请先选择要上传的证书文件！');
                    return false;
                } else {
                    return true;
                }
            });
            $("[id$='ddlUpType']").change(function () {
                $("[id$='Hftype']").val($("[id$='ddlUpType']").val());
            });
            $("[id$='btnSubmit']").click(function () {
                if ($("[id$='FilePath']").val() == "" || $("[id$='FilePath']").val().length <= 1) {
                    ShowFailTip("请先选择要上传的证书文件！");
                    return false;
                } else if ($("[id$='ddlUpType']").val() == "") {
                    ShowFailTip("请选择证书类型！");
                    return false;
                }
                else {
                    return true;
                }
            });
        });
        function FileUpChange() {
            $("[id$='FilePath']").val("1");
        }
    </script>
<style type="text/css">
.inp {    border: 1px solid #C8C8C8;    height: 24px;    line-height: 2;    margin-right: 3px;    padding: 0 3px;    vertical-align: middle;}
.inw {width: 228px;}
        
.action_color {background: url("http://pic2.58.com/ui6/my/images/inw-bg.gif") repeat-x scroll left top #FEFFE3; border: 1px solid #C8C8C8;}
.wrong_color{  border:1px solid #ff9a9a!important; background:#feffe3 url(http://pic2.58.com/ui6/my/images/inw-bg.gif) left top repeat-x;}
.nameyz,.sjyz,.maileyz,.zzyz,.nameyzw,.sjyzw,.maileyzw,.zzyzw{ height:19px; border:0; overflow:hidden; display:inline-block; margin-right:8px; cursor:pointer;
background-image:url(http://pic2.58.com/ui6/my/images/txbackground.gif)!important; background-repeat: no-repeat;}   
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="FilePath" value="" runat="server">
<input type="hidden" id="Hftype" value="" runat="server">
<input type="hidden" id="pageInfo" value="8" />
<!-- start main -->
<div class="main">

<!-- start authenticate -->
<div class="active border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">个人信息</a> > <strong>认证管理</strong></div>
<h2>认证管理</h2>
<div class="class_table">
<div class="tabs"><a href="javascript:void(0);" class="link">身份认证</a><a href="javascript:void(0);">机构认证</a><a href="javascript:void(0);">其他认证</a></div>
<div class="balancecontentin">
<div class="Authen">
<div class="auBox">
<div class="auPbox">
<p>认证状态：<span>                      
<%= strStatus %>
</span>
</p>
<p>真实姓名：<span>                      
<asp:TextBox ID="txtTrueName" runat="server"  CssClass="inw inp" onfocus='this.className = "inp inw action_color ";' Enabled="false"></asp:TextBox>
</span>
</p>
<p>身份证号：<span>
<asp:HiddenField ID="hfIDCard" runat="server" />
<asp:TextBox ID="txtIDCard" runat="server" CssClass="inw inp"></asp:TextBox>
</span></p>
</div> 
<div class="auUpload">
<p>
<span class="upM">上传身份证：</span>
<span>
<asp:HiddenField ID="hfImgURL" runat="server" />
<asp:FileUpload ID="fileIDCard" runat="server" CssClass="uploadName" />
</span>
<span >
<asp:ImageButton ID="btnUplodIDCard" runat="server" ImageUrl="../images/uploadzj.jpg" OnClick="btnUplodIDCard_Click" />
</span>
<%= strImgUrl %>
</p>
<p class="whe">
支持图片格式：jpg、gif、png，尺寸不能大于500K。
</p>
</div>
</div>
</div>
</div>


<div class="balancexq">

<table>
<tr>
<th></th>
<td align="left"><span id="spEnterpriseTip" class="red" style="font-size: 10pt">公司名称和公司别称填写后不能修改</span> </td>
</tr>
<tr>
<th align="right">认证状态 ：</th>
<td width="80%" align="left">
<%=strEnterpriseStatus%>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span> 公司名 ：</th>
<td width="80%" align="left">
<input type="hidden" name="fc" id="fc" value="" />
<asp:TextBox ID="txtEnterpriseName" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvEnterpriseName" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtEnterpriseName" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<span id="span_enterpriseName" class="fGrey2 fen f13"></span>&nbsp; <span id="enterpriseName_Tip">
</span>
</td>
</tr>
<tr >
<th align="right"> <span class="red">*</span> 注册资本 ：</th>
<td align="left">
<asp:TextBox ID="txtRegisteredCapital" runat="server" CssClass="inw inp" style="width: 240px;text-align:right" ValidationGroup="one" MaxLength="9"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvRegisteredCapital" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtRegisteredCapital" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revRegisteredCapital" runat="server" ControlToValidate="txtRegisteredCapital"   ErrorMessage="*格式错误！" ValidationExpression="^[+-]?\d+$" Display="Dynamic" ValidationGroup="one"></asp:RegularExpressionValidator>
               
<span id="enterpriseSize_Tip"></span>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span> 联系人 ：</th>
<td align="left">
<asp:TextBox ID="txtContact" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvContact" runat="server" ErrorMessage="*不能为空！"  ControlToValidate="txtContact" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<span id="linkMan_Tip"></span>
</td>
</tr>
<tr>
<th  align="right">  <span class="red">*</span>联系电话： </th>
<td align="left">
<asp:TextBox ID="txtPhone" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtPhone" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<span id="phone_Tip"></span>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span>邮编 ：</th>
<td align="left">
<asp:TextBox ID="txtPostCode" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtPostCode" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<span id="lblEnterpriseAlias" class="fGrey2 fen f13"></span>&nbsp; <span id="enterpriseAlias_Tip">
</span>
</td>
</tr>
<tr id ="tel" style="display: none;" align="right">
<th > </th>
<td>
<input name="telPhone" type="text" id="telPhone" value="" class="inw inp" style="width: 240px" maxlength="20" />
<span id="telPhone_Tip"></span>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span> 电子邮件 ：</th>
<td align="left">
<asp:TextBox ID="txtContactMail" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvContactMail" runat="server" ErrorMessage="*不能为空！" ControlToValidate="txtContactMail" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
<span id="email_Tip"></span>
</td>
</tr>
<tr>
<th  align="right"> <span class="red">*</span>公司主页： </th>
<td align="left">
<asp:TextBox ID="txtHomePage" runat="server" CssClass="inw inp" style="width: 240px;" ValidationGroup="one"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvHomePage" runat="server" ErrorMessage="*不能为空！"   ControlToValidate="txtHomePage" Display="Dynamic" ValidationGroup="one"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span> 营业执照 ：</th>
<td align="left">
<asp:HiddenField ID="hfBusinessLicense" runat="server" />
<asp:FileUpload ID="FileUploadBusinessLicense" runat="server" CssClass="uploadName" ValidationGroup="one" />
<%= strImgBusinessLicense%>
<span id="Span1"></span>
</td>
</tr>
<tr>
<th align="right"> <span class="red">*</span> 公司简介 ：</th>
<td align="left"> 
<asp:TextBox ID="txtIntroduction" runat="server" style="width:450px; height:150px; font-size:12px; line-height:20px;" TextMode="MultiLine"></asp:TextBox>
<span id="intro_Tip"></span>
</td>
</tr>
<tr>
<th>&nbsp;</th>
<td>
<br /><br />
<label class="butt" id="butt">
<asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btns" OnClick="btnSave_Click" ValidationGroup="one" />
</label>
<span id="errortip" class="red"></span>
</td>
</tr>
</table>
</div>


<div class="balancexq">

<div class="Authen">
<div class="auBox">
<div class="auPbox">
<p>用户名：
<b style="color:#024A85;margin-left:5px;">
<label id="lblUserName" runat="server"></label>
</b></p>
<p>真实姓名：<span><label id="lblTrueUserName" runat="server"></label></span></p>
<p>已传认证资料：
<span >
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<img src="/images/rz.jpg" /><b><%#Eval("ApproveName")%></b>&nbsp;
</ItemTemplate>
</asp:Repeater>
</span></p>
</div>
<div class="auUpload">
<p>
<span class="upM">上传其它资料：</span>
<span class="upMw">
<asp:DropDownList  ID="ddlUpType" runat="server">
</asp:DropDownList>
</span>
<span><input name="uploadName" id="DocUp" type="file" class="uploadName" runat="server" onchange="FileUpChange()"/></span>
<span >
<asp:ImageButton ID="upDoc" runat="server" ImageUrl="../images/uploadzj.jpg" onclick="upDoc_Click" />
</span>
</p>
<p class="whe">
支持图片格式：jpg、gif、png，尺寸不能大于500K。
</p>								
<p class="upBotton">
<a href="#">
<asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="../Images/xgwc.jpg"  onclick="btnSubmit_Click" Visible="False" /></a>
</p>
</div>
</div>
</div>
</div>
</div>
</div>

</div>
</div>
</div>
</div>
<!-- end authenticate -->

</div>
<!-- end main -->

</asp:Content>
