using GigHubApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class GenreConfiguration:EntityTypeConfiguration<Genre>
    {

        public GenreConfiguration()
        {
            Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();
        }

    }
}