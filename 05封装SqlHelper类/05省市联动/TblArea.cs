using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05省市联动
{
    class TblArea
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int AreaPID { get; set; }
        public override string ToString()
        {
            return this.AreaName;
        }
    }
}
