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

namespace _04登陆验证
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //验证用户登录
        private void M_SIgnin_Click(object sender, EventArgs e)
        {
            #region 使用带参数拼接的sql语句(不安全，有sql注入攻击的问题)
//             //1.采集用户输入数据
//             string loginid = textloginid.Text.Trim();
//             string loginpwd = textloginPwd.Text.Trim();
//             //2.连接数据库效验是否登录成功
//             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
//             using(SqlConnection con=new SqlConnection(constr))
//             {
//                 string sql = string.Format("select count(*) from users where loginid='{0}'and loginpwd='{1}'",loginid,loginpwd);
//                 using(SqlCommand cmd=new SqlCommand(sql,con))
//                 {
//                     con.Open();
//                     int count= (int)cmd.ExecuteScalar();
//                     if (count > 0)
//                     {
//                         this.BackColor = Color.Green;
//                     }
//                     else
//                     {
//                         this.BackColor = Color.Red;
//                     }
//                 }
//             }
            #endregion

            #region 使用带参数的sql语句
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = "select count(*) from users where loginid=@loginid and loginpwd=@password";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    //1.当使用带参数的sql语句的时候，sql中会出现参数
                    //2.sql语句中有参数，必须在command对象中提供对应的参数和值
                    //3.创建两个参数对象  方法1
//                     SqlParameter paramLoginId = new SqlParameter("@loginid", SqlDbType.NVarChar, 10) { Value=textloginid.Text.Trim()};
//                     SqlParameter paraPassword = new SqlParameter("@password", SqlDbType.NVarChar, 50) { Value = textloginPwd.Text.Trim() };
//                     //4.参数加入到Command中
//                     cmd.Parameters.Add(paramLoginId);
//                     cmd.Parameters.Add(paraPassword);
                    //方法二  推荐使用
//                     SqlParameter[] pms = new SqlParameter[]{
//                     new SqlParameter("@loginid",SqlDbType.NVarChar,10){Value=textloginid.Text.Trim()},
//                     new SqlParameter("@password",SqlDbType.NVarChar,50){Value=textloginPwd.Text.Trim()}
//                     };
//                     cmd.Parameters.AddRange(pms);
                    //方法三  有bugue，当值为特殊值的时候
                    cmd.Parameters.AddWithValue("@loginid", textloginid.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", textloginPwd.Text.Trim());

                    con.Open();
                    int r=(int)cmd.ExecuteScalar();
                    if(r>0)
                    {
                        this.Text = "登陆成功";
                    }
                    else
                    {
                        this.Text = "登陆失败！";
                    }

                }
            }
            #endregion
        }

        private void M_Signin1_Click(object sender, EventArgs e)
        {
            //1.采集用户输入数据
            string loginid = textloginid.Text.Trim();
            string loginpwd = textloginPwd.Text.Trim();
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            //2.根据用户名去数据库中查找是否有对应的用户
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("select * from users where loginid='{0}'", loginid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            if(reader.Read())
                            {
                                //3.如果有对应的用户，再比较密码是否正确
                                string pwd = reader.GetString(2);
                                if (pwd == loginpwd)
                                {
                                    this.Text = "登录成功！";
                                    this.BackColor = Color.Green;
                                    //启用修改密码按钮
                                    modity.Enabled = true;
                                    //获取当前登录用户的主键id，并设置到静态类GlobalHelper中
                                    GlobalHelper._autoid = reader.GetInt32(0);
                                }
                                else
                                {
                                    this.Text = "登录失败，密码错误！";
                                    this.BackColor = Color.Red;
                                }

                            }
                        }
                        else
                        {
                            //4.如果没有用户，则提示
                            this.Text="用户不存在";
                        }
                    }
                }
            }

        }

        private void modity_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
