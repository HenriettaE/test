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
    public class ScheduleTablesController : ApiController
    {
        private EmployeeScheduleEntities db = new EmployeeScheduleEntities();

        // GET: api/ScheduleTables
        public List<ScheduleModel> GetScheduleTable()
        {
            List<ScheduleModel> SM = new List<ScheduleModel>();
            foreach (var row in db.ScheduleTable)
            {
                ScheduleModel temp = new ScheduleModel
                {
                    ScheduleCode = row.ScheduleCode,
                    ValidForm = row.ValidForm,
                    ValidTo = row.ValidTo,
                    Uploader = row.Uploader
                    
                };
                SM.Add(temp);
            }
            return SM;
        }

        // GET: api/ScheduleTables/5
        [ResponseType(typeof(ScheduleTable))]
        public IHttpActionResult GetScheduleTable(int id)
        {
            ScheduleTable scheduleTable = db.ScheduleTable.Find(id);
            if (scheduleTable == null)
            {
                return NotFound();
            }
            ScheduleModel temp = new ScheduleModel
            {
                ScheduleCode = scheduleTable.ScheduleCode,
                ValidForm = scheduleTable.ValidForm,
                ValidTo = scheduleTable.ValidTo,
                Uploader = scheduleTable.Uploader
                
            };

            return Ok(temp);
        }

        // PUT: api/ScheduleTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScheduleTable(int id, ScheduleTable scheduleTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scheduleTable.ScheduleCode)
            {
                return BadRequest();
            }

            db.Entry(scheduleTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleTableExists(id))
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

        // POST: api/ScheduleTables
        [ResponseType(typeof(ScheduleModel))]
        public IHttpActionResult PostScheduleTable(ScheduleModel scheduleTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ScheduleTable temp = new ScheduleTable
            {
                ScheduleCode = scheduleTable.ScheduleCode,
                ValidForm = scheduleTable.ValidForm,
                ValidTo = scheduleTable.ValidTo,
                Uploader = scheduleTable.Uploader
                
            };

            db.ScheduleTable.Add(temp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scheduleTable.ScheduleCode }, scheduleTable);
        }

        // DELETE: api/ScheduleTables/5
        [ResponseType(typeof(ScheduleTable))]
        public IHttpActionResult DeleteScheduleTable(int id)
        {
            ScheduleTable scheduleTable = db.ScheduleTable.Find(id);
            if (scheduleTable == null)
            {
                return NotFound();
            }

            db.ScheduleTable.Remove(scheduleTable);
            db.SaveChanges();

            return Ok(scheduleTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleTableExists(int id)
        {
            return db.ScheduleTable.Count(e => e.ScheduleCode == id) > 0;
        }
    }
}