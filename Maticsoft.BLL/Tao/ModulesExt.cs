using System;
using System.Collections.Generic;
using System.Data;

namespace Maticsoft.BLL.Tao
{
    public partial class Modules
    {
        /// <summary>
        /// 根据ModuleID得到ModuleName
        /// </summary>
        public Model.Tao.Modules GetModuleName(int ModuleID)
        {
            return dal.GetModuleName(ModuleID);
        }

        /// <summary>
        /// 根据moduleId更新Module的价格
        /// </summary>
        public int UpDateModulePrice(int moduleId, decimal price)
        {
            return dal.UpDateModulePrice(moduleId, price);
        }

        /// <summary>
        /// 上传课程章节
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool CreateModule(Model.Tao.Modules model, int courseId)
        {
            return dal.CreateModule(model, courseId);
        }

        /// <summary>
        /// 创建新课程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool CreateNewModule(Model.Tao.Modules model, int courseId)
        {
            return dal.CreateNewModule(model, courseId);
        }

        public bool UpDateLocalModule(Model.Tao.Modules model, int cid)
        {
            return dal.UpDateLocalModule(model, cid);
        }

        public bool CreateModuleExtInfo(Model.Tao.Modules model, int courseId)
        {
            return dal.CreateModuleExtInfo(model, courseId);
        }

        public bool UpdateModuleExtInfo(Model.Tao.Modules model, int courseId)
        {
            return dal.UpdateModuleExtInfo(model, courseId);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DeleteModule(int moduleId)
        {
            return dal.DeleteModule(moduleId);
        }

        /// <summary>
        /// 设置课程价格
        /// </summary>
        public DataSet SetCoursePricr(int userId, int courseId)
        {
            return dal.SetCoursePricr(userId, courseId);
        }

        /// <summary>
        /// 获取课程的名称和课程已存入的价格
        /// </summary>
        public DataSet GetCourseInfo(int userID, int courseId)
        {
            return dal.GetCourseInfo(userID, courseId);
        }

        public DataSet GetListByUserIDAndCourseID(int createdUserID, int Type, int courseID)
        {
            return dal.GetList(" createdUserID=" + createdUserID + " and Type=" + Type + " and moduleID in (select moduleID from Tao_CourseModule where CourseID=" + courseID + ")");
        }

        public DataSet getModuleInfo(int userId, int CourseId)
        {
            return dal.getModuleInfo(userId, CourseId);
        }

        public int CloseModule(int ModuleId)
        {
            return dal.CloseCourse(ModuleId, 5);
        }

        public bool UpdatePubCourseInfo(Maticsoft.Model.Tao.Modules model)
        {
            return dal.UpdatePubCourseInfo(model);
        }

        public DataSet GetModuleInfo(int? cid, int? mid)
        {
            return dal.GetModuleInfo(cid, mid);
        }

        public decimal GetModulePrice(int mid)
        {
            return dal.GetModulePrice(mid);
        }

        public DataSet GetModuleByCid(int Cid, int type, int uid)
        {
            return dal.GetModuleByCid(Cid, type, uid);
        }

        public int GetMaxModuleSeq(int cid, int type)
        {
            return dal.GetMaxModuleSeq(cid, type);
        }

        public bool DeleteModuleInfo(int cid, int mid)
        {
            return dal.DeleteModuleInfo(cid, mid);
        }

        public List<Model.Tao.Modules> GetCourseList(int courseId, out int rowCount, out int pageCount, int? PageIndex, int? PageSize)
        {
            DataSet ds = dal.GetCourseModuleList(courseId, out rowCount, out pageCount, PageIndex, PageSize);
            if (ds != null)
            {
                return DTToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        public List<Model.Tao.Modules> GetModuleInfo(int cid)
        {
            DataSet ds = dal.GetModuleInfo(cid);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Tao.Modules> DTToList(DataTable dt)
        {
            List<Maticsoft.Model.Tao.Modules> modelList = new List<Maticsoft.Model.Tao.Modules>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Tao.Modules model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.Tao.Modules();
                    if (dt.Rows[n]["ModuleID"] != null && dt.Rows[n]["ModuleID"].ToString() != "")
                    {
                        model.ModuleID = int.Parse(dt.Rows[n]["ModuleID"].ToString());
                    }
                    if (dt.Rows[n]["ModuleName"] != null && dt.Rows[n]["ModuleName"].ToString() != "")
                    {
                        model.ModuleName = dt.Rows[n]["ModuleName"].ToString();
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    if (dt.Rows[n]["TimeDuration"] != null && dt.Rows[n]["TimeDuration"].ToString() != "")
                    {
                        model.TimeDuration = int.Parse(dt.Rows[n]["TimeDuration"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.ImageUrl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["Type"] != null && dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["VideoContent"] != null && dt.Rows[n]["VideoContent"].ToString() != "")
                    {
                        model.VideoContent = dt.Rows[n]["VideoContent"].ToString();
                    }
                    if (dt.Rows[n]["CreatedDate"] != null && dt.Rows[n]["CreatedDate"].ToString() != "")
                    {
                        model.CreatedDate = DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.CreatedUserID = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["PV"] != null && dt.Rows[n]["PV"].ToString() != "")
                    {
                        model.PV = int.Parse(dt.Rows[n]["PV"].ToString());
                    }
                    if (dt.Rows[n]["Sequence"] != null && dt.Rows[n]["Sequence"].ToString() != "")
                    {
                        model.Sequence = int.Parse(dt.Rows[n]["Sequence"].ToString());
                    }
                    if (dt.Rows[n]["Attachment"] != null && dt.Rows[n]["Attachment"].ToString() != "")
                    {
                        model.Attachment = dt.Rows[n]["Attachment"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["UpdatedDate"] != null && dt.Rows[n]["UpdatedDate"].ToString() != "")
                    {
                        model.UpdatedDate = DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
                    }
                    //if (dt.Rows[n]["IsBuy"] != null && dt.Rows[n]["IsBuy"].ToString() != "")
                    //{
                    //    model.IsBuy = int.Parse(dt.Rows[n]["IsBuy"].ToString());
                    //}
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}