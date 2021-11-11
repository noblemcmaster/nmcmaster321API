using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadPostData : IGetAllPosts, IGetPosts
    {
        public List<Post> GetAllPosts()
        {
            List<Post> allPosts = new List<Post>();

            ConnectionString myCon = new ConnectionString();
            string cs = myCon.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "SELECT * FROM posts ORDER BY id DESC";
            using var cmd = new MySqlCommand(stm, con);

            cmd.CommandText = "SELECT * FROM posts ORDER BY id DESC";


            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Post temp = new Post(){Id=rdr.GetInt32(0), Text=rdr.GetString(1), Date=rdr.GetString(2)};
                allPosts.Add(temp);
            }
            
            return allPosts;
        }

        public Post GetPost(int id)
        {
            ConnectionString myCon = new ConnectionString();
            string cs = myCon.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "SELECT * FROM posts WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Post(){Id=rdr.GetInt32(0), Text=rdr.GetString(1), Date=rdr.GetString(2)};
        }
    }
}