using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ScheduleProgram.Models;

namespace ScheduleProgram.Controllers
{
    public class PersonalInfoesController : ApiController
    {
        private EmployeeScheduleEntities db = new EmployeeScheduleEntities();

        // GET: api/PersonalInfoes
        public List<PersonalInfoModel> GetPersonalInfo()
        {
            List<PersonalInfoModel> PM = new List<PersonalInfoModel>();
            foreach(var row in db.PersonalInfo)
            {
                PersonalInfoModel temp = new PersonalInfoModel
                {
                    Id = row.Id,
                    PersonellNumber = row.PersonellNumber,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    ScheduleCode = row.ScheduleCode
                };
                PM.Add(temp);
            }
            return PM;
        }

        // GET: api/PersonalInfoes/5
        [ResponseType(typeof(PersonalInfoModel))]
        public IHttpActionResult GetPersonalInfo(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            PersonalInfoModel temp = new PersonalInfoModel
            {
                Id = personalInfo.Id,
                PersonellNumber = personalInfo.PersonellNumber,
                FirstName = personalInfo.FirstName,
                LastName =personalInfo.LastName,
                ScheduleCode = personalInfo.ScheduleCode
            };

            return Ok(temp);
        }

        // PUT: api/PersonalInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalInfo(int id, PersonalInfoModel personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonalInfoes
        [ResponseType(typeof(PersonalInfoModel))]
        public IHttpActionResult PostPersonalInfo(PersonalInfoModel personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PersonalInfo temp = new PersonalInfo
            {
                Id = personalInfo.Id,
                PersonellNumber = personalInfo.PersonellNumber,
                FirstName = personalInfo.FirstName,
                LastName = personalInfo.LastName,
                ScheduleCode = personalInfo.ScheduleCode
            };

            db.PersonalInfo.Add(temp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalInfo.Id }, personalInfo);
        }

        // DELETE: api/PersonalInfoes/5
        [ResponseType(typeof(PersonalInfoModel))]
        public IHttpActionResult DeletePersonalInfo(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfo.Find(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            db.PersonalInfo.Remove(personalInfo);
            db.SaveChanges();

            return Ok(personalInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalInfoExists(int id)
        {
            return db.PersonalInfo.Count(e => e.Id == id) > 0;
        }
    }
}