using GigHubApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration: EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a=> new { a.GigId, a.AttendeeId });
        }
    }
}