using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Albummusic
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string Albumabstract { get; set; }
        public int ID { get; set; }
        public string AlbuTime { get; set; }
        public int Listeners { get; set; }
        public string ImageUrl { get; set; }

        public Albummusic() { }

        /// <summary>
        /// 构造函数:Albummusic()
        /// </summary>
        /// <param name="albumid">歌单编号</param>
        /// <param name="albumname">歌单名称</param>
        /// <param name="albumabstract">歌单简介</param>
        /// <param name="id">用户ID</param>
        /// <param name="albutime">创建时间</param>
        public Albummusic(int albumid,string albumname,string albumabstract,int id,string albutime,int listeners,string imageurl)
        {
            this.AlbumID = albumid;
            this.AlbumName = albumname;
            this.Albumabstract = albumabstract;
            this.ID = id;
            this.AlbuTime = albutime;
            this.Listeners = listeners;
            this.ImageUrl = imageurl;
        }
    }
}
