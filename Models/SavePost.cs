using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;
using API.Models.Interfaces;
using System;


namespace API.Models
{
    public class SavePost : IInsertPost
    {
        public void InsertPost(Post value)
        {
            DateTime time = DateTime.Now;
            string Date = time.ToString();
            ConnectionString myCon = new ConnectionString();
            string cs = myCon.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
            using var cmd = new MySqlCommand(stm, con);

            //cmd.CommandText = @"INSERT INTO posts(text, date) VALUES(@text, @date)";
            cmd.Parameters.AddWithValue("@text", value.Text);
            cmd.Parameters.AddWithValue("@date",Date);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}