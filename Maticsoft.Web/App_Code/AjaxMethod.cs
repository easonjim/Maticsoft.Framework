using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class AjaxMethod
{
    #region 地区DropDownlist
    public static DataSet GetPovinceList()
    {
        DataSet dsProvice = Maticsoft.BLL.Tao.Regions.GetPrivoceName();
        return dsProvice;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public static DataSet GetCityList(int povinceid)
    {
        DataSet dsCity = Maticsoft.BLL.Tao.Regions.GetRegionName(povinceid.ToString());
        return dsCity;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public static DataSet GetAreaList(int povinceid)
    {
        DataSet dsCity = Maticsoft.BLL.Tao.Regions.GetRegionName(povinceid.ToString());
        return dsCity;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public static DataTable GetParentId(int id)
    {
        DataTable dtPar = Maticsoft.BLL.Tao.Regions.GetParentId(id);
        return dtPar;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public static int GetRegPath( int ? regId)
    {
        return Maticsoft.BLL.Tao.Regions.GetRegPath(regId);
    }
    #endregion

    #region 获得分类联动
    public static DataSet GetCate0(int parentId)
    {
        DataSet dsCate0 = Maticsoft.BLL.Tao.Categories.GetCate0(parentId);
        return dsCate0;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public static DataSet GetCate(int parentId)
    {
        DataSet dsCate0 = Maticsoft.BLL.Tao.Categories.GetCate0(parentId);
        return dsCate0;
    } 
    #endregion

}