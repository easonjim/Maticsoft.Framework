<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="userRecharge1.aspx.cs" Inherits="Maticsoft.Web.MyAccount.userRecharge1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var reg = /^\d+$/;
        $(document).ready(function () {
            var resstatus = true;
            $('#btnNext').click(function () {
                if (!$("[id$='txtAccount']").val()) {
                    ShowFailTip('请输入正确的充值帐号！', 2000);
                    return false;
                }
                else if (!$('#txtMoney').val()) {
                    ShowFailTip('请输入正确的金额！', 2000);
                    return false;
                } else {
                    window.location.href = 'userRecharge2.aspx?total_fee=' + $('#txtMoney').val() + '&uid=' + $("[id$='hfUid']").val();
                }
            });
        });
        function changeTextOnBlur(control) {
            var Mprice = control.value;
            if (!Mprice) {
                return false;
            }
            if (reg.test(Mprice)) {
                if (Mprice < 0 || Mprice > 99999) {
                    ShowFailTip('输入的金额有误,最多充值99999个学币！', 2000);
                    $("#bmoney").text('0');
                }
                else {
                    var money = parseInt(Mprice);
                    $("#bmoney").text(money);
                }
            }
            else {
                ShowFailTip('请输入正确的金额！', 2000);
                $("#bmoney").text('0');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" id="pageInfo" value="2" />
<input type="hidden" id="hfUid" runat="server" />
<!-- start main -->
<div class="main">

<!-- start recharge -->
<div class="recharge border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
<div class="nav"><a href="UserCenter.aspx">我的帐户</a> > <strong>我要充值</strong> > <strong>确认充值帐户与金额</strong></div>
<h2>我要充值</h2>
<div class="one">
<div class="img"><img src="/imagesN/TLaoShi_bg052.gif" width="659" height="23" /></div>
<ul>
<li>确认帐号：<input name="" type="text" class="txt04"  id='txtAccount' style="width:180px;" readonly="readonly" runat="server"/></li>
<li>充值数量：<input name="" type="text" class="txt04" id='txtMoney' style="width:180px;" onblur='changeTextOnBlur(this);' /> 个学币</li>
<li>需要扣除金额<strong>￥<b id="bmoney" >0</b></strong>元</li>
<li><input name="" type="button" class="button10"  id="btnNext"/></li>
</ul>
<div class="img"><a href="#"><img src="/imagesN/TLaoShi_bg049.gif" /></a>　　<a href="#"><img src="/imagesN/TLaoShi_bg050.gif" /></a>　　<a href="#"><img src="/imagesN/TLaoShi_bg051.gif" /></a></div>
</div>
</div>
</div>
</div>
</div>
</div>
<!-- end recharge -->

</div>
<!-- end main -->
</asp:Content>
