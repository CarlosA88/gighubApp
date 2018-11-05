using GigHubApp.Core;
using GigHubApp.Core.Dtos;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHubApp.Controllers.api
{
    [Authorize]
    public class AttendancesController : ApiController
    {

        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
            
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDtos dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists");

            }
            var attendance = new Attendance
            {
                GigId= dto.GigId,
                AttendeeId=userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);
            //var attendance = _unitOfWork.Attendances.GetAttendance(id,userId);

            if(attendance==null)
                return NotFound();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok(id);


            //var userId = User.Identity.GetUserId();

            //var attendance = _unitOfWork.Attendances.GetAttendance(id,userId);

            //if(attendance == null)
            //    return NotFound();

            //_unitOfWork.Attendances.Remove(attendance);
            //_unitOfWork.Complete();

            //return Ok(id);
        }
     
    }
}
