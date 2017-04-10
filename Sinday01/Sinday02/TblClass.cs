using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinday02
{
    class TblClass
    {
        
        //tClassID tClassName tClassDesc
        //数据绑定的时候只认属性，不认字段
        //         public int TClassID; //不认字段
        //         public string TClassName;
        //         public string TClassDesc;
        public int TClassID { get; set; }
        public string TClassName { get; set; }
        public string TClassDesc { get; set; }
        //public string 我的属性 { get { return "测试"; } }




    }
}
