using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using System.Data.Entity;
using VideoStore.ViewModel;

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

        [HttpGet]
        public ActionResult New()
        {
            var model = new MovieFormViewModel()
            {
                Movie = new Movie()
            };

            model.Genres = _dbContext.Genres.ToList();

            return View("MovieForm", model);
        }

        public ActionResult Edit(int movieId)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel();
            viewModel.Movie = movie;
            viewModel.Genres = _dbContext.Genres.ToList();

            return View("MovieForm", viewModel);
        }

        public ActionResult Delete(int movieId)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return HttpNotFound();
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            //New
            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieFromDb = _dbContext.Movies.SingleOrDefault(x => x.Id == movie.Id);

                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.DateAdded = movie.DateAdded;
                movieFromDb.NumberInStock = movie.NumberInStock;
                movieFromDb.GenreId = movie.GenreId;
            }


            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(x => x.Genre).ToList();
        }
    }
}