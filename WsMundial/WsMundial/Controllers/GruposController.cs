using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CADMundial;

namespace WebApiMundial.Controllers
{
    public class GruposController : ApiController
    {
        private ModeloMundial db = new ModeloMundial();

        // GET: http://localhost/api/Grupos
        public List<Grupo> GetGrupos()
        {
            try
            {
                return db.Grupo.ToList();
            }
            catch (System.Exception e)
            {
                return null;
                throw;
            }
        }

        // GET: http://localhost/api/Grupos/A
        [ResponseType(typeof(Grupo))]
        public IHttpActionResult GetGrupos(string id)
        {
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo);
        }

        // PUT: api/Grupos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupos(string id, Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(grupo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposExists(id))
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

        // POST: api/Grupos
        [ResponseType(typeof(Grupo))]
        public IHttpActionResult PostGrupos(Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupo.Add(grupo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GruposExists(grupo.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grupo.Codigo }, grupo);
        }

        // DELETE: api/Grupos/5
        [ResponseType(typeof(Grupo))]
        public IHttpActionResult DeleteGrupos(string id)
        {
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return NotFound();
            }

            db.Grupo.Remove(grupo);
            db.SaveChanges();

            return Ok(grupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GruposExists(string id)
        {
            return db.Grupo.Count(e => e.Codigo == id) > 0;
        }
    }
}