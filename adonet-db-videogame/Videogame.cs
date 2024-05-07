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

        static void GetVideogameById(int id)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}, Release Date: {reader["release_date"]}, Created At: {reader["created_at"]}, Updated At: {reader["updated_at"]}");
                }
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

        static void GetVideogameByInput(string input)
        {
            string query = "SELECT * FROM videogames WHERE name = @input OR overview = @input";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@input", input));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}, Release Date: {reader["release_date"]}, Created At: {reader["created_at"]}, Updated At: {reader["updated_at"]}");
                }
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
