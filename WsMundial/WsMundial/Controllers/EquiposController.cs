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
using CADMundial;

namespace WsMundial.Controllers
{
    public class EquiposController : ApiController
    {
        private ModeloMundial db = new ModeloMundial();

        // GET: api/Equipos
        public IQueryable<Equipo> GetEquipo()
        {
            return db.Equipo;
        }

        // GET: api/Equipos/5
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult GetEquipo(short id)
        {
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        // PUT: api/Equipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipo(short id, Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipo.IdEqupo)
            {
                return BadRequest();
            }

            db.Entry(equipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipos
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult PostEquipo(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipo.Add(equipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipo.IdEqupo }, equipo);
        }

        // DELETE: api/Equipos/5
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult DeleteEquipo(short id)
        {
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            db.Equipo.Remove(equipo);
            db.SaveChanges();

            return Ok(equipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipoExists(short id)
        {
            return db.Equipo.Count(e => e.IdEqupo == id) > 0;
        }
    }
}