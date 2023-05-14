using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Data;
using ShootingGalleryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShootingGalleryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactShowController : ControllerBase
    {
        private readonly FactShowDbContext _context;

        public FactShowController(FactShowDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FactShow>> Get()
        {
            var list = _context.FactShow.Select(fs => new FactShow
            {
                SessionKey = fs.SessionKey,
                GalleryName = fs.GalleryName,
                CaliberType = fs.CaliberType,
                CustomerLevelName = fs.CustomerLevelName,
                PeriodStartDay = fs.PeriodStartDay.Date,
                PeriodEndDay = fs.PeriodEndDay.Date.Date,
                TotalIncome = fs.TotalIncome,
                Quantity = fs.Quantity,
                IncomeDifference = fs.IncomeDifference ?? 0
            }).ToList();

            return Ok(list);
        }
    }
}
