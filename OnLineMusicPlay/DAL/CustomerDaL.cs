using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class CustomerDaL
    {
        /// <summary>
        /// 方法：添加用户数据
        /// </summary>
        /// <param name="cus">操作对象</param>
        /// <returns>受影响行数</returns>
        public int InsterRegist(Model.CustomerMusic cus)
        {
            return Dbhelper.ExecQuery("insert into CustomerMusic(UserName,UserPwd,Phone,Birthday,Sex,Email,LastLoginTime,Remark,[State],RankID) values('" + cus.UserName + "','" + cus.UserPwd + "','" + cus.Phone + "','" + cus.Birthday + "','" + cus.Sex + "','" + cus.Email + "',default,'',1,1)");
        }

        /// <summary>
        /// 方法：查询用户信息
        /// </summary>
        /// <returns>返回对象集合</returns>
        public List<Model.CustomerMusic> SelectLogin(string phone, string pwd)
        {
            List<Model.CustomerMusic> list = new List<Model.CustomerMusic>();
            string sql = "select c.*,r.RankName from CustomerMusic c left join  RankUser r on c.RankID=r.RankID where c.Phone='" + phone + "' and c.UserPwd='" + pwd + "'";
            SqlDataReader dr = Dbhelper.ExecReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                {
                    list.Add(new Model.CustomerMusic(
                        (int)dr["ID"],
                        dr["UserName"].ToString(),
                        dr["UserPwd"].ToString(),
                        dr["Phone"].ToString(),
                        dr["Birthday"].ToString(),
                        dr["Sex"].ToString(),
                        dr["Email"].ToString(),
                        dr["LastLoginTime"].ToString(),
                        dr["Remark"].ToString(),
                        (int)dr["State"],
                        (int)dr["RankID"],
                        dr["RankName"].ToString()
                    ));
                }
                dr.Close();
            }
            return list;
        }

        /// <summary>
        /// 修改：修改登录时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateCustomerID(int id)
        {
            string sql = "update CustomerMusic set LastLoginTime=default where ID=" + id + "";
            if (id != 0)
            {
                return Dbhelper.ExecQuery(sql);
            }
            else
            {
                return 0;
            }

        }
    }
}
