using GigHubApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHubApp.Core.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public UserDto Artist { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

    }
}