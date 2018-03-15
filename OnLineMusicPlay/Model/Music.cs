using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Music
    {
        public string MusicID { get; set; }
        public string MusicName { get; set; }
        public string Dearmer { get; set; }
        public string MusicTime { get; set; }
        public int SongsterID { get; set; }
        public int MusicTypeID { get; set; }
        public string Musicyear { get; set; }
        public int ID { get; set; }
        public int Musicheart { get; set; }
        public int State { get; set; }
        public  string SongsterName { get; set; }
        public string TypeName { get; set; }
        public int AlbID { get; set; }

        public Music() { }
        public Music(string musicid,string musicname,string dearmer,string musictime,int songsterid,int musictype,string musicyear,int id,int musicheart,int state,string songstername,string typename,int albid)
        {
            this.MusicID = musicid;
            this.MusicName = musicname;
            this.Dearmer = dearmer;
            this.MusicTime = musictime;
            this.SongsterID = songsterid;
            this.MusicTypeID = musictype;
            this.Musicyear = musicyear;
            this.ID = id;
            this.Musicheart = musicheart;
            this.State = state;
            this.SongsterName = songstername;
            this.TypeName = typename;
            this.AlbID = albid;
        }
    }
}
