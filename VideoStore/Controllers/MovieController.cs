using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using System.Data.Entity;

namespace VideoStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(x => x.Genre).ToList();

        }
    }
}