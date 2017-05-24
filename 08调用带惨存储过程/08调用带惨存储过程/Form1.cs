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

namespace _08调用带惨存储过程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = textBox1.Text.Trim();
            string to = textBox2.Text.Trim();
            double money = double.Parse(textBox3.Text.Trim());
            string sql="us_transfer";//存储过程语句
            SqlParameter[] pms = new SqlParameter[]{
            new SqlParameter("@from",SqlDbType.Char,4){Value=from},
            new SqlParameter("@to",SqlDbType.Char,4){Value=to},
            new SqlParameter("@balance",SqlDbType.Money){Value=money},
            new SqlParameter("@resultnumber",SqlDbType.Int){Direction=ParameterDirection.Output}//输出参数
            };
            //调用存储过程实现转账
            _05封装SqlHelper类.SqlHelper.ExecuteNonQuery(sql, CommandType.StoredProcedure, pms);
            //获取存储过程的输出结果
            int result = Convert.ToInt32(pms[3].Value);
            switch(result)
            {
                case 1:
                    MessageBox.Show("成功");
                    break;
                case 3:
                    MessageBox.Show("余额不足！");
                    break;
                default: 
                    MessageBox.Show("失败！");
                    break;

            }

        }
    }
}
