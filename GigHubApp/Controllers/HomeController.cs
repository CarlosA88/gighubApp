using GigHubApp.Core.Models;
using GigHubApp.Persistence;
using GigHubApp.Persistence.Repositories;
using GigHubApp.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHubApp.Core;

namespace GigHubApp.Controllers
{
    public class HomeController : Controller
    {
 
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query=null)
        {
            var upcomingGigs = _unitOfWork.Gigs.GetUpcomingGigs(query);

            var userId = User.Identity.GetUserId();

            var attendances = _unitOfWork.Attendances.GetFutureAttendance(userId)
                .ToLookup(a=>a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs=upcomingGigs,
                ShowActions=User.Identity.IsAuthenticated,
                Heading="Upcoming Gigs",
                SearchTerm = query,
                Attendances= attendances
            };
        

            return View("Gigs", viewModel);
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