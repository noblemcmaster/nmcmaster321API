using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace API.Models
{
    public class DeletePost : IDeletePost
    {
        public void DeletePost(int id)
        {
            ConnectionString myCon = new ConnectionString();
            string cs = myCon.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "DELETE FROM posts WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.CommandText = "DELETE FROM posts WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}