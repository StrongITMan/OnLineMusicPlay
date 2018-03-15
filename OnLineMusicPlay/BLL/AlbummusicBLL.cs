using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AlbummusicBLL
    {
        /// <summary>
        /// 添加方法：创建新歌单
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int Insertalbudata(Model.Albummusic cs)
        {
            return new DAL.AlbummusicDAL().Insertalbudata(cs);
        }


        /// <summary>
        /// 查询方法：显示歌单
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<Model.Albummusic> SelectAlbu(int x)
        {
            return new DAL.AlbummusicDAL().SelectAlbu(x);
        }
    }
}
