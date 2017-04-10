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

namespace Sinday02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }     
        //窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //将TbClass表中的数据读取到List<T>中
            LoadData();
        }
        private void LoadData()
        {
            List<TblClass> list = new List<TblClass>();
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = "select * from tblclass";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.HasRows)//是否查询到数据
                        {
                           //一条一条读取数据,自动下移
                            while(reader.Read())
                            {
                                TblClass model = new TblClass();
                                model.TClassID = reader.GetInt32(0);
                                model.TClassName = reader.GetString(1);
                                model.TClassDesc =reader.IsDBNull(2)?"NULL":reader.GetString(2);
                                list.Add(model);//把读取到的数据加载到list集合中
                            }
                        }

                    }
                }
            }
            //数据绑定的时候只认属性，不认字段,内部通过反射实现
            this.dgvClass.DataSource = list;//数据绑定
        }
        //增加一条数据
        private void button1_Click(object sender, EventArgs e)
        {
            #region 正常插入数据
//             //1.采集用户的输入
//             string className = textClassName.Text.Trim();
//             string classDesc = textClassDesc.Text.Trim();
//             //2.执行插入操作
//             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
//             using(SqlConnection con=new SqlConnection(constr))
//             {
//                 string sql = string.Format("insert into TblClass values(N'{0}',N'{1}')",className,classDesc);
//                 using(SqlCommand cmd=new SqlCommand(sql,con))
//                 {
//                     con.Open();
//                     int r=cmd.ExecuteNonQuery();
//                     if(r>0)
//                     {
//                         //MessageBox会阻塞线程，影响using资源的释放
//                         //MessageBox.Show("成功插入了" + r + "行语句");
//                         this.Text = "插入成功！";
//                         LoadData();//刷新下窗口
//                     }
//                     else
//                     {
//                         //MessageBox.Show("插入了" + r + "行。！");
//                         this.Text = "插入"+r+"行。！";
//                     }
// 
//                 }
//             }
            #endregion

            #region 插入并返回一个编号
            //1.采集用户的输入
            string className = textClassName.Text.Trim();
            string classDesc = textClassDesc.Text.Trim();
            //2.执行插入操作
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("insert into TblClass output inserted.tclassid values(N'{0}',N'{1}')", className, classDesc);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    object obj = cmd.ExecuteScalar();
                    //MessageBox会阻塞线程，影响using资源的释放
                    //MessageBox.Show("成功插入了" + r + "行语句");
                    this.Text = "刚刚插入的自动编号的值是："+obj.ToString();
                    LoadData();
                }
            }
            #endregion
        }
        //行获取焦点事件，sender表示整个窗口控件事件
        private void dgvClass_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前选中的行的对象
            DataGridViewRow currentRow=this.dgvClass.Rows[e.RowIndex];
            //获取当前行中绑定的Tblclass数据对象
            TblClass model = currentRow.DataBoundItem as TblClass;//转换类型
            if(model!=null)
            {
                lblid.Text = model.TClassID.ToString();
                textEditName.Text = model.TClassName;
                textEditClassDesc.Text = model.TClassDesc;
            }
        }
        //保存更新数据
        private void button2_Click(object sender, EventArgs e)
        {
            //1.采集用户输入
            TblClass model = new TblClass();
            model.TClassID = Convert.ToInt32(lblid.Text);
            model.TClassName = textEditName.Text.Trim();
            model.TClassDesc = textEditClassDesc.Text.Trim();
            //2.连接数据库，执行更新
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = string.Format("update TblClass set tClassName='{0}',tClassDesc='{1}' where tClassid={2}"
                    ,model.TClassName,model.TClassDesc,model.TClassID);
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    int r=cmd.ExecuteNonQuery();
                    this.Text = "更新了" + r + "行";
                    //重新加载，绑定DataGridView
                    LoadData();
                }
            }
        }
        //删除数据
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("确定要删除吗？", "操作提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(result==System.Windows.Forms.DialogResult.OK)
            {
                //1.采集用户输入 
                int tClassid = Convert.ToInt32(lblid.Text);
                //2.连接数据库，执行删除
                string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = string.Format("delete from TblClass where tClassid={0}", tClassid);
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        this.Text = "删除了" + r + "行";
                        //重新绑定数据
                        LoadData();

                    }
                }
            }

        }
    }
}
