<%@ Page Title="" Language="C#" MasterPageFile="~/TaoBasic.Master" AutoEventWireup="true" CodeBehind="TeacherDetailInfo.aspx.cs" Inherits="Maticsoft.Web.TeacherDetailInfo" %>
<%@ Register src="Controls/CourseView.ascx" tagname="CourseView" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perinfor.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
            <!--主体body内容-->
			<div class="perinforAll">
				<p><a href="/">首页</a>&nbsp;&gt;&gt;&nbsp;教师信息</p>
				<div class="perinforBox">
					<div class="perftop">
						<div class="pertext">
							<div class="pertextL"><img id='imgGravatar'  src="images/imgbox.jpg"  runat="server"/></div>
							<div class="pertextR">
								<h3 style="width:300px;">姓名：<asp:Literal ID="litName" runat="server"></asp:Literal><%=isTrueName %>
								<div style="float:right;margin-left:30px;">性别：<%=sexStr%></div></h3>
                                <p><h3 style="width:300px;">省份：<asp:Literal ID="litProvice" runat="server"></asp:Literal></h3></p>
                                 <p><h3 style="width:300px;">职业：<asp:Literal ID="litCareer" runat="server"></asp:Literal></h3></p>
                                  <p><h3 style="width:300px;">兴趣：<asp:Literal ID="litHobby" runat="server"></asp:Literal></h3></p>
								<span class="peryz">认证：</span>
								<span class="perzs">									
									<p>
										<asp:Literal ID="litRz" runat="server">sdsdsd</asp:Literal>
										</p>
								</span>
							</div>
						</div>
					</div>
					<div class="perfbigbox">
						<div class="perfjj">
							<h3>简介：</h3>
							<p>
								<asp:Literal ID="litDescrit" runat="server"></asp:Literal></p>
						</div>
						<div class="perfjj">
                            <h3>标签：</h3>
								<p><asp:Label ID="labTag" runat="server" Text="" CssClass="tags"></asp:Label></p>
						</div>
					</div>
					<div class="perfbigbox">
						<div class="perfbottom">
							<h2>所开课程：</h2>
								<uc1:CourseView ID="CourseView1" runat="server" />
						</div>
					</div>
				</div>
				<div class="perinforImgbox">
					<img src="images/zrimg.jpg" style="zrimg"/>
					<img src="images/zximg.jpg" style="zximg"/>
				</div>
			</div>
</asp:Content>
