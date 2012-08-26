using System;

namespace Maticsoft.Model.Tao
{
    /// <summary>
    /// UserEmailAc:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserEmailAc
    {
        public UserEmailAc()
        { }

        #region Model

        private int _id;
        private int _userid;
        private string _email;
        private bool _isactive = false;
        private string _avtivecode;

        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        ///
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }

        /// <summary>
        ///
        /// </summary>
        public string AvtiveCode
        {
            set { _avtivecode = value; }
            get { return _avtivecode; }
        }

        #endregion Model
    }
}