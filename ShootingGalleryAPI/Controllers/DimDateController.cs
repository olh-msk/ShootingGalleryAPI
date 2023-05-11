using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimDateController : ControllerBase
    {
        private readonly DimDateDbContext _context;

        public DimDateController(DimDateDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DimDate>> Get()
        {
            var list = _context.DimDate.ToList();

            return Ok(list);
        }
    }
}
