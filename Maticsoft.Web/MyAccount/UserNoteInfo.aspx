<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserNoteInfo.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserNoteInfo" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<input type="hidden" id="pageInfo" value="5" />
<!-- start main -->
<div class="main">

<!-- start biji1 -->
<div class="biji1 border">
<div class="bg01">
<div class="bg02">
<div class="bg03">
<div class="bg_r"></div>
<div class="bg_l"></div>
<div class="con">

<div class="nav"><a href="Userbuycourse.aspx">学习管理</a> > <strong>笔记管理</strong></div>
<h2>笔记管理</h2>

<div class="padding">
	<div class="notes">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="notesBox">
<ul>
<li class="litop">
<span>课程名称</span>
<span>我的笔记</span>
</li>
<asp:Repeater ID="Repeater_Notes" runat="server"  
onitemcommand="Repeater_Notes_ItemCommand">
<ItemTemplate>
<li class="liCont">
<span>
<div class="notesImg"><img src='<%#Eval("ImageUrl") %>'/></div>
<div class="notesText">
<a><%#Eval("CourseName")%></a><br />
<a><%#Eval("ModuleName")%></a>
</div>
</span>
<span>
<textarea id="notesTarea" class="nTarea" runat="server"><%#Eval("Contents")%></textarea>
<asp:Label ID="labMid" runat="server" Text='<%#Eval("ModuleID") %>' Visible="false"></asp:Label>
<asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label>
<asp:Label ID="labNid" runat="server" Text='<%#Eval("NoteID") %>' Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSave" CommandArgument="save" runat="server" class="buttonR9"/>&nbsp;
</span>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" 
LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页" 
CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="4" 
OnPageChanged="AspNetPager1_PageChanged">
</webdiyer:AspNetPager>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</div>

</div>

</div>
</div>
</div>
</div>
</div>
<!-- end biji1 -->

</div>
<!-- end main -->
</asp:Content>
