using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class AlbummusicDAL
    {
        /// <summary>
        /// 添加方法：创建新歌单
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int Insertalbudata(Model.Albummusic cs)
        {
            return Dbhelper.ExecQuery("insert into Albummusic values('" + cs.AlbumName + "','" + cs.Albumabstract + "'," + cs.ID + ",default,0,default)");
        }

        /// <summary>
        /// 查询方法：显示歌单
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<Model.Albummusic> SelectAlbu(int x)
        {
            List<Model.Albummusic> cs = new List<Model.Albummusic>();
            string sql = "";
            if(x==-1)
            {
                 sql = "select * from Albummusic";
            }
            else
            {
                 sql = "select * from Albummusic where ID=" + x + "";
            }
            
            SqlDataReader dr = Dbhelper.ExecReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                    cs.Add(new Model.Albummusic((int)dr["AlbumID"], dr["AlbumName"].ToString(), dr["Albumabstract"].ToString(), (int)dr["ID"], dr["AlbuTime"].ToString(), (int)dr["Listeners"], dr["ImageUrl"].ToString()));

                dr.Close();
            }

            return cs;
        }

        /// <summary>
        /// 下拉框绑定数据源
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<Model.Albummusic> SelectDropList(int x)
        {
            List<Model.Albummusic> cs = new List<Model.Albummusic>();
            string sql = "select [AlbumID],[AlbumName] from Albummusic where ID=" + x + "";
            SqlDataReader dr = Dbhelper.ExecReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                    cs.Add(new Model.Albummusic(dr["AlbumName"].ToString(),(int)dr["AlbumID"]));

                dr.Close();
            }

            return cs;
        }

        /// <summary>
        /// 修改歌单背景图片
        /// </summary>
        /// <param name="pic">修改图片路径</param>
        /// <param name="id">歌单ID</param>
        /// <returns></returns>
        public int UpdateAlbu(string pic, int id)
        {
            string sql = "update Albummusic set ImageUrl='" + pic + "' where AlbumID='" + id + "'";
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
