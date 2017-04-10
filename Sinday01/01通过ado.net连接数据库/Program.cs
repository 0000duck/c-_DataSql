using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01通过ado.net连接数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  如何打开连接
            //连接数据库的基本步骤
            //1.创建连接字符串（连接哪个数据库 ）
            //Data Source=DESKTOP-J4JFLTU\SQLEXPRESS    哪个服务器的哪个实例
            //Initial Catalog= MyFirstDataBase  初始化的连接分类服务器
            //Integrated Security=True   使用windows验证方式

            //             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;INITIAL CATALOG=MyFirstDataBase;Integrated Security=True";//集成连接方式
            //             //string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalot=MyFirstDataBase;User ID=sa;Password=1";//用户名密码连接方式
            // 
            //             //2.创建连接对象
            //             using (SqlConnection con=new SqlConnection(constr))
            //             {
            //                 //测试，打开连接
            //                 //3.打开连接（如果打开数据连接没问题，表示连接成功！）
            //                 con.Open();
            //                 Console.WriteLine("打开连接成功");
            //                 //4.关闭连接，释放资源
            //                 //con.Close();//SqlConnection类中Dispose默认调用Close()
            //                 //con.Dispose();//因为用了using默认调用了它
            //             }
            //             Console.WriteLine("关闭数据库，释放资源");
            //             Console.ReadKey();
            #endregion

            #region 通过ado.net向表中插入一条数据
            //             //1.连接字符串
            //             string constr="Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;INITIAL CATALOG=MyFirstDataBase;Integrated Security=True";
            //             //2.创建连接对象
            //             using(SqlConnection con=new SqlConnection(constr))
            //             {
            // //                 //3.打开连接
            // //                 con.Open();
            //                 Console.WriteLine("连接打开成功");
            //                 //4.编写sql语句
            //                 string sql = "insert into tblscore values(7,89,90,'郑国')";
            //                 //5.创建一个执行sql语句的对象(命令对象)sqlCommand
            //                 using(SqlCommand cmd=new SqlCommand(sql,con))
            //                 {
            //                      //3.打开连接(连接对象最晚打开，最早关闭！节省资源)
            //                      con.Open();
            //                      //6.开始执行sql语句 (下面三条语句都能成功执行但)
            //                      //                      cmd.ExecuteNonQuery();//当执行insert\delete\update语句时,返回int类型，表示所影响的行数。
            //                      //特别注意ExecuteNonQuery()执行其他语句，永远返回-1
            //                      //                      cmd.ExecuteReader();//当查询多行，多列结果的时候
            //                      //                      cmd.ExecuteScalar();//当执行返回单个结果
            // 
            //                      int r=cmd.ExecuteNonQuery();
            //                      Console.WriteLine("成功插入了{0}行数据。", r);
            // 
            //                 }
            // 
            //             }
            //             Console.ReadKey();
            #endregion

            #region 通过ado.net重表中删除一条数据
            //             //1.连接字符串
            //             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            // 
            //             //2.连接对象
            //             using (SqlConnection con = new SqlConnection(constr))
            //             {
            //                 //3.sql语句
            //                 string sql = "delete from tblscore where tName='郑国'";
            //                 //4.创建一个sqlCommand对象
            //                 using (SqlCommand cmd = new SqlCommand(sql,con))
            //                 {
            //                     //5.打开连接
            //                     con.Open();
            //                     //6.执行
            //                     int r = cmd.ExecuteNonQuery();
            //                     Console.WriteLine("成功删除了{0}条数据。", r);
            //                 }
            // 
            //             }
            #endregion

            #region 通过ado.net在表中修改一条语句
            //             //1.创建连接字符串
            //             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial Catalog=MyFirstDataBase;Integrated Security=True";
            //             //2.创建连接对象
            //             using(SqlConnection con=new SqlConnection(constr))
            //             {
            //                 //3.编写sql语句
            //                 string sql = "update tblscore set tName='王国维',tsid=8,tenglish=96,tmath=45 where tscoreid=4";
            //                 //4.创建一个执行sql语句的对象（命令对象）sqlCommand
            //                 using(SqlCommand cmd=new SqlCommand(sql,con))
            //                 {
            //                     //5.打开连接
            //                     con.Open();
            //                     //6.执行语句
            //                     int r = cmd.ExecuteNonQuery();
            //                     Console.WriteLine("修改了{0}条语句", r);
            //                 }
            // 
            //             }
            //             Console.ReadKey();
            #endregion

            #region 查询数据库中的记录条数
            //             //1.连接字符串
            //             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
            //             //2.创建连接对象
            //             using(SqlConnection con=new SqlConnection(constr))
            //             {
            //                 //3.创建sql语句
            //                 string sql="select count(*) from tblscore";
            //                 //4.创建命令对象
            //                 using(SqlCommand cmd=new SqlCommand(sql,con))
            //                 {
            //                     //5.打开数据库
            //                     con.Open();
            //                     //6.执行语句
            //                     //注意执行sql语句时，如果是聚合函数，那么ExecuteScalar()返回值不可能是null,因为聚合函数不会返回null,
            //                     //但如果sql语句使用的不是聚合函数，那么ExecuteScalar()方法是可能返回null的，那么使用count变量前，需要
            //                     //判断下是否为null了。
            //                     //object count=(int)cmd.ExecuteScalar();
            //                     object count = Convert.ToInt32(cmd.ExecuteScalar());//可避免出错
            //                     Console.WriteLine("tblscore表中共有{0}条数据。", count);
            //                 }
            // 
            //             }
            //             Console.ReadKey();

            #endregion

            #region 插入数据测试
            //1.创建连接字符串
