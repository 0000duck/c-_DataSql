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

namespace _08存储过程增_删_改_查
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //增加记录
        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@name",SqlDbType.NVarChar,50){Value=textBox1.Text.Trim()},
            new SqlParameter("@desc",SqlDbType.VarChar,50){Value=textBox2.Text.Trim()}
            };
            int r=_05封装SqlHelper类.SqlHelper.ExecuteNonQuery("usp_insert_tblclass",CommandType.StoredProcedure,pms);
            MessageBox.Show("插入了"+r+"条记录");
           
        }
    }
}
