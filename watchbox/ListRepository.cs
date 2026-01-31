using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchbox
{
    static class ListRepository
    {
        public static List<ListItem> GetUserLists(int userId)
        {
            var lists = new List<ListItem>();

            using (var con = DB.GetConnection())
            {
                con.Open();

                var cmd = new SQLiteCommand(
                    "SELECT * FROM Lists WHERE UserId=@u", con);
                cmd.Parameters.AddWithValue("@u", userId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lists.Add(new ListItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"]?.ToString(),
                        IsPublic = Convert.ToInt32(reader["IsPublic"]) == 1
                    });
                }
            }

            return lists;
        }
    }
}
