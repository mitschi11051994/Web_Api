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
using System.Web.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class tblClientsController : ApiController
    {
        private CMDEntities db = new CMDEntities();

      
        // GET: api/tblClients
        public IQueryable<tblClient> GettblClient()
        {
            return db.tblClient;
        }

        // GET: api/tblClients/5
        [ResponseType(typeof(tblClient))]
        public IHttpActionResult GettblClient(int id)
        {
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return NotFound();
            }

            return Ok(tblClient);
        }

        // PUT: api/tblClients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblClient(int id, tblClient tblClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblClient.id_client)
            {
                return BadRequest();
            }

            db.Entry(tblClient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblClientExists(id))
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

        // POST: api/tblClients
        [ResponseType(typeof(tblClient))]
        public IHttpActionResult PosttblClient(tblClient tblClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblClient.Add(tblClient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblClient.id_client }, tblClient);
        }

        // DELETE: api/tblClients/5
        [ResponseType(typeof(tblClient))]
        public IHttpActionResult DeletetblClient(int id)
        {
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return NotFound();
            }

            db.tblClient.Remove(tblClient);
            db.SaveChanges();

            return Ok(tblClient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblClientExists(int id)
        {
            return db.tblClient.Count(e => e.id_client == id) > 0;
        }
    }
}