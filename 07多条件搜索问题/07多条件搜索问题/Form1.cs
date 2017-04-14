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

namespace _07多条件搜索问题
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //假设表名：Books
            //列名：BookName Author Pub

            //根据用户输入的内容进行sql语句动态拼接
            //1.假设用户没有输入任何条件，那么就查询所有记录
            StringBuilder sbSQL = new StringBuilder("select * from Books");
            //2.如果用户输入了条件，则根据用户输入条件动态进行SQL语句
            //在wheres集合中保存查询的sql条件
            List<string> wheres = new List<string>();
            //把参数也放到一个集合中
            List<SqlParameter> listParameters = new List<SqlParameter>();

            List<TextData> list = new List<TextData>();


            if(textBookName.Text.Trim().Length>0)
            {
                //sbSQL.Append("BookName like @bkName");
                //参数里面加%进行模糊查询
                wheres.Add(" BookName like @bkName ");
                listParameters.Add(new SqlParameter("@bkName", SqlDbType.NVarChar, 100) { Value="%"+textBookName.Text.Trim()+"%" });
            }
            if(textAuthor.Text.Trim().Length>0) 
            {
                //sbSQL.Append("BookAuthor like @bkName");
                wheres.Add(" BookAuthor like @author ");
                listParameters.Add(new SqlParameter("@author", SqlDbType.NVarChar, 100) { Value = "%"+textAuthor.Text.Trim()+"%" });
            }
            if(textPub.Text.Trim().Length>0)
            {
                //sbSQL.Append("Pub like @pub");
                wheres.Add(" Pub like @pub ");
                listParameters.Add(new SqlParameter("@pub", SqlDbType.NVarChar, 100) { Value = "%"+textPub.Text.Trim()+"%" });
            }
            //拼接SQL语句
            //如果wheres集合中的记录条数大于0，证明用户输入了条件
            if(wheres.Count>0)
            {
                sbSQL.Append(" where ");//只要有查询条件就评拼接一个where
                //然后把后面的查询条件拼接起来
                sbSQL.Append(string.Join(" and ", wheres));
            }
            SqlParameter[] pms = listParameters.ToArray();
            //MessageBox.Show(sbSQL.ToString());
            using (SqlDataReader reader = _05封装SqlHelper类.SqlHelper.ExecuteReader(sbSQL.ToString(), pms))
            { 
                if(reader.HasRows)
                {
                    
                    while(reader.Read())
                    {
                        TextData model = new TextData();//放在此行
                        model.textid = reader.GetInt32(0);
                        model.textName = reader.GetString(1);
                        model.textAuthor = reader.GetString(2);
                        model.textPub = reader.GetString(3);
                        model.textDate = reader.GetString(4);
                        list.Add(model);

                    }
                }
            }
            dataGridView1.DataSource=list;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String sbSQL = "select * from Books";
            List<TextData> list = new List<TextData>();
            using (SqlDataReader reader = _05封装SqlHelper类.SqlHelper.ExecuteReader(sbSQL))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        TextData model = new TextData();//放在此行
                        model.textid = reader.GetInt32(0);
                        model.textName = reader.GetString(1);
                        model.textAuthor = reader.GetString(2);
                        model.textPub = reader.GetString(3);
                        model.textDate = reader.GetString(4);
                        list.Add(model);

                    }
                }
            }
            dataGridView1.DataSource = list;
        }
    }
}
