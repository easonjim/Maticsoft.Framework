<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="OrgClist.aspx.cs" Inherits="Maticsoft.Web.PubCourse.OrgClist" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/tabmenu.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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

<div class="nav"><a href="">我要教</a> > <strong>线下课程</strong> > <strong>我参与的组织课程</strong></div>
<h2>我参与的组织课程</h2>

<div class="class_table">
    <div class="tabs"><a href="javascript:void(0);" class="link">我的组织课程</a><a href="javascript:void(0);">未完成的组织课程</a><a href="javascript:void(0);">我参与的组织课程</a><a href="javascript:void(0);">邀请信息</a></div>
    <div class="balancecontentin">

                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                   <ContentTemplate>
                                    <div class="opentableBox">
                                    <table border="0" cellspacing="0" cellpadding="0">
		                                    <tr>
			                                    <td align="center" width="100">课程图片</td>
			                                    <td align="center" valign="middle" width="100">课程名称</td>
			                                    <td align="center" valign="middle" width="60">共开课数</td>
			                                    <td align="center" valign="middle" width="60">定价(元)</td>
                                                <td align="center" valign="middle" width="150">发布时间</td>
			                                    <td align="center" valign="middle" width="40">评分</td>
			                                    <td align="center" valign="middle" width="60">评论</td>
		                                    </tr>
                                            <asp:Repeater ID="Repeater_OrgCourse" runat="server" 
                                                onitemcommand="Repeater_OrgCourse_ItemCommand" 
                                                onitemdatabound="Repeater_OrgCourse_ItemDataBound" >
                                            <ItemTemplate>
		                                    <tr>
			                                    <td align="center" valign="middle" class="b1" ><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\" height:70px;width:90px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%><%--<img src='<%#Eval("ImageUrl") %>' style="width:90px;height:70px;"/>--%></td>
			                                    <td align="center" valign="middle" class="b1">
                                                    <a href="/PubCourse/CourseDetailInfo.aspx?CourseId=<%#Eval("CourseID") %>&ctypes=1"  style="color:#004986;"><%#Eval("CourseName")%></a><br /></td>
			                                    <td align="center" valign="middle" class="b2">
                                                    <asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
                                                        <asp:Label ID="labCount" runat="server" Text=""></asp:Label></td>
			                                    <td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}") %></td>
                                                <td align="center" valign="middle" class="b1"><%#Eval("CreatedDate")%>
			                                    <td align="center" valign="middle" class="b1">0</td>
			                                    <td align="center" valign="middle" class="b3">
				                                    <a href="/PubCourse/CourseComment.aspx?CourseId=<%#Eval("CourseID") %>" style="color:#004986;">查看评论</a>
			                                    </td>
		                                    </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     </table> 
                                            <asp:Label ID="ErrorMsg" runat="server" Text='暂时没有课程信息！' ForeColor="Red" Visible="false"></asp:Label>
                                    </div>
                                       <span>
                                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
                                               CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
                                               LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
                                               CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10"
                                               OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="False" NumericButtonCount="3">
                                           </webdiyer:AspNetPager>
                                       </span>
                                        </ContentTemplate>
                                  </asp:UpdatePanel>
    </div>
    
