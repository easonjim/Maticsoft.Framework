/**
* OffLineCourseInfo.cs
*
* 功 能： [N/A]
* 类 名： OffLineCourseInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/7/21 17:06:56  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class OffLineCourseInfo1 : System.Web.UI.UserControl
    {
        public string display = string.Empty;
        private int _uId;

        public int UID
        {
            get { return _uId; }
            set { _uId = value; }
        }

        private int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();

        public override void DataBind()
        {
            this.AspNetPager1.RecordCount = bll.IndexListCount(UID, Type);
            InitData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            DataSet ds = bll.GetIndexList(AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, UID, Type);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.rpr_offLine.DataSource = ds;
                this.rpr_offLine.DataBind();
            }
            else
            {
                display = "style='display:none;'";
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
                    return "未知";
                }
            }
            else
            {
                return "未知";
            }
        }

        public string SubCourseName(object OldName)
        {
            if (OldName != null)
            {
                string EndName = string.Empty;
                if (OldName.ToString().Length >= 13)
                {
                    EndName = OldName.ToString().Substring(0, 12) + "...";
                    return EndName;
                }
                else
                {
                    return OldName.ToString();
                }
            }
            else
            {
                return "未知课程名";
            }
        }
    }
}