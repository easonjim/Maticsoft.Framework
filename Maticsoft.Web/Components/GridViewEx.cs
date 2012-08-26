using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls
{
    public enum CheckColumnAlign
    {
        Left, Right, Center
    }

    public enum CheckColumnVAlign
    {
        Top, Middle, Bottom
    }

    #region 多语言文字

    public class GridViewUIText
    {
        public static string ExportExcel
        {
            get
            {
                return Resources.Site.GVTextExportExcel;
            }
        }

        public static string ExportWord
        {
            get
            {
                return Resources.Site.GVTextExportWord;
            }
        }

        public static string First
        {
            get
            {
                return Resources.Site.GVTextFirst;
            }
        }

        public static string Previous
        {
            get
            {
                return Resources.Site.GVTextPrevious;
            }
        }

        public static string Next
        {
            get
            {
                return Resources.Site.GVTextNext;
            }
        }

        public static string Last
        {
            get
            {
                return Resources.Site.GVTextLast;
            }
        }

        public static string Page
        {
            get
            {
                return Resources.Site.GVTextPage;
            }
        }

        public static string Record
        {
            get
            {
                return Resources.Site.GVTextRecord;
            }
        }
    }

    #endregion 多语言文字

    public delegate void BindEventHandler();

    [ToolboxData(@"<{0}:GridViewEx runat='server'></{0}:GridViewEx>")]
    public class GridViewEx : GridView
    {
        private SortTip sortTip;

        /// <summary>
        /// 排序提示信息
        /// </summary>
        [Description("排序提示信息"), Category("扩展"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)]
        public SortTip SortTip
        {
            get
            {
                if (sortTip == null)
                {
                    sortTip = new SortTip();
                }
                return sortTip;
            }
            set
            {
                sortTip = value;
            }
        }

        public string CheckBoxID
        {
            get
            {
                return "ItemCheckBox";
            }
        }

        //增加了一个设置是否显示“导出Word”按钮的属性
        /// <summary>
        /// 排序提示信息
        /// </summary>
        [Description("显示导出到Word"), Category("扩展"), DefaultValue(true)]
        public virtual bool ShowExportWord
        {
            get
            {
                object obj2 = this.ViewState["ShowExportWord"];
                if (obj2 != null)
                {
                    return (bool)obj2;
                }
                return true;
            }
            set
            {
                bool aShowExportWord = this.ShowExportWord;
                if (value != aShowExportWord)
                {
                    this.ViewState["ShowExportWord"] = value;
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        //增加了一个设置是否显示“导出Excel”按钮的属性
        [Description("显示导出到Excel"), Category("扩展"), DefaultValue(true)]
        public virtual bool ShowExportExcel
        {
            get
            {
                object obj2 = this.ViewState["ShowExportExcel"];
                if (obj2 != null)
                {
                    return (bool)obj2;
                }
                return true;
            }
            set
            {
                bool aShowExportExcel = this.ShowExportExcel;
                if (value != aShowExportExcel)
                {
                    this.ViewState["ShowExportExcel"] = value;
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        //是否显示全选
        [Description("显示全选列"), Category("扩展"), DefaultValue(false)]
        public virtual bool ShowCheckAll
        {
            get
            {
                object obj2 = this.ViewState["ShowCheckAll"];
                if (obj2 != null)
                {
                    return (bool)obj2;
                }
                return false;
            }
            set
            {
                bool aShowCheckAll = this.ShowCheckAll;
                if (value != aShowCheckAll)
                {
                    this.ViewState["ShowCheckAll"] = value;
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        [Description("全选列的位置"), Category("扩展"), DefaultValue(CheckColumnAlign.Left)]
        public virtual CheckColumnAlign CheckColumnAlign
        {
            get
            {
                object obj2 = this.ViewState["CheckColumnAlign"];
                if (obj2 != null)
                {
                    return (CheckColumnAlign)obj2;
                }
                return CheckColumnAlign.Left;
            }
            set
            {
                CheckColumnAlign aCheckColumnAlign = this.CheckColumnAlign;
                if (value != aCheckColumnAlign)
                {
                    this.ViewState["CheckColumnAlign"] = value;
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        [Description("选择列的位置"), Category("扩展"), DefaultValue(CheckColumnVAlign.Middle)]
        public virtual CheckColumnVAlign CheckColumnVAlign
        {
            get
            {
                object obj2 = this.ViewState["CheckColumnVAlign"];
                if (obj2 != null)
                {
                    return (CheckColumnVAlign)obj2;
                }
                return CheckColumnVAlign.Middle;
            }
            set
            {
                CheckColumnVAlign aCheckColumnAlign = this.CheckColumnVAlign;
                if (value != aCheckColumnAlign)
                {
                    this.ViewState["CheckColumnVAlign"] = value;
                    if (base.Initialized)
                    {
                        base.RequiresDataBinding = true;
                    }
                }
            }
        }

        public GridViewEx()
        {
            this.AutoGenerateColumns = false;
            this.AllowSorting = true;
            this.AllowPaging = true;
        }

        #region OnBind

        public event BindEventHandler Bind;

        public virtual void OnBind()
        {
            if (Bind != null)
            {
                Bind();

                if (DataSetSource != null)
                {
                    int rows_Count = DataSetSource.Tables[0].Rows.Count;
                    DataView dv = DataSetSource.Tables[0].DefaultView;
                    string sortStr = "";
                    if (rows_Count != 0)
                    {
                        if (!string.IsNullOrEmpty(SortExpressionStr))
                        {
                            sortStr = SortExpressionStr + " " + SortDirectionStr;
                        }

                        if (!string.IsNullOrEmpty(sortStr))
                        {
                            dv.Sort = sortStr;
                        }
                    }
                    if (!string.IsNullOrEmpty(FilterExpressionStr))
                    {
                        dv.RowFilter = FilterExpressionStr;
                    }
                    this.DataSource = dv;
                    rows_Count = dv.ToTable().Rows.Count;
                    this.DataBind();
                    if (this.Controls.Count > 0)
                    {
                        Table t = this.Controls[0] as Table;
                        if (t != null)
                        {
                            foreach (TableRow r in t.Rows)
                            {
                                foreach (TableCell c in r.Cells)
                                {
                                    c.Wrap = Wrap;
                                }
                            }
                        }
                    }
                    //分页

                    int page_Size = this.PageSize;
                    int page_Count = this.PageCount;
                    int page_Current = this.PageIndex + 1;

                    lblRowsCount.Text = rows_Count.ToString();
                    lblPageCount.Text = page_Count.ToString();
                    lblCurrentPage.Text = page_Current.ToString();

                    #region 显示页导航

                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;

                    if (this.PageIndex == 0)
                    {
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        if (page_Count == 0)
                        {
                            btnNext.Enabled = false;
                            btnLast.Enabled = false;
                        }
                        if (this.PageCount == 1)
                        {
                            btnLast.Enabled = false;
                            btnNext.Enabled = false;
                        }
                    }
                    else if (this.PageIndex == this.PageCount - 1)
                    {
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                    }

                    #endregion 显示页导航

                    #region 显示Foot页导航

                    btnFirstFoot.Enabled = true;
                    btnPrevFoot.Enabled = true;
                    btnNextFoot.Enabled = true;
                    btnLastFoot.Enabled = true;

                    if (this.PageIndex == 0)
                    {
                        btnFirstFoot.Enabled = false;
                        btnPrevFoot.Enabled = false;
                        if (page_Count == 0)
                        {
                            btnNextFoot.Enabled = false;
                            btnLastFoot.Enabled = false;
                        }
                        if (this.PageCount == 1)
                        {
                            btnLastFoot.Enabled = false;
                            btnNextFoot.Enabled = false;
                        }
                    }
                    else if (this.PageIndex == this.PageCount - 1)
                    {
                        btnLastFoot.Enabled = false;
                        btnNextFoot.Enabled = false;
                    }

                    #endregion 显示Foot页导航
                }
            }
        }

        #endregion OnBind

        [Description("过滤条件表达式"), Category("扩展"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual string FilterExpressionStr
        {
            get
            {
                if (ViewState["FilterExpression"] == null)
                {
                    return null;
                }
                return ViewState["FilterExpression"].ToString();
            }
            set
            {
                ViewState["FilterExpression"] = value;
            }
        }

        [Description("排序表达式"), Category("扩展"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual string SortExpressionStr
        {
            get
            {
                if (ViewState["SortExpression"] == null)
                {
                    return null;
                }
                return ViewState["SortExpression"].ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        [Description("排序方向"), Category("扩展"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual string SortDirectionStr
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    return "DESC";
                }
                if (ViewState["SortDirection"].ToString().ToLower() != "asc" && ViewState["SortDirection"].ToString().ToLower() != "desc")
                {
                    return "DESC";
                }
                return ViewState["SortDirection"].ToString();
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        [Description("显示上部的工具栏"), Category("扩展"), DefaultValue(true)]
        public bool ShowToolBar
        {
            get
            {
                if (ViewState["ShowToolBar"] != null)
                {
                    return Convert.ToBoolean(ViewState["ShowToolBar"]);
                }
                return true;
            }
            set
            {
                ViewState["ShowToolBar"] = value;
            }
        }

        [Description("显示页脚的上下页导航"), Category("扩展"), DefaultValue(false)]
        public bool ShowFootPageButton
        {
            get
            {
                if (ViewState["ShowFootPageButton"] != null)
                {
                    return Convert.ToBoolean(ViewState["ShowFootPageButton"]);
                }
                return false;
            }
            set
            {
                ViewState["ShowFootPageButton"] = value;
            }
        }

        [Description("显示网格线"), Category("扩展"), DefaultValue(true)]
        public bool ShowGridLine
        {
            get
            {
                if (ViewState["ShowGridLine"] != null)
                {
                    return Convert.ToBoolean(ViewState["ShowGridLine"]);
                }
                return true;
            }
            set
            {
                ViewState["ShowGridLine"] = value;
            }
        }

        [Description("行高"), Category("扩展"), DefaultValue(25)]
        public string RowHeight
        {
            get
            {
                if (ViewState["RowHeight"] != null)
                {
                    return ViewState["RowHeight"].ToString();
                }
                return "27px";
            }
            set
            {
                ViewState["RowHeight"] = value;
            }
        }

        [Description("单元格是否换行"), Category("扩展"), DefaultValue(true)]
        public bool Wrap
        {
            get
            {
                if (ViewState["Wrap"] != null)
                {
                    return Convert.ToBoolean(ViewState["Wrap"]);
                }
                return true;
            }
            set
            {
                ViewState["Wrap"] = value;
            }
        }

        private Table table = new Table();

        #region OnInit

        private LinkButton btnExportWord;
        private LinkButton btnExport;
        private Label lblCurrentPage;
        private Label lblPageCount;
        private Label lblRowsCount;
        private LinkButton btnFirst;
        private LinkButton btnPrev;
        private LinkButton btnNext;
        private LinkButton btnLast;
        private LinkButton btnFirstFoot;
        private LinkButton btnPrevFoot;
        private LinkButton btnNextFoot;
        private LinkButton btnLastFoot;

        protected override void OnInit(EventArgs e)
        {
            this.EnableViewState = true;

            btnExport = new LinkButton();
            btnExport.CommandName = "ExportToExcel";
            btnExport.EnableViewState = true;
            btnExport.Text = GridViewUIText.ExportExcel;
            btnExport.CausesValidation = false;

            btnExportWord = new LinkButton();
            btnExportWord.CommandName = "ExportToWord";
            btnExportWord.EnableViewState = true;
            btnExportWord.Text = GridViewUIText.ExportWord;
            btnExportWord.CausesValidation = false;

            lblCurrentPage = new Label();
            lblCurrentPage.ForeColor = ColorTranslator.FromHtml("#e78a29");
            lblCurrentPage.Text = "1";

            lblPageCount = new Label();
            lblPageCount.Text = "1";

            lblRowsCount = new Label();
            lblRowsCount.ForeColor = ColorTranslator.FromHtml("#e78a29");

            btnFirst = new LinkButton();
            btnFirst.Text = GridViewUIText.First;
            btnFirst.Command += new CommandEventHandler(NavigateToPage);
            btnFirst.CommandName = "Pager";
            btnFirst.CommandArgument = "First";
            btnFirst.CausesValidation = false;

            btnPrev = new LinkButton();
            btnPrev.Text = GridViewUIText.Previous;
            btnPrev.Command += new CommandEventHandler(NavigateToPage);
            btnPrev.CommandName = "Pager";
            btnPrev.CommandArgument = "Prev";
            btnPrev.CausesValidation = false;

            btnNext = new LinkButton();
            btnNext.Text = GridViewUIText.Next;
            btnNext.Command += new CommandEventHandler(NavigateToPage);
            btnNext.CommandName = "Pager";
            btnNext.CommandArgument = "Next";
            btnNext.CausesValidation = false;

            btnLast = new LinkButton();
            btnLast.Text = GridViewUIText.Last;
            btnLast.Command += new CommandEventHandler(NavigateToPage);
            btnLast.CommandName = "Pager";
            btnLast.CommandArgument = "Last";
            btnLast.CausesValidation = false;

            #region foot

            btnFirstFoot = new LinkButton();
            btnFirstFoot.Text = GridViewUIText.First;
            btnFirstFoot.Command += new CommandEventHandler(NavigateToPageFoot);
            btnFirstFoot.CommandName = "Pager";
            btnFirstFoot.CommandArgument = "First";
            btnFirstFoot.CausesValidation = false;

            btnPrevFoot = new LinkButton();
            btnPrevFoot.Text = GridViewUIText.Previous;
            btnPrevFoot.Command += new CommandEventHandler(NavigateToPageFoot);
            btnPrevFoot.CommandName = "Pager";
            btnPrevFoot.CommandArgument = "Prev";
            btnPrevFoot.CausesValidation = false;

            btnNextFoot = new LinkButton();
            btnNextFoot.Text = GridViewUIText.Next;
            btnNextFoot.Command += new CommandEventHandler(NavigateToPageFoot);
            btnNextFoot.CommandName = "Pager";
            btnNextFoot.CommandArgument = "Next";
            btnNextFoot.CausesValidation = false;

            btnLastFoot = new LinkButton();
            btnLastFoot.Text = GridViewUIText.Last;
            btnLastFoot.Command += new CommandEventHandler(NavigateToPageFoot);
            btnLastFoot.CommandName = "Pager";
            btnLastFoot.CommandArgument = "Last";
            btnLastFoot.CausesValidation = false;

            #endregion foot

            base.OnInit(e);

            this.BorderWidth = new Unit(1);
        }

        #endregion OnInit

        private DataSet _ds;

        [Description("自定义的DataSet类型数据源"), Category("扩展"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual DataSet DataSetSource
        {
            get
            {
                return _ds;
            }
            set
            {
                _ds = value;
            }
        }

        #region NavigateToPage

        public void NavigateToPage(object sender, CommandEventArgs e)
        {
            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            switch (e.CommandArgument.ToString())
            {
                case "Prev":
                    if (this.PageIndex > 0)
                    {
                        this.PageIndex -= 1;
                    }
                    break;

                case "Next":
                    if (this.PageIndex < (this.PageCount - 1))
                    {
                        this.PageIndex += 1;
                    }
                    break;

                case "First":
                    this.PageIndex = 0;
                    break;

                case "Last":
                    this.PageIndex = this.PageCount - 1;
                    break;
            }
            if (this.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (this.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (this.PageIndex == this.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            OnBind();
        }

        public void NavigateToPageFoot(object sender, CommandEventArgs e)
        {
            btnFirstFoot.Enabled = true;
            btnPrevFoot.Enabled = true;
            btnNextFoot.Enabled = true;
            btnLastFoot.Enabled = true;
            switch (e.CommandArgument.ToString())
            {
                case "Prev":
                    if (this.PageIndex > 0)
                    {
                        this.PageIndex -= 1;
                    }
                    break;

                case "Next":
                    if (this.PageIndex < (this.PageCount - 1))
                    {
                        this.PageIndex += 1;
                    }
                    break;

                case "First":
                    this.PageIndex = 0;
                    break;

                case "Last":
                    this.PageIndex = this.PageCount - 1;
                    break;
            }
            if (this.PageIndex == 0)
            {
                btnFirstFoot.Enabled = false;
                btnPrevFoot.Enabled = false;
                if (this.PageCount == 1)
                {
                    btnLastFoot.Enabled = false;
                    btnNextFoot.Enabled = false;
                }
            }
            else if (this.PageIndex == this.PageCount - 1)
            {
                btnLastFoot.Enabled = false;
                btnNextFoot.Enabled = false;
            }
            OnBind();
        }

        #endregion NavigateToPage

        #region OnRowCreated

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            this.Style.Add("background-color", "#e6eff8");
            this.Attributes.Add("border", "0px");
            this.Attributes.Add("cellpadding", "4px");
            this.Attributes.Add("cellspacing", "1px");

            this.Attributes.Add("class", "GridViewTyle");

            e.Row.Style.Add("height", RowHeight);
            e.Row.Attributes.Add("height", RowHeight);

            try
            {
                //页眉
                //if (e.Row.RowType == DataControlRowType.Header)
                //    AddGlyph(GridView1, e.Row);

                #region 页导航 Pager

                if (e.Row.RowType == DataControlRowType.Pager)
                {
                    TableRow row = e.Row.Controls[0].Controls[0].Controls[0] as TableRow;

                    foreach (TableCell cell in row.Cells)
                    {
                        Control lb = cell.Controls[0];
                        if (lb is Label)
                        {
                            Label lblpage = (Label)lb;
                            lblpage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e78a29");
                            lblpage.Font.Bold = true;
                            lblpage.Text = "[" + lblpage.Text + "]";
                        }
                        else
                            if (lb is LinkButton)
                            {
                                LinkButton lblpage = (LinkButton)lb;
                                lblpage.Font.Bold = true;
                                lblpage.Text = "[" + lblpage.Text + "]";
                                lblpage.Style.Add("color", "#1317fc");
                            }
                    }

                    #region 分页导航

                    if (ShowFootPageButton)
                    {
                        TableCell cellbtnFirst = new TableCell();
                        cellbtnFirst.Controls.Add(btnFirstFoot);
                        row.Cells.AddAt(0, cellbtnFirst);

                        TableCell cellbtnPrev = new TableCell();
                        cellbtnPrev.Controls.Add(btnPrevFoot);
                        row.Cells.AddAt(1, cellbtnPrev);

                        TableCell cellbtnNext = new TableCell();
                        cellbtnNext.Controls.Add(btnNextFoot);
                        row.Cells.Add(cellbtnNext);

                        TableCell cellbtnLast = new TableCell();
                        cellbtnLast.Controls.Add(btnLastFoot);
                        row.Cells.Add(cellbtnLast);
                    }

                    #endregion 分页导航
                }

                #endregion 页导航 Pager

                if (ShowCheckAll)
                {
                    #region

                    GridViewRow row = e.Row;

                    if (row.RowType == DataControlRowType.Header)
                    {
                        TableCell cell = new TableCell();
                        cell.Wrap = Wrap;
                        cell.Width = Unit.Pixel(30);
                        cell.Style.Clear();
                        cell.Style.Add("BACKGROUND-IMAGE", "url(/admin/images/title.gif)");//f4f6f8  BACKGROUND-IMAGE: url(/admin/images/title.gif)
                        cell.Text = " <input id='Checkbox2' type='checkbox' onclick='CheckAll(this)'/><label></label>";
                        if (CheckColumnAlign == CheckColumnAlign.Left)
                        {
                            row.Cells.AddAt(0, cell);
                        }
                        else
                        {
                            int index = row.Cells.Count;
                            row.Cells.AddAt(index, cell);
                        }
                    }
                    else if (row.RowType == DataControlRowType.DataRow)
                    {
                        TableCell cell = new TableCell();

                        cell.Wrap = Wrap;
                        switch (CheckColumnVAlign)
                        {
                            case CheckColumnVAlign.Top:
                                cell.VerticalAlign = VerticalAlign.Top;
                                break;

                            case CheckColumnVAlign.Middle:
                                cell.VerticalAlign = VerticalAlign.Middle;
                                break;

                            case CheckColumnVAlign.Bottom:
                                cell.VerticalAlign = VerticalAlign.Bottom;
                                break;
                        }

                        CheckBox cb = new CheckBox();
                        cell.Width = Unit.Pixel(30);
                        cell.Style.Clear();
                        cb.ID = "ItemCheckBox";
                        cell.Controls.Add(cb);
                        if (CheckColumnAlign == CheckColumnAlign.Left)
                        {
                            row.Cells.AddAt(0, cell);
                        }
                        else
                        {
                            int index = row.Cells.Count;
                            row.Cells.AddAt(index, cell);
                        }
                    }

                    #endregion OnRowCreated
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    #region

                    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#E3EFFF';this.style.cursor='pointer';");
                    //当鼠标移走时还原该行的背景色
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

                    //e.Row.Style.Add("background-color", "#FFFFFF");
                    e.Row.Style.Add("color", "#666666");

                    foreach (TableCell tc in e.Row.Cells)
                    {
                        if (ShowGridLine)
                        {
                            tc.Style.Add("border-bottom", "1px dashed #b8dae9");
                        }
                        tc.Style.Add("padding-left", "5px");

                        tc.Style.Add("height", RowHeight);
                        tc.Attributes.Add("height", RowHeight);
                    }

                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        foreach (Control c in e.Row.Cells[i].Controls)
                        {
                            if (c is LinkButton)
                            {
                                LinkButton aLinkButton = c as LinkButton;
                                aLinkButton.Style.Add("color", "#1317fc");
                            }
                            if (c is HtmlAnchor)
                            {
                                HtmlAnchor aHtmlAnchor = c as HtmlAnchor;
                                aHtmlAnchor.Style.Add("color", "#1317fc");
                            }
                        }
                    }

                    #endregion
                }

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    #region

                    e.Row.Style.Add("height", RowHeight);
                    e.Row.Attributes.Add("height", RowHeight);
                    e.Row.Style.Add("background-color", "#E3EFFF");//f4f6f8
                    e.Row.Style.Add("color", "#003366");

                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (ShowGridLine)
                            {
                                e.Row.Cells[i].Style.Add("border", "1px solid #dae2e8");
                            }
                            e.Row.Cells[i].Style.Add("border-right", "0px");
                        }
                        else if (i == e.Row.Cells.Count)
                        {
                            if (ShowGridLine)
                            {
                                e.Row.Cells[i].Style.Add("border", "1px solid #dae2e8");
                            }
                            e.Row.Cells[i].Style.Add("border-left", "0px");
                        }
                        else
                        {
                            if (ShowGridLine)
                            {
                                e.Row.Cells[i].Style.Add("border", "1px solid #dae2e8");
                            }
                            e.Row.Cells[i].Style.Add("border-left", "0px");
                            e.Row.Cells[i].Style.Add("border-right", "0px");
                        }

                        foreach (Control c in e.Row.Cells[i].Controls)
                        {
                            if (c is LinkButton)
                            {
                                LinkButton aLinkButton = c as LinkButton;
                                aLinkButton.Style.Add("color", "#003366");
                            }
                            if (c is HtmlAnchor)
                            {
                                HtmlAnchor aHtmlAnchor = c as HtmlAnchor;
                                aHtmlAnchor.Style.Add("color", "#003366");
                            }
                        }
                    }

                    #endregion
                }

                if (this.AllowSorting && !SortTip.IsNotSet)
                    if (e.Row.RowType == DataControlRowType.Header)
                    {
                        foreach (TableCell cell in e.Row.Cells)
                        {
                            foreach (Control c in cell.Controls)
                            {
                                if (c is LinkButton)
                                {
                                    LinkButton lb = c as LinkButton;
                                    if (lb == null)
                                    {
                                        continue;
                                    }
                                    if (lb.CommandArgument == this.SortExpressionStr)
                                    {
                                        System.Web.UI.WebControls.Image img;
                                        if (this.SortDirectionStr == "DESC")
                                        {
                                            img = new System.Web.UI.WebControls.Image();
                                            img.ImageAlign = ImageAlign.AbsMiddle;
                                            img.ImageUrl = base.ResolveUrl(SortTip.DescImg);
                                        }
                                        else
                                        {
                                            img = new System.Web.UI.WebControls.Image();
                                            img.ImageAlign = ImageAlign.AbsMiddle;
                                            img.ImageUrl = base.ResolveUrl(SortTip.AscImg);
                                        }
                                        if (img != null)
                                        {
                                            cell.Controls.Add(img);
                                        }
                                    }
                                }
                            }
                        }
                    }
                base.OnRowCreated(e);
            }
            catch
            {
            }
        }

        #endregion

        #region CreateChildControls

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int res = base.CreateChildControls(dataSource, dataBinding);
            if (ShowToolBar)
            {
                try
                {
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Pager, DataControlRowState.Normal);
                    TableCell c = new TableCell();
                    c.Width = Unit.Percentage(100);
                    c.ColumnSpan = this.Columns.Count;
                    if (ShowCheckAll)
                    {
                        c.ColumnSpan++;
                    }
                    row.Cells.Add(c);
                    TableCell cell1 = new TableCell();
                    Table table = new Table();
                    TableRow r = new TableRow();
                    table.Rows.Add(r);
                    table.Width = Unit.Percentage(100);
                    c.Controls.Add(table);
                    r.Cells.Add(cell1);

                    Literal l1 = new Literal();
                    l1.Text = GridViewUIText.Page + "：";
                    cell1.Controls.Add(l1);
                    cell1.Wrap = false;
                    cell1.Controls.Add(lblCurrentPage);
                    l1 = new Literal();
                    l1.Text = "/";
                    cell1.Controls.Add(l1);
                    cell1.Controls.Add(lblPageCount);
                    l1 = new Literal();
                    l1.Text = "，" + GridViewUIText.Record + ":";
                    cell1.Controls.Add(l1);
                    cell1.Controls.Add(lblRowsCount);
                    l1 = new Literal();
                    l1.Text = "";
                    cell1.HorizontalAlign = HorizontalAlign.Left;
                    cell1.Controls.Add(l1);
                    TableCell cell2 = new TableCell();
                    cell2.HorizontalAlign = HorizontalAlign.Right;
                    cell2.Wrap = false;

                    if (this.ShowExportExcel == true)
                    {
                        l1 = new Literal();
                        l1.Text = " [";
                        cell2.Controls.Add(l1);
                        cell2.Controls.Add(btnExport);
                        l1 = new Literal();
                        l1.Text = "] ";
                        cell2.Controls.Add(l1);
                    }

                    if (this.ShowExportWord == true)
                    {
                        l1 = new Literal();
                        l1.Text = " [";
                        cell2.Controls.Add(l1);
                        cell2.Controls.Add(btnExportWord);
                        l1 = new Literal();
                        l1.Text = "] ";
                        cell2.Controls.Add(l1);
                    }

                    l1 = new Literal();
                    l1.Text = " [";
                    cell2.Controls.Add(l1);
                    cell2.Controls.Add(btnFirst);
                    l1 = new Literal();
                    l1.Text = "] ";
                    cell2.Controls.Add(l1);

                    l1 = new Literal();
                    l1.Text = " [";
                    cell2.Controls.Add(l1);
                    cell2.Controls.Add(btnPrev);
                    l1 = new Literal();
                    l1.Text = "] ";
                    cell2.Controls.Add(l1);

                    l1 = new Literal();
                    l1.Text = " [";
                    cell2.Controls.Add(l1);
                    cell2.Controls.Add(btnNext);
                    l1 = new Literal();
                    l1.Text = "] ";
                    cell2.Controls.Add(l1);

                    l1 = new Literal();
                    l1.Text = " [";
                    cell2.Controls.Add(l1);
                    cell2.Controls.Add(btnLast);
                    l1 = new Literal();
                    l1.Text = "] ";
                    cell2.Controls.Add(l1);
                    r.Cells.Add(cell2);
                    this.Controls[0].Controls.AddAt(0, row);
                }
                catch
                {
                }
            }
            return res;
        }

        #endregion

        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            this.PageIndex = e.NewPageIndex;
            OnBind();
        }

        protected override void ExtractRowValues(System.Collections.Specialized.IOrderedDictionary fieldValues, GridViewRow row, bool includeReadOnlyFields, bool includePrimaryKey)
        {
            TableCell expCell = row.Cells[0];
            row.Cells.Remove(expCell);
            base.ExtractRowValues(fieldValues, row, includeReadOnlyFields, includePrimaryKey);
        }

        #region OnLoad

        protected override void OnLoad(EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" <script type=\"text/javascript\">");
            sb.Append("function CheckAll(oCheckbox)");
            sb.Append("{");
            sb.Append("var GridView2 = document.getElementById(\"" + this.ClientID + "\");");
            sb.Append(" for(i = 1;i < GridView2.rows.length; i++)");
            sb.Append("{");
            sb.Append("var inputArray = GridView2.rows[i].getElementsByTagName(\"INPUT\");");
            sb.Append("for(var j=0;j<inputArray.length;j++)");
            sb.Append("{ if(inputArray[j].type=='checkbox')");
            sb.Append("{if(inputArray[j].id.indexOf('ItemCheckBox',0)>-1){inputArray[j].checked =oCheckbox.checked; }}  }");
            sb.Append("}");
            sb.Append(" }");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CheckFun", sb.ToString(), false);
            if (!Page.IsPostBack)
            {
                try
                {
                    if (ShowGridLine)
                    {
                        this.BorderColor = ColorTranslator.FromHtml(HttpContext.Current.Application[HttpContext.Current.Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                    }
                    this.HeaderStyle.BackColor = ColorTranslator.FromHtml(HttpContext.Current.Application[HttpContext.Current.Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                    OnBind();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
            base.OnLoad(e);
        }

        #endregion

        //public string SortExpressionEx
        //{
        //    get
        //    {
        //        if (ViewState["SortExpressionEx"] == null)
        //        {
        //            return null;
        //        }
        //        return ViewState["SortExpressionEx"].ToString();
        //    }
        //    set
        //    {
        //        ViewState["SortExpressionEx"] = value;
        //    }
        //}

        #region PrepareControlHierarchy

        protected override void PrepareControlHierarchy()
        {
            if (ShowCheckAll)
            {
                if (this.Controls.Count != 0)
                {
                    bool controlStyleCreated = base.ControlStyleCreated;
                    Table table = (Table)this.Controls[0];
                    table.CopyBaseAttributes(this);
                    if (controlStyleCreated && !base.ControlStyle.IsEmpty)
                    {
                        table.ApplyStyle(base.ControlStyle);
                    }
                    else
                    {
                        table.GridLines = GridLines.Both;
                        table.CellSpacing = 0;
                    }
                    table.Caption = this.Caption;
                    table.CaptionAlign = this.CaptionAlign;
                    TableRowCollection rows = table.Rows;
                    Style s = null;
                    if (this.AlternatingRowStyle != null)
                    {
                        s = new TableItemStyle();
                        s.CopyFrom(this.RowStyle);
                        s.CopyFrom(this.AlternatingRowStyle);
                    }
                    else
                    {
                        s = this.RowStyle;
                    }
                    int num = 0;
                    bool flag2 = true;
                    foreach (GridViewRow row in rows)
                    {
                        Style style2;
                        switch (row.RowType)
                        {
                            case DataControlRowType.Header:
                                if (this.ShowHeader && (this.HeaderStyle != null))
                                {
                                    row.MergeStyle(this.HeaderStyle);
                                }
                                goto Label_0256;

                            case DataControlRowType.Footer:
                                if (this.ShowFooter && (this.FooterStyle != null))
                                {
                                    row.MergeStyle(this.FooterStyle);
                                }
                                goto Label_0256;

                            case DataControlRowType.DataRow:
                                if ((row.RowState & DataControlRowState.Edit) == DataControlRowState.Normal)
                                {
                                    goto Label_01D9;
                                }
                                style2 = new TableItemStyle();
                                if ((row.RowIndex % 2) == 0)
                                {
                                    break;
                                }
                                style2.CopyFrom(s);
                                goto Label_01A5;

                            case DataControlRowType.Pager:
                                if (row.Visible && (this.PagerStyle != null))
                                {
                                    row.MergeStyle(this.PagerStyle);
                                }
                                goto Label_0256;

                            case DataControlRowType.EmptyDataRow:
                                row.MergeStyle(this.EmptyDataRowStyle);
                                goto Label_0256;

                            default:
                                goto Label_0256;
                        }
                        style2.CopyFrom(this.RowStyle);
                    Label_01A5:
                        if (row.RowIndex == this.SelectedIndex)
                        {
                            style2.CopyFrom(this.SelectedRowStyle);
                        }
                        style2.CopyFrom(this.EditRowStyle);
                        row.MergeStyle(style2);
                        goto Label_0256;
                    Label_01D9:
                        if ((row.RowState & DataControlRowState.Selected) != DataControlRowState.Normal)
                        {
                            Style style3 = new TableItemStyle();
                            if ((row.RowIndex % 2) != 0)
                            {
                                style3.CopyFrom(s);
                            }
                            else
                            {
                                style3.CopyFrom(this.RowStyle);
                            }
                            style3.CopyFrom(this.SelectedRowStyle);
                            row.MergeStyle(style3);
                        }
                        else if ((row.RowState & DataControlRowState.Alternate) != DataControlRowState.Normal)
                        {
                            row.MergeStyle(s);
                        }
                        else
                        {
                            row.MergeStyle(this.RowStyle);
                        }
                    Label_0256:
                        if ((row.RowType != DataControlRowType.Pager) && (row.RowType != DataControlRowType.EmptyDataRow))
                        {
                            foreach (TableCell cell in row.Cells)
                            {
                                DataControlFieldCell cell2 = cell as DataControlFieldCell;
                                if (cell2 != null)
                                {
                                    DataControlField containingField = cell2.ContainingField;
                                    if (containingField != null)
                                    {
                                        if (!containingField.Visible)
                                        {
                                            cell.Visible = false;
                                            continue;
                                        }
                                        if ((row.RowType == DataControlRowType.DataRow) && flag2)
                                        {
                                            num++;
                                        }
                                        Style headerStyleInternal = null;
                                        switch (row.RowType)
                                        {
                                            case DataControlRowType.Header:
                                                headerStyleInternal = containingField.HeaderStyle;
                                                break;

                                            case DataControlRowType.Footer:
                                                headerStyleInternal = containingField.FooterStyle;
                                                break;

                                            default:
                                                headerStyleInternal = containingField.ItemStyle;
                                                break;
                                        }
                                        if (headerStyleInternal != null)
                                        {
                                            cell.MergeStyle(headerStyleInternal);
                                        }
                                        if (row.RowType == DataControlRowType.DataRow)
                                        {
                                            foreach (Control control in cell.Controls)
                                            {
                                                WebControl control2 = control as WebControl;
                                                Style controlStyleInternal = containingField.ControlStyle;
                                                if (((control2 != null) && (controlStyleInternal != null)) && !controlStyleInternal.IsEmpty)
                                                {
                                                    control2.ControlStyle.CopyFrom(controlStyleInternal);
                                                }
                                            }
                                        }
                                        continue;
                                    }
                                }
                            }
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                flag2 = false;
                            }
                        }
                    }
                    if ((this.Rows.Count > 0) && (num != this.Rows[0].Cells.Count))
                    {
                        if (ShowCheckAll)
                        {
                            num++;
                        }
                        if ((this.TopPagerRow != null) && (this.TopPagerRow.Cells.Count > 0))
                        {
                            this.TopPagerRow.Cells[0].ColumnSpan = num;
                        }
                        if ((this.BottomPagerRow != null) && (this.BottomPagerRow.Cells.Count > 0))
                        {
                            this.BottomPagerRow.Cells[0].ColumnSpan = num;
                        }
                    }
                }
            }
            else
            {
                base.PrepareControlHierarchy();
            }
        }

        #endregion

        #region OnSorting

        protected override void OnSorting(GridViewSortEventArgs e)
        {
            SortExpressionStr = e.SortExpression;
            if (SortDirectionStr.ToLower() == "asc")
            {
                SortDirectionStr = "DESC";
            }
            else
            {
                SortDirectionStr = "ASC";
            }
            OnBind();
        }

        #endregion

        private string _excelName = "FileName1";

        [Category("扩展"), DefaultValue("FileName1")]
        public string ExcelFileName
        {
            get
            {
                return _excelName;
            }
            set
            {
                _excelName = value;
            }
        }

        private string _UnExportedColumnNames = "";

        [Description("不导出的数据列集合,将HeaderText用,隔开"), Category("扩展"), PersistenceMode(PersistenceMode.InnerProperty)]
        public string UnExportedColumnNames
        {
            get
            {
                return _UnExportedColumnNames.Trim();
            }
            set
            {
                _UnExportedColumnNames = value;
            }
        }

        private void DisableControls(Control gv)
        {
            LinkButton lb = new LinkButton();

            Literal l = new Literal();

            string name = String.Empty;

            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;

                    gv.Controls.Remove(gv.Controls[i]);

                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;

                    gv.Controls.Remove(gv.Controls[i]);

                    gv.Controls.AddAt(i, l);
                }

                if (gv.Controls[i].HasControls())
                {
                    DisableControls(gv.Controls[i]);
                }
            }
        }

        #region OnRowDataBound

        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            base.OnRowDataBound(e);
        }

        #endregion

        #region OnRowCommand

        protected override void OnRowCommand(GridViewCommandEventArgs e)
        {
            base.OnRowCommand(e);
            if (e.CommandName == "ExportToExcel")
            {
                string[] ss = UnExportedColumnNames.Split(',');
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();

                foreach (string s in ss)
                {
                    if (s != ",")
                    {
                        list.Add(s);
                    }
                }
                ShowToolBar = false;
                this.AllowSorting = false;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write("<meta   http-equiv=Content-Type   content=text/html;charset=GB2312>");
                string fileName = HttpUtility.UrlEncode(ExcelFileName + ".xls", Encoding.GetEncoding("GB2312"));
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);

                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文

                ////HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
                HttpContext.Current.Response.ContentType = "application/vnd.xls";
                System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);

                System.IO.StringWriter stringWrite = new System.IO.StringWriter(myCItrad);

                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                bool showCheckAll = ShowCheckAll;
                this.ShowCheckAll = false;
                this.AllowPaging = false;
                OnBind();
                DisableControls(this);
                foreach (DataControlField c in this.Columns)
                {
                    if (list.Contains(c.HeaderText) && !string.IsNullOrEmpty(c.HeaderText))
                    {
                        c.Visible = false;
                    }
                }
                this.RenderControl(htmlWrite);
                string content = System.Text.RegularExpressions.Regex.Replace(stringWrite.ToString(), "(<a[^>]+>)|(</a>)", "");
                HttpContext.Current.Response.Write(content);
                HttpContext.Current.Response.End();

                this.AllowPaging = true;
                this.AllowSorting = true;
                ShowToolBar = true;
                this.ShowCheckAll = showCheckAll;
                OnBind();
            }
            else if (e.CommandName == "ExportToWord")
            {
                string[] ss = UnExportedColumnNames.Split(',');
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();

                foreach (string s in ss)
                {
                    if (s != ",")
                    {
                        list.Add(s);
                    }
                }
                ShowToolBar = false;
                this.AllowSorting = false;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write("<meta   http-equiv=Content-Type   content=text/html;charset=GB2312>");
                string fileName = HttpUtility.UrlEncode(ExcelFileName + ".doc", Encoding.GetEncoding("GB2312"));
                HttpContext.Current.Response.AddHeader("content-disposition",
                "attachment;filename=" + fileName);

                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文

                ////HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
                HttpContext.Current.Response.ContentType = "application/ms-word";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();

                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);

                bool showCheckAll = ShowCheckAll;
                this.ShowCheckAll = false;
                this.AllowPaging = false;
                OnBind();

                DisableControls(this);
                foreach (DataControlField c in this.Columns)
                {
                    if (list.Contains(c.HeaderText) && !string.IsNullOrEmpty(c.HeaderText))
                    {
                        c.Visible = false;
                    }
                }
                this.RenderControl(htmlWrite);
                string content = System.Text.RegularExpressions.Regex.Replace(stringWrite.ToString(), "(<a[^>]+>)|(</a>)", "");
                HttpContext.Current.Response.Write(content);
                HttpContext.Current.Response.End();
                this.AllowPaging = true;
                this.AllowSorting = true;
                ShowToolBar = true;
                ShowCheckAll = showCheckAll;
                OnBind();
            }
        }

        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            //string style = @"<style> .text { mso-number-format:\@; } </script> ";

            ////text-decoration: underline;
            writer.Write(@"
<style type='text/css'>
.text { mso-number-format:\@; }
.GridViewTyle a{ color:#1317fc;text-decoration: none;}
.GridViewTyle a:hover{ color:#1317fc;}
.GridViewTyle span{  text-align:center;}
</style>
");

            base.Render(writer);
        }
    }
}