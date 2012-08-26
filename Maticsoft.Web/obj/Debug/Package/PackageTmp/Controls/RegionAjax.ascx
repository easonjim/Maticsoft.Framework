<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegionAjax.ascx.cs" Inherits="Maticsoft.Web.Controls.RegionAjax" %>
<asp:HiddenField ID="HiddenField_SelectValue" runat="server" />
<asp:HiddenField ID="HiddenField_OldValue" runat="server" />
<asp:DropDownList runat="server" ID="ddlProvince" onchange="getCitys(this);">
</asp:DropDownList>
 <asp:DropDownList runat="server" ID="ddlCity"  onchange="getAreas(this);">
</asp:DropDownList>
 <asp:DropDownList runat="server" ID="ddlArea" onchange="getAreasID(this);">
</asp:DropDownList>