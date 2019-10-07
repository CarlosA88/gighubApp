using GigHubApp.Core.Models;
using GigHubApp.Persistence;
using GigHubApp.Persistence.Repositories;
using GigHubApp.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHubApp.Core;

namespace GigHubApp.Controllers
{

    public class GigsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;//Dependency Injection >>
        }

        [Authorize]
        public ActionResult Mine()
        {

            var userId = User.Identity.GetUserId();

            var gigs = _unitOfWork.Gigs.GetUpcomingGigsByArtist(userId);

            return View(gigs);

        }

        public ActionResult Details( int id )
        {
            var gig = _unitOfWork.Gigs.GetGigsDetails(id);

            if (gig == null)
                return HttpNotFound();

            var viewModel = new GigDetailsViewModel { Gig = gig };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending =
                    _unitOfWork.Attendances.GetAttendance(gig.Id,userId)!=null;

                viewModel.IsFollowing =
                    _unitOfWork.Followings.GetFollowings(userId,gig.ArtistId)!=null; 
                    
            }

            return View("Details", viewModel);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gig´s I am attending",
                Attendances = _unitOfWork.Attendances.GetFutureAttendance(userId).ToLookup(a => a.GigId)

        };

            return View("Gigs", viewModel);
        }

        [HttpPost]
        public ActionResult Search( GigsViewModel viewModel )
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenres(),
                Heading = "Add a Gig"
            };

            return View("GigForm", viewModel);
        }
        [Authorize]
        public ActionResult Edit( int id )
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigsDetails(id);

            var viewModel = new GigFormViewModel
            {
                Heading = "Edit a gig",
                Id = gig.Id,
                Genres = _unitOfWork.Genres.GetGenres(),
                Date = gig.DateTime.ToString("d MMM yyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue
            };

            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( GigFormViewModel viewModel )
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue

            };
            _unitOfWork.Gigs.Add(gig);
            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update( GigFormViewModel viewModel )
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("GigForm", viewModel);
            }
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(viewModel.Id);

            gig.Venue = viewModel.Venue;
            gig.DateTime = viewModel.GetDateTime();
            gig.GenreId = viewModel.Genre;

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }
    }
}