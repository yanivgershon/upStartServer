using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using upStartServer.Data;
using upStartServer.Service;

namespace upStartServer.Controllers
{

    public class EntityController : ApiController
    {
      
        private UpStartDbContext db = new UpStartDbContext();

        // GET: api/Entity
        public IQueryable<Entity> GetEntities()
        {
            return db.Entities;
        }

        // GET: api/Entity/5
        [ResponseType(typeof(Entity))]
        public IHttpActionResult GetEntity(Guid id)
        {
            Entity entity = db.Entities.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // PUT: api/Entity/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntity(Guid id, Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            db.Entry(entity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        // POST: api/Entity
        [ResponseType(typeof(Entity))]
        public IHttpActionResult PostEntity(Entity entity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (entity.Id == Guid.Empty)
                db.Entities.Add(entity);
            else
            {
                Entity result = db.Entities.SingleOrDefault(b => b.Id == entity.Id);
                if (result != null)
                {
                    try
                    {
                        //db.Entities.Attach(result);
                        result.update(entity);
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {               
               throw;            
            }

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        // DELETE: api/Entity/5
        [ResponseType(typeof(Entity))]
        public IHttpActionResult DeleteEntity(Guid id)
        {
            Entity entity = db.Entities.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            db.Entities.Remove(entity);
            db.SaveChanges();

            return Ok(entity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(Guid id)
        {
            return db.Entities.Count(e => e.Id == id) > 0;
        }
    }
}