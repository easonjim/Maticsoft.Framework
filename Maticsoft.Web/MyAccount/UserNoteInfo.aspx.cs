using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserNoteInfo : PageBaseUser
    {
        private BLL.Tao.CourseNotes noteBll = new BLL.Tao.CourseNotes();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AspNetPager1.RecordCount = noteBll.SumNoteCourse(CurrentUser.UserID);
            if (!IsPostBack)
            {
                BindCourseNotes();
            }
        }

        private void BindCourseNotes()
        {
            System.Data.DataSet ds = noteBll.GetCourseNote(CurrentUser.UserID, AspNetPager1.StartRecordIndex, AspNetPager1.PageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.Repeater_Notes.DataSource = ds;
                this.Repeater_Notes.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindCourseNotes();
        }

        protected void Repeater_Notes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("save"))
            {
                Label labMid = (Label)e.Item.FindControl("labMid");
                Label labCid = (Label)e.Item.FindControl("labCid");
                HtmlTextArea txtContent = (HtmlTextArea)e.Item.FindControl("notesTarea");
                if (labMid == null || labCid == null || txtContent == null)
                {
                    return;
                }
                Model.Tao.CourseNotes noteModel = new Model.Tao.CourseNotes();
                BLL.Tao.CourseNotes noteBll = new BLL.Tao.CourseNotes();
                int cid = int.Parse(labCid.Text);
                int Mid = int.Parse(labMid.Text);
                noteModel.CourseID = cid;
                noteModel.ModuleID = Mid;
                noteModel.UserID = CurrentUser.UserID;
                string contentStr = txtContent.Value;
                Label labNid = (Label)e.Item.FindControl("labNid");
                if (labNid != null && labNid.Text != "")
                {
                    noteModel.NoteID = int.Parse(labNid.Text);
                    noteModel.Contents = contentStr;
                    noteModel.Updatetime = DateTime.Now;
                    if (noteBll.Update(noteModel))
                    {
                        Maticsoft.Common.MessageBox.Show(this, "修改成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.Show(this, "修改失败！");
                    }
                }
                else
                {
                    noteModel.Contents = contentStr;
                    noteModel.Updatetime = DateTime.Now;
                    if (noteBll.Add(noteModel) > 0)
                    {
                        Maticsoft.Common.MessageBox.Show(this, "保存成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.Show(this, "保存失败！");
                    }
                }
            }
        }
    }
}