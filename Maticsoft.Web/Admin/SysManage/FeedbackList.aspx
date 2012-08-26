<%@ Page Title="客户反馈" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true"
    CodeBehind="FeedbackList.aspx.cs" Inherits="Maticsoft.Web.FeedbackList" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="user_border" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0" id="table1">
        <tr>
            <td valign="top">
                <table class="user_box" cellspacing="0" cellpadding="5" width="100%" border="0" id="table2">
                    <tr>
                        <td align="left">
                            <span style="font-size: 12pt; font-weight: bold; color: #3666AA">
                                <img src="/admin/images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                <asp:Literal ID="Literal1" runat="server" Text="客户反馈" /></span>
                        </td>
                        <td align="middle">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </br>
    <cc1:GridViewEx ID="gridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" OnBind="BindData" OnPageIndexChanging="gridView_PageIndexChanging"
        OnRowDataBound="gridView_RowDataBound" UnExportedColumnNames="Modify" Width="100%"
        PageSize="10" ShowExportExcel="false" ShowExportWord="False" CellPadding="0"
        BorderWidth="1px" ShowCheckAll="true" DataKeyNames="Feedback_iID">
        <Columns>
            <asp:BoundField DataField="Feedback_iID" HeaderText="编号
            " SortExpression="Feedback_iID" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Feedback_cUserName" HeaderText="姓名" SortExpression="Feedback_cUserName"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Feedback_cPhone" HeaderText="电话" SortExpression="Feedback_cPhone"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Feedback_cCompany" HeaderText="公司" SortExpression="Feedback_cCompany"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Feedback_cMail" HeaderText="邮箱" SortExpression="Feedback_cMail"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Feedback_cContent" HeaderText="反馈内容" SortExpression="Feedback_cContent"
                ItemStyle-HorizontalAlign="Left"/>
                   <asp:BoundField DataField="Feedback_dateCreate" HeaderText="提交时间
" SortExpression="Feedback_dateCreate" ItemStyle-HorizontalAlign="Center" />
     <asp:BoundField DataField="Feedback_cUserIP" HeaderText="IP
" SortExpression="Feedback_cUserIP" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="是否已经解决" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <%# GetboolText(Eval("Feedback_bSolved"))%></ItemTemplate>
            </asp:TemplateField>
              <asp:BoundField DataField="Feedback_cResult" HeaderText="解决结果" SortExpression="Feedback_cResult" ItemStyle-HorizontalAlign="left" />
       
         
<asp:HyperLinkField HeaderText="<%$ Resources:Site, btnDetailText %>" ControlStyle-Width="50" DataNavigateUrlFields="Feedback_iID" DataNavigateUrlFormatString="FeedbackListShow.aspx?id={0}"
                                Text="<%$ Resources:Site, btnDetailText %>"  ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </cc1:GridViewEx>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
