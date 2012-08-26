<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountsList.ascx.cs" Inherits="Maticsoft.Web.Controls.AccountsList" %>

			<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

			<div class="balancetableBox">
					<table border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td align="center" valign="middle" class="a1">时间</td>
							<td align="center" valign="middle" class="a2">存入</td>
							<td align="center" valign="middle" class="a3">支出</td>
							<td align="center" valign="middle" class="a4">余额</td>
							<td align="center" valign="middle" class="a5">备注</td>
						</tr>
                        <asp:Repeater ID="rpt_ThreeRecord" runat="server">
                         <ItemTemplate>
						<tr>
							<td align="center" valign="middle" class="b1"><%#Eval("CreateDate")%></td>
							<td align="right" valign="middle" class="b2"><%#Eval("Income", "{0:C}")%></td>
							<td align="right" valign="middle" class="b3"><%#Eval("Pay", "{0:C}")%></td>
							<td align="right" valign="middle" class="b4"><%#Eval("Balance", "{0:C}")%></td>
							<td align="center" valign="middle" class="b5"><%#Eval("Remark") %></td>
						</tr>
                        </ItemTemplate>
                        </asp:Repeater>
					</table>
            </div>
<%--<div class="balancePage">--%>
					<span>
						<%--<a href="#">1</a>&nbsp;&nbsp;|&nbsp;&nbsp;
						<a href="#">2</a>&nbsp;&nbsp;|&nbsp;&nbsp;
						<a href="#">3</a>&nbsp;&nbsp;...&nbsp;&nbsp;
						<a href="#" style="color:#024987;">更多></a>--%>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CurrentPageButtonPosition="Center"
                            CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" PrevPageText="上一页"
                            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" PageSize="10"
                            OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
					</span>
<%--</div>--%>

