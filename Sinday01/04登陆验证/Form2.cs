using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//数据库头文件
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04登陆验证
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void moditypwd_Click(object sender, EventArgs e)
        {
            //1.采集用户的输入
            string old_pwd = textoldpwd.Text;
            string new_pwd = textnewpwd.Text;
            string new_pwd1 = textnewpwd1.Text;
            //2.校验两次输入的新密码是否正确
            if(new_pwd==new_pwd1)
            {
                //3.校验旧密码是否正确
                //使用当前用户输入的旧密码和GlobalHelper._autoid进行匹配
                if (CheckUserOldPwd(old_pwd, GlobalHelper._autoid))
                {
                    //4.修改密码
                    if (UpdatePassword(GlobalHelper._autoid, new_pwd))
                    {
                        MessageBox.Show("密码修改成功");
                        //关掉窗口
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败！");
                    }
                }
                else 
                {
                    MessageBox.Show("旧密码错误！");
                }
   
            }
            else
            {
                MessageBox.Show("两次输入的新密码不一致！");
            }

        }
        //修改密码的方法
        private bool UpdatePassword(int autoid, string new_pwd)
        {
            string sql = string.Format("update users set loginpwd='{0}'where autoid={1}",new_pwd,autoid);
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    return r > 0;
                }
            }
        }
        //校验旧密码是否正确
        private bool CheckUserOldPwd(string old_pwd, int autoid)
        {
            string sql = string.Format("select count(*) from users where autoid={0} and loginpwd='{1}'", autoid, old_pwd);
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    int r=(int)cmd.ExecuteScalar();
                    return r > 0;
                }
            }

        }
    }
}
