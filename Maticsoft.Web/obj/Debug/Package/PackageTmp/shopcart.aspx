<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="shopcart.aspx.cs" Inherits="Maticsoft.Web.shopcart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="css/cartcss.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
　　        var checksubmitflg = false;
        function checksubmit() {
            if (checksubmitflg == true) {
                return false;
            }
            checksubmitflg = true;
            return true;
        }
        document.ondblclick = function docondblclick() {
            window.event.returnvalue = false;
        }
        document.onclick = function doconclick() {
            if (checksubmitflg) {
                window.event.returnvalue = false;
            }
        }
        
    </script>
    <script type="text/javascript">
        function deletModule(mid) {
            if (confirm("删除一节课程之后，购买价格将不再优惠。确定删除吗？")) {
                //遍历所有的价格
                var count = 0;
                var mCount = 0;
                $(".rptclass").each(function () {
                    count += parseFloat($(this).find(".aclass").html());
                    mCount += 1;
                });

                if (mCount == 1) {
                    alert("至少有一条数据！");
                    return false;
                }
                var liID = "mid" + mid;
                var priceID = "price" + mid;
                var mprice = parseFloat($("#" + priceID + "").html());
                var totalMoney = parseFloat($("[id$='labTotalMoney']").html());
                $("#" + liID + "").remove();
                count -= mprice;
                $("[id$='labTotalMoney']").html(MathRound(count));
            }
        }


        function MathRound(LSTR_Num) {
            var LINT_Num;
            if (LSTR_Num == "") {
                LINT_Num = 0;
            }
            else {
                LINT_Num = parseFloat(LSTR_Num);
                LINT_Num = Math.round(LINT_Num * 100) / 100;
            }
            return LINT_Num;
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$='btntest']").click(function () {

                if ($("[id$='labTotalMoney']").html() == "") {
                    alert("合计价格不正确！");
                    return false;
                }
                var count = "";
                $(".rptclass").each(function () {
                    count += $(this).find("input").val() + ",";
                });
                if (count != "") {
                    $.ajax({
                        url: "ShopCartHandle.aspx",
                        type: 'post', dataType: 'json', timeout: 10000,
                        data: { cid: $("[id$='hfCid']").val(), mids: count, uid: $("[id$='hfUid']").val(), uName: $("[id$='hfUName']").val(), uEmail: $("[id$='hfEmail']").val(), SellerId: $("[id$='hfSellerId']").val(), tprice: $("[id$='labTotalMoney']").html() },
                        success: function (resultData) {
                            if (resultData.STATUS == "SUCCESS") {
                                window.location.href = "OrderPayment.aspx?OrderId=" + resultData.DATA;
                            } else {
                                alert("系统繁忙，请稍后再试！");
                            }
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:HiddenField ID="hfCid" runat="server" />
    <asp:HiddenField ID="hfMid" runat="server" />
    <asp:HiddenField ID="hfSellerId" runat="server" />
    <asp:HiddenField ID="hfUid" runat="server" />
    <asp:HiddenField ID="hfEmail" runat="server" />
    <asp:HiddenField ID="hfUName" runat="server" />

    
<!-- start content -->
<div id="content">

<!-- start search_e -->
<div class="search_e border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">
    <div >
        <h3 style="font-size: 30px; color: #004A88;">
            购买课程</h3>
        <div class="listcontentinBox" style="margin-bottom: 80px;margin-left:-220px;">
            <ol>
                <asp:Repeater ID="Repeater_Cart" runat="server" OnItemDataBound="Repeater_Cart_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <%--<span class="colRx">
									    <p><%#Eval("RNum")%></p>
								    </span>--%>
                            <span class="colImg">
                                <img src="images/none.gif" style="width: 90px; height: 70px;" /></span> <span class="colBText">
                                    <asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID")%>' Visible="false"></asp:Label>
                                    <h6>
                                        <a href="../show.aspx?cid=<%# Eval("CourseID") %>" style="color:#004986;"  target="_blank"><%#HttpUtility.HtmlEncode(Eval("CourseName").ToString())%></a></h6>
                                </span><span class="colJs">
                                    <h6>
                                        <p style="padding-left: 8px;">
                                            教师</p>
                                    </h6>
                                    <%-- <p><%#Eval("TrueName") %></p>--%>
                                </span><span class="colTime">
                                    <h6>
                                        <p style="padding-left: 8px;">
                                            &nbsp;&nbsp;&nbsp;时长</p>
                                    </h6>
                                    <%--<p><%#ConvertTimme(Eval("TimeDuration")) %>&nbsp;</p>--%>
                                </span><span class="colRx">
                                    <h6>
                                        <p style="padding-left: 8px;">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价格</p>
                                    </h6>
                                </span><span class="colgmBotton">
                                    <h6>
                                        <p style="padding-left: 8px;">
                                            &nbsp;&nbsp;&nbsp;操作</p>
                                    </h6>
                                </span></li>
                        <asp:Repeater ID="rptCarts" runat="server" >
                            <ItemTemplate>
                                <li style="height: 40px;" id="mid<%#Eval("ModuleID") %>" class='rptclass'><span class="colRxm1"></span>
                                    <input type="text" name="name" value='<%#Eval("ModuleID") %>' style="display:none;" />
                                    <span class="colRxm1">
                                        <p>
                                            <%#Eval("RNum")%></p>
                                    </span><span class="colBTextm">
                                        <h6>
                                             <a href="../show.aspx?cid=<%# Eval("CourseID") %>&mid=<%#Eval("ModuleID") %>" style="color:#004986;" target="_blank"><%#Eval("ModuleName") %></a></h6>
                                    </span><span class="colJsm">
                                        <p>
                                          <a href="TeacherDes.aspx?uid=<%#Eval("CreatedUserID")%>" target="_blank" >  <%#Eval("TrueName") %></a></p>
                                    </span><span class="colTimem">
                                        <p > </p>
                                        <p style="padding-top: 6px;">
                                            <%#ConvertTimme(Eval("TimeDuration")) %>&nbsp;</p>
                                    </span><span class="colRxm">
                                        <h6 ><a id="price<%#Eval("ModuleID") %>" style="display:none;" class="aclass"><%#Eval("Price")%></a> <%#Eval("Price","{0:C}") %></h6>
                                    </span><span class="colgmBottonm"><a href='#none' title='删除' style="color: #004986;"
                                        onclick='deletModule(<%#Eval("ModuleID") %>)'>&nbsp;&nbsp;&nbsp;&nbsp;删除</a>
                                    </span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>
            <div align="right" style="margin-bottom: 50px;">
                <span style="margin-right: 40px;">总计：￥<asp:Label ID="labTotalMoney" runat="server"
                    Text="<%= GetTotalMoney()%>"></asp:Label>
                </span><span style="margin-right: 40px;">
                    <%--<asp:Button ID="btnConfirm" runat="server" Text="确认支付" OnClientClick="return checksubmit();"
                        OnClick="btnConfirm_Click" />--%>
                    <input type="button" id="btntest" value="生成订单" />
                  <%--  <img src="Images/zf.jpg" alt="确定购买，生成订单"  id="btntest" />--%>
                </span>
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
