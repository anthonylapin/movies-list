using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Model;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Pages.MovieList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Movie> Movies { get; set; }
        public async Task OnGet()
        {
            Movies = await _db.Movies.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var movie = await _db.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
