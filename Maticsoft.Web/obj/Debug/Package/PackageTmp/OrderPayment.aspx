<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="OrderPayment.aspx.cs" Inherits="Maticsoft.Web.OrderPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
/*----------accountbody确认充值方式---------*/
.buyBoxfs .buyFsbox{width:600px;margin-top:46px;margin-left:50px;}
.buyFsbox p{color:#888;font-size:13px;margin-top:5px;}
.buyBoxfs .FsContbox{width:732px;height:368px;margin-top:25px;color:#878787;margin-left:50px;}
.FsContbox{margin:0;padding:0;}
/*.FsContbox .fsCbox{width:732px;height:288px;border:1px solid #E7E7E7;}*/
.FsContbox .fsCbox{width:732px;border:1px solid #E7E7E7;float:left}
.fsCbox .fsTop{width:100%;height:60px;*height:65px;border-bottom:1px solid #E7E7E7;}
.fsBottom .fsBrad,.fsTop .fsP{margin:0;padding:0;margin-left:30px;margin-top:15px;*margin-top:10px;}
.fsP span{display:block;margin-right:5px;float:left;}
.fsP span input.fsRbox{margin-top:17px;*margin-top:12px;}
.fsP span.fsRtext{margin-top:16px;}
.fsP span img{width:132px;height:40px;overflow:hidden;}
.fsCbox .fsBottom{width:100%;height:200px;margin-top:8px;}
.fsBottom .fsBradBox{width:690px;height:160px;margin-left:22px;}
.fsBradBox ul{margin:0;padding:0;}
.fsBradBox ul li{width:200px;_width:180px;height:50px;*height:10px;float:left;margin-left:22px;margin-top:15px;}
.fsBradBox ul li input.yhradio{float:left;margin-top:10px;margin-right:5px;}
.fsBradBox ul li img.yhimg{float:left;}
.fsBradBox p{clear:both;padding-left:40px;*padding-left:25px;}
.fsBradBox p a{color:#014783;}
.FsContbox p{margin-top:30px;}
.dis {display:block;}
 .dis h3{color:#034985;height:22px;font-size:14px;border-bottom:1px solid #F5F5F5;margin-bottom:20px;margin-top:10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" id="hfOrderId" runat="server" />
    <asp:HiddenField ID="hfCid" runat="server" />
    <asp:HiddenField ID="hfMid" runat="server" />
    <asp:HiddenField ID="hfSellerId" runat="server" />
<!-- start content -->
<div id="content">

<!-- start search_e -->
<div class="search_e border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con" style="width:auto;text-align:left">

				 <div class="buyBoxfs" style="width:600px;">
					<div style="margin-left:50px;"><h3 style="font-size: 22px; color: #004A88;">
                            确认支付</h3></div>
    <div class="buyContfs">
						<div class="buyFsbox">
							<p>账号：<asp:Label ID="labUAccount" runat="server" Text=""></asp:Label></p>
							<p >可用余额：<b style="color:#014783;"><asp:Label ID="labBalance" runat="server"  Text=""></asp:Label></b>个学币</p>
							<p >需扣除金额：<b style="color:#014783;"><asp:Label ID="labTotalMoney" runat="server"  Text=""></asp:Label></b>个学币</p>
                            <%=BalanceInfo()%>
                            <asp:Button ID="btnLocal" runat="server" Text="账户支付" onclick="btnLocal_Click" style="margin-top:15px;" />
						</div>
						<div class="FsContbox">
								<div class="fsCbox">
									<div class="fsTop">
										<div class="fsP">
											<span><input type="radio" id="fsRadio" class="fsRbox" checked  runat="server" /></span>
											<span class="fsRtext">使用<b style="color:#004986;">财付通</b></span>
											<span><img src="../images/tenpay.jpg"/></span>
										</div>
									</div>
									<div class="fsBottom" style="display:none">
										<div class="fsBrad">
											<input type="radio" name="fsRadio"/>
											使用<b style="color:#004986;">在线银行</b>
											支持招行、工行、建行、中行、交行等主流银行的网银支付
										</div>
										<div class="fsBradBox">
											<ul>
												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/gh.jpg" class="yhimg"/>
												</li>
												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/jh.jpg" class="yhimg"/>
												</li>
												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/zh.jpg" class="yhimg"/>
												</li>

												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/zsyh.jpg" class="yhimg"/>
												</li>
												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/jtyh.jpg" class="yhimg"/>
												</li>
												<li>
													<input type="radio" name="ghradio" class="yhradio"/>
													<img src="../images/nh.jpg" class="yhimg"/>
												</li>
											</ul>
											<p><a href="#">更多银行></a></p>
										</div>
									</div>
								</div>
								<p>
                                    <asp:Button ID="btnNext" runat="server" Text="网上支付" OnClick="btnNext_Click"  style="margin-top:15px;" />
                                </p>
						</div>
					</div>
                 </div>
</div>
</div>
</div>
</div>
</div>
<!-- end search_e -->

</div>
<!-- end content -->
</asp:Content>
