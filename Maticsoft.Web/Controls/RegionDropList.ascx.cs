using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class RegionDropList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            if (RegionId.HasValue)
            {
                BindReg(RegionId.Value);
            }
            else
            {
                InitRegion();
            }
        }

        private int? _regionId;
        /// <summary>
        /// 地区ID
        /// </summary>
        public int? RegionId
        {
            get { return _regionId; }
            set { _regionId = value; }
        }

        /// <summary>
        /// 初始化绑定数据
        /// </summary>
        private void InitRegion()
        {
            this.ddlProvince.DataSource = AjaxMethod.GetPovinceList();
            this.ddlProvince.DataTextField = "RegionName";
            this.ddlProvince.DataValueField = "RegionId";
            this.ddlProvince.DataBind();
            this.ddlProvince.Items.Insert(0, new ListItem("请选择", ""));
            this.ddlProvince.Attributes.Add("onChange", "cityResult();");
            this.ddlCity.Attributes.Add("onChange", "areaResult();");
        }

        /// <summary>
        /// 根据已有的RegionID获取对应的地区名称
        /// </summary>
        /// <param name="id"></param>
        private void BindReg(int id)
        {

            int regPath = AjaxMethod.GetRegPath(RegionId);

            switch (regPath)
            {
                case 3:
                    FullRegPath(id);
                    break;
                case 2:
                    NoAreaRegion(id);
                    break;
                case 1:
                    ProRegion(id);
                    break;
                default:
                    break;
            }

        }

        private void ProRegion(int id)
        {
            DataTable dt = AjaxMethod.GetParentId(id);
            DataRow dr;

            int parentId = -1;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                parentId = int.Parse(dr["ParentId"].ToString());
            }
            InitProInfo(parentId);
        }

        private void NoAreaRegion(int id)
        {
            DataTable dt = AjaxMethod.GetParentId(id);
            DataRow dr;

            int parentId = -1;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                parentId = int.Parse(dr["ParentId"].ToString());
            }

            InitProInfo(parentId);

            if (ddlProvince.SelectedValue != "")
            {
                this.ddlCity.DataSource = AjaxMethod.GetCityList(parentId);
                this.ddlCity.DataTextField = "RegionName";
                this.ddlCity.DataValueField = "RegionId";
                this.ddlCity.DataBind();
                ddlCity.SelectedValue = parentId.ToString();
            }
        }

        private void FullRegPath(int id)
        {
            int SecparentId = int.Parse(AjaxMethod.GetParentId(id).Rows[0]["ParentId"].ToString());
            DataTable dt = AjaxMethod.GetParentId(SecparentId);
            DataRow dr;

            int parentId = -1;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                parentId = int.Parse(dr["ParentId"].ToString());
            }
            InitProInfo(parentId);
            InitCityInfo(SecparentId, parentId);
            InitAreaInfo(id, SecparentId);
        }

        private void InitProInfo(int parentId)
        {
            this.ddlProvince.DataSource = AjaxMethod.GetPovinceList();
            this.ddlProvince.DataTextField = "RegionName";
            this.ddlProvince.DataValueField = "RegionId";
            this.ddlProvince.DataBind();
            ddlProvince.SelectedValue = parentId.ToString();
            this.ddlProvince.Attributes.Add("onChange", "cityResult();");
            this.ddlCity.Attributes.Add("onChange", "areaResult();");
        }

        private void InitCityInfo(int SecparentId, int parentId)
        {
            if (ddlProvince.SelectedValue != "")
            {
                this.ddlCity.DataSource = AjaxMethod.GetCityList(parentId);
                this.ddlCity.DataTextField = "RegionName";
                this.ddlCity.DataValueField = "RegionId";
                this.ddlCity.DataBind();
                ddlCity.SelectedValue = SecparentId.ToString();
            }
        }

        private void InitAreaInfo(int id, int SecparentId)
        {
            if (ddlCity.SelectedValue != "")
            {
                this.ddlArea.DataSource = AjaxMethod.GetAreaList(SecparentId);
                this.ddlArea.DataTextField = "RegionName";
                this.ddlArea.DataValueField = "RegionId";
                this.ddlArea.DataBind();
                ddlArea.SelectedValue = id.ToString();
            }
        }
    }
}