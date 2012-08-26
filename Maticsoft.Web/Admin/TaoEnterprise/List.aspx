<%@ Page Title="Ms_Enterprise" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.TaoEnterprise.Enterprise.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Title -->
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="企业管理" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="Add.aspx" target="">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="List.aspx" target="">
                                            <img title="" src="/admin/images/view.gif" border="0" alt="" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--Title end -->
    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="right" class="tdbg">
                <b>关键字：</b>
            </td>
            <td class="tdbg">
                <asp:DropDownList ID="ddlStatus" runat="server">
                 <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
                 <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                 <asp:ListItem Value="1" Text="正常"></asp:ListItem>
                 <asp:ListItem Value="2" Text="冻结"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Site, btnSearchText %>"
                    OnClick="btnSearch_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
            <td class="tdbg">
            </td>
        </tr>
    </table>
    <!--Search end-->
    <br />
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting" UnExportedColumnNames="Modify"
        Width="100%" PageSize="15" DataKeyNames="EnterpriseID" ShowExportExcel="false"
        ShowExportWord="False" ExcelFileName="FileName1" CellPadding="0" BorderWidth="1px"
        ShowCheckAll="true">
        <Columns>
            <asp:TemplateField HeaderText="LOGO" SortExpression="LOGO" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# GetImage(Eval("logo"), 45, 45)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="企业名称" SortExpression="Name" ItemStyle-HorizontalAlign="Left"   HeaderStyle-Width="30%" />
            <asp:BoundField DataField="EnteClassID" HeaderText="企业分类" Visible="false" SortExpression="EnteClassID"
                ItemStyle-HorizontalAlign="Center"  />
            <asp:TemplateField HeaderText="公司性质" SortExpression="CompanyType" ItemStyle-HorizontalAlign="Left"   HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%# GetCompanyType(Eval("CompanyType"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ArtiPerson" HeaderText="法人" SortExpression="ArtiPerson"
                ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Introduction" HeaderText="企业介绍" SortExpression="Introduction"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="RegisteredCapital" HeaderText="注册资本" SortExpression="RegisteredCapital"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="TelPhone" HeaderText="电话" SortExpression="TelPhone" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="CellPhone" HeaderText="手机" SortExpression="CellPhone"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="ContactMail" HeaderText="联系邮箱" SortExpression="ContactMail"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="RegionID" HeaderText="省/市" SortExpression="RegionID" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="Contact" HeaderText="联系人" SortExpression="Contact" ItemStyle-HorizontalAlign="Left"
                Visible="false" />
            <asp:BoundField DataField="UserName" HeaderText="用户名" SortExpression="UserName" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="EstablishedCity" HeaderText="注册地" SortExpression="EstablishedCity"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="Fax" HeaderText="传真" SortExpression="Fax" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="PostCode" HeaderText="邮编" SortExpression="PostCode" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="HomePage" HeaderText="主页" SortExpression="HomePage" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="EnteRank" HeaderText="企业等级" SortExpression="EnteRank"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="BusinessLicense" HeaderText="营业执照" SortExpression="BusinessLicense"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="TaxNumber" HeaderText="税务登记" SortExpression="TaxNumber"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="AccountBank" HeaderText="开户银行" SortExpression="AccountBank"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="AccountInfo" HeaderText="账号信息" SortExpression="AccountInfo"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="ServicePhone" HeaderText="客服电话" SortExpression="ServicePhone"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="MSN" HeaderText="MSN" SortExpression="MSN" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:TemplateField HeaderText="状态" SortExpression="State" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <%# GetEnterpriseState(Eval("Status"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreatedDate" HeaderText="创建日期" SortExpression="CreatedDate"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="CreatedUserID" HeaderText="创建用户" SortExpression="CreatedUserID"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="UpdatedDate" HeaderText="更新日期" SortExpression="UpdatedDate"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="UpdatedUserID" HeaderText="更新用户" SortExpression="UpdatedUserID"
                ItemStyle-HorizontalAlign="Center" Visible="false" />
            <asp:BoundField DataField="AgentID" HeaderText="代理商ID" SortExpression="AgentID" ItemStyle-HorizontalAlign="Center"
                Visible="false" />
            <asp:BoundField DataField="EstablishedDate" HeaderText="成立时间" SortExpression="EstablishedDate"
                ItemStyle-HorizontalAlign="Right" />
             <asp:TemplateField  HeaderText="操作"
                Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkLook" runat="server" Text="详细信息"
                        NavigateUrl='<%#Eval("EnterpriseID","Show.aspx?id={0}")%>'></asp:HyperLink>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="hlkEdit" runat="server" Text="编辑"
                        NavigateUrl='<%#Eval("EnterpriseID","Modify.aspx?id={0}")%>'></asp:HyperLink>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td align="left">
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click" />
                <asp:Button ID="btnApproveList" runat="server" Text="<%$ Resources:Site, btnApproveListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnApproveList_Click" />
                <asp:Button ID="btnInverseApprove" runat="server" Text="批量未审核" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnInverseApprove_Click" />
                <asp:Button ID="btnUpdateState" runat="server" Text="批量冻结" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'" OnClick="btnUpdateState_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
