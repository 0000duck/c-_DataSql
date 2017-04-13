using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 加载连接查询的结果到DataGridView.cx
{
    class PhoneNum
    {

        public int PID { get; set; }
        //public int PTypeID { get; set; }
        public PhoneType Group { get; set; }//包含另一张表中的属性
        public string PName { get; set; }
        public string PCellPhone { get; set; }
        public string PHomePhone { get; set; }
    }
}
