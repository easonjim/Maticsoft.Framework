using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Maticsoft.Common;


namespace Maticsoft.Web.Controls
{
    public partial class FavoriteCourse : System.Web.UI.UserControl
    {
        private int? _userId;
        private bool _isFav;
        private int? _recordCount;

        BLL.Tao.Favorite favBll = new BLL.Tao.Favorite();
        BLL.Tao.CourseModule coursesBll = new BLL.Tao.CourseModule();
        public override void DataBind()
        {
            this.AspNetPager1.RecordCount = favBll.GetRecordCount(UserId.Value);
            BindFavCourse();
        }

        private void BindFavCourse()
        {
            System.Data.DataSet ds = favBll.GetSinglePageRecord(UserId, AspNetPager1.StartRecordIndex, AspNetPager1.PageSize);
            this.Repeater_Fav.DataSource = ds;
            this.Repeater_Fav.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindFavCourse();
        }

        protected void Repeater_Fav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label labcid = e.Item.FindControl("labCid") as Label;
                if (labcid == null && labcid.Text == "")
                {
                    return;
                }
                if (null != Session["ModuleIDList"])
                {
                    //查询所有的购买的章节ID
                    List<int> list = (List<int>)Session["ModuleIDList"];
                    if (null != list)
                    {
                        if (list.Contains(int.Parse(labcid.Text)))
                        {

                        }
                    }
                }
                Button span = (Button)e.Item.FindControl("btnCancle");
                if (IsFav)
                {
                    span.Visible = true;
                }
                else
                {
                    span.Visible = false;
                }
            }
        }

        public int? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public bool IsFav
        {
            get { return _isFav; }
            set { _isFav = value; }
        }

        public int? RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        protected void Repeater_Fav_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("Fav"))
            {
                Label labcid = e.Item.FindControl("labCid") as Label;
                if (labcid == null && labcid.Text == "")
                {
                    return;
                }
                int ids = int.Parse(labcid.Text);
                BLL.Tao.Favorite favBll = new BLL.Tao.Favorite();
                if (favBll.Delete(ids))
                {
                    this.DataBind();
                }
                else
                {
                    this.DataBind();
                }
            }
        }

        public int getTeacherCount(object courseId)
        {
            if (courseId != null )
            {
                if (!string.IsNullOrEmpty(courseId.ToString()) )
                {
                    int cid =Convert.ToInt32(courseId);
                    int count = coursesBll.GetCourserteacher(cid);
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
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

        public int GetBuyNums(object courseId)
        {
            if (courseId != null)
            {
                if (!string.IsNullOrEmpty(courseId.ToString()))
                {
                    BLL.Tao.Courses coursesBLL = new BLL.Tao.Courses();
                 return    coursesBLL.GetSellCourseNum(int.Parse(courseId.ToString()));
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public string NavInfo(object cid)
        {
            if (cid != null)
            {
                if (!string.IsNullOrEmpty(cid.ToString()))
                {
                    int cateId = Common.Globals.SafeInt(cid.ToString(), 0);
                    BLL.Tao.Categories categoriesBLL = new BLL.Tao.Categories();
                    System.Text.StringBuilder str = new System.Text.StringBuilder();
                    Maticsoft.Model.Tao.Categories model = categoriesBLL.GetModelByCache(cateId);
                    if (null != model)
                    {
                        string[] strPath = model.Path.Split('|');
                        str.Append(" 全部分类 ");
                        foreach (string s in strPath)
                        {
                            if (Maticsoft.Common.PageValidate.IsNumber(s))
                            {
                                Maticsoft.Model.Tao.Categories categoriesModel = categoriesBLL.GetModelByCache(int.Parse(s));
                                if (null != categoriesModel)
                                {
                                    str.Append("&nbsp;&gt;&nbsp;" + categoriesModel.Name);
                                }
                            }
                        }
                        return str.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}