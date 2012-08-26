<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseModuleList.ascx.cs" Inherits="Maticsoft.Web.Controls.CourseModuleList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:GridView ID="grd_ModuleList" runat="Server" AutoGenerateColumns="False" EnableModelValidation="True" Width="98%" 
    onrowdatabound="grd_ModuleList_RowDataBound" ShowHeader="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                第<asp:Label ID="Label1" runat="server" Text='<%# Bind("ModuleIndex") %>'></asp:Label>节
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ModuleName" />
        <asp:TemplateField>
            <ItemTemplate>
                老师：<asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                时长：<asp:Label ID="Label3" runat="server" Text='<%# Bind("TimeDuration") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                价格：<asp:Label ID="Label4" runat="server" Text='<%# Bind("ModulePrice") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" Text="购买本节"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>                        
</asp:GridView>
<webdiyer:AspNetPager ID="AspNetPager1" HorizontalAlign="Center"  
    runat="server" CssClass="pages" CurrentPageButtonClass="cpb" FirstPageText="首页" 
    PrevPageText="上一页" NextPageText="下一页" LastPageText="末页" 
     SubmitButtonText="确定" ShowMoreButtons="true" PageIndexBoxType="TextBox" 
    ShowPageIndexBox="Always" TextAfterPageIndexBox="页" PageSize="10"
     TextBeforePageIndexBox="转到" onpagechanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>