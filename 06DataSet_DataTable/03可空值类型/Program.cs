using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03可空值类型
{
    class Program
    {
        static void Main(string[] args)
        {
//             int n = 10;
//             string s = "hello";
//             s = null;
           // n = null;
            int? n = 10;
//             Nullable<int> m = 10;//与上面等价，是结构
//                 m.HasValue = true;
//                 m.Value = 10;
            n = null;
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
