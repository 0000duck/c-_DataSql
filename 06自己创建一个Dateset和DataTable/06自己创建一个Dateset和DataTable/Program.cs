using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06自己创建一个Dateset和DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建一个DataSet
            //DataSet是一个集合，内存数据库，临时数据库
            DataSet ds = new DataSet("School");
            //2.创建一张表
            DataTable dt = new DataTable("Student");

            //2.1向表中
            //3.把dt加载到ds中
            ds.Tables.Add(dt);
        }
    }
}
