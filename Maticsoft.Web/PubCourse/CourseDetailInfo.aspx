<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="CourseDetailInfo.aspx.cs" Inherits="Maticsoft.Web.PubCourse.CourseDetailInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
    .opentableBox{width:640px;margin:0;padding:0;border:1px solid #E7E7E7;border-top:none;background:url(../images/cline5.jpg) no-repeat;*background:url(../images/cline4.jpg) no-repeat;margin-left:40px;margin-bottom:10px;}
.opentableBox table{font-size:12px;margin:0;padding:0;margin-top:10px; }
.opentableBox table tr td.a1{width:120px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
.opentableBox table tr td.a2{width:70px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
.opentableBox table tr td.a3{width:120px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
.opentableBox table tr td.a4{width:120px;height:35px;background:#F5F5F5;color:#004986;font-weight:bold;}
.opentableBox table tr td.b1{width:120px;height:75px;border:1px solid #e7e7e7;border-bottom:none;border-left:none;}
.opentableBox table tr td.b2{width:70px;height:75px;border:1px solid #e7e7e7;border-bottom:none;border-left:none;}
.opentableBox table tr td.b3{width:120px;height:75px;border:1px solid #e7e7e7;border-right:none;border-bottom:none;*padding-top:30px;}
.opentableBox table tr td.b4{width:120px;height:75px;border:1px solid #e7e7e7;border-left:none;border-right:none;border-bottom:none;*padding-top:30px;}
.opentableBox table tr td.c1{width:120px;height:75px;border-bottom:1px solid #e7e7e7;border-right:1px solid #e7e7e7;}
.opentableBox table tr td.c2{width:70px;height:75px;border-bottom:1px solid #e7e7e7;border-right:1px solid #e7e7e7;}
.opentableBox table tr td.c3{width:120px;height:75px;border-bottom:1px solid #e7e7e7;*padding-top:30px;}
.opentableBox table tr td.b1 img{width:84px;height:17px;*margin-top:40px;}
.opentableBox table tr td.c3 img,.opentableBox table tr td.c1 img{width:84px;height:25px;*margin-top:40px;}
.openRe .openPage,.opencontentin .openPage{width:750px;*width:760px;height:25px;border-top:1px solid #E7E7E7;margin-top:30px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input type="hidden" runat="server" id="hfCid" />
<input type="hidden" id="pageInfo" value="10" />
<!-- start main -->
<div class="main">

<!-- start input11 -->
<div class="input8 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>线下课程</strong> > <strong>课程详细信息</strong></div>
<h2>课程详细信息</h2>


						<div class="openRe">
                            <div class="opentableBox">
									<table border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td align="center" valign="middle" class="a2">节&nbsp;&nbsp;次</td>
											<td align="center" valign="middle" class="a1">节标题</td>
											<td align="center" valign="middle" class="a2">章节简介</td>
											<%--<td  align="center" valign="middle" class="a2">参与老师</td>--%>
                                            <%=addtd() %>
											<td align="center" valign="middle" class="a2">价&nbsp;&nbsp;格</td>
											    <td align="center" valign="middle" class="a2">关键字</td>
											<td align="center" valign="middle" class="a1">发布时间</td>
											<td align="center" valign="middle" class="a2">视频状态</td>
											    <td align="center" valign="middle" class="a3">操&nbsp;&nbsp;作</td>
										</tr>
                                        <asp:Repeater ID="Repeater_PubCourse" runat="server" 
                                                        onitemcommand="Repeater_PubCourse_ItemCommand" 
                                                        onitemdatabound="Repeater_PubCourse_ItemDataBound" >
                                                    <ItemTemplate>
		                                            <tr>
                                                        <td align="center" valign="middle" class="b2"><%#Eval("ModuleIndex")%></td>
											            <td align="center" valign="middle" class="b2"><a href="/show.aspx?cid=<%=CourseIdStr %>" style="color:#004986;"><%#Eval("ModuleName")%></a></td>
											            <td align="center" valign="middle" class="b1"><%#ModuleDes(Eval("Description").ToString()) %></td>
											            <td id="teach" runat="server" align="center" valign="middle" class="b2"><%#Eval("TrueName")%></td>
											            <td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}")%></td>
											            <td align="center" valign="middle" class="b2"><%#SplitTag(Eval("Tags").ToString()) %></td>
											            <td align="center" valign="middle" class="b2"><%#Eval("CreatedDate")%></td>
											            <td align="center" valign="middle" class="b2"><%#GetModuleStatus(Eval("Status"))%></td>
											            <td align="center" valign="middle" class="b1">
                                                        <asp:Label ID="labMId" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="labUid" runat="server" Text='<%#Eval("CreatedUserID") %>' Visible="false"></asp:Label>
                                                            <asp:Button ID="btnEdit" runat="server" CommandArgument="btnModify" Text="编辑" />
                                                            <asp:Button ID="btnClose" runat="server" CommandArgument="Close" Text="关闭" />
                                                        </td>
		                                            </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
										</table>
								</div>
                            <div id="detailInfo" runat="server">
                                <h2>编辑信息</h2>
                                <div class="openRe" style="margin-left:20px;vertical-align:top">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                	                    <tr>
                		                    <td style="width:20%" align="right">
                                                <span style="width:100px">节&nbsp;标&nbsp;题：</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtModuleName" runat="Server" Width="350px" MaxLength="50"></asp:TextBox>
                                                <asp:Label ID="labMod" runat="server" Text="" Visible="false"></asp:Label>
                                                <br />
                                            </td>
                	                    </tr>
                                        <tr>
                                            <td colspan="2" style="height:20px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span style="width:100px">章节简介：</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContent" runat="Server" TextMode="MultiLine" Width="350px" Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height:20px">
                                            </td>
                                        </tr>
                	                    <tr >
                		                    <td style="width:20%"  align="right">
                                                <span style="width:100px">价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;格：</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPrice" runat="Server" Width="80px" MaxLength="50"></asp:TextBox><br />
                                            </td>
                	                    </tr>
                                        <tr>
                                            <td colspan="2" style="height:20px">
                                            </td>
                                        </tr>
                	                    <tr>
                		                    <td style="width:20%"  align="right">
                                                <span style="width:100px">标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;签：</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTags" runat="Server" Width="350px" MaxLength="50"></asp:TextBox><br />
                                            </td>
                	                    </tr>
                                        <tr>
                                            <td colspan="2" style="height:20px">
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="2" style="height:20px">
                                                <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />&nbsp;&nbsp; 
                                                <asp:Button ID="btnCancle" runat="server" Text="取消" onclick="btnCancle_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
						</div>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input11 -->

</div>
<!-- end main -->
</asp:Content>
