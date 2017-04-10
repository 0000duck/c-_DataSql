using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinday02_增_删_改_查
{
    class TblStudent
    {
        //定义属性
        public int tsid{get;set;}
        public string tsname { get; set; }
        public string tsgender { get; set; }
        public string tsaddress { get; set; }
        public int? tsage { get; set; }
        public DateTime? tsbirthday { get; set; }
        public string tscardid { get; set; }
        public int? tsclassid { get; set; }

    }
}
