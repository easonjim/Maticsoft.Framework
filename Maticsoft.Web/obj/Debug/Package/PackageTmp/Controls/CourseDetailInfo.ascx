<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseDetailInfo.ascx.cs" Inherits="Maticsoft.Web.Controls.CourseDetailInfo" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div class="opentableBox">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th >选择</th>
    <th width="100">课程图片</th>
    <th>课程名称</th>
    <th>共开课数</th>
    <th>单价</th>
    <th>发布时间</th>
    <th>操作</th>
  </tr>
        <asp:Repeater ID="Repeater_Detail" runat="server" 
            onitemdatabound="Repeater_Detail_ItemDataBound">
        <ItemTemplate>
		<tr>
            <td align="center" valign="middle" class="ckd" >
                <asp:CheckBox ID="ckCourse" runat="server" /></td>
			<td align="center" valign="middle" style="width:100px;" ><a href="../show.aspx?cid=<%# Eval("CourseID") %>" title='<%#Eval("CourseName")%>'><%# string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ? "<img src='../images/pics/none.gif' style='width:90px;height:70px;'/>" : "<img src=\"" + Eval("ImageUrl").ToString() + "\" style=\" height:70px;width:90px\"/>"%></a></td>
			<td align="left" valign="middle" class="b1">
                <a href="/PubCourse/CourseDetailInfo.aspx?CourseId=<%#Eval("CourseID") %>&ctypes=0"  title='<%#Eval("CourseName")%>' style="color:#004986;">
                <%#HttpUtility.HtmlEncode(Eval("CourseName").ToString())%></a><br /></td>
			<td align="center" valign="middle" class="b2">
                <asp:Label ID="labCID" runat="server" Text='<%#Eval("CourseID") %>' Visible="false" ></asp:Label>
                    <asp:Label ID="labCount" runat="server" Text=""></asp:Label></td>
			<td align="center" valign="middle" class="b2"><%#Eval("Price","{0:C}") %></td>
            <td align="center" valign="middle" class="b1"><%#Eval("CreatedDate")%>
			<td align="center" valign="middle" class="b3">
				<a href="/PubCourse/CourseComment.aspx?CourseId=<%#Eval("CourseID") %>" style="color:#004986;">查看评论</a>
			</td>
		</tr>
        </ItemTemplate>
    </asp:Repeater>
 </table> 
        <asp:Label ID="ErrorMsg" runat="server" Text='暂时没有课程信息！' ForeColor="Red" Visible="false"></asp:Label>
</div>
<%--<div class="openPage">--%>
	<span>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" 
    HorizontalAlign="Center" PageSize="10"
            OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="False" 
    NumericButtonCount="3">
        </webdiyer:AspNetPager>
	</span><div style="margin:10px;">
<asp:Button ID="btnOutOfStock" runat="server" Text="下架" 
        onclick="btnOutOfStock_Click" /></div>
<%--</div>--%>

    
    

