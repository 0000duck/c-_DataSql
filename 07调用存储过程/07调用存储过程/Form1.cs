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

namespace _07调用存储过程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int pageIndex = 1;//当前页码
        private int pagesize = 7;//每页显示的记录条数
        private int pagecount;//总页数
        private int recordcount;//总条数
        //传统加载显示第一页数据
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=myfirstdatabase;Integrated Security=true";
            #region MyRegion
//             using(SqlConnection con=new SqlConnection(constr))
//             {
//                 //将sql语句变为存储过程名称
//                 string sql = "usp_getstlstudentByPage";
//                 using(SqlCommand cmd=new SqlCommand(sql,con))
//                 {
//                     //告诉sqlCommand对象，现在执行的存储过程，不是SQL语句
//                     cmd.CommandType = CommandType.StoredProcedure;//原理默认是sql语句，此处改为存储过程
//                     //增加参数
//                     // @pagesize int=7,--每页记录条数
//                     //@pageindex int=1,--当前要查看第几页的记录
//                     // @recordcount int output,--总的记录条数
//                     //@pagecount int output--总的页数
//                     SqlParameter[] pms=new SqlParameter[]{
//                     new SqlParameter("@pagesize",SqlDbType.Int){Value=pagesize},
//                     new SqlParameter("@pageindex",SqlDbType.Int){Value=pageIndex},
//                     new SqlParameter("@recordcount",SqlDbType.Int){Direction=ParameterDirection.Output},//需要指定输出参数
//                     new SqlParameter("@pagecount",SqlDbType.Int){Direction=ParameterDirection.Output}//需要指定输出参数
//                     };
//                     cmd.Parameters.AddRange(pms);
//                     con.Open();
//                 }
            //             }
            #endregion
            DataTable dt = new DataTable();
            string sql="usp_getstlstudentByPage";
            using(SqlDataAdapter adapter=new SqlDataAdapter(sql,constr))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;//设为为执行存储过程
                //增加参数
                // @pagesize int=7,--每页记录条数
                //@pageindex int=1,--当前要查看第几页的记录
                // @recordcount int output,--总的记录条数
                //@pagecount int output--总的页数
                SqlParameter[] pms = new SqlParameter[]{
                                     new SqlParameter("@pagesize",SqlDbType.Int){Value=pagesize},
                                     new SqlParameter("@pageindex",SqlDbType.Int){Value=pageIndex},
                                     new SqlParameter("@recordcount",SqlDbType.Int){Direction=ParameterDirection.Output},//需要指定输出参数
                                     new SqlParameter("@pagecount",SqlDbType.Int){Direction=ParameterDirection.Output}//需要指定输出参数
                                     };
                adapter.SelectCommand.Parameters.AddRange(pms);
                adapter.Fill(dt);
                //获取参数并赋值给label
                label1.Text = "总条数："+pms[2].Value.ToString();
                label2.Text = "总页数："+pms[3].Value.ToString();
                label3.Text = "当前页：" + pageIndex;

            }
            this.dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageIndex++;
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageIndex--;
            LoadData();
        }
    }
}
