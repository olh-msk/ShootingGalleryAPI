using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimGunController : ControllerBase
    {
        private readonly DimGunDbContext _context;

        public DimGunController(DimGunDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DimGun>> Get()
        {
            var list = _context.DimGun.ToList();

            return Ok(list);
        }
    }
}
