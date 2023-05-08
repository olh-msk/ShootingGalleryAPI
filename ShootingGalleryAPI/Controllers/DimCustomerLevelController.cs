using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimCustomerLevelController : ControllerBase
    {
        private readonly DimCustomerLevelDbContext _context;

        public DimCustomerLevelController(DimCustomerLevelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DimCustomerLevels>> Get()
        {
            var levels = _context.DimCustomerLevel.ToList();

            return Ok(levels);
        }
    }
}
