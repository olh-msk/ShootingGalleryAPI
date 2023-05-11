using Microsoft.AspNetCore.Mvc;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactSessionController : ControllerBase
    {
        private readonly FactSessionDbContext _context;

        public FactSessionController(FactSessionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FactSession>> Get()
        {
            var list = _context.FactSession.ToList();

            // Check for null values before accessing any properties
            foreach (var session in list)
            {
                if (session.IncomeDifference == null)
                {
                    session.IncomeDifference = 0;
                }
            }

            return Ok(list);
        }
    }
}
