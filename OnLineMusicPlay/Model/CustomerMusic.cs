using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class CustomerMusic
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string LastLoginTime { get; set; }
        public string Remark { get; set; }
        public int State { get; set; }
        public int RankID { get; set; }
        public string RankName { get; set; }

        public CustomerMusic() { }
        /// <summary>
        /// /用户信息表
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">用户密码</param>
        /// <param name="phone">电话号码</param>
        /// <param name="birthday">出生日期</param>
        /// <param name="sex">性别</param>
        /// <param name="email">邮箱地址</param>
        /// <param name="lastlogintime">最后一次登录时间</param>
        /// <param name="remark">备注</param>
        /// <param name="state">状态</param>
        /// <param name="rankid">会员等级</param>
        /// <param name="rankName">会员等级名称</param>
        public CustomerMusic(int id,string username,string userpwd,string phone,string birthday,string sex,string email,string lastlogintime,string remark,int state,int rankid,string rankName)
        {
            this.ID = id;
            this.UserName = username;
            this.UserPwd = userpwd;
            this.Phone = phone;
            this.Birthday = birthday;
            this.Sex = sex;
            this.Email = email;
            this.LastLoginTime = lastlogintime;
            this.Remark = remark;
            this.State = state;
            this.RankID = rankid;
            this.RankName = rankName;
        }
    }
}
