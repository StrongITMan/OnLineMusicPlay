using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class CustomerBLL
    {
        /// <summary>
        /// 方法：添加用户操作
        /// </summary>
        /// <param name="cus">操作对象</param>
        /// <returns>返回受影响行数</returns>
        public int InsterRegist(Model.CustomerMusic cus)
        {
            //if (!new Rule.Testexist().TestInsert(cus.Phone))
            //    return -3;

            return new DAL.CustomerDaL().InsterRegist(cus);
        }
        /// <summary>
        /// 方法:查询用户
        /// </summary>
        /// <param name="phone">登录账户(手机号码)</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public Model.CustomerMusic SelectLogin(string phone, string pwd)
        {
            List<Model.CustomerMusic> cs = new List<Model.CustomerMusic>();
            cs = new DAL.CustomerDaL().SelectLogin(phone, DAL.Dbhelper.Encryption(pwd));

            if (cs.Count != 1)
            {
                return new Model.CustomerMusic() { Phone = "0", UserPwd = "登录失败!" };
            }
            else
            {
                return cs[0];
            }
        }

        /// <summary>
        /// 修改登录时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateCustomerID(int id)
        {
            return new DAL.CustomerDaL().UpdateCustomerID(id);
        }
    }
}
