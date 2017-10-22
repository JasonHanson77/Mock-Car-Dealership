using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories.ADO;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        private readonly ICarsRepository _carsRepo;
        private readonly ISpecialsRepository _specialsRepo;

        public HomeController(ICarsRepository carsRepo, ISpecialsRepository specialsRepo)
        {
            _carsRepo = carsRepo;
            _specialsRepo = specialsRepo;
        }

        public ActionResult Index()
        {
            var model = new IndexPageViewModel()
            {
                FeaturedCars = _carsRepo.GetAllFeaturedCars(),
                Specials = _specialsRepo.GetAll(),
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}