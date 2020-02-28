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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        private PraxisDBModel db = new PraxisDBModel();

        // GET: api/School
        public IQueryable<School> GetSchools()
        {
            return db.Schools;
        }

        // GET: api/School/5
        [ResponseType(typeof(School))]
        public IHttpActionResult GetSchool(string id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT: api/School/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchool(string id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.SchoolID)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/School
        [ResponseType(typeof(School))]
        public IHttpActionResult PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schools.Add(school);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SchoolExists(school.SchoolID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = school.SchoolID }, school);
        }

        // DELETE: api/School/5
        [ResponseType(typeof(School))]
        public IHttpActionResult DeleteSchool(string id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.Schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(string id)
        {
            return db.Schools.Count(e => e.SchoolID == id) > 0;
        }
    }
}