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
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int SoftwareHouseId { get; set; }

        public Videogame(string name, string overview, DateTime relesedate, DateTime createdat, DateTime updateat, int softwarehouseid = 1) 
        {
            Name = name;
            Overview = overview;
            ReleaseDate = relesedate;
            CreatedAt = createdat;
            UpdatedAt = updateat;
            SoftwareHouseId = softwarehouseid;
        }
    }

    public static class VideogameManagement
    {
        const string CONNECT_DATABASE = "Server=localhost;Database=db-videogames;Trusted_Connection=True";
        public static void InsertVideogame(string name, string overview, DateTime relesedate, DateTime createdat, DateTime updatedat, int softwarehouseid)
        {
           Videogame videogame = new Videogame(name, overview, relesedate, createdat, updatedat, softwarehouseid);

            string query = "INSERT INTO videogames(name, overview, release_date, created_at, updated_at, software_house_id) VALUES (@name, @overview, @relesedate, @createdat, @updatedat, @softwarehouseid)";

            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@relesedate", relesedate));
                cmd.Parameters.Add(new SqlParameter("@createdat", createdat));
                cmd.Parameters.Add(new SqlParameter("@updatedat", updatedat));
                cmd.Parameters.Add(new SqlParameter("@softwarehouseid", softwarehouseid));

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

        public static void GetVideogameById(int id)
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
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}");
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

        public static void GetVideogameByInput(string input)
        {
            string query = "SELECT * FROM videogames WHERE name LIKE @input OR overview LIKE @input";
            //string query = "SELECT * FROM videogames WHERE CAST(name AS NVARCHAR(MAX)) = @input OR CAST(overview AS NVARCHAR(MAX)) = @input";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@input", "%" + input + "%"));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Overview: {reader["overview"]}");
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

        public static void DeleteVideogame(string name)
        {
            string query = "DELETE FROM videogames WHERE name = @name";
            SqlConnection connect = new SqlConnection(CONNECT_DATABASE);

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@name", name));
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
