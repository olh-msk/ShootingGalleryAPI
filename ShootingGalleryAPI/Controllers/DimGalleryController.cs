using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimGalleryController : ControllerBase
    {
        private readonly DimGalleryDbContext _context;

        public DimGalleryController(DimGalleryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DimGallery>> Get()
        {
            var list = _context.DimGallery.ToList();

            return Ok(list);
        }
    }
}
