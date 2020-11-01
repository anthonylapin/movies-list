using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Model;

namespace MoviesApp.Pages.MovieList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task OnGet(int id)
        {
            Movie = await _db.Movies.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var movieFromDb = await _db.Movies.FindAsync(Movie.Id);
                movieFromDb.Name = Movie.Name;
                movieFromDb.Year = Movie.Year;
                movieFromDb.Genre = Movie.Genre;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
