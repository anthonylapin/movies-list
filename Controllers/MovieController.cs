using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Model;

namespace MoviesApp.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Movies.ToList() });
        }
    }
}