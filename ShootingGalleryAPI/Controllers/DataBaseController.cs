using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ShootingGalleryAPI.Controllers
{
    public class DataBaseController : Controller
    {
        private const string connectionString = "Data Source=DESKTOP-13G90JS;Initial Catalog=MasiukOleh_PZ35_ShootingGallery;Integrated Security=True;";
        public IActionResult Index()
        {
            return View();
        }

        // C# API endpoint clear db
        [HttpPost]
        [Route("ClearDatabase")]
        public IActionResult ClearDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DBClear", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return Ok("Database cleared successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error clearing database: " + ex.Message);
            }
        }

        // C# API endpoint insert db
        [HttpPost]
        [Route("InsertDatabase")]
        public IActionResult InsertDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DBInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return Ok("Database inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error inserting database: " + ex.Message);
            }
        }
    }
}
