using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MusicBLL
    {
        /// <summary>
        /// 查询方法：查询歌单内的歌曲
        /// </summary>
        /// <param name="albuID"></param>
        /// <returns></returns>
        public List<Model.Music> GetMusicData(int albuID)
        {
            return new DAL.MuiscDaL().GetMusicData(albuID);
        }
    }
}