<div class="balancexq">
   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate >
                                            <div class="opentableBox">
                                            <table border="0" cellspacing="0" cellpadding="0">
		                                            <tr>
			                                    <td align="center" width="90">课程图片</td>
			                                    <td align="center" valign="middle" width="100">课程名称</td>
			                                    <td align="center" valign="middle" width="50">共开课数</td>
			                                    <td align="center" valign="middle" width="50">定价(元)</td>
                                                <td align="center" valign="middle" width="100">发布时间</td>
			                                            <td align="center" valign="middle" width="100">更新时间</td>
			                                            <td align="center" valign="middle" class="a3">操&nbsp;&nbsp;作</td>
		                                            </tr>
                                                    <asp:Repeater ID="Repeater_unOrg" runat="server" 
                                                        onitemcommand="Repeater_unOrg_ItemCommand" 
                                                        onitemdatabound="Repeater_unOrg_ItemDataBound"  >
                                                    <ItemTemplate>
		                                            <tr>
			                                            <td align="center" valign="middle" class="b1" ><a href="/PubCourse/OrganizeCourse.aspx?courseId=<%#Eval("CourseID") %>"  style="color:#004986;"><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\" height:70px;width:90px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></a></td>
			                                            <td align="center" valign="middle" class="b1"> <a href="/PubCourse/OrganizeCourse.aspx?courseId=<%#Eval("CourseID") %>"  style="color:#004986;"><%#Eval("CourseName")%></a><br /></td>
			                                            <td align="center" valign="middle" class="b2">
                                                            <asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
                                                                <asp:Label ID="labCount" runat="server" Text=""></asp:Label></td>
			                                            <td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}") %></td>
                                                        <td align="center" valign="middle" class="b1"><%#Eval("CreatedDate")%></td>
			                                            <td align="center" valign="middle" class="b1"> <%#Eval("CreatedDate")%></td>
			                                            <td align="center" valign="middle" class="b3">
                                                        <asp:Button ID="btnEdit" runat="server" CommandArgument="btnEdit" Text="编辑" />
                                                        <%--<a href="/PubCourse/OrganizeCourse.aspx?courseId=<%#Eval("CourseID") %>">编辑</a>--%>
                                                        &nbsp;
                                                            <asp:Button ID="btnPublish" runat="server" CommandArgument="btnDel" Text="删除" />
			                                            </td>
		                                            </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                             </table> 
                                                    <asp:Label ID="ErrorMsg2" runat="server" Text='暂时没有课程信息！' ForeColor="Red" 
                                                    Visible="False"></asp:Label>
                                            </div>
	                                            <span>
                                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CurrentPageButtonPosition="Center"
                                                        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
                                                        CssClass="pages" CurrentPageButtonClass="cpb" 
                                                        HorizontalAlign="Center" PageSize="10"
                                                        OnPageChanged="AspNetPager2_PageChanged" AlwaysShow="false"
                                                        NumericButtonCount="3">
                                                    </webdiyer:AspNetPager>
	                                            </span>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger  ControlID="AspNetPager2"/>
                                        </Triggers>
                                  </asp:UpdatePanel>
</div>

<div class="balancexq">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate >
                                            <div class="opentableBox">
                                            <table border="0" cellspacing="0" cellpadding="0">
		                                            <tr>
			                                    <td align="center" width="100">课程图片</td>
			                                    <td align="center" valign="middle" width="100">课程名称</td>
			                                    <td align="center" valign="middle" width="50">共开课数</td>
			                                            <td align="center" valign="middle" width="60">参与教师</td>
			                                            <td align="center" valign="middle" width="50">组织者</td>
			                                            <td align="center" valign="middle" width="50">定价(元)</td>
                                                        <td align="center" valign="middle" width="100">发布时间</td>
			                                            <td align="center" valign="middle" width="50">视频状态</td>
		                                            </tr>
                                                    <asp:Repeater ID="Repeater_AttendOrg" runat="server" 
                                                        onitemcommand="Repeater_AttendOrg_ItemCommand" 
                                                        onitemdatabound="Repeater_AttendOrg_ItemDataBound" >
                                                    <ItemTemplate>
		                                            <tr>
			                                            <td align="center" valign="middle" class="b1" ><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\" height:70px;width:90px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></td>
			                                            <td align="center" valign="middle" class="b1"><a href="/PubCourse/CourseDetailInfo.aspx?CourseId=<%#Eval("CourseID") %>&ctypes=2"  style="color:#004986;"><%#Eval("CourseName") %></a><br /></td>
			                                            <td align="center" valign="middle" class="b2">
                                                            <asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
                                                                <asp:Label ID="labCount" runat="server" Text=""></asp:Label></td>
			                                            <td align="center" valign="middle" class="b1"> <asp:Label ID="labTeacherCount" runat="server" Text=""></asp:Label></td>
			                                            <td align="center" valign="middle" class="b2"> <%#Eval("TrueName") %></td>
			                                            <td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}") %></td>
                                                        <td align="center" valign="middle" class="b1"><%#Eval("UpdatedDate")%></td>
			                                            <td align="center" valign="middle" class="b3">
                                                            <%#VideoStatus(Eval("Status"))%>
			                                            </td>
		                                            </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                             </table> 
                                                    <asp:Label ID="Label1" runat="server" Text='暂时没有课程信息！' ForeColor="Red" 
                                                    Visible="False"></asp:Label>
                                            </div>
	                                            <span>
                                                    <webdiyer:AspNetPager ID="AspNetPager3" runat="server" CurrentPageButtonPosition="Center"
                                                        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
                                                        CssClass="pages" CurrentPageButtonClass="cpb" 
                                                        HorizontalAlign="Center" PageSize="10"
                                                        OnPageChanged="AspNetPager3_PageChanged" AlwaysShow="false"
                                                        NumericButtonCount="3">
                                                    </webdiyer:AspNetPager>
	                                            </span>
                                        </ContentTemplate>
                                  </asp:UpdatePanel>
