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
using apiBoutiqueSecurity.Models;

namespace apiBoutiqueSecurity.Controllers
{
    public class BoutiquesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Boutiques
        [Authorize]
        public IQueryable<Boutique> GetBoutiques()
        {
            return db.Boutiques;
        }

        // GET: api/Boutiques/5
        [Authorize]
        [ResponseType(typeof(Boutique))]
        public IHttpActionResult GetBoutique(int id)
        {
            Boutique boutique = db.Boutiques.Find(id);
            if (boutique == null)
            {
                return NotFound();
            }

            return Ok(boutique);
        }

        // PUT: api/Boutiques/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoutique(int id, Boutique boutique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boutique.ClothesID)
            {
                return BadRequest();
            }

            db.Entry(boutique).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoutiqueExists(id))
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

        // POST: api/Boutiques
        [Authorize]
        [ResponseType(typeof(Boutique))]
        public IHttpActionResult PostBoutique(Boutique boutique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boutiques.Add(boutique);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boutique.ClothesID }, boutique);
        }

        // DELETE: api/Boutiques/5
        [Authorize]
        [ResponseType(typeof(Boutique))]
        public IHttpActionResult DeleteBoutique(int id)
        {
            Boutique boutique = db.Boutiques.Find(id);
            if (boutique == null)
            {
                return NotFound();
            }

            db.Boutiques.Remove(boutique);
            db.SaveChanges();

            return Ok(boutique);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoutiqueExists(int id)
        {
            return db.Boutiques.Count(e => e.ClothesID == id) > 0;
        }
    }
}