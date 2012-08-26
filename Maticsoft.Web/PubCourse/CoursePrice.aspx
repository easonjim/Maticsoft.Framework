<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="CoursePrice.aspx.cs" Inherits="Maticsoft.Web.PubCourse.CoursePrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     .cPsebox{width:600px;height:auto;overflow:hidden;margin-left:25px;margin-top:10px;}
.cPsebox .cPtableall{margin:0;padding:0;}
/*------table课程定价样式start------*/
.cPtable{width:600px;border-collapse:collapse;}
.cPtable td, #cPtable th{font-size:12px;border:1px solid #98bf21;padding:8px 7px 0 7px;}
.cPtable th{font-size:12px; text-align:center; padding-top:8px; padding-bottom:8px;background-color:#EBF0F4;color:#343233;}
.cPtable tr td{color:#888;background-color:#fff;border:none;}
.cPtable th.cPtoth{width:100px;border-left:none;}
.cPtable th.cPttth{width:300px;border-left:none;}
.cPtable th.cPtrth{width:150px;}
.cPtable tr td p{margin:0;padding:0;}.cPprice{width:600px;margin-top:5px;}
.cPprice .price{width180px;height:90px;float:right;}
.price h2{display:block;float:right;color:#004A84;}
.price p{clear:both;}
.price p.prit{padding-top:8px;}
.price p span{display:block;float:right;}
.price p span input.priN{width:40px;border:1px solid #E7E7E7;margin:0 5px;padding:3px;}
.price p span.prill{margin-top:5px;}
.price p span.prilb{color:#9AB6CE;}
 .cpBottom{width:100%;margin-top:10px;border-top:1px solid #E7E7E7;}
.cpBottom .cpBcont{width:600px;height:200px;margin-top:18px;margin-left:35px;}
.cpBcont h3{height:25px;}
.cpBcont .cpBcc{width:100%;height:120px;}
.cpBcc .sxs{float:left;*margin-top:5px;}
.cpBcc ul{margin:0;padding:0;width:450px;float:left;margin-left:10px;}
.cpBcc ul li{line-height:20px;}
.cpBcc ul li input.cpByj{margin-right:3px;}
.cpBcc ul li input.cpBjz{width:50px;border:1px solid #E7E7E7;margin:0 5px;}
.cpBcont .cpBcb{width:100%;height:30px;margin-top:5px;}
.cpBcb span{display:block;float:left;}
.cpBcb span.cpbmar{margin-left:80px;}
/*------table课程定价样式end------*/
    </style>
    
    <script src="../Admin/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#a_5").removeClass("aa").addClass("bb");
            $("#tb_5").removeClass("aa").addClass("bb");


            $("[id$='imgBtnPreview']").click(function () {

                var totalprice = parseFloat($("#totleMoney").text());
                var pubPrice = parseFloat($("[id$='priceName']").val());
                if (totalprice < pubPrice) {
                    alert("打包价不能超过合计价格！");
                    return false;
                }


                if (pubPrice < 0) {
                    alert("请输入正确的价格！");
                    return false;
                }

                if ($("[id$='rbExpTime']").attr("checked")) {
                    if ($("[id$='txtExpTime']").val() == "") {
                        alert("请输入正确有效时间！");
                        return false;
                    }
                }
                if ($("[id$='priceName']").val() == "") {
                    alert("请输入课程发布价格！");
                    return false;
                }
                if ($("[id$='rbSum']").attr("checked")) {
                    if ($("[id$='limitSum']").val() == "") {
                        alert("请输入正确的观看次数！");
                        return false;
                    }
                }
            });

            $("[id$='btnNext']").click(function () {
                if ($("[id$='hfCourseID']").val() == "-1") {
                    alert("请先填写你要发布的课程信息！");
                    return false;
                }
                if ($("[id$='priceName']").val() == "") {
                    alert("请输入课程发布价格！");
                    return false;
                }
                if ($("[id$='rbSum']").attr("checked")) {
                    if ($("[id$='limitSum']").val() == "") {
                        alert("请输入正确的观看次数！");
                        return false;
                    }
                }
                if ($("[id$='rbExpTime']").attr("checked")) {
                    if ($("[id$='txtExpTime']").val() == "") {
                        alert("请输入正确有效时间！");
                        return false;
                    }
                }
            });



            $("[id$='priceName']").blur(function () {
                var Mprice = $("[id$='priceName']").val();
                var reg = /\d{1,3}$/;
                if (reg.test(Mprice)) {
                    var totalprice = $("#totleMoney").text();
                    var pubPrice = parseFloat($("[id$='priceName']").val());

                    if (pubPrice < 0) {
                        alert("请输入正确的价格！");
                        return false;
                    }

                    if (totalprice > pubPrice) {
                        $("[id$='zk']").text(MathRound(MathRound((pubPrice / totalprice)) * 100));
                    }


                    if (totalprice < pubPrice) {
                        $("[id$='zk']").text('0.00');
                        alert("打包价不能超过合计价格！");
                    }

                    if (totalprice == pubPrice) {
                        $("[id$='zk']").text('0.00');
                    }
                }
                else {
                    //不是数字
                    alert("请输入正确的金额!");
                }
            });

        });

        function changeBar(operator, ids) {
            var Mprice = parseFloat($("#txtPrice" + ids).val());

            if (operator == "+") {
                //进行加一
                if ((parseFloat(Mprice) + 1) > 99999) {
                    alert("最高金额99999!");
                }
                else {
                    Mprice++;
                }
            }
            else {
                //进行减1
                if (parseFloat(Mprice) - 1 < 0) {
                    alert("请输入正确的金额，免费为0!");
                }
                else {
                    Mprice--;
                }
            }
            $.post("/PublishCourse/SetPrice.aspx", { "action": "change", "moduleId": ids, "price": Mprice }, function (s) {
                if (s == "Succ") {
                    //进行赋值
                    $("#txtPrice" + ids).val(Mprice.toString());

                    calculateMoney();
                }
                else {
                    alert(s);
                }
            }, "text");
        }


        //得到焦点时的事件
        var onFocusBookCount = 0;
        function changeTxtOnFocus(control) {
            onFocusBookCount = control.value;
        }

        //失去焦点时的事件
        function changeTextOnBlur(control, ModuleID) {
            var Mprice = control.value;
            var reg = /\d{1,3}$/;
            if (reg.test(Mprice)) {
                //是1-3位的数字
                if (Mprice < 0 || Mprice > 99999) {
                    alert("输入的金额有误！");
                    control.value = onFocusBookCount;
                }
                else {//数字合法,更新到数据库
                    $.post("/PublishCourse/SetPrice.aspx", { "action": "change", "moduleId": ModuleID, "price": Mprice }, function (s) {
                        if (s == "Succ") {
                            //进行赋值
                            calculateMoney();
                        }
                        else {
                            alert(s);
                        }
                    }, "text");
                }
            }
            else {
                //不是数字
                alert("请输入正确的金额!");
                control.value = onFocusBookCount;
            }
        }

        function calculateMoney() {
            var totalMoney = 0;
            var FirstPrice = 0;
            $(".rptclass:eq(0)").each(function () {
                totalMoney = parseFloat($(this).find("input").val());
            });
            $(".rptclass:gt(0)").each(function () {
                var count = $(this).find("input").val();
                //alert(count);
                totalMoney += parseFloat(count); // +parseFloat(FirstPrice);
            }
			);
            $("#totleMoney").text(MathRound(totalMoney));
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" id="hfCourseID" value="" runat="server">
<input type="hidden" id="pageInfo" value="4" />
<!-- start main -->
<div class="main">

<!-- start input5 -->
<div class="input5 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>公开课程</strong> > <strong>课程定价</strong></div>
<h2>课程定价</h2>
<div class="padding" style="padding-left:19px;margin-top:0px;">
<ul>
<li><span>课程名称：</span><strong><asp:Literal ID="litCName" runat="server"></asp:Literal></strong></li>
<div class="cPsebox">
<div class="cPtableall">
<table class="cPtable">
<tr>
<th class="cPtoth">
节序号
</th>
<th class="cPttth">
节名称
</th>
<th class="cPtrth">
价格
</th>
</tr>
<asp:Repeater ID="rptPrice" runat="server">
<ItemTemplate>
<tr class='rptclass'>
<td>
第
<%#Eval("ModuleIndex")%>
节
</td>
<td>
<p>
<%#Eval("ModuleName")%></p>
</td>
<td align="center">
<a href='#none' title='减一' style='margin-right: 2px;'>
<img src="../../Images/bag_close.gif" width="9" height="9" border='none' style='display: inline' onclick='changeBar("-",<%#Eval("ModuleID") %>)' /></a>
<input type="text" id='<%#Eval("ModuleID","txtPrice{0}") %>' style="width: 40px;  text-align: right;" value='<%#Eval("Price","{0:0.00}")%>' onkeydown='if(event.keyCode == 13) event.returnValue = false' onfocus='changeTxtOnFocus(this);' onblur="changeTextOnBlur(this,<%#Eval("ModuleID") %>);" />
<a href='#none' title='加一' style='margin-left: 2px;'>
<img src='../../images/bag_open.gif' width="9" height="9" border='none' style='display: inline' onclick='changeBar("+",<%#Eval("ModuleID") %>)' /></a>
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
<div class="cPprice">

<div class="price">
合计价格：<span id="totleMoney"><%=TotalMoney %></span>元
<p class="prit">
<span class="prill">元</span> <span>
<input type="text" id="priceName" runat="server" class="priN" value="" style="text-align: right;" /></span>
<span class="prill">打包价格:</span>
</p>
<p class="prit">
<span class="prilb">折扣<a id="zk" style="color: #9AB6CE;">0.00</a> %</span></p>
</div>
</div>
</div>

<div class="cpBottom">
<div class="cpBcont">
<h3>
课程有效：</h3>
<div class="cpBcc">
<div class="sxs">
设置可观看时限设定为：</div>
<ul>
<li>
<input type="radio" id="rbExpTime" runat="server" name="time" class="cpByj" checked="true" />
截至到
<input type="text" id="txtExpTime" runat="server" name="jz" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
</li>
<li>
<input type="radio" id="rbForever" runat="server" name="time" class="cpByj" />&nbsp;永久</li>
<li>
<input type="radio" id="rbSum" runat="server" name="yj" class="cpByj" checked="true" />
限制次数为：
<input type="text" id="limitSum" runat="server" name="cs" class="cpBjz" value="50" />
次 </li>
<li>
<input type="radio" id="rbNolimit" runat="server" name="yj" class="cpByj" />&nbsp;无限制</li>
</ul>
</div>
</div>
</div>
<li><span>&nbsp;</span><asp:Button ID="btnBack" runat="server" class="button15"    onclick="btnBack_Click"    />      <asp:Button ID="BtnPreview" runat="server" class="button17"   onclick="BtnPreview_Click"  />　<asp:Button ID="btnNext" runat="server"    class="button14" onclick="btnNext_Click"/></li>
</ul>
</div>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input5 -->

</div>
<!-- end main -->
</asp:Content>