</div>
<div class="balancexq">
     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate >
                                            <div class="opentableBox">
                                            <table border="0" cellspacing="0" cellpadding="0">
		                                            <tr>
			                                    <td align="center" width="100">课程图片</td>
			                                    <td align="center" valign="middle" width="100">课程名称</td>
			                                    <td align="center" valign="middle" width="50">共开课数</td>
			                                            <td align="center" valign="middle" class="a2">参与章节</td>
			                                            <td align="center" valign="middle" class="a2">组织者</td>
			                                            <td align="center" valign="middle" class="a2">课程定价(元)</td>
                                                        <td align="center" valign="middle" class="a1">邀请时间</td>
			                                            <td align="center" valign="middle" class="a3">操作</td>
		                                            </tr>
                                                    <asp:Repeater ID="Repeater_Invite" runat="server" 
                                                        onitemcommand="Repeater_Invite_ItemCommand" 
                                                        onitemdatabound="Repeater_Invite_ItemDataBound" >
                                                    <ItemTemplate>
		                                            <tr>
			                                            <td align="center" valign="middle" class="b1" ><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\" height:70px;width:90px\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></td>
			                                            <td align="center" valign="middle" class="b1"><a href="/PubCourse/CourseDetailInfo.aspx?CourseId=<%#Eval("CourseID") %>&ctypes=2"  style="color:#004986;"><%#Eval("CourseName") %></a><br /></td>
			                                            <td align="center" valign="middle" class="b2"><%#Eval("ModuleNum")%></td>
			                                            <td align="center" valign="middle" class="b1"> <%#Eval("ModuleName")%></td>
			                                            <td align="center" valign="middle" class="b2"> <%#Eval("TrueName") %></td>
			                                            <td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}") %></td>
                                                        <td align="center" valign="middle" class="b1"><%#Eval("InviteDate")%></td>
			                                            <td align="center" valign="middle" class="b3">
                                                            <asp:Label ID="labMid" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label>
                                                            <%--<%=strMsg%>--%>
                                                             <asp:Label ID="labID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                                             <asp:Label ID="LaInviteID" runat="server" Text='<%#Eval("InviteID") %>' Visible="false"></asp:Label>
                                                             <asp:Label ID="labText" runat="server" Text=""  ></asp:Label>
                                                            <asp:Button ID="btnAccsess" CommandArgument="access" runat="server" Text="同意邀请" />
                                                            <asp:Button ID="btnRefuse" CommandArgument="refuse" runat="server" Text="拒绝邀请" />
			                                            </td>
		                                            </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                             </table> 
                                                    <asp:Label ID="Label2" runat="server" Text='暂时没有课程信息！' ForeColor="Red" 
                                                    Visible="False"></asp:Label>
                                            </div>
	                                            <span>
                                                    <webdiyer:AspNetPager ID="AspNetPager4" runat="server" CurrentPageButtonPosition="Center"
                                                        CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
                                                        CssClass="pages" CurrentPageButtonClass="cpb" 
                                                        HorizontalAlign="Center" PageSize="10"
                                                        OnPageChanged="AspNetPager3_PageChanged" AlwaysShow="false"
                                                        NumericButtonCount="3">
                                                    </webdiyer:AspNetPager>
	                                            </span>
                                        </ContentTemplate>
                                  </asp:UpdatePanel>
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
