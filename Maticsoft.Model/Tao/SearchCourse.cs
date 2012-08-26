/**
* SearchCourse.cs
*
* 功 能： [N/A]
* 类 名： SearchCourse
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/26 17:02:30  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;

namespace Maticsoft.Model.Tao
{
    public class SearchCourse
    {
        private int _courseid;

        public int Courseid
        {
            get { return _courseid; }
            set { _courseid = value; }
        }

        private string _coursename;

        public string Coursename
        {
            get { return _coursename; }
            set { _coursename = value; }
        }

        private int? _timeduration;

        public int? Timeduration
        {
            get { return _timeduration; }
            set { _timeduration = value; }
        }

        private string _imageurl;

        public string Imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }

        private int? _createduserid;

        public int? Createduserid
        {
            get { return _createduserid; }
            set { _createduserid = value; }
        }

        private decimal? _price;

        public decimal? Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int? _pv;

        public int? Pv
        {
            get { return _pv; }
            set { _pv = value; }
        }

        private string _trueName;

        public string TrueName
        {
            get { return _trueName; }
            set { _trueName = value; }
        }

        private string _departmentId;

        public string DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        private string _enterName;

        public string EnterName
        {
            get { return _enterName; }
            set { _enterName = value; }
        }

        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private int _bookCount;

        public int BookCount
        {
            get { return _bookCount; }
            set { _bookCount = value; }
        }
    }
}