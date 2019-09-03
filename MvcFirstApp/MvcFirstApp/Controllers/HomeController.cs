using Microsoft.AspNetCore.Mvc;
using MvcFirstApp.Models;
using MvcFirstApp.Repository;
using System;
using System.Collections;

namespace MvcFirstApp.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository _movieRepository;
        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            IEnumerable model = _movieRepository.GetMovieList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Movie model = _movieRepository.GetMovie(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Movie newMovie = _movieRepository.AddMovie(movie);
                return RedirectToAction("index", new { id = newMovie.Id });
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Movie model = _movieRepository.GetMovie(id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Movie model = _movieRepository.Delete(id);
            return View(model);
        }

    }
}