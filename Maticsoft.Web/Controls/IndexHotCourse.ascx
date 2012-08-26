<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexHotCourse.ascx.cs" Inherits="Maticsoft.Web.Controls.IndexHotCourse" %>

                              <asp:Repeater ID="Repeater_Hot" runat="server" 
    onitemdatabound="Repeater_Hot_ItemDataBound">
                                <HeaderTemplate>
							        <div class="orderText">
								        <div class="oTleft">课程名称</div>
								        <div class="oTright">人气</div>
							        </div>
                                    <div class="orderList">
                                </HeaderTemplate>
                                <ItemTemplate>
								    <span>
                                        <asp:Label ID="labName" runat="server" Text=""></asp:Label>
									    <div class="oLright" title="浏览量"><%#Eval("PV") %></div>
								    </span>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                              </asp:Repeater>