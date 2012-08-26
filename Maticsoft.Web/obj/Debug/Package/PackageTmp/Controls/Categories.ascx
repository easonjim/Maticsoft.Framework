<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs"
    Inherits="Maticsoft.Web.Controls.Categories" %>
    
    <!--课程分类-->
    <script type="text/javascript">
        function Cate1Result() {
            var cate1 = document.getElementById('<%= ddlCate0.ClientID %>');
            AjaxMethod.GetCate(cate1.value, get_cate0_Result_CallBack);
        }

        function get_cate0_Result_CallBack(response) {
            if (response.value != null) {
                //debugger;
                document.all('<%= ddlCate1.ClientID %>').length = 0;
                var ds = response.value;
                if (ds != null && typeof (ds) == "object" && ds.Tables != null) {

                    document.all('<%= ddlCate1.ClientID %>').options.add(new Option("请选择", ""));
                    document.all('<%= ddlCate2.ClientID %>').length = 0;
                    document.all('<%= ddlCate2.ClientID %>').options.add(new Option("请选择", ""));
                    for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                        var name = ds.Tables[0].Rows[i].Name;
                        var id = ds.Tables[0].Rows[i].CategoryId;
                        document.all('<%= ddlCate1.ClientID %>').options.add(new Option(name, id));
                    }
                } 
            }
            else {
                document.all('<%= ddlCate1.ClientID %>').length = 0;
                document.all('<%= ddlCate1.ClientID %>').options.add(new Option("请选择", ""));
                document.all('<%= ddlCate2.ClientID %>').length = 0;
                document.all("<%= ddlCate2.ClientID %>").options.add(new Option("请选择", ""));
            }
            return
        }

        //---------------------------------
        function Cate2Result() {
            var cate2 = document.getElementById('<%= ddlCate1.ClientID %>');
            AjaxMethod.GetCate(cate2.value, get_Cate2_Result_CallBack);
        }
        function get_Cate2_Result_CallBack(response) {
            if (response.value != null) {
                document.all('<%= ddlCate2.ClientID %>').length = 0;
                var ds = response.value;
                if (ds != null && typeof (ds) == "object" && ds.Tables != null) {
                    document.all('<%= ddlCate2.ClientID %>').options.add(new Option("请选择", ""));
                    for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                        var name = ds.Tables[0].Rows[i].Name;
                        var id = ds.Tables[0].Rows[i].CategoryId;
                        document.all('<%= ddlCate2.ClientID %>').options.add(new Option(name, id));
                    }
                }

            }
            else {
                document.all('<%= ddlCate2.ClientID %>').length = 0;
                document.all('<%= ddlCate2.ClientID %>').options.add(new Option("请选择", ""));
            }
            return
        }
    </script>
<span class="textR" style="width:auto;">
    <asp:DropDownList ID="ddlCate0" runat="server" >
        <asp:ListItem Value="">请选择</asp:ListItem>
    </asp:DropDownList>
</span>&nbsp;&nbsp;&nbsp;<span class="textR"  style="width:auto;">
    <asp:DropDownList ID="ddlCate1" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
    </asp:DropDownList>
</span>&nbsp;&nbsp;&nbsp;<span class="textR"  style="width:auto;">
    <asp:DropDownList ID="ddlCate2" runat="server">
        <asp:ListItem Value="">请选择</asp:ListItem>
    </asp:DropDownList>
</span>