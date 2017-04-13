using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02自己创建一个Dataset和DataTale
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建DataSet
            //DataSet就是一个集合，内存数据库，临时数据库
            DataSet ds = new DataSet("School");
            //2.创建一张表
            DataTable dt = new DataTable("Student");

            //2.1向dt表中增加列
            DataColumn dcAutoID = new DataColumn("AutoID",typeof(int));
            //设置列自动编号
            dcAutoID.AutoIncrement = true;
            dcAutoID.AutoIncrementSeed = 1;
            dcAutoID.AutoIncrementStep = 1;
            //把列加到表dt中
            dt.Columns.Add(dcAutoID);

            //增加一个姓名列
            DataColumn dcUserName=dt.Columns.Add("UserName",typeof(string));
            //设置姓名列不允许为空
            dcUserName.AllowDBNull = false;
            //增加一个年龄列
            dt.Columns.Add("UserAge", typeof(int));


            //--------------向表中增加行数据
            //创建一个行对象增加到dt中
            DataRow dr1 = dt.NewRow();//根据表dt的结果来创建行对象
            dr1["UserName"] = "胡飞行";
            dr1["UserAge"] = 21;
            //把该行对象增加到dt中
            dt.Rows.Add(dr1);

            //--再增加一行
            DataRow dr2 = dt.NewRow();
            dr2["UserName"] = "赵宇星";
            dr2["UserAge"] = 20;
            dt.Rows.Add(dr2);

            //3.把表加载到数据库中
            ds.Tables.Add(dt);

            Console.WriteLine("--------------------------------遍历表中的数据-------------------------");
            //1.遍历DataSet中的每张表
            for (int i = 0; i < ds.Tables.Count;i++ )
            {
                //输出每张表的表名
                Console.WriteLine("表名：{0}", ds.Tables[i].TableName);
                //遍历表中每一行
                for (int r = 0; r < ds.Tables[i].Rows.Count;r++ )
                {
                    DataRow currentRow=ds.Tables[i].Rows[r];
                    //输出当前行中的每一列
                    for (int c = 0; c < dt.Columns.Count;c++ )
                    {
                        Console.Write(currentRow[c].ToString()+"\t"+"|"+"\t");
                    }
                    Console.WriteLine();//换行
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
