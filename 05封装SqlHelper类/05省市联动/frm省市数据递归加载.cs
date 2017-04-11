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
    public partial class frm省市数据递归加载 : Form
    {
        public frm省市数据递归加载()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAreasToTree(0,this.treeView1.Nodes);
        }
        //将指定的id 下的节点加载到Nodes集合中
        private void LoadAreasToTree(int pid, TreeNodeCollection treeNodeCollection)
        {
            //1.根据pid查询下面的所有子城市
            List<TblArea> list = GetAreaByParentId(pid);
            //2.把这些城市加载到TreeView中
            //遍历list集合，把数据加载到treeNodeCollection中
            foreach(TblArea item in list)
            {
                TreeNode node = treeNodeCollection.Add(item.AreaName);
                node.Tag = item.AreaID;

                //下面实现递归
                LoadAreasToTree(item.AreaID, node.Nodes);
            }
        }
        //根据父id查询子城市
        private List<TblArea> GetAreaByParentId(int pid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "select Areaid,AreaName from TblArea where AreaPid=@pid";
            SqlParameter pl = new SqlParameter("@pid", SqlDbType.Int) { Value = pid };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, pl))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
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
    }
}
