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

namespace 加载连接查询的结果到DataGridView.cx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PhoneNum> list = new List<PhoneNum>();
            string sql = "select pid,pname,pcellphone,ptname,ptid from phonenum as pn inner join phonetype as pt on pn.ptypeid=pt.ptid";
            using(SqlDataReader reader=_05封装SqlHelper类.SqlHelper.ExecuteReader(sql))
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        PhoneNum model = new PhoneNum();//添加数据源
                        model.PID = reader.GetInt32(0);
                        model.PName = reader.GetString(1);
                        model.PCellPhone = reader.GetString(2);
                        model.Group = new PhoneType();
                        model.Group.PTName = reader.GetString(3);
                        model.Group.PTID = reader.GetInt32(4);
                        list.Add(model);
                    }
                }
            }
            this.dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //告诉dataGridView1不要自动生成列，添加几列数据源就生成几列
            this.dataGridView1.AutoGenerateColumns = false;
        }
        //设置单元格格式
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
//             //将分组这列，显示分组名称
                 if(e.Value!=null&&e.Value is PhoneType&&e.ColumnIndex==3)
                 {
                     //重新设置最后一个单元格中的值为PTName，即分组
                     e.Value = (e.Value as PhoneType).PTName;
                 }
         }

    }
}
