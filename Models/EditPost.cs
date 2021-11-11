using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace API.Models
{
    public class EditPost : IEditPost
    {
        public void EditPosts(int id, string value)
        {
            ConnectionString myCon = new ConnectionString();
            string cs = myCon.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "UPDATE posts SET text = @text WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.CommandText = "UPDATE posts SET text = @text WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@text", value);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}