/**
* PageModel.cs
*
* 功 能： [N/A]
* 类 名： PageModel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/27 10:46:24  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Maticsoft.Model.Tao
{
    public class PageModel
    {
        private int? _pageIndex;

        public int? PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private int? _pageSize;

        public int? PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private int? _orderid;

        public int? Orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int? _courseid;

        public int? Courseid
        {
            get { return _courseid; }
            set { _courseid = value; }
        }

        private int? _moduleid;

        public int? Moduleid
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }

        private int? _userid;

        public int? Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
    }
}