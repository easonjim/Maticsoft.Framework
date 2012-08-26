<%@ Page Title="<%$ Resources:SysManage, ptTreeFavorite%>" Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="TreeFavorite.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.TreeFavorite" %>
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
                                        <img src="/admin/Images/icon.gif" align="absmiddle" style="border-width: 0px;" />
                                        定制收藏</span>
                                </td>
                                <td align="middle">   
                                <table align="left" id="table3">
                                <tr valign="top" align="left">
                                    <td width="80">
                                       <a href="addpi.aspx">
                                            <img title="" src="/admin/images/edit.gif" border="0" alt="" /></a>
                                    </td>
                                    <td width="80">                                       
                                       
                                    </td>
                                </tr>
                            </table>                                
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">                
                <tr>                  
                    <td class="tdbg" align="center"> 
                    <asp:DataList ID="listMenus" Width="550px" runat="server" RepeatColumns="2" 
                        ItemStyle-VerticalAlign="Top"  RepeatDirection="Horizontal" 
                         ItemStyle-HorizontalAlign="Left"
                        OnItemDataBound="listMenus_ItemDataBound" DataKeyField="NodeID">
                         <ItemTemplate>
                         <img alt="" src="/admin/images/menuimg/thumbnails.gif" />
                         <b><%# DataBinder.Eval(Container, "DataItem.TreeText")%>
                         </b><br/>                            
                        <asp:TreeView runat="server" ID="treeMenu" ShowLines="true" ShowCheckBoxes="Leaf"  ShowExpandCollapse="true" >                        
                        </asp:TreeView>
                        </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                <td colspan="3" align="center" class="tdbg">
                    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>" class="inputbutton" OnClick="btnSave_Click"
                            onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'" />
                    <asp:Label ID="lblTooltip" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
                </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>
