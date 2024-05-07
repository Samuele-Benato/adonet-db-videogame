using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        public Videogame(int id, string name, string overview, DateTime relesedate, DateTime createdat, DateTime updateat) 
        {
            ID = id;
            Name = name;
            Overview = overview;
            ReleaseDate = relesedate;
            CreatedAt = createdat;
            UpdatedAt = updateat;
        }
    }

    public static class VideogameManagement
    {
        static string CONNECT_DATABASE = "Server=localhost;Database=master;Trusted_Connection=True";
        static void InsertVideogame(int id, string name, string overview, DateTime relesedate, DateTime createdat, DateTime updatedat)
        {
           Videogame videogame = new Videogame(id, name, overview, relesedate, createdat, updatedat);

            string query = "INSERT INTO videogames(id, name, overview, release_date, created_ad, udated_ad) VALUES (id, name, overview, relesedate, createdat, updatedat)";

            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.Parameters.Add(new SqlParameter("overview", overview));
                cmd.Parameters.Add(new SqlParameter("relesedate", relesedate));
                cmd.Parameters.Add(new SqlParameter("createdat", createdat));
                cmd.Parameters.Add(new SqlParameter("updatedat", updatedat));

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
