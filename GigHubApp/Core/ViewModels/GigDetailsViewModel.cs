using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }

    }
}