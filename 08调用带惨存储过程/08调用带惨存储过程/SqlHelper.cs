using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05封装SqlHelper类
{
    //写成一个静态类，不用在New了
    public static class SqlHelper
    {
        //定义连接字符串类内部使用
        //readonly修饰的变量，只能在初始化的时候赋值和构造函数中赋值，其他地方只能读取不能设置。
        //从配置文件中读取连接字符串
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;
        //1.执行增（insert）、删（delete）、改（update）的方法
        //EexcuteNonQuery()
        public static int ExecuteNonQuery(string sql,CommandType cmdType, params SqlParameter[] pms)
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    cmd.CommandType = cmdType;//查看是否使用存储过程
                    if(pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //2.执行查找，返回单个值的方法
        //EexcuteScalar()
        public static object EexcuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    cmd.CommandType = cmdType;//查看是否使用存储过程
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }


        //3.执行查询，返回多行，多列的方法
        //ExecuteReader()
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);//不用using是因为返回之前using已释放，无法使用con
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;//查看是否使用存储过程
                if (sql != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //(System.Data.CommandBehavior.CloseConnection参数表示使用完毕SqlDataReader后，
                    //在关闭reader时，在SqlDataReader内部会自动将关联的SqlConnection关闭
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch//当try中发生异常时，关闭连接
                {
                    con.Close();
                    con.Dispose();
                    throw;//因为函数有返回值，也相当于一个返回
                }
            }
        }

        //4.查询数据放回DataTable类型
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();

            using(SqlDataAdapter adapter=new SqlDataAdapter(sql,conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;//查看是否使用存储过程
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

    }
}
