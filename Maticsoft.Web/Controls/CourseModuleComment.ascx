<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseModuleComment.ascx.cs" Inherits="Maticsoft.Web.Controls.CourseModuleComment" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="610px">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" height="170px" 
                        style="border-collapse:separate" width="610px">
                        <tr>
                            <td>
                                <h4>
                                    我要评论</h4>
                                <a name="Comment"></a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblComment" runat="Server" ForeColor="Red"  Visible="false"
                                    Text="请输入评论内容！"></asp:Label>
                                <asp:TextBox ID="txtComment" runat="server" Height="80px" TextMode="MultiLine" 
                                    Width="600px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                        <input id="Reset1" type="reset" value=" 重 写 " />
                                <asp:Button ID="btnSubmit" runat="Server" onclick="btnSubmit_Click" 
                                    Text=" 提 交 " />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <h4>
                                    全部评论</h4>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height:30px">
                        <hr style="width:98%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="DataList_CommentList" runat="Server" DataKeyField="CourseID" 
                                    Width="610px">
                                    <ItemTemplate>
                                        <table style="width:98%;">
                                            <tr>
                                                <td rowspan="4">
                                                    <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" />
                                                </td>
                                                <td>
                                                    用户名：<asp:Label ID="UserName" runat="Server" Text='<%# Eval("UserName") %>'></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCreateDate" runat="Server" Text='<%# Eval("CommentDate") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblComment" runat="Server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                        <!-- Comment(<%# Eval("CommentID") %>,<%# Eval("UserName") %>,<%# Eval("Comment") %>) -->
                                                    <a href="#Comment" 
                                                        onclick='Comment(<%# Eval("CommentID") %>,"<%# Eval("UserName").ToString() %>","<%# Eval("Comment") %>")'>
                                                    回复</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="comment_AspNetPager" runat="server" 
                                    FirstPageText="首页" HorizontalAlign="Center" LastPageText="末页" 
                                    NextPageText="下一页" onpagechanged="comment_AspNetPager_PageChanged" 
                                    PageIndexBoxType="TextBox" PageSize="5" PrevPageText="上一页" 
                                    ShowMoreButtons="true" ShowPageIndexBox="Always" SubmitButtonText="确定" 
                                    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" AlwaysShow="True">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="HiddenField1" runat="server" />
<script type="text/javascript">
    function Comment(msg, msg1, msg2) {
        $("#CourseModuleComment1_txtComment").val("@" + msg1 + ":" + msg2);
        $("#CourseModuleComment1_HiddenField1").val(msg);
    }
</script>