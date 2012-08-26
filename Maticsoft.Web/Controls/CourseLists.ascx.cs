using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Model;
using Maticsoft.Common;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web.Controls
{
    public partial class CourseLists : System.Web.UI.UserControl
    {
        private int? _recordCount;
        private string _searchKey;
        private int? _orderType;
        private string _whereStr;
        private bool _isId;
        private int? _uid;
        private bool _isRecommended;

        public bool IsRecommended
        {
            get { return _isRecommended; }
            set { _isRecommended = value; }
        }

        BLL.Tao.CourseModule coursesBll = new BLL.Tao.CourseModule();
        public override void DataBind()
        {
            if (IsId)
            {
                this.AspNetPager1.RecordCount = coursesBll.CourseCountByUid(Uid.Value);
            }
            else if (IsRecommended)
            {
            
            }
            else
            {
                if (SearchByCateId)
                {
                    this.AspNetPager1.RecordCount = coursesBll.GetCountByCateId(CateId);
                }
                else
                {
                    this.AspNetPager1.RecordCount = coursesBll.CourseRowsCount(SearchKey, WhereStr);
                }
            }
            InitData();
        }

        private void InitData()
        {
            System.Data.DataSet ds = null;
            if (IsId)
            {
                ds = coursesBll.CourseBuUid(AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, Uid, OrderType.Value);
            }
            else
            {
                if (SearchByCateId)
                {
                    ds = coursesBll.GetSearchByCateID(AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, OrderType.Value, CateId);
                }
                else
                {
                    ds = coursesBll.GetSearchRes(AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, InjectionFilter.Filter(SearchKey), OrderType.Value, WhereStr);
                }
            }
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //Model.Tao.Categories cateList = cateBll.GetModel(CateId);
                    //string CateName = string.Empty;
                    //if (cateList != null)
                    //{
                    //    CateName = cateList.Name;
                    //}
                    // Response.Redirect("/searchCourse.aspx");
                    return;
                }
                this.Repeater_List.DataSource = ds;
                this.Repeater_List.DataBind();
            }
            else
            {
                Response.Redirect("/SearchError.aspx?key=" + Server.UrlEncode(InjectionFilter.Filter(SearchKey)) + "&type=" + Types);
            }
        }

        public string getTeacherCount(object courseId, object createUid)
        {
            if (courseId != null && createUid != null)
            {
                if (!string.IsNullOrEmpty(courseId.ToString()) && !string.IsNullOrEmpty(createUid.ToString()))
                {

                    int cid = int.Parse(courseId.ToString());
                    int count = coursesBll.GetCourserteacher(cid);
                    //return count;
                    string teacherName = string.Empty;
                    if (PageValidate.IsNumber(createUid.ToString()))
                    {
                        Maticsoft.Accounts.Bus.User currentUser = new Maticsoft.Accounts.Bus.User(Convert.ToInt32(createUid));
                        if (null != currentUser)
                        {
                            teacherName = currentUser.TrueName;
                            if (count > 1)
                            {
                                return teacherName + "<br/>等" + count + "人";
                            }
                            else
                            {
                                return teacherName;
                            }
                        }
                        else
                        {
                            return "不详";
                        }
                    }
                    else
                    {
                        return "不详";
                    }
                }
                else
                {
                    return "不详";
                }
            }
            else
            {
                return "不详";
            }
        }


        protected void Repeater_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                object obj = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[5];
                if (obj == null)
                {
                    return;
                }
                Label labLook = e.Item.FindControl("labView") as Label;
                HtmlImage img = e.Item.FindControl("Buy") as HtmlImage;
                if (!Convert.ToDecimal(obj).Equals(0))
                {
                    labLook.Visible = false;
                    return;
                }
                labLook.Visible = false;
                if (img != null)
                {
                    img.Visible = false;
                }
            }
        }


        public string ConvertTimme(object time)
        {
            if (time != null)
            {
                if (!string.IsNullOrEmpty(time.ToString()))
                {
                    int timedur = int.Parse(time.ToString());
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未&nbsp;&nbsp;&nbsp;知";
                }
            }
            else
            {
                return "未&nbsp;&nbsp;&nbsp;知";
            }
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            InitData();
        }

        public int? Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public bool IsId
        {
            get { return _isId; }
            set { _isId = value; }
        }

        public int? RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        public string SearchKey
        {
            get { return _searchKey; }
            set { _searchKey = value; }
        }

        public int? OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private string _types;

        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public string WhereStr
        {
            get { return _whereStr; }
            set { _whereStr = value; }
        }

        private bool _searchByCateId;

        public bool SearchByCateId
        {
            get { return _searchByCateId; }
            set { _searchByCateId = value; }
        }

        private int _cateId;

        public int CateId
        {
            get { return _cateId; }
            set { _cateId = value; }
        }
    }
}