using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public enum CourseStatus
    {
        //课程状态
        Unfinished=0,//未完成
        Unaudited=1,//完成未审核
        Approved=2,//审核通过
        Publish =3,//发布上架
        Unapproved=4//审核未通过
    }
}
