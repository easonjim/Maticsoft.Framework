<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LearnCourse.ascx.cs" Inherits="Maticsoft.Web.Controls.LearnCourse" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%--<script>
    function FastComment(ids) {
        var CommentID = $("#txtComment" + ids).val();
        var userID = $("#txtID" + ids).val();
        var CourseID = $("#CourseID" + ids).val();
        //获得评分结果
        if (CommentID != "") {
            $.ajax({
                url: "EvaluateHandle.aspx",
                type: "post", dataType: "text", timeout: 10000,
                data: { action: "nolearn", courseID: CourseID, mark: "", content: CommentID, userId: userID },
                success: function (resultData) {
                    if (resultData == "Success") {
                        alert("评论成功");
                        $("#btnComment" + ids).hide();
                        $("#aComment" + ids).text(CommentID);
                        $("#txtComment" + ids).hide();
                    } else {
                        alert("失败！");
                    }
                }
            });
        } else {
        alert("请先输入评论内容！");
        }
    }
</script>--%>

<div class="setableBox">
<div>
    <table border="0" cellspacing="0" cellpadding="0">
        <tr style="background-color: #CDD8E5; height: 30px;">
			<td align="center" valign="middle" class="a2">订单编号</td>
			<td align="center" valign="middle" class="a1">所选课程</td>
			<td align="center" valign="middle" class="a2">教师</td>
			<td align="center" valign="middle" class="a2">价格</td>
			<td align="center" valign="middle" class="a1">购买时间</td>
			<td align="center" valign="middle" class="a1">评价</td>
			<td align="center" valign="middle" class="a3">评论</td>
        </tr>
        <asp:Repeater ID="rptPrice" runat="server" 
            OnItemDataBound="rptPrice_ItemDataBound" onitemcommand="rptPrice_ItemCommand">
            <ItemTemplate>
                <tr class='rptclass'>
                    <td align="center" valign="middle" class="b2"><%#Eval("OrderID")%>
                        <asp:Label ID="LabOid" runat="server" Text='<%#Eval("OrderID") %>' Visible="false"></asp:Label></td>
                    <td align="center" valign="middle" class="b1"><%#Eval("CourseName") %><asp:Label ID="labCid" runat="server" Text='<%#Eval("CourseID") %>' Visible="false"></asp:Label></td>
                    <td align="center" valign="middle" class="b2"><%#Eval("TrueName") %></td>
                    <td align="center" valign="middle" class="b2"><%#Eval("Amount", "{0:C}")%></td>
                    <td align="center" valign="middle" class="b1"><%#Eval("OrderDate")%></td>
                    <td align="center" valign="middle" class="b1"><img src="../images/xing.jpg"/></td>
                    <td align="center" valign="middle" class="b3">
                        <%#Eval("Comment")%><br />
                        <asp:TextBox ID="txtCom" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:ImageButton ID="imgBtn" runat="server" CommandArgument="btnCom" ImageUrl="../images/kspl.jpg" /> </td>
                    <%--<td>
                        <%#Eval("Comment")%>
                        <label id='<%#Eval("OrderID","aComment{0}")%>'></label>
                        <textarea id='<%#Eval("OrderID","txtComment{0}")%>'></textarea><br />
                        <input type="button" id='<%#Eval("OrderID","btnComment{0}")%>' value="快速评论" onclick='FastComment(<%#Eval("OrderID")%>)' />
                    </td>--%>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
</div>
<%--<div class="openPage">--%>
	<span>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10"
            OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="false" NumericButtonCount="3">
        </webdiyer:AspNetPager>
	</span>

