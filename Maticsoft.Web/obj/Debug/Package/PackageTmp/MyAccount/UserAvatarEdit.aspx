<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount/AccountBasic.Master" AutoEventWireup="true" CodeBehind="UserAvatarEdit.aspx.cs" Inherits="Maticsoft.Web.MyAccount.UserAvatarEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/AvatarCut.css" rel="stylesheet" type="text/css" />
    <script src="../js/CutAvatar/jquery1.2.6.pack.js" type="text/javascript"></script>
    <script src="../js/CutAvatar/ui.core.packed.js" type="text/javascript"></script>
    <script src="../js/CutAvatar/ui.draggable.packed.js" type="text/javascript"></script>
    <script src="../js/CutAvatar/CutPic.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="MainBody" style="float: right; margin-right: 80px; margin-top: 10px; padding-left: 10px;padding-top: 10px;">
                &nbsp;<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="safari-style1">
                    <tr>
                        <td align="left" valign="top">
                            <div id="Step1Container">
                                <div class="title">
                                    <b>选择要上传的图片</b></div>
                                <div class="uploadtooltip">
                                    请选择新的照片文件，文件需小于1MB，图片格式为jpg.</div>
                                <br />
                                <div class="uploaddiv">
                                    <asp:FileUpload ID="fuPhoto" runat="server" ToolTip="选择照片" Style="padding: 3px;" /></div>
                                <br />
                                <div class="uploaddiv">
                                    <asp:Button ID="btnUpload" runat="server" Text="上 传" Style="padding: 3px;"   onclick="btnUpload_Click" />
                                </div>
                            </div> </td>
                            <td width="70px"></td>
    <td>

        <div id="Step2Container">
            <div class="title">
                <b>裁切头像照片</b></div>
            <div class="uploadtooltip">
                您可以拖动照片以裁剪满意的头像</div>
            <div id="Canvas" class="uploaddiv">
                <div id="ImageDragContainer">
                    <asp:Image ID="ImageDrag" runat="server" ImageUrl="../Images/blank.jpg" CssClass="imagePhoto"
                        ToolTip="" />
                </div>
                <div id="IconContainer">
                    <asp:Image ID="ImageIcon" runat="server" ImageUrl="../Images/blank.jpg" CssClass="imagePhoto"
                        ToolTip="" />
                </div>
            </div>
            <div class="uploaddiv">
                <table>
                    <tr>
                        <td id="Min">
                            <img alt="缩小" src="../Images/_c.gif" onmouseover="this.src='../Images/_c.gif';" onmouseout="this.src='../Images/_h.gif';"
                                id="moresmall" class="smallbig" />
                        </td>
                        <td>
                            <div id="bar">
                                <div class="child">
                                </div>
                            </div>
                        </td>
                        <td id="Max">
                            <img alt="放大" src="../Images/c.gif" onmouseover="this.src='../Images/c.gif';" onmouseout="this.src='../Images/h.gif';"
                                id="morebig" class="smallbig" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="uploaddiv">
                <asp:Button ID="btnUpdateGravatar" runat="server" Text="保存头像" onclick="btnUpdateGravatar_Click" />
            </div>
            <div style="display: none">
                图片实际宽度：
                <asp:TextBox ID="txt_width" runat="server" Text="1">
                </asp:TextBox><br />
                图片实际高度：
                <asp:TextBox ID="txt_height" runat="server" Text="1">
                </asp:TextBox><br />
                距离顶部：
                <asp:TextBox ID="txt_top" runat="server" Text="47">
                </asp:TextBox><br />
                距离左边：
                <asp:TextBox ID="txt_left" runat="server" Text="38">
                </asp:TextBox><br />
                截取框的宽：
                <asp:TextBox ID="txt_DropWidth" runat="server" Text="120">
                </asp:TextBox><br />
                截取框的高：
                <asp:TextBox ID="txt_DropHeight" runat="server" Text="120">
                </asp:TextBox><br />
                放大倍数：
                <asp:TextBox ID="txt_Zoom" runat="server">
                </asp:TextBox>
            </div>
        </div>
    </td>
    </tr>
    <tr>
        <td class="style2">
        </td>
        <td>
        </td>
    </tr>
    </table> </div>
</asp:Content>
