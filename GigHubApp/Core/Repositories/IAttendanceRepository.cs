using GigHubApp.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace GigHubApp.Core.Persistence
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendance(string userId);
        Attendance GetAttendance(int gigId, string userId);
        void Remove(Attendance attendance);
    }
}