<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnFinshCourse.ascx.cs" Inherits="Maticsoft.Web.Controls.UnPublishCourse" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div class="opentableBox">
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th width="100">课程图片</th>
    <th>课程名称</th>
    <th>共开课数</th>
    <th>单价</th>
    <th>发布时间</th>
    <th>更新时间</th>
    <th>操作</th>
  </tr>
        <asp:Repeater ID="Repeater_PubCourse" runat="server"   onitemcommand="Repeater_PubCourse_ItemCommand"    onitemdatabound="Repeater_PubCourse_ItemDataBound" >
        <ItemTemplate>
		<tr>
			<td align="center" valign="middle" class="b1" ><a href="<%=strFlag %><%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style=\"width:90px;height:70px;\"/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></a></td>
			<td align="left" valign="middle" style="width:100px;">
            <a href="<%=strFlag %><%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>' style="color:#004986;"><%# HttpUtility.HtmlEncode(Eval("CourseName").ToString())%></a><br /></td>
			<td align="center" valign="middle" class="b2">
                <asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
                    <asp:Label ID="labCount" runat="server" Text=""></asp:Label></td>
			<td align="center" valign="middle" ><%#Eval("Price","{0:C}") %></td>
            <td align="center" valign="middle" ><%#Eval("CreatedDate")%></td>
			<td align="center" valign="middle"  > <%#Eval("CreatedDate")%></td>
			<td align="center" valign="middle"  >
            <asp:Button ID="btnEdit" runat="server" CommandArgument="btnEdit" Text="编辑" />&nbsp;
                <asp:Button ID="btnPublish" runat="server" CommandArgument="btnDel" Text="删除" />
			</td>
		</tr>
        </ItemTemplate>
    </asp:Repeater>
 </table> 
        <asp:Label ID="ErrorMsg1" runat="server" Text='暂时没有课程信息！' ForeColor="Red"   Visible="False"></asp:Label>
</div>
	<span>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" 
    HorizontalAlign="Center" PageSize="10"
            OnPageChanged="AspNetPager1_PageChanged" 
    NumericButtonCount="3" AlwaysShow="False">
        </webdiyer:AspNetPager>
	</span>