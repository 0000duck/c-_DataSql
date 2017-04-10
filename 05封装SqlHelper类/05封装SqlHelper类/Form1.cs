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

namespace _05封装SqlHelper类
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void M_Singin_Click(object sender, EventArgs e)
        {
            string sql="select count(*) from users where loginid=@uid and loginpwd=@pwd";
            SqlParameter[] pms=new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.NVarChar,10){Value=textusername.Text.Trim()},
                new SqlParameter("@pwd",SqlDbType.NVarChar,50){Value=textuserpwd.Text}
            };
            int r=(int)SqlHelper.EexcuteScalar(sql,pms);
            if(r>0)
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }
    }
}
