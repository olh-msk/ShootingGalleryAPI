using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ShootingGalleryAPI.Controllers
{
    public class DataWarehouseController : Controller
    {
        private const string connectionString = "Data Source=DESKTOP-13G90JS;Initial Catalog=MasiukOleh_PZ35_ShootingGallery_Datawarehouse;Integrated Security=True;";
        private const string connectionStringStaging = "Data Source=DESKTOP-13G90JS;Initial Catalog=ShootingGalleryStaging;Integrated Security=True;";
        public IActionResult Index()
        {
            return View();
        }

        // C# API endpoint clear
        [HttpPost]
        [Route("ClearWarehouse")]
        public IActionResult ClearDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("WareClear", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return Ok("Warehouse cleared successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error clearing Warehouse: " + ex.Message);
            }
        }

        // C# API endpoint insert
        [HttpPost]
        [Route("InsertWarehouseFirst")]
        public IActionResult InsertWarehouseFirst()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringStaging))
                {
                    using (SqlCommand command = new SqlCommand("StagingInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("WareFirstInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
     
            return Ok("Warehouse first inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error first inserting warehouse: " + ex.Message);
            }
        }

        // C# API endpoint insert
        [HttpPost]
        [Route("InsertWarehouseIncremental")]
        public IActionResult InsertWarehouseIncremental()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringStaging))
                {
                    using (SqlCommand command = new SqlCommand("StagingInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("WareIncInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return Ok("Warehouse incremental inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error incremental inserting warehouse: " + ex.Message);
            }
        }
    }
}
