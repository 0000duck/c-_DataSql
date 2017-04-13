using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01SqlDataAdapter使用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               //方式1没用SqlHelper
//             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=true";
//             string sql="select * from tblscore";
//             DataTable dt=new DataTable();
//             using(SqlDataAdapter adatper=new SqlDataAdapter(sql,constr))
//             {
//                adatper.Fill(dt);//实现从数据库中读取数据并加载到Datatable中
//             }
//             this.dataGridView1.DataSource=dt;//数据绑定
            //方式二2使用SqlHelper
            string sql = "select * from tblscore";
            this.dataGridView1.DataSource = _05封装SqlHelper类.SqlHelper.ExecuteDataTable(sql);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1.创建DataSet
            //DataSet就是一个集合，内存数据库，临时数据库
            DataSet ds = new DataSet("School");
            //2.创建一张表
            DataTable dt = new DataTable("Student");
                //2.1向dt表中增加列
            DataColumn dcAutoID = new DataColumn("AutoID", typeof(int));
                //设置列自动编号
            dcAutoID.AutoIncrement = true;
            dcAutoID.AutoIncrementSeed = 1;
            dcAutoID.AutoIncrementStep = 1;
                //把列加到表dt中
            dt.Columns.Add(dcAutoID);

                //增加一个姓名列
            DataColumn dcUserName = dt.Columns.Add("UserName", typeof(string));
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

            this.dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
