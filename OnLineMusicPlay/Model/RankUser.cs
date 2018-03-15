using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 会员类
    /// </summary>
    public class RankUser
    {
        public int RankID { get; set; }
        public string RankName { get; set; }
        public string RankImage { get; set; }

        public RankUser() { }
        /// <summary>
        /// 会员表
        /// </summary>
        /// <param name="rankid">会员等级编号</param>
        /// <param name="rankname">会员等级名称</param>
        /// <param name="rankimage">会员等级图标路径</param>
        public RankUser(int rankid, string rankname, string rankimage)
        {
            this.RankID = rankid;
            this.RankName = rankname;
            this.RankImage = rankimage;
        }
    }
}