//             string constr="Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=TTT;Integrated Security=True";
//             //2.创建连接对象
//             using(SqlConnection con=new SqlConnection(constr))
//             {
//                 //3.创建sql语言
//                 string sql = "insert into Table_1 values(N'小红杨')";
//                 //4.创建命令对象
//                 using(SqlCommand cmd=new SqlCommand(sql,con))
//                 {
//                     //5.打开连接
//                     con.Open();
//                     //6.执行语句
//                     int r=cmd.ExecuteNonQuery();
//                     Console.WriteLine("成功插入{0}行", r);
//                 }
// 
//             }
//             Console.ReadKey();

            #endregion

            #region  通过ExecuteReader()读取数据
            //             string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
//             using(SqlConnection con=new SqlConnection(constr))
//             {
//                 string sql = "select * from TblScore";
//                 using(SqlCommand cmd=new SqlCommand(sql,con))
//                 {
//                     con.Open();
//                     //通过调用ExecuteReader()方法，将给定的sql语句在服务器端执行
//                     //执行完毕后，服务器端就已经查询出了数据，但是数据是保存在数据库服务器的内存当中
//                     //并没有返回给应用程序，只是返回给应用程序一个reader对象，这个对象就是用来获取数据的对象
//                     //1.SqlDataReader只读，只进没法后退，使用时必须保证连接Opend()是打开连接状态
//                     //2.Reader使用完毕时，必须关闭reader,释放，同时关闭连接对象
//                     //3.Reader默认独占一个连接
//                     using(SqlDataReader reader=cmd.ExecuteReader())
//                     {
//                         //接下来通过reader对象一条一条获取数据
//                         //1.在获取数据之前，先判断下本次执行查询后，是否查询到了数据
//                         
//                         if(reader.HasRows)//如果有数据，则为true
//                         {
//                             //2.如果有数据，那么接下来就一条一条获取数据
//                             //3.reader指向第一条数据的前一条，需要调用Read()方法，向后移动一条数据，
//                             //如果成功移动到某条数据，返回true,否则返回false
//                             while(reader.Read())
//                             {
//                                 //获取当前reader指向的每一行数据
//                                 //reader.FielCount，可以获取当前查询语句查询出的列的个数
//                                 //reader当遇到数据库中null值的时候，通过reader.GetValue(i)或者索引获取的是事DBNull.Value.不是c#的null,
//                                 //而DBNull.Value的ToString()方法返回的是空字符串，所以不会报错
//                                 for(int i=0;i<reader.FieldCount;++i)
//                                 {
//                                     //可以通过索引或者列的名称获取列的值
//                                     Console.Write(reader[i]+"\t|\t");//1.利用索引器读取数据
//                                     //reader["tName"]在给定列的名称的情况下，获取到列的索引，在读取数据
//                                     //Console.Write(reader["tName"] + "\t|\t");//1.利用列的名称读取数据
//                                     //GetValue()只能通过猎德索引来获取列的值
//                                     //Console.Write(reader.GetValue(i) + "\t|\t");
// 
//                                     //如果要获取到对应数据库中的类型，要使用
//                                     //reader.GetXxxxxx();
//                                 }
//                                 Console.WriteLine();
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("没有查询到任何数据！！！");
//                         }
//                        
//                     }
// 
//                 }
//             }
//             Console.ReadKey();
            #endregion

            #region 通过ExecuteReader()读取数据，并保持数据原类型
            string constr = "Data Source=DESKTOP-J4JFLTU\\SQLEXPRESS;Initial CataLog=MyFirstDataBase;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string sql = "select * from TblScore";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                {
                    con.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            //注意：通过reader.GetXxxx()方法获取的数据，如果为null那么会报异常，此时需要手动处理
                            while (reader.Read())//如果成功移动到某条数据，返回true,否则返回false
                            {
                                //tScoreid tsid tenglish tmath,tname
                                Console.Write(reader.GetInt32(0)+ "\t|\t");
                                //判断可以为空的列，是否为空，如果为空，输出null,否则正常输出
                                Console.Write(reader.IsDBNull(1) ? "NULL" + "\t|\t" : reader.GetInt32(1) + "\t|\t");
                                Console.Write(reader.GetValue(2) + "\t|\t");//数据库中float和c#中float不同，只能用GetValue()获取数据
                                Console.Write(reader.GetValue(3) + "\t|\t");
                                //判断可以为空的列，是否为空，如果为空，输出null,否则正常输出
                                Console.Write(reader.IsDBNull(4) ? "NULL" : reader.GetString(4) + "\t|\t");
                                Console.WriteLine();
                             }
                        }
                        else
                        {
                            Console.WriteLine("数据库中没有数据！！！");
                        }
                    }
                }
            }
            Console.ReadKey();
            #endregion
        }
    }
}
