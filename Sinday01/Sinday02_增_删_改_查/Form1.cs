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

namespace Sinday02_增_删_改_查
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void DataLoad()
        {
            List<TblStudent> list = new List<TblStudent>();
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = "select * from TblStudent";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
               
                                TblStudent model=new TblStudent();
                                model.tsid=reader.GetInt32(0);
                                model.tsname = reader.GetString(1);
                                model.tsgender = reader.IsDBNull(2)?null:reader.GetString(2);
                                model.tsaddress = reader.IsDBNull(3) ? null : reader.GetString(3);
                                model.tsage = reader.IsDBNull(4) ? null : (int ?)reader.GetInt32(4);
                                model.tsbirthday = reader.IsDBNull(5) ? null :(DateTime?) reader.GetDateTime(5);
                                model.tscardid = reader.IsDBNull(6) ? null : reader.GetString(6);
                                model.tsclassid = reader.GetInt32(7);
                                list.Add(model);//添加到集合中
                            }
                        }
                    }
                }
            }
            this.dgvStudent.DataSource=list;//调用集合显示，即为绑定技术
        }

        private void m_insert_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string name = texttsName.Text.Trim();
                string gender = texttsGender.Text.Trim().Length == 0 ? null : texttsGender.Text.Trim();
                string address = texttsAddress.Text.Trim().Length == 0 ? null : texttsAddress.Text.Trim();
                int? age = texttsAge.Text.Trim().Length==0?null:(int?)Convert.ToInt32(texttsAge.Text.Trim());
                DateTime? birthday = texttsBirthday.Text.Trim().Length==0?null:(DateTime?)Convert.ToDateTime(texttsBirthday.Text.Trim());
                string cardid = texttsCardid.Text.Trim();
                int? classid = texttsClassid.Text.Trim().Length==0?null:(int?)Convert.ToInt32(texttsClassid.Text.Trim());

                string sql = string.Format("insert into Tblstudent values(N'{0}',N'{1}',N'{2}',{3},N'{4}',N'{5}',{6})"
                                            ,name,gender,address,age,birthday,cardid, classid);
               
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = "成功插入数据！";
                        DataLoad();
                    }
                    else
                        this.Text = "插入了"+r+"行数据";
                    
                    
                }
            }

        }

        private void m_delete_Click(object sender, EventArgs e)
        {
            int tsid = Convert.ToInt32(lbuptsid.Text);
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = string.Format("delete from Tblstudent where tsid={0}",tsid);
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    int r=cmd.ExecuteNonQuery();
                    this.Text="删除了"+r+"行数据";
                    DataLoad();
                }
            }

        }

        private void m_update_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                TblStudent model = new TblStudent();
                model.tsname = textedittsName.Text.Trim();
                model.tsgender = textedittsGender.Text.Trim().Length == 0 ? null : textedittsGender.Text.Trim();
                model.tsaddress = textedittsAddress.Text.Trim().Length == 0 ? null : textedittsAddress.Text.Trim();
                model.tsage =textedittsAge.Text.Trim().Length==0?null:(int?)Convert.ToInt32(textedittsAge.Text.Trim());
                
                model.tsbirthday = textedittsBirthday.Text.Trim().Length == 0 ? null : (DateTime?)Convert.ToDateTime(textedittsBirthday.Text.Trim());
                model.tscardid = textedittsCardid.Text.Trim();
                model.tsclassid = textedittsClassid.Text.Trim().Length==0?null:(int?)Convert.ToInt32(textedittsClassid.Text.Trim());
                model.tsid = Convert.ToInt32(lbuptsid.Text.Trim());

                string sql = string.Format("update Tblstudent set tsName='{0}',tsgender='{1}',tsaddress='{2}',tsage={3},tsbirthday='{4}',tscardid='{5}',tsclassid={6} where tsid={7} "
                , model.tsname, model.tsgender, model.tsaddress, model.tsage
                , model.tsbirthday, model.tscardid, model.tsclassid, model.tsid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    this.Text = "更新了" + r + "行数据";
                    DataLoad();
                }
            }
        }

        private void m_lookup_Click(object sender, EventArgs e)
        {
            List<TblStudent> list1 = new List<TblStudent>();
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
               
                int tsid = Convert.ToInt32(textlptsid.Text.Trim());
                string sql = string.Format("select * from tblstudent where tsid={0}", tsid);
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TblStudent model = new TblStudent();
                                model.tsid=reader.GetInt32(0);
                                model.tsname = reader.GetString(1);
                                model.tsgender = reader.GetString(2);
                                model.tsaddress = reader.GetString(3);
                                model.tsage = reader.GetInt32(4);
                                model.tsbirthday = reader.GetDateTime(5);
                                model.tscardid = reader.GetString(6);
                                model.tsclassid = reader.GetInt32(7);
                                list1.Add(model);
                            }
                        }
                        else
                        {
                            MessageBox.Show("数据库中没有此信息");
                        }

                    }
                }
            }
            this.dgvStudent.DataSource = list1;
        }

        private void dgvStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow currentRow=this.dgvStudent.Rows[e.RowIndex];//获取当前选中行对象
            TblStudent model = currentRow.DataBoundItem as TblStudent;//获取当前选中行对象中的数据信息
            if(model!=null)
            {
                lbuptsid.Text = Convert.ToString(model.tsid);
                textedittsName.Text = model.tsname;
                textedittsGender.Text = model.tsgender;
                textedittsAddress.Text = model.tsaddress;
                textedittsAge.Text = Convert.ToString(model.tsage);
                textedittsBirthday.Text = Convert.ToString(model.tsbirthday);
                textedittsCardid.Text = model.tscardid;
                textedittsClassid.Text = Convert.ToString(model.tsclassid);
            }
  
        }

        private void M_data_Click(object sender, EventArgs e)
        {
            DataLoad();
        }
    }
}
