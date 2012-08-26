/*----------------------------------------------------------------

// Copyright (C) 2012 动软卓越 版权所有。
//
// 文件名：EntryForm.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/07/22 16:29:24
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// EntryForm:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EntryForm
    {
        public EntryForm()
        { }

        #region Model

        private int _id;
        private string _username;
        private int? _age;
        private string _email;
        private string _telphone;
        private string _phone;
        private string _qq;
        private string _msn;
        private string _houseaddress;
        private string _companyaddress;
        private int? _regionid;
        private int? _sex;
        private string _description;
        private string _remark;
        private int? _state;

        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }

        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }

        /// <summary>
        /// 家庭地址
        /// </summary>
        public string HouseAddress
        {
            set { _houseaddress = value; }
            get { return _houseaddress; }
        }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress
        {
            set { _companyaddress = value; }
            get { return _companyaddress; }
        }

        /// <summary>
        /// 所在省份
        /// </summary>
        public int? RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }

        #endregion Model

        private int _courseID;

        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }
    }
}