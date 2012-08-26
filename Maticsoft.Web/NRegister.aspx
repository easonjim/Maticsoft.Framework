<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="NRegister.aspx.cs" Inherits="Maticsoft.Web.NRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="js/PasswordStrength.js" type="text/javascript"></script>
    <script src="js/Register.js" type="text/javascript"></script>
    <link href="css/regcss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- start content -->
<div id="content">

<!-- start register -->
<div class="register border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<h2>新用户注册</h2>
<ul>
<li  style="height:36px;"><span style="padding-top:6px;">用户名：</span><input name="" type="text" class="txtreg" id="txtUserName" runat="server" /> 
<div id="MsgUserName"  class="msgPosition"></div>
</li>
<li style="height:36px;"><span style="padding-top:6px;">电子信箱：</span>
<input name="" type="text" class="txtreg" runat="server" id='txtMail' /> 
<div id="MsgEmail" class="msgPosition" > </div>
</li>
<li  style="height:36px;"><span style="padding-top:6px;">密码：</span>
<input name="" type="password" class="txtreg"   onKeyUp="pwStrength($(this).attr('value'))" id="txtPass" runat="server" maxlength="16"/> 
<div id="msgPassword"  class="msgPosition"></div>
</li>
<li style="height:18px;padding-top:8px;"><span>&nbsp;</span>
<div class="mimaqd" >
<table width="217"  cellspacing="0" cellpadding="1"  style='display: inline;'>
<tr align="center" > <td width="60px" id="strength_L" style="background-color:#EEEFF4" >弱 </td> 
<td width="1px"> </td>
 <td width="60px" id="strength_M" style="background-color:#EEEFF4" >中 </td>
 <td width="1px"> </td> <td width="60px" id="strength_H"  style="background-color:#EEEFF4" >强</td>
</tr></table>
</div>
</li>
<li  style="height:36px;"><span style="padding-top:6px;">确认密码：</span>
<input name="" type="password" class="txtreg" runat="server" id='txtConfirm' maxlength="16"/> 
<div id="MsgConfirm"  class="msgPosition"> </div>
</li>
<li style="padding-top:6px;"><span>&nbsp;</span>
<input name="" type="checkbox" value="" runat="server" checked="checked" style="vertical-align:bottom;" id="chkAgree"/> <a href="Nagreement.aspx"  target="_blank">淘老师服务协议</a></li>
<li><span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" Text=""    class="button24" onclick="btnSubmit_Click" /></li>
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
