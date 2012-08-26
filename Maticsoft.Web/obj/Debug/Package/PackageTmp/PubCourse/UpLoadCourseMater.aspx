<%@ Page Title="" Language="C#" MasterPageFile="~/PubCourse/PubBasic.Master" AutoEventWireup="true" CodeBehind="UpLoadCourseMater.aspx.cs" Inherits="Maticsoft.Web.PubCourse.UpLoadCourseMater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .btn
        {
            cursor: pointer;
            color: #004986;
            height: 17px;
        }
        .setableBox{width:600px;margin:0;padding:0;border:1px solid #E7E7E7;border-top:none;background:url(../images/cline5.jpg) no-repeat;margin-top:10px;}
        .setableBox table{font-size:12px;margin:0;padding:0;margin-top:15px;}
        .setableBox table tr td.a1{width:240px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a2{width:64px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a3{width:250px;height:35px;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.a4{width:104px;height:35px;border-right:1px solid #e7e7e7;background:#F5F5F5;color:#004986;font-weight:bold;}
        .setableBox table tr td.b1{width:140px;height:50px;border:1px solid #e7e7e7;border-left:none;border-bottom:none;}
        .setableBox table tr td.b2{width:40px;height:50px;border:1px solid #e7e7e7;border-left:none;border-bottom:none;}
        .setableBox table tr td.b3{width:120px;height:50px;border:1px solid #e7e7e7;border-right:none;border-bottom:none;border-left:none;}
        .setableBox table tr td.b1 img{width:84px;height:17px;*margin-top:40px;border-bottom:none;}
        .setableBox table tr td.c3 img .setableBox table tr td.c1 img{width:84px;height:25px;*margin-top:40px;}
        .cancle{margin-left:10px;}
        .upcxfile{width:260px;height:25px;border:1px solid #E7E7E7;margin-top:-5px;margin-left:30px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" id="pageInfo" value="3" />
<!-- start main -->
<div class="main">

<!-- start input4 -->
<div class="input4 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="">我要教</a> > <strong>公开课程</strong> > <strong>上传学习资料</strong></div>
<h2>上传学习资料</h2>
<div class="padding" style="padding-left:19px;margin-top:0px;">
<ul>
<li><span>资料名称：</span>
<asp:HiddenField ID="hfCourseId" runat="server" />
<asp:HiddenField ID="hfMaterialID" runat="server" />
<asp:TextBox ID="txtMaterialName" runat="server"  Text='<%#Eval("MaterialName") %>'   class="txt04" ></asp:TextBox></li>
<li>
<asp:HiddenField ID="hfMaterialURL" runat="server" />
<asp:FileUpload ID="FileUpload1" runat="server" CssClass="upcxfile"  />
<asp:ImageButton ID="btnUpload" runat="server" ImageUrl="~/Images/up1.jpg" OnClick="btnUpload_Click"/>
<img src="../Images/cancle.jpg" alt="取消" id="cn" style="<%=cancleStr%>" /><%--<input name="" type="file" class="txt04" /> <input name="" type="button" class="button03" />--%></li>

<div class="upMaBox" style="height: auto; border: 0px solid #7F9DB9;  margin-bottom: 10px;">
<div align="center">
<!--开始-->
<div class="setableBox">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="center" valign="middle" class="a2">
编号
</td>
<td align="center" valign="middle" class="a1">
资料名称
</td>
<td align="center" valign="middle" class="a1">
所属课程
</td>
<td align="center" valign="middle" class="a3">
操作
</td>
</tr>
<asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
<ItemTemplate>
<tr>
<td align="center" valign="middle" class="b2">
<%#Eval("MaterialID")%>
</td>
<td align="left" valign="middle" class="b1">
<%#Eval("MaterialName")%>
</td>
<td align="left" valign="middle" class="b2">
<%#GetCourseName(Eval("CourseID"))%>
</td>
<td align="center" valign="middle" class="b3">
<a href='<%#Eval("MaterialURL")%>' target="_blank" style="color: #004986;">下载</a>&nbsp;
&nbsp; &nbsp; <a href="StudyMaterial2.aspx?CourseId=<%# Eval("CourseID")%>&MaterialID=<%# Eval("MaterialID") %>"  class="btn">编辑</a> &nbsp; &nbsp; &nbsp;
<asp:Button ID="btnDel" runat="server" Text="删除" CommandArgument="del" CommandName='<%# Eval("MaterialID") %>'  BorderStyle="None" BackColor="White" CssClass="btn" />
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
<!--结束-->
</div>
</div>

<li><span>&nbsp;</span><asp:Button ID="btnBack" runat="server" class="button15" 
        onclick="btnBack_Click" />　<asp:Button ID="btnNext" runat="server" 
        class="button14" onclick="btnNext_Click" /></li>
</ul>
</div>
<div class="soild"></div>


</div>
</div>
</div>
</div>
</div>
<!-- end input4 -->

</div>
<!-- end main -->
</asp:Content>
