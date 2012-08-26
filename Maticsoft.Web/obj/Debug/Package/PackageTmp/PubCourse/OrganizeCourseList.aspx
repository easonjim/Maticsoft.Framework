<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="OrganizeCourseList.aspx.cs" Inherits="Maticsoft.Web.PubCourse.OrganizeCourseList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
<script type="text/javascript">
        $(function () {

            $("[id$='lbEditPic']").click(function () {
                window.location = "/PublishCourse/CourseThumbnai.aspx?courseId=" + <%=cid %> + "&ReturnUrl=" + $("[id$='hfRuturnUrl']").val();
            });

            $("[id$='btnSava']").click(function () {
                if(!$("[id$='txtModuleName']").val())
                {

                }
            });
        });
    </script>
    <script src="../Admin/js/popup_layer.js" type="text/javascript"></script>
    <link href="../css/core.css" rel="stylesheet" type="text/css" />
    <style type="text/css">     
        .txtCss{width: 450px; height: 110px;margin-left: 85px; margin-top: -30px;}
        .txtname{width:240px;margin-left:1px;}
        
        
 .corSend{margin:0;padding:0;}
.corSend .sendBox{width:100%;}
.sendBox .sendTop{width:640px;height:168px;margin-top:10px;margin-left:35px;}
.sendTop .sdtop{height:35px;}
.partTop ul,.sendTop ul{width:100%px;margin:0;padding:0;margin-top:10px;}
.partTop ul li,.sendTop ul li{float:left;}
.partTop ul li.partliL,.sendTop ul li.sendliL{width:98px;height:110px;text-align:center;}
.partliL img,.sendliL img{width:90px;height:68px;border:1px solid #E9E9E9;padding:1px;}
.partliL span,.sendliL span{display:block;margin-top:5px;}
.partliL span a,.sendliL span a{color:#004B85;}
.partTop ul li.partliR,.sendTop ul li.sendliR{width:350px;height:50px;margin-left:10px;}
.partliR h3,.sendliR h3{color:#004885;height:25px;}
.partliR p,.sendliR p{color:#888;}
.sendBox .cursystem{width:640px;margin-left:18px;margin-bottom:10px;}

.leaUP{margin-left:55px;}
.leaUP .leaUcont,.leaUP .leaUtext{float:left;}
.leaUP .leaUtext{font-weight:bold;color:#323232;}
.leaUP .leaUcont{margin:0;padding:0;margin-left:0px;}
.leaUcont .lrUc{width:640px;border:1px solid #E7E7E7;}
.leaUcont .lrUcs{width:640px;height:330px; border:1px solid #E7E7E7;}
.lrUcs .firsts{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;}
.leaUcont .lrUcsUrl{width:640px;height:445px; border:1px solid #E7E7E7;}
.lrUcsUrl .firsts{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hfRuturnUrl" value="" runat="server">
<input type="hidden" id="pageInfo" value="9" />
<!-- start main -->
<div class="main">

<!-- start input10 -->
<div class="input10 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>线下课程</strong> > <strong>发送邀请链接</strong></div>
<h2>发送邀请链接</h2>
<div class="padding" style="padding-bottom:0px;">
<ul>
<li class="tit"><img id="CourseThumbnai" runat="server" src="../images/none.gif"  width="170" height="113" />
<strong><asp:Label ID="labCourseName" runat="server" Text=""></asp:Label></strong>
<p>组织者：Game Theory<br />
分类：商场职场>实战<br />
机构：个人<br />
预定价格总计：<%=price %>
</p>
</li>
<li><a  id="lbEditPic" href="javascript:void(0)">修改课程缩略图</a></li>
<li style="border-top:1px dotted #ccc;margin-top:10px;padding-top:10px;"><span>&nbsp;</span><%--<input name="" type="button"  class="button18"/>--%></li>
</ul>
</div>
<!--发送邀请连接Send invitation connection-->
<div class="dis" id="tbc_010">
<div class="corSend">
<div class="sendBox">
<div class="cursystem">                            
<asp:Label ID="ErrorMsg" runat="server" Text='未找到用户，请确认此用户为站内用户！' ForeColor="Red" Visible="false"></asp:Label>
								
<div class="leaUP">
<div id="LocalUp" class="lrUcs"  style="height:230px;border:1px solid #E7E7E7;" runat="server">
<div class="firsts"><h3>课程体系：</h3></div>
<div class="basicRight">
<p style="margin-top:8px;margin-left:18px;">
<span class="Tlmar" style="margin-left:0px;">&nbsp;&nbsp;&nbsp;节标题：</span>
<asp:TextBox id="txtModuleName" runat="server" MaxLength="300"  CssClass="txtname"/>
</p>
<p style="margin-left:18px;margin-top:10px;">										    
<span class="Tlmar"  style="margin-bottom:88px;">章节信息：</span>
</p>
<p  style="margin-top:18px;">
<span>
<asp:TextBox ID="txtDescription" runat="Server" TextMode="MultiLine" MaxLength="1000" CssClass="txtCss"></asp:TextBox>
</span>
</p>
<p style="margin-left:490px;margin-top:18px;">			
<asp:Button ID="btnSava" runat="Server" Text="保 存" onclick="btnSava_Click" />
</p>
</div>
</div>
<br />
<asp:GridView ID="GridView_ModuleList" runat="server" AutoGenerateColumns="False" 
EnableModelValidation="True"  OnRowCommand="GridView_ModuleList_RowCommand" 
DataKeyNames="CourseID,ModuleID" OnRowDataBound="GridView_ModuleList_RowDataBound" 
OnRowEditing="GridView_ModuleList_RowEditing" OnRowDeleting="GridView_ModuleList_RowDeleting" CssClass="sendtable" Width="585px">
<Columns>
<asp:BoundField DataField="ModuleIndex" HeaderText="小节" ControlStyle-CssClass="sendtoth" />
<asp:TemplateField HeaderText="名称" >
<ItemTemplate>
<asp:Label ID="lblModuleName" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="描述">
<ItemTemplate>
<asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField >
<asp:TemplateField HeaderText="价格">
<ItemTemplate>
<asp:Label ID="lblPrice" runat="server" Text='<%# Bind("ModulePrice") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField >
<asp:TemplateField HeaderText="邀请"  >
<ItemTemplate>
<asp:Label ID="lblStatsu" runat="server" Text='<%#Eval("Status") %>' Visible="false"></asp:Label>
<div id="emample9" onclick='GetParament(<%# Eval("UserID") %>,<%# Eval("ModuleID") %>)' style="display:block;border:1px solid #999;color:#333;cursor:pointer;float:left"> 
<%#ModuleStatus(Eval("ModuleID"), Eval("Status"))%>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False" HeaderText="邀请用户">
<ItemTemplate>
<%#InviteUser(Eval("ModuleId"))%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"  HeaderText="编辑">
<ItemTemplate>
<asp:LinkButton ID="LinkButton_Edit" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
<asp:LinkButton ID="LinkButton_Del" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center" 
CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" 
LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页" 
CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="1" 
OnPageChanged="AspNetPager1_PageChanged">
</webdiyer:AspNetPager></div>
<div id="blk9" class="blk" style="display:none" > 
<div class="head"><div class="head-right"></div></div> 
<div class="main"> 
<h2>邀请教师</h2> 
<a href="javascript:void(0);" id="close9" class="closeBtn">关闭</a> 
<ul> 
<li>
<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Text="站内用户" Value="0" Selected="True"></asp:ListItem>
<asp:ListItem Text="站外用户" Value="1"></asp:ListItem>
</asp:RadioButtonList>
</li>
</ul>
<div id="show1" style="margin-left:20px;vertical-align:top">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
<tr>
<td style="width:20%">
<span style="width:100px">用户名：</span>
</td>
<td>
<asp:TextBox ID="txtUserName" runat="Server" Width="350px" MaxLength="50"></asp:TextBox><br />
<asp:Label ID="lblUserName" runat="server" Text='用户名不能为空！' ForeColor="Red" style="display:none"></asp:Label>
</td>
</tr>
<tr>
<td colspan="2" style="height:20px">
</td>
</tr>
<tr>
<td>
<span style="width:100px">内容：</span>
</td>
<td>
<asp:TextBox ID="txtContent" runat="Server" TextMode="MultiLine" Width="350px" Height="100px"></asp:TextBox>
</td>
</tr>
</table>
</div>
<div id="show2" style="display:none;margin-left:20px; vertical-align:top">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
<tr>
<td style="width:20%">
<span style="width:100px">邮箱：</span>
</td>
<td>
<asp:TextBox ID="txtUserEmail" runat="Server" Width="350px" MaxLength="200"></asp:TextBox><br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  
ControlToValidate="txtUserEmail"  runat="server" ErrorMessage="不是正确的邮箱格式！" 
ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
<asp:Label ID="lblUserEmail" runat="server" Text='邮箱不能为空！' ForeColor="Red" style="display:none"></asp:Label>
</td>
</tr>
<tr>
<td colspan="2" style="height:20px">
</td>
</tr>
<tr>
<td>
<span style="width:100px">内容：</span>
</td>
<td>
<asp:TextBox ID="txtEmailContent" TextMode="MultiLine" runat="Server" Width="350px" Height="100px"></asp:TextBox>
</td>
</tr>
</table>
</div>
<br />
<center>
<asp:Button ID="btn_SendEmail" runat="Server" Text=" 发 送 " OnClientClick="get()" />
</center>
<br />
</div> 
<div class="foot"><div class="foot-right"></div></div> 
</div>
</div>
</div>
</div>
</div>

<asp:Button ID="Button1" runat="Server" onclick="Button1_Click" style="display:none" />
<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:HiddenField ID="HiddenFieldAddresser" runat="server" />
<asp:HiddenField ID="HiddenFieldRadio" runat="server" />
<asp:HiddenField ID="HiddenField2" runat="server" />
<asp:HiddenField ID="HiddenFieldUserName" runat="server" />
<asp:HiddenField ID="HiddenFieldUserEmail" runat="server" />
<asp:HiddenField ID="HiddenFieldtxtContent" runat="server" />
<asp:HiddenField ID="HiddenFieldtxtEmailContent" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            var t9 = new PopupLayer({ trigger: ".tigger", popupBlk: "#blk9", closeBtn: "#close9", useOverlay: true, useFx: true,
                offsets: {
                    x: 100,
                    y: 300
                }
            });
            t9.doEffects = function (way) {
                if (way == "open") {
                    this.popupLayer.css({ opacity: 0.3 }).show(400, function () {
                        this.popupLayer.animate({
                            left: ($(document).width() - this.popupLayer.width()) / 2,
                            top: this.trigger.offset().top,
                            opacity: 0.8
                        }, 500, function () { this.popupLayer.css("opacity", 1) } .binding(this));
                    } .binding(this));
                }
                else {
                    this.popupLayer.animate({
                        left: this.trigger.offset().left,
                        top: this.trigger.offset().top,
                        opacity: 0.1
                    }, { duration: 500, complete: function () { this.popupLayer.css("opacity", 1); this.popupLayer.hide() } .binding(this) });
                }
            }

            $(":radio").bind("click", function () {
                if ($("[id$='RadioButtonList1_0']").attr("checked")) {
                    $("[id$='HiddenFieldRadio']").val("0");
                    $("#show1").show();
                    $("#show2").hide();
                } else {
                    $("[id$='HiddenFieldRadio']").val("1");
                    $("#show1").hide();
                    $("#show2").show();
                }
            });
        });

        function GetParament(msg, msg1) {
            $("[id$='HiddenField1']").val(msg);
            $("[id$='HiddenField2']").val(msg1);
            //测试路径，网站上线需修改
            var url = "~/Admin/Teacher/TeachUpLoadModule.aspx?UserID=" + msg + "&ModuleID=" + msg1;
            var content = $("[id$='HiddenFieldAddresser']").val() + "在陶老师发布了组织课程，邀请您添加课程小节，点击链接上传课程小节" + url;
            $("[id$='txtContent']").val(content);
            $("[id$='txtEmailContent']").val(content)
            $("[id$='HiddenFieldRadio']").val(0);
        }

        function get() {
            if ($(":radio")[0].checked) {
                if ($("[id$='txtUserName']").val() == "" || $("[id$='txtUserName']").val() == null || $("[id$='txtUserName']").val() == undefined) {
                    document.getElementById("<%= lblUserName.ClientID%>").style.display = "";
                    return;
                }
                $("[id$='HiddenFieldUserName']").val($("[id$='txtUserName']").val());
                $("[id$='HiddenFieldtxtContent']").val($("[id$='txtContent']").val());
            }
            else {
                if ($("[id$='txtUserEmail']").val() == "" || $("[id$='txtUserEmail']").val() == null || $("[id$='txtUserEmail']").val() == undefined) {
                    document.getElementById("<%= lblUserEmail.ClientID%>").style.display = "";
                    return;
                }
                $("[id$='HiddenFieldUserEmail']").val($("[id$='txtUserEmail']").val());
                $("[id$='HiddenFieldtxtEmailContent']").val($("[id$='txtEmailContent']").val());
            }
            document.getElementById('<%= Button1.ClientID%>').click();
        }

    </script>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input10 -->

</div>
<!-- end main -->
</asp:Content>
