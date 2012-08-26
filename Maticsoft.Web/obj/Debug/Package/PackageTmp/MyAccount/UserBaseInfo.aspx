<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserBaseInfo.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserBaseInfo" %>
<%@ Register src="../Controls/RegionAjax.ascx" tagname="RegionAjax" tagprefix="MaticSoft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/regionjs.js" type="text/javascript"></script>
<script src="../Admin/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- start main -->
<div class="main">

<input type="hidden" id="pageInfo" value="7" />
<!-- start information -->
<div class="information border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserBaseInfo.aspx">个人信息</a> > <strong>基本资料</strong></div>
<h2>基本资料</h2>
<ul>
<li><span>用户名：</span><asp:Literal ID="litUName" runat="server"></asp:Literal></li>
<li><span>真实姓名：</span><input name="" type="text" class="txt03"  id="txtTrueName" runat="server" />（请填写真实姓名，教课必填，将显示在老师简介中。）</li>
<li><span>登录信箱：</span><asp:Literal ID="litEmail" runat="server"></asp:Literal></li>
<li><span>性别：</span><input name="sex" type="radio" class="radio01"   id="rbMan" runat="server"/>男<input name="sex" type="radio"  class="radio01" id="rbWomen" runat="server"/>女<input name="sex" type="radio"  class="radio01" id="rbSec" runat="server"/>保密</li>
<li><span>生日：</span><input  id="txtBir" runat="server"  type="text" class="txt03" style="width:150px" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"/></li>
<li><span>所在地： </span><MaticSoft:RegionAjax ID="RegionAjax1" runat="server"/></li>
<li><span>&nbsp;</span>没有你要的地区？请给我们<a href="#">留言</a></li>
<li><span>电话：</span><input name="" type="text" class="txt03" id="txtTel" runat="server" style="width:150px"/></li>
<li><span>职业：</span><input name="" type="text" class="txt03"  id="txtProfession" runat="server"  style="width:150px"/></li>
<li style="height:100px"><span>兴趣：</span><textarea name="" class="textarea01"  id="txthobby" runat="server"  ></textarea></li>
<li style="height:40px;"><span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" class="button04" OnClick="btnSubmit_Click"/></li>
</ul>
<div class="img"><img src="/imagesN/001.gif" width="157" height="179" runat="server"  id="imgGravatar" /><br /><a href="UserAvatarEdit.aspx">修改个人头像</a></div>
</div>
</div>
</div>
</div>
</div>
<!-- end information -->

</div>
<!-- end main -->
</asp:Content>
