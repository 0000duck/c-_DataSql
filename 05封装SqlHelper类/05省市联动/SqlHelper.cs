using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05省市联动
{

    public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;
        public static int ExecuteNonQuery(string sql,params SqlParameter[] pms)
        {
            using(SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if(pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string sql,params SqlParameter[] pms)
        {
            using(SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if(pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql,params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }

            }
        }
    }
}
