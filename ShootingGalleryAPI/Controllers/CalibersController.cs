using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalibersController : ControllerBase
    {
        private readonly CalibersDbContext _context;

        public CalibersController(CalibersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Calibers>> Get()
        {
            var list = _context.Calibers.ToList();

            return Ok(list);
        }
    }
}

