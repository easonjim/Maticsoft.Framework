<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="UploadCourse.aspx.cs" Inherits="Maticsoft.Web.PubCourse.UploadCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css"> .leaUP{margin-top:10px;}
.leaUP .leaUcont,.leaUP .leaUtext{float:left;}
.leaUP .leaUtext{font-weight:bold;color:#323232;}
.leaUP .leaUcont{margin:0;padding:0;margin-left:0px;}
.leaUcont .lrUc{width:600px;border:1px solid #E7E7E7;}
.leaUcont .lrUcs{width:600px;height:330px; border:1px solid #E7E7E7;}
.lrUcs .firsts{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;border:none;margin-top:-10px;}
.leaUcont .lrUcsUrl{width:600px;height:445px; border:1px solid #E7E7E7;}
.lrUcsUrl .firsts{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;}
.leaUcont .lrUcsScript{width:600px;height:445px; border:1px solid #E7E7E7;}
.lrUcsScript .firsts{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;}
.leaUcont .unlrUc{display: :none;}
.lrUc .first{height:25px;background:#F5F5F5;border-bottom:1px solid #E7E7E7;padding-top:5px;padding-left:10px;}
.lrUc .lUcont{width:445px;margin-left:10px;margin-top:8px;}
.lUcont p{clear:both;}
.lUcont p span{display:block;float:left;}


        .basicRight{margin:0;padding:0;border:none;height:auto;}
        .basicRight p{clear:both;margin-top:10px;padding-top:10px;*padding-top:0;margin-left:20px;}
        .basicRight p span{display:block;float:left;}
        .basicRight p span input.dayStyle,.basicRight p span input.monStyle,.basicRight p span input.yeStyle,.basicRight p span input.trueName{width:100px;border:1px solid #E7E7E7;}
        .basicRight p span.Tlmar{margin-top:5px;margin-right:5px;}
        
        
        .setableBox{width:600px;margin:0;padding:0;border:1px solid #E7E7E7;border-top:none;background:url(../images/cline5.jpg) no-repeat;margin-top:10px;}
        .setableBox table{font-size:12px;margin:0;padding:0;margin-top:15px;}
        .setableBox table tr td.a1{width:140px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a2{width:40px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a3{width:120px;height:35px;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a4{width:104px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.b1{width:140px;height:50px;border:1px solid #e7e7e7;border-left:none;}
        .setableBox table tr td.b2{width:40px;height:50px;border:1px solid #e7e7e7;border-left:none;}
        .setableBox table tr td.b3{width:120px;height:50px;border:1px solid #e7e7e7;border-right:none;}
        .setableBox table tr td.c1{width:120px;height:50px;border-bottom:1px solid #e7e7e7;border-right:1px solid #e7e7e7;}
        .setableBox table tr td.c2{width:90px;height:50px;border-bottom:1px solid #e7e7e7;border-right:1px solid #e7e7e7;}
        .setableBox table tr td.c3{width:120px;height:50px;border-bottom:1px solid #e7e7e7;}
        .setableBox table tr td.b1 img{width:84px;height:17px;*margin-top:40px;}
        .setableBox table tr td.c3 img,.setableBox table tr td.c1 img{width:84px;height:25px;*margin-top:40px;}
        .cancle{margin-left:10px;}
    </style>
    
    <link href="/js/jquery/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet"
        type="text/css" />
    <script src="/js/jquery/jquery.uploadify-v2.1.0/swfobject.js" type="text/javascript"></script>
    <script src="/js/jquery/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"   type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#uploadify").uploadify({
            'uploader': '/js/jquery/jquery.uploadify-v2.1.0/uploadify.swf',
            'script': '/HomeIndex.aspx?Action=uploadico',
            'cancelImg': '/js/jquery/jquery.uploadify-v2.1.0/cancel.png',
            'buttonImg': '/imagesN/uploadfile.png',
            'folder': 'UploadFile',
            'queueID': 'fileQueue',
            'auto': true,
            'multi': true,
            'fileExt': '*.jpg;*.gif;*.png;*.bmp',
            'fileDesc': 'Image Files (.JPG, .GIF, .PNG)',
            'queueSizeLimit': 1,
            'sizeLimit': 1024 * 1024 * 10,
            'onInit': function () {
            },

            'onSelect': function (e, queueID, fileObj) {
            },
            'onComplete': function (event, queueId, fileObj, response, data) {
                var jsonData = eval("(" + response.split('|')[1] + ")");
                switch (jsonData.Status) {
                    case "OK":
                        //将获取的值放在隐藏隐藏域中，供后台调用
                        $("[id$='CourseThumbnai']").attr("src", jsonData.SavePath);
                        $("[id$='HiddenField_ICOPath']").val(jsonData.SavePath);
                        break;
                    case "Failed":
                        alert(jsonData.ErrorMessage);
                        break;
                }
            }
        });
    });
</script>

    <script type="text/javascript">
        $(function () {
            $("#a_3").removeClass("aa").addClass("bb");
            $("#tb_3").removeClass("aa").addClass("bb");

            $("[id$='lbEditPic']").click(function () {
                window.location = "/PubCourse/CourseAvatarEdit.aspx?courseId=" + $("[id$='hfCourseID']").val() + "&ReturnUrl=" + $("[id$='hfRuturnUrl']").val();
            });

            $("[id$='fileVideoNew']").change(function () {
                $("[id$='hfChoseCourse']").val("true");
            });
            $("[id$='btnUp']").click(function () {
                if ($("[id$='txtSequence']").val() == "") {
                    alert("请填写章节编号！");
                    return false;
                }
                if ($("[id$='txtMName']").val() == "") {
                    alert("请填写章节名称！");
                    return false;
                }
                if ($("[id$='hfChoseCourse']").val() == "" && $("[id$='labOldVideo']").val() == "") {
                    alert("请先选择视频文件");
                    return false;
                }
            });


            $("[id$='btnUrlSave']").click(function () {
                if ($("[id$='txtUrlSeq']").val() == "") {
                    alert("请填写章节编号！");
                    return false;
                }
                if ($("[id$='txtUrlMName']").val() == "") {
                    alert("请填写章节名称！");
                    return false;
                }

                if ($("[id$='txtVideoContent']").val() == "") {
                    alert("请填写视频地址！");
                    return false;
                }

                if ($("[id$='txtTimeHour']").val() == "" && $("[id$='txtMinute']").val() == "" && $("[id$='txtSeconds']").val() == "") {
                    alert("请输入正确的时长");
                    return false;
                }
            });


            $("[id$='btnHtmlSave']").click(function () {
                if ($("[id$='txtCodeSeq']").val() == "") {
                    alert("请填写章节编号！");
                    return false;
                }
                if ($("[id$='txtCodeTitle']").val() == "") {
                    alert("请填写章节名称！");
                    return false;
                }

                if ($("[id$='txtHtmlCode']").val() == "") {
                    alert("请填写Html代码！");
                    return false;
                }

                if ($("[id$='txtCodeHour']").val() == "" && $("[id$='txtCodeMinute']").val() == "" && $("[id$='txtCodeSeconds']").val() == "") {
                    alert("请输入正确的时长");
                    return false;
                }
            });
        });

        //防止重复提交表单功能
        var checkSubmitFlg = false;
        function checkSubmit() {
            if (!checkSubmitFlg) {
                // 第一次提交
                checkSubmitFlg = true;
                return true;
            } else {

                //重复提交
                alert("请勿重复提交");
                return false;
            }
        }
    </script>
    <!--SWF图片上传结束-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" id="hfCourseID" value="" runat="server">
    <input type="hidden" id="hfChoseCourse" value="" runat="server">
    <input type="hidden" id="hfRuturnUrl" value="" runat="server">
    <input type="hidden" id="hfMid" value="" runat="server">
<input type="hidden" id="pageInfo" value="2" />
<!-- start main -->
<div class="main">

<!-- start input3 -->
<div class="input3 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>公开课</strong> > <strong>上传课程</strong></div>
<h2>上传课程</h2>
<div class="padding">
<ul>
<li class="tit"><img src="images/007.gif" id="CourseThumbnai" runat="server" width="170" height="113" />
<strong>
    <asp:Literal ID="litCourseName" runat="server"></asp:Literal></strong>
<p>教师：<asp:Literal ID="litTeacherName" runat="server"></asp:Literal><br />
分类：商场职场>实战<br />
机构：<asp:Literal ID="litDept" runat="server"></asp:Literal></p>
</li>
<li><a id="lbEditPic" href="javascript:void(0)">修改课程缩略图</a></li>
<li><span>课程上传：</span>
<asp:RadioButtonList ID="radl" runat="server" AutoPostBack="True"   RepeatDirection="Horizontal"  onselectedindexchanged="radl_SelectedIndexChanged"  OnClientClick="return checkSubmit();"  >
<asp:ListItem Value="0" Selected="True">本地视频</asp:ListItem>
<asp:ListItem Value="1">Flash地址</asp:ListItem>
<asp:ListItem Value="2">Html代码</asp:ListItem>
</asp:RadioButtonList></li><li>
<div class="upload" style="width:600px;">
						<div class="leaUP">
                            <div class="leaUcont">
                                <div id="LocalUp" class="lrUcs"  style="height:170px;" runat="server">
                                    <div class="firsts">本地上传：(单个视频最大50M)</div>
                                    <div class="basicRight">
                                        <p style="margin-top:8px;margin-left:18px;">
                                            <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序号：
                                                <input id="txtSequence" type="text" runat="server" style="width:40px;margin-top:-16px;margin-left:90px;"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" /></span>
                                            <span class="Tlmar" style="margin-left:85px;">&nbsp;&nbsp;&nbsp;&nbsp;节标题：</span>
                                            <input id="txtMName" type="text"  style="width:240px;margin-left:1px;margin-top:3px;" runat="server" />
                                        </p>
                                        <p style="margin-left:18px;">					
										    <span class="Tlmar">选择视频：</span>
										    <span>
                                                <asp:FileUpload ID="fileVideoNew" runat="server" Width="400px"   />
                                                <input type="hidden" id="labOldVideo" value="" runat="server">
                                            </span>
									    </p>
                                        <p style="margin-left:18px;">			
										    <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;标签：</span>
										    <span><input type="text" id="txtTags" runat="server" style="width:450px;"/></span>
									    </p>
                                        <p style="margin-left:18px;">			
                                            <asp:Button ID="btnUp" runat="server" Text="上传" Width="90px"  onclick="btnUp_Click" OnClientClick="return checkSubmit();"  />
                                            <asp:Button ID="btnCancle" runat="server" Text="取消" Width="90px"     OnClientClick="return checkSubmit();"  CssClass="cancle" Visible="false"  onclick="btnCancle_Click"   />
									    </p>
                                    </div>
                                </div>

                                <div id="divUrl" class="lrUcsUrl"   style="height:360px;margin-top:-10px;" runat="server">
                                    <div class="firsts">视频地址：(支持优酷、酷六、土豆、网易、新浪正确的Flash地址)</div>
                                    <div class="basicRight">                                        
                                        <p style="margin-top:8px;margin-left:18px;">
                                            <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序号：
                                                <input id="txtUrlSeq" type="text" runat="server" style="width:40px;margin-top:-16px;margin-left:90px;"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))"  /></span>
                                            <span class="Tlmar" style="margin-left:85px;">&nbsp;&nbsp;&nbsp;&nbsp;节标题：</span>
                                            <input id="txtUrlMName" type="text"  style="width:240px;margin-left:1px;" runat="server" />
                                        </p>
                                        <p style="margin-left:18px;">										    
                                            <span class="Tlmar"  style="margin-bottom:88px;">视频地址：</span>
                                        </p>
									    <p  >
										    <span><textarea id="txtVideoContent" runat="server" style="width:450px;height:80px;margin-left:85px;margin-top:-110px;"></textarea> </span>
									    </p>
									    <p style="margin-left:18px;">
										    <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;标签：</span>
										    <span><input type="text" id="txtUrlTags" runat="server"  style="width:450px;"/></span><p>         
                                        <p style="margin-top:8px;margin-left:18px;">
                                            <span class="Tlmar">课程时长：</span>
                                            <input id="txtTimeHour" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtMinute" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtSeconds" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />(时:分:秒)
                                        </p>                                   
                                        <p style="margin-left:18px;">
                                            <asp:Button ID="btnUrlSave" runat="server" Text="添加" Width="90px"   OnClick="btnUrlSave_Click"   OnClientClick="return checkSubmit();"  />
									    </p>
                                    </div>
                                </div>
                                <div id="divScript" class="lrUcsScript"  style="height:340px;margin-top:-10px;" runat="server">
                                    <div class="firsts">Html代码：(支持优酷、酷六、土豆、网易、新浪正确的Html代码)</div>
                                    <div class="basicRight">
                                        <p style="margin-top:8px;margin-left:18px;">
                                            <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序号：
                                                <input id="txtCodeSeq" type="text" runat="server" style="width:40px;margin-top:-16px;margin-left:90px;"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))"  /></span>
                                            <span class="Tlmar" style="margin-left:85px;">&nbsp;&nbsp;&nbsp;&nbsp;节标题：</span>
                                            <input id="txtCodeTitle" type="text"  style="width:240px;margin-left:1px;" runat="server" />
                                        </p>
                                        <p style="margin-left:18px;">										    
                                            <span class="Tlmar"  style="margin-bottom:88px;">Html代码：</span>
                                                <asp:Label ID="labHtmlMid" runat="server" Text="" Visible="false"></asp:Label>
                                        </p>
									    <p  >
										    <span><textarea id="txtHtmlCode" runat="server" style="width:450px;height:80px;margin-left:85px;margin-top:-110px;"></textarea> </span>
									    </p>
                                        <p style="margin-left: 18px;margin-top:-30px;">
                                            <span class="Tlmar">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;标签：</span> 
                                            <span><input type="text" id="txtCodeTags" runat="server" style="width:450px;" /></span>
                                        <p>
                                        <p style="margin-top:8px;margin-left:18px;">
                                            <span class="Tlmar">课程时长：</span>
                                            <input id="txtCodeHour" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtCodeMinute" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />:
                                            <input id="txtCodeSeconds" type="text"  style="width:40px;text-align:center;" value="0"  runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />(时:分:秒)
                                        </p>
                                        <p style="margin-left:18px;">			
                                            <asp:Button ID="btnHtmlSave" runat="server" Text="保存"  Width="90px"    onclick="btnHtmlSave_Click" OnClientClick="return checkSubmit();" />
									    </p>
                                    </div>
                                </div>
                            </div>
                            
                    <div class="setableBox" >
									<table border="0" cellspacing="0" cellpadding="0"><%--style="<%=strDivClass %>"--%>
										<tr>
											<td align="center" valign="middle" class="a2">序号</td>
											<td align="center" valign="middle" class="a1">节标题</td>
											<td align="center" valign="middle" class="a4">时长</td>
											<%--<td align="center" valign="middle" class="a4">价格</td>--%>
											<td align="center" valign="middle" class="a1">标签</td>
											<td align="center" valign="middle" class="a1">上传时间</td>
											<td align="center" valign="middle" class="a3">操作</td>
										</tr>
                                        <asp:Repeater ID="Repeater1" runat="server" 
                                            onitemcommand="Repeater1_ItemCommand">
                                            <ItemTemplate >
										        <tr>
											        <td align="center" valign="middle" class="b2"><%#Eval("Sequence")%></td>
											        <td align="center" valign="middle" class="b1"><%#Eval("ModuleName")%></td>
											        <td align="center" valign="middle" class="b2"><%#ConvertTimme(Eval("TimeDuration")) %></td>
											        <%--<td align="center" valign="middle" class="b2"><%#Eval("Price", "{0:C}")%></td>--%>
											        <td align="center" valign="middle" class="b1"><%#Eval("Tags")%></td>
											        <td align="center" valign="middle" class="b1"><%#Eval("CreatedDate")%></td>
											        <td align="center" valign="middle" class="b3">
                                                        <asp:Label ID="labModuleID" runat="server" Text='<%#Eval("ModuleID")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labCourseID" runat="server" Text='<%#Eval("CourseID")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labSeq" runat="server" Text='<%#Eval("Sequence")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labModuleName" runat="server" Text='<%#Eval("ModuleName")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labDesc" runat="server" Text='<%#Eval("Description")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labVideo" runat="server" Text='<%#Eval("VideoContent")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labTime" runat="server" Text='<%#Eval("TimeDuration")%>' Visible="false"></asp:Label>           
                                                        <asp:Label ID="labTags" runat="server" Text='<%#Eval("Tags")%>' Visible="false"></asp:Label>                                                      
                                                    <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandArgument="btnedit" />
                                                    <asp:Button ID="btnDel" runat="server" Text="删除" CommandArgument="btndel" />
                                                    </td>
										        </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <caption>
                                            &nbsp;
                                        </caption>
									</table>
								</div>
					</div>
</div>
</li>
<li><span>&nbsp;</span><asp:Button ID="btnBack" runat="server" class="button15"  />
                        <asp:Button ID="btnNext" runat="server" class="button14" 
        onclick="btnNext_Click1" /></li>
</ul>
</div>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input3 -->

</div>
<!-- end main -->
</asp:Content>
