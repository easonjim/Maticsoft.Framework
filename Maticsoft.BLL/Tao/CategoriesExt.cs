using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class Categories
    {
        /// <summary>
        /// 添加新的分类 主页菜单导航
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewCate(Maticsoft.Model.Tao.Categories model)
        {
            return dal.AddNewCate(model);
        }

        /// <summary>
        /// 对类别进行排序
        /// </summary>
        /// <param name="categoryId">类别ID</param>
        /// <param name="zIndex">排序方式</param>
        /// <returns></returns>
        public int SwapCategorySequence(int categoryId, Maticsoft.Common.CategoryZIndex zIndex)
        {
            return dal.SwapCategorySequence(categoryId, zIndex);
        }

        /// <summary>
        /// 级联删除分类及子类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Maticsoft.Common.CategoryActionStatus DeleteCategory(int categoryId)
        {
            return dal.DeleteCategory(categoryId);
        }

        /// <summary>
        /// 更新分类信息
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Maticsoft.Common.CategoryActionStatus UpdateCategory(Maticsoft.Model.Tao.Categories category)
        {
            return dal.UpdateCategory(category);
        }

        /// <summary>
        /// 根据CategoryId获取对应的名称
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public string GetCateNameById(int cateId)
        {
            Maticsoft.Model.Tao.Categories cateModel = dal.GetModel(cateId);
            if (cateModel != null)
            {
                return cateModel.Name;
            }
            else
            {
                return "未知分类";
            }
        }

        public bool UpdateImgURL(string id)
        {
            return dal.UpdateImgURL(id);
        }

        /// <summary>
        /// 得到最大Depth
        /// </summary>
        public int GetDepth()
        {
            return dal.GetDepth();
        }

        public List<Maticsoft.Model.Tao.Categories> GetAllCate(int? parentId)
        {
            return dal.GetAllCate(parentId);
        }

        /// <summary>
        /// 获取课程分类的顶级分类
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCate0(int parentId)
        {
            return DAL.Tao.Categories.GetCate0(parentId);
        }

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public List<Maticsoft.Model.Tao.Categories> GetCate(int parentCategoryId)
        {
            List<Maticsoft.Model.Tao.Categories> modelList = new List<Maticsoft.Model.Tao.Categories>();
            DataRow[] rowArray = dal.GetCate().Tables[0].Select("ParentCategoryId=" + parentCategoryId);
            Maticsoft.Model.Tao.Categories model;
            for (int i = 0; i < rowArray.Length; i++)
            {
                model = new Maticsoft.Model.Tao.Categories();
                if (rowArray[i]["CategoryId"] != null && rowArray[i]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(rowArray[i]["CategoryId"].ToString());
                }
                if (rowArray[i]["Name"] != null && rowArray[i]["Name"].ToString() != "")
                {
                    model.Name = rowArray[i]["Name"].ToString();
                }
                if (rowArray[i]["Sequence"] != null && rowArray[i]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(rowArray[i]["Sequence"].ToString());
                }
                if (rowArray[i]["ParentCategoryId"] != null && rowArray[i]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = int.Parse(rowArray[i]["ParentCategoryId"].ToString());
                }
                if (rowArray[i]["Depth"] != null && rowArray[i]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(rowArray[i]["Depth"].ToString());
                }
                if (rowArray[i]["Path"] != null && rowArray[i]["Path"].ToString() != "")
                {
                    model.Path = rowArray[i]["Path"].ToString();
                }
                if (rowArray[i]["Description"] != null && rowArray[i]["Description"].ToString() != "")
                {
                    model.Description = rowArray[i]["Description"].ToString();
                }
                if (rowArray[i]["IconUrl"] != null && rowArray[i]["IconUrl"].ToString() != "")
                {
                    model.IconUrl = rowArray[i]["IconUrl"].ToString();
                }
                if (rowArray[i]["Status"] != null && rowArray[i]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(rowArray[i]["Status"].ToString());
                }
                if (rowArray[i]["CreatedDate"] != null && rowArray[i]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(rowArray[i]["CreatedDate"].ToString());
                }
                if (rowArray[i]["CreatedUserID"] != null && rowArray[i]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(rowArray[i]["CreatedUserID"].ToString());
                }
                if (rowArray[i]["RewriteName"] != null && rowArray[i]["RewriteName"].ToString() != "")
                {
                    model.RewriteName = rowArray[i]["RewriteName"].ToString();
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}