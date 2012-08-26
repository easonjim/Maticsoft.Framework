using System.Data;
using Maticsoft.Common;

namespace Maticsoft.BLL.Tao
{
    public partial class Regions
    {
        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPrivoceName()
        {
            return Maticsoft.DAL.Tao.Regions.GetPrivoceName();
        }

        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public static DataSet GetRegionName(string parentID)
        {
            return Maticsoft.DAL.Tao.Regions.GetRegionName(parentID);
        }

        /// <summary>
        /// 获取读取父Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetParentId(int id)
        {
            return Maticsoft.DAL.Tao.Regions.GetParentId(id);
        }

        public static int GetRegPath(int? regid)
        {
            return Maticsoft.DAL.Tao.Regions.GetRegPath(regid);
        }

        public string GetRegionAllName(int regionId)
        {
            string regionName = string.Empty;
            Model.Tao.Regions region = dal.GetModel(regionId);
            if (region != null)
            {
                regionName = region.RegionName;
                if (region.ParentId.HasValue)
                {
                    region = dal.GetModel(region.ParentId.Value);
                    if (region != null)
                    {
                        regionName = region.RegionName + "" + regionName;
                        if (region.ParentId.HasValue)
                        {
                            region = dal.GetModel(region.ParentId.Value);
                            if (region != null)
                            {
                                regionName = region.RegionName + "" + regionName;
                            }
                        }
                    }
                }
            }
            return regionName;
        }

        public DataTable GetDistrictByParentId(int iParentId)
        {
            return dal.GetDistrictByParentId(iParentId).Tables[0];
        }

        public DataSet GetDisByParentId(int iParentId)
        {
            return dal.GetDistrictByParentId(iParentId);
        }

        public DataSet GetAllCityList()
        {
            DataSet ds = DataCache.GetCache("Maticsoft_CityList") as DataSet;
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                ds = dal.GetAllCityList();
                DataCache.SetCache("Maticsoft_CityList", ds);
            }
            return ds;
        }

        //根据RID获取地域全名
        public string GetRegionNameByRID(int RID)
        {
            return dal.GetRegionNameByRID(RID);
        }

        public DataSet GetParentIDs(int regID, out int Count)
        {
            return dal.GetParentIDs(regID, out Count);
        }

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetPrivoces()
        {
            return dal.GetPrivoces();
        }
    }
}