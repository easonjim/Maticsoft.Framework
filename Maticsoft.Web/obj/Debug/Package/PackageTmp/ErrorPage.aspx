<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Maticsoft.Web.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
<br /><br /><br />
<div align="center" >
    <img  src="Images/error.gif"/>
</div>
<div align="center" >
无法访问的原因：
   <span style="color:Red;"><asp:Literal ID="lblMsg" runat="server"></asp:Literal></span> 
    <br/><br/><br/><br/><br/>
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
