using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace DAL
{
    /// <summary>
    /// 类：用于完成有关SQL Server数据库的操作
    /// </summary>
    public class Dbhelper
    {
        public static SqlConnection Conn {
            get
            {
                //获取表示层配置文件Web.Config文件中的连接字符串
                string str = ConfigurationManager.ConnectionStrings["SQL"].ToString();

                SqlConnection conn = new SqlConnection(str);
                if (conn == null)
                    conn.Open();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
                return conn;
            }
        }

        /// <summary>
        /// 方法：根据指令填充数据表，在此完成查询类型的操作
        /// </summary>
        /// <param name="sqlQuery">SQL查询命令或存储过程名称</param>
        /// <param name="cmType">查询命令的类型，默认为SQL查询语句</param>
        /// <param name="parms">参数列表，默认为无参</param>
        /// <returns>填充的数据表</returns>
        public static DataTable FillTable(string sqlQuery, CommandType cmType = CommandType.Text, SqlParameter[] parms = null)
        {
            //创建数据适配器对象
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, Conn);
            //创建数据表对象
            DataTable dt = new DataTable();
            //设置查询命令类型
            da.SelectCommand.CommandType = cmType;

            //如果参数列表不为空，则将其添加到命令参数集合中
            if (parms != null)
                da.SelectCommand.Parameters.AddRange(parms);


            try
            {
                //填充数据表，如果成功则返回填充的数据表
                da.Fill(dt);
                return dt;
            }
            catch
            {
                //如果有异常则返回空
                return null;
            }
            finally
            {
                //销毁对象
                dt.Dispose();
                da.Dispose();
            }
        }


        /// <summary>
        /// 方法：根据指令获取数据读取对象，在此完成查询类型操作
        /// </summary>
        /// <param name="sqlQuery">SQL查询命令或存储过程名称</param>
        /// <param name="cmType">查询命令的类型，默认为SQL查询语句</param>
        /// <param name="parms">参数列表，默认为无参</param>
        /// <returns>数据读取对象</returns>
        public static SqlDataReader ExecReader(string sqlQuery, CommandType cmType = CommandType.Text, SqlParameter[] parms = null)
        {
            //创建命令对象
            SqlCommand cm = new SqlCommand(sqlQuery, Conn);
            //设置命令类型
            cm.CommandType = cmType;

            //如果参数列表不为空，则将其添加到命令参数集合中
            if (parms != null)
                cm.Parameters.AddRange(parms);

            try
            {
                //执行操作，如果成功则返回数据读取对象
                return cm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                //如果有异常则返回空
                return null;
            }
        }

        ///// <summary>
        ///// 执行Select查询语句，返回数据集对象
        ///// </summary>
        ///// <param name="cmdType">命令类型</param>
        ///// <param name="cmdText">Select查询语句或存储过程</param>
        ///// <param name="cmdParams">Select查询语句或存储过程中带的参数(params表示此参数可以不赋值)</param>
        ///// <returns>返回数据集对象</returns>
        ///// 
        //public static DataSet GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
        //    da.SelectCommand.CommandType = cmdType;          //设置命令类型
        //    da.SelectCommand.Parameters.AddRange(cmdParams); //添加参数
        //    da.Fill(ds);
        //    return ds;
        //}



        /// <summary>
        /// 方法：返回受影响的行数，在此完成添加、更新、删除类型的操作
        /// </summary>
        /// <param name="sqlQuery">SQL查询命令或存储过程名称</param>
        /// <param name="cmType">查询命令的类型，默认为SQL查询语句</param>
        /// <param name="parms">参数列表，默认为无参</param>
        /// <returns>受影响的行数：
        ///          -2：表示数据库连接异常
        ///          -1：表示命令异常
        /// </returns>
        public static int ExecQuery(string sqlQuery, CommandType cmType = CommandType.Text, SqlParameter[] parms = null)
        {

            //创建命令对象
            SqlCommand cm = new SqlCommand(sqlQuery, Conn);
            //设置命令类型
            cm.CommandType = cmType;

            //如果参数列表不为空，则将其添加到命令参数集合中
            if (parms != null)
                cm.Parameters.AddRange(parms);

            try
            {
                try
                {
                    //执行操作，如果成功则返回受影响的行数
                    return cm.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    //如果操作异常，则返回-1
                    string xe = ex.Message;
                    return -1;
                }
            }
            catch(Exception ex)
            {
                //如果数据库连接异常，则返回-2
                string wd = ex.Message;
                return -2;
            }
            finally
            {
                //销毁对象
                cm.Dispose();
            }

        }

        /// <summary>
        /// Md5加密方法
        /// </summary>
        /// <param name="pwd">要加密的字符串</param>
        /// <returns></returns>
        public static string Encryption(string pwd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            bytes = md5.ComputeHash(bytes);
            return BitConverter.ToString(bytes);
        }


        /// <summary>
        /// 方法：返回首行首列的值，在此完成所有验证查询和聚合查询类型的操作
        /// </summary>
        /// <param name="sqlQuery">SQL查询命令或存储过程名称</param>
        /// <param name="cmType">查询命令的类型，默认为SQL查询语句</param>
        /// <param name="parms">参数列表，默认为无参</param>
        /// <returns>首行首列的值：
        ///          -2：表示数据库连接异常
        ///          -1：表示数据操作异常
        /// </returns>
        public static object ExecScalar(string sqlQuery, CommandType cmType = CommandType.Text, SqlParameter[] parms = null)
        {

            //创建命令对象
            SqlCommand cm = new SqlCommand(sqlQuery, Conn);
            //设置命令类型
            cm.CommandType = cmType;

            //如果参数列表不为空，则将其添加到命令参数集合中
            if (parms != null)
                cm.Parameters.AddRange(parms);
            try
            {
                try
                {
                    //执行操作，如果成功则返回首行首列的值
                    return cm.ExecuteScalar();
                }
                catch
                {
                    //如果操作异常，则返回-1
                    return -1;
                }
            }
            catch
            {
                //如果数据库连接异常，则返回-2
                return -2;
            }
            finally
            {
                //销毁对象
                cm.Dispose();
            }
        }
    }
}
