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

namespace _05省市联动
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.把所有的省份加载到combox1上
            LoadProvince();
        }

        private void LoadProvince()
        {
            /*throw new NotImplementedException();*/
            //1.查询所有父ID为0的那些数据
            string sql = "select Areaid,AreaName from TblArea where AreaPid=@pid";
            SqlParameter pl = new SqlParameter("@pid", SqlDbType.Int) { Value = 0 };
            using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,pl))
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaID = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        
                        comboBox1.Items.Add(model);//会调用TblArea类的ToString方法，所有需要重载此方法
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem!=null)
            {
                TblArea model = comboBox1.SelectedItem as TblArea;//因为上文中添加的信息即为TblArea类型的
                MessageBox.Show(model.AreaName + "      " + model.AreaID);
            }
        }
        //选择项改变事件

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取省份id
            if(comboBox1.SelectedItem!=null)
            {
                //comboBox3.Items.Clear();//每次清空数据
                TblArea model = comboBox1.SelectedItem as TblArea;
                int areaid = model.AreaID;
                //2.根据areaid从数据库中查询对应的数据
                List<TblArea> cities = GetSubCity(areaid);
                //方式1
//                 foreach(TblArea item in cities)
//                 {
//                     comboBox3.Items.Add(item);
//                 }
                //方式2 通过数据绑定技术向下拉菜单中增加选项
                //建议绑定数据源的时候先设置DisplayMember和ValueMember的值
                //再设置DataSource的数据源
                comboBox3.DisplayMember = "AreaName";
                comboBox3.ValueMember = "AreaID";
                comboBox3.DataSource = cities;
                
            }
        }

        private List<TblArea> GetSubCity(int areaid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "select Areaid,AreaName from TblArea where AreaPid=@id";
            SqlParameter pl=new SqlParameter("@id",SqlDbType.Int){Value=areaid};
            using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,pl))
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaID = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //通过数据绑定技术获取到的名称和id
            MessageBox.Show(comboBox3.Text + "     " + comboBox3.SelectedValue.ToString());
        }
    }
}
