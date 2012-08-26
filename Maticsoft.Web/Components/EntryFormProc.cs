/**
* EntryFormProc.cs
*
* 功 能： [N/A]
* 类 名： EntryFormProc
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/5/31 12:31:12  蒋海滨    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Maticsoft.Web.Components
{
    public class EntryFormProc
    {
        private static Maticsoft.BLL.Tao.Regions bll = new Maticsoft.BLL.Tao.Regions();

        /// <summary>
        /// 根据RID获取地域全名
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public static string GetRegionNameByRID(int RID)
        {
            return bll.GetRegionNameByRID(RID);
        }
    }
}