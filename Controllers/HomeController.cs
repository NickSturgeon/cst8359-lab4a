using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _movieContext;

        public HomeController(MovieContext context)
        {
            _movieContext = context;
        }
        
        public IActionResult Index()
        {
            return View(_movieContext.Movies?.ToList());
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Add(movie);
                _movieContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditMovie(int id)
        {
            var movie = _movieContext.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(movie);
        }

        [HttpPost]
        public IActionResult ModifyMovie(Movie formMovie)
        {
            var movie = _movieContext.Movies.SingleOrDefault(m => m.MovieId == formMovie.MovieId);

            if (movie != null && ModelState.IsValid)
            {
                movie.Title = formMovie.Title;
                movie.SubTitle = formMovie.SubTitle;
                movie.Description = formMovie.Description;
                movie.Year = formMovie.Year;
                movie.Rating = formMovie.Rating;
            
                _movieContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieContext.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie != null)
            {
                _movieContext.Remove(movie);
                _movieContext.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}