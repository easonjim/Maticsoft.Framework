<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigSystem.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.ConfigSystem"  Title="系统配置"%>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<%@ Register Src="/Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register Src="/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>参数管理</title>
    <link href="/admin/css/Guide.css" type="text/css" rel="stylesheet" />
    <link href="/admin/css/index.css" type="text/css" rel="stylesheet" />
    <link href="/admin/css/MasterPage<%=Session["Style"].ToString()%>.css" type="text/css" rel="stylesheet" />
    <link href="/admin/css/xtree.css" type="text/css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
            border="0" id="table1">
            <tr>
                <td valign="top">
                    <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                        <tr>
                            <td align="left">
                                <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                    <img src="/admin/Images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                    系统配置</span>
                            </td>
                            <td align="center">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td style="width: 80px" align="left" class="tdbg">
                    <b>添加配置：</b>
                </td>
                <td class="tdbg">
                    KeyName:<asp:TextBox ID="txtKeyName" runat="server" class="inputtext"></asp:TextBox>&nbsp;
                    Value:<asp:TextBox ID="txtValue" runat="server" class="inputtext"></asp:TextBox>&nbsp;
                    描述:<asp:TextBox ID="txtDescription" runat="server" class="inputtext"  Width="300px"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="保存" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                        onmouseout="this.className='inputbutton'" OnClick="btnSave_Click" />
                    <asp:Label ID="lblToolTip" runat="server" Text=""></asp:Label>
                </td>
                <td class="tdbg">
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td style="width: 80px" align="left" class="tdbg">
                    <b>搜索选项：</b>
                </td>
                <td class="tdbg">
                    <asp:TextBox ID="txtKeyWord" runat="server" class="inputtext"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                        onmouseout="this.className='inputbutton'" OnClick="btnSearch_Click" />
                </td>
                <td class="tdbg">
                </td>
            </tr>
        </table>
        <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
            OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" OnRowCancelingEdit="gridView_RowCancelingEdit"
            OnRowEditing="gridView_RowEditing" OnRowUpdating="gridView_RowUpdating" UnExportedColumnNames="Modify"
             Width="100%" PageSize="20" DataKeyNames="ID" ShowExportExcel="false"
            ShowExportWord="False" ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px"
            ShowCheckAll="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="true" />
                <asp:BoundField DataField="Keyname" HeaderText="Keyname" />
                <asp:BoundField DataField="Value" HeaderText="Value" ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Description" HeaderText="描述" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="<%$ Resources:Site, lblOperation %>" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
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
    </div>
    <uc1:copyright ID="Copyright1" runat="server" />
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
