using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;

namespace WebApplication.Tarea1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        [WebMethod]
        public static string ObtenerUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var usuarios = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Correo FROM Usuarios";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["Correo"].ToString()
                            });
                        }
                    }
                }
            }

            return new JavaScriptSerializer().Serialize(usuarios);
        }

        [WebMethod]
        public static string GuardarUsuario(string nombre, string correo)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Usuarios (Nombre, Correo) VALUES (@Nombre, @Correo)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return new JavaScriptSerializer().Serialize(new { success = true });
            }

            catch (Exception ex)
            {
                return new JavaScriptSerializer().Serialize(new { success = false, error = ex.Message });
            }
        }
    }
}