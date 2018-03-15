using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public  class MuiscDaL
    {
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="albuID">歌单编号</param>
        /// <returns>查询对象</returns>
        public List<Model.Music> GetMusicData(int albuID)
        {
            List<Model.Music> cs = new List<Model.Music>();
            string sql = "select * from Muisc_Song_Type d where d.AlbID="+ albuID + "";
            SqlDataReader dr = Dbhelper.ExecReader(sql);
            if(dr!=null)
            {
                while(dr.Read())
                {
                    cs.Add(new Model.Music(dr["MusicID"].ToString(), dr["MusicName"].ToString(), dr["Dearmer"].ToString(), dr["MusicTime"].ToString(), (int)dr["SongsterID"], (int)dr["MusicTypeID"], dr["Musicyear"].ToString(), (int)dr["ID"], (int)dr["Musicheart"], (int)dr["State"],dr["SongsterName"].ToString(),dr["TypeName"].ToString(),(int)dr["AlbID"]));
                }
                dr.Close();
            }
            return cs; 
        }
    }
}
