<%@ Page Title="Tao_Categories" Language="C#" MasterPageFile="~/Admin/Basic.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Admin.TaoCategories.List" %>

<%@ Register Assembly="Maticsoft.Web" Namespace="Maticsoft.Web.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_ContentPlaceHolder1_grdTopCategries tr").each(function (index, domEle) {
                if (index != 0) {
                    var optionTag = $(this).html();
                    if (optionTag.indexOf("parentid=\"0\"") < 0) {
                        $(domEle).hide();
                        $(".productcag1 span img").attr("src", "../../images/jia.gif");
                    }
                }
            })
        });
    </script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="分类管理" /></span>
                        </td>
                        <td align="middle">
                            <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                        <a href="add.aspx">
                                            <img title="" src="/admin/images/add.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="100">
                                        <a href="list.aspx">
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
    <!--Add  -->
    <!--Add end -->
    <!--Search -->
    <table style="width: 100%; display:none" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="left" class="tdbg">
                <b>
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Site, lblSearch%>" />：</b>
            </td>
            <td class="tdbg">
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
    <br />
    <div class="shou">
        <span id="openAll">
            <img src="../../images/jia.gif" width="24" height="24" /><a style="cursor: pointer;">全部展开</a></span>
        <span id="closeAll">
            <img src="../../images/jian.gif" width="24" height="24" /><a style="cursor: pointer;">全部收缩</a></span>
    </div>
    <!--Search end-->
    <br />
    <asp:GridView ID="grdTopCategries" runat="server" AutoGenerateColumns="false" ShowHeader="true"
        DataKeyNames="CategoryId" CssClass="GridViewStyle" GridLines="none" RowStyle-CssClass="grdrow"
        HeaderStyle-CssClass="GridViewHeaderStyle" ShowFooter="false" SelectedRowStyle-BackColor="#FBFBF4"
        OnRowDataBound="grdTopCategries_RowDataBound" OnRowCommand="grdTopCategries_RowCommand"
        OnRowDeleting="grdTopCategries_RowDeleting" CellPadding="0" BorderWidth="1px" BackColor="White" >
        <Columns>
            <asp:TemplateField HeaderText="<%$ Resources:TopCategories, IDS_Header_Name %>">
                <ItemTemplate>
                <span id="spShowImage" runat="server" parentid='<%# Eval("ParentCategoryId") %>'>
                <img src="../../Images/jian.gif" " width="24" height="24"  />
                </span>
                    <asp:Label ID="lblCategoryName" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="URL重写"
                HeaderStyle-Width="80px" DataField="RewriteName" />
            <asp:TemplateField HeaderText="排序" ItemStyle-Width="80px">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDesc" runat="server" ImageUrl="../../Images/pics/desc.png"
                        CommandName="Fall" />
                    <asp:ImageButton ID="imgAsc" runat="server" ImageUrl="../../Images/pics/asc.png"
                        CommandName="Rise" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" ItemStyle-Width="150px">
                <ItemStyle />
                <ItemTemplate>
                        <asp:HyperLink CssClass="SmallCommonTextButton" ID="HyperLink3" runat="server" Text="查看分类"
                        NavigateUrl='<%#Eval("CategoryId", "Show.aspx?CategoryId={0}")%>'></asp:HyperLink>
                    <asp:HyperLink CssClass="SmallCommonTextButton" ID="lkEdit" runat="server" Text="编辑"
                        NavigateUrl='<%#Eval("CategoryId", "~/admin/TaoCategories/Modify.aspx?CategoryId={0}")%>'></asp:HyperLink>
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:Site, btnDeleteText %>"  ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    
    
    
    
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:Site, btnDeleteListText %>" Visible="false"
                    class="inputbutton" onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'"
                    OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            //全部隐藏
            $("#closeAll").bind("click", function () {
                $("#ctl00_ContentPlaceHolder1_grdTopCategries tr").each(function (index, domEle) {
                    if (index != 0) {
                        var optionTag = $(this).html();
                        if (optionTag.indexOf("parentid=\"0\"") < 0) {
                            $(domEle).hide();
                            $(".productcag1 span img").attr("src", "../../images/jia.gif");
                        }
                    }
                })
            });
            //全部展开
            $("#openAll").bind("click", function () {
                $("#ctl00_ContentPlaceHolder1_grdTopCategries tr").each(function (index, domEle) {
                    if (index != 0) {
                        $(domEle).show();
                        $(".productcag1 span img").attr("src", "../../images/jian.gif");
                    }
                })
            });
            $(".productcag1 span img").each(function (index, imgObj) {
                $(imgObj).click(function () {
                    if ($(imgObj).attr("src") == "../../images/jian.gif") {
                        var currentTrNode = $(imgObj).parents("tr");
                        currentTrNode = currentTrNode.next();
                        var optionHTML;
                        while (true) {
                            optionHTML = currentTrNode.html();
                            if (typeof (optionHTML) != "string") { break; }
                            if (optionHTML.indexOf("parentid=\"0\"") < 0) {
                                currentTrNode.hide();
                                currentTrNode = currentTrNode.next();
                            }
                            else { break; }
                        }
                        //把img src设加可开打状态
                        $(imgObj).attr("src", "../../images/jia.gif");
                    }
                    else {
                        var currentTrNode = $(imgObj).parents("tr");
                        currentTrNode = currentTrNode.next();
                        var optionHTML;
                        while (true) {
                            optionHTML = currentTrNode.html();
                            if (typeof (optionHTML) != "string") { break; }
                            if (optionHTML.indexOf("parentid=\"0\"") < 0) {
                                currentTrNode.show();
                                currentTrNode = currentTrNode.next();
                            }
                            else { break; }
                        }
                        $(imgObj).attr("src", "../../images/jian.gif");
                    }
                })
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
