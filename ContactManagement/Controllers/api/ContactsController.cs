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
using ContactManagemet.Models.Entities;
using ContactManagemet.Models.Repository;

namespace ContactManagemet.Controllers.api
{
    public class ContactsController : ApiController
    {
        private IContactRepository Repo;

        public ContactsController() : this(new ContactRepository())
        {

        }

        public ContactsController(IContactRepository repo)
        {
            Repo = repo;
        }

        // GET: api/Contacts
        public IEnumerable<Contact> GetContacts()
        {
            return Repo.ListContact();
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = Repo.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != contact.Id)
            {
                return BadRequest();
            }

            try
            {
                Repo.UpdateContact(contact);
            }
            catch
            {
                if (!IsContactExists(id)) return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contact = Repo.AddContact(contact);

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = Repo.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            Repo.DeleteContact(id);

            return Ok(contact);
        }

        private bool IsContactExists(int id)
        {
            Contact contact = Repo.GetContact(id);
            if (contact == null) return false; else return true;
        }
    }
}