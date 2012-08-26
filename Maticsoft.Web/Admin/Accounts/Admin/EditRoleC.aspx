<%@ Page Title="<%$ Resources:Site, ptEditRole %>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master"
    AutoEventWireup="true" CodeBehind="EditRoleC.aspx.cs" Inherits="Maticsoft.Web.Admin.Accounts.Admin.EditRoleC" %>
    <%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, ptEditRole%>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
    <a href="EditRole.aspx?RoleID=<%=RoleID%>">风格一</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Site, lblNewRoleName %>" />:
    <asp:TextBox ID="TxtNewname" runat="server" Width="120px"></asp:TextBox>&nbsp;
    <asp:Button ID="BtnUpName" runat="server" Text="<%$ Resources:Site, btnUpdateText %>"
        OnClick="BtnUpName_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
        onmouseout="this.className='inputbutton'" />
    &nbsp;&nbsp;&nbsp;<asp:Button ID="RemoveRoleButton" runat="server" Text="<%$ Resources:Site, btnDeleteText %>"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="RemoveRoleButton_Click"></asp:Button>
    <asp:Label ID="lblTiptool" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Site, btnBackText %>"
         OnClick="btnBach_ServerClick" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
        onmouseout="this.className='inputbutton'"></asp:Button>
    <asp:Label ID="lblRoleID" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <table cellpadding="5" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center" height="25" colspan="2">
                <b>
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Site, lblRole%>" />:
                    <asp:Label ID="RoleLabel" runat="server"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td valign="Top" Width="250px">
                <b>
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Site, lblCategory%>" />
                </b>:                
                <asp:ListBox ID="CategoryDownList" runat="server" AutoPostBack="True"  Height="200px" Width="150px"
                OnSelectedIndexChanged="CategoryDownList_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td valign="Top" align="left">
            <asp:CheckBox ID="chkAll" runat="server"  Text="选择全部"
                    oncheckedchanged="chkAll_CheckedChanged" AutoPostBack="true" /><br/>
            <asp:CheckBoxList ID="chkPermissions" runat="server" RepeatColumns="5" CellPadding="3"
                    OnDataBound="chkPermissions_DataBinding" s>
                </asp:CheckBoxList>
                
            </td>
        </tr>        
        <tr>
            <td class="tdbg" align="center" valign="bottom" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" CausesValidation="false" Text="<%$ Resources:Site, btnBackText %>"
                    OnClientClick="javascript:history.go(-1);return false;" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
<br/>
 <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
                        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
                        Width="100%" PageSize="10" DataKeyNames="UserID" ShowExportExcel="false" ShowExportWord="False"
                        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px" ShowCheckAll="true">
                        <Columns>                            
                            <asp:TemplateField HeaderText="<%$ Resources:Site, fieldUserName %>" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href='RoleAssignment.aspx?UserID=<%#Eval("UserID") %>' > 
                                                <%# Eval("UserName")%>  
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="TrueName" HeaderText="<%$ Resources:Site, fieldTrueName %>" SortExpression="TrueName" ControlStyle-Width="40" ItemStyle-HorizontalAlign="center"/>                            
                            <asp:BoundField DataField="Phone" HeaderText="<%$ Resources:Site, fieldTelphone %>" SortExpression="Phone" ItemStyle-HorizontalAlign="center"  /> 
                            <asp:BoundField DataField="Email" HeaderText="<%$ Resources:Site, fieldEmail %>" SortExpression="Email" ItemStyle-HorizontalAlign="center"  /> 
                            <asp:BoundField DataField="EmployeeID" HeaderText="员工ID" SortExpression="EmployeeID" ItemStyle-HorizontalAlign="center"  />                                    
                            <asp:HyperLinkField HeaderText="<%$ Resources:Site, btnEditText %>" ControlStyle-Width="50" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserUpdate.aspx?userid={0}"
                                Text="<%$ Resources:Site, btnEditText %>"  ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="<%$ Resources:Site, btnDeleteText %>" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick='return confirm("你确认要删除这条记录吗?")' Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle Height="25px" HorizontalAlign="Right" />
                        <HeaderStyle Height="25px" />
                        <PagerStyle Height="25px" HorizontalAlign="Right" />
                        <SortTip AscImg="~/Images/up.JPG" DescImg="~/Images/down.JPG" />
                        <RowStyle Height="25px" />
                        <SortDirectionStr>DESC</SortDirectionStr>
                    </cc1:GridViewEx>  
                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td>
                        <asp:Button ID="btnRemove" runat="server" Text="从该角色移除" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                            onmouseout="this.className='inputbutton'" OnClick="btnRemove_Click"/>                    
                       
                    </td>
                </tr>
            </table>   
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
