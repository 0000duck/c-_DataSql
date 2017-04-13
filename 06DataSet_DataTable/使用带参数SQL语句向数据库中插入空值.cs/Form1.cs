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

namespace 使用带参数SQL语句向数据库中插入空值.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int age = Convert.ToInt32(textBox2.Text.Trim());
            int? height = textBox3.Text.Length == 0 ? null :(int?) Convert.ToInt32(textBox3.Text.Trim());
            bool? gender = textBox4.Text.Length == 0 ? null : (bool?)Convert.ToBoolean(textBox4.Text.Trim());
            string sql="insert into Tblperson values(@uname,@age,@height,@gender)";
            SqlParameter[] pms=new SqlParameter[]{
                new SqlParameter("@uname",SqlDbType.NVarChar,50){Value=name},
                new SqlParameter("@age",SqlDbType.Int){Value=age==null?DBNull.Value:(object)age},
                //向数据库中插入null值不能使用c#中的null，必须使用数据库中的DBNull.Values，
                new SqlParameter("@height",SqlDbType.Int){Value=(height==null?DBNull.Value:(object)height)},
                new SqlParameter("@gender",SqlDbType.Int){Value=(gender==null?DBNull.Value:(object)gender)}
            };
            _05封装SqlHelper类.SqlHelper.ExecuteNonQuery(sql,pms);
            MessageBox.Show("插入成功！");
        }
    }
}
