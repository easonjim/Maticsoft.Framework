<%@ Page Title="<%$ Resources:SysManage, ptMultiLanguage %>" Language="C#" MasterPageFile="~/Admin/BasicAddSearch.Master"
    AutoEventWireup="true" CodeBehind="MultiLanguage.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.MultiLanguage" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:SysManage, ptMultiLanguage%>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_TitleButton"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_ADD" runat="server">
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:SysManage, lblAddMultiLang%>" />:    
    <asp:DropDownList ID="dropLanguage" runat="server">
    </asp:DropDownList>
    Field:<asp:TextBox ID="txtMultiLang_cField" runat="server" ></asp:TextBox>&nbsp;
    PKValue:<asp:TextBox ID="txtMultiLang_iPKValue" runat="server" ></asp:TextBox>&nbsp;
    Value:<asp:TextBox ID="txtMultiLang_cValue" runat="server" ></asp:TextBox>&nbsp;    
    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
        OnClick="btnSave_Click" />
    <asp:Label ID="lbltip1" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <b>
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblSearch%>" />：</b>
    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
        class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
    </asp:Button>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder_Gridview" runat="server">
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="False" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowCancelingEdit="gridView_RowCancelingEdit"
        OnRowEditing="gridView_RowEditing" OnRowUpdating="gridView_RowUpdating" UnExportedColumnNames="Modify"
         OnRowDeleting="gridView_RowDeleting"
        Width="100%" PageSize="10" DataKeyNames="MultiLang_iID" ShowExportExcel="false" ShowExportWord="False"
        ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="MultiLang_cField" HeaderText="<%$ Resources:SysManage, fieldMultiLang_cField%>" ReadOnly="true"
                SortExpression="MultiLang_cField"  />
            <asp:BoundField DataField="MultiLang_iPKValue" HeaderText="<%$ Resources:SysManage, fieldMultiLang_iPKValue%>" ReadOnly="true"
                SortExpression="MultiLang_iPKValue" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="MultiLang_cLang" HeaderText="<%$ Resources:SysManage, fieldMultiLang_cLang%>" ReadOnly="true"
                SortExpression="MultiLang_cLang" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"/>
            <asp:TemplateField HeaderText="<%$ Resources:SysManage, fieldMultiLang_cValue %>" >
                <EditItemTemplate>
                    <asp:TextBox ID="TBDescription" runat="server" Text='<%# Bind("MultiLang_cValue") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBDescription" runat="server" Text='<%# Bind("MultiLang_cValue") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:Site, lblOperation %>" ShowHeader="False"
                ItemStyle-HorizontalAlign="Center">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="<%$ Resources:Site, btnUpdateText %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="<%$ Resources:Site, btnCancleText %>"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="<%$ Resources:Site, btnEditText %>"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                         Text="<%$ Resources:Site, btnDeleteText  %>"></asp:LinkButton>
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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
