using ContactManagemet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagemet.Models.Repository
{
    public class ContactRepository : IContactRepository
    {

        private ContactsDBEntities DBContext = new ContactsDBEntities();

        public Contact GetContact(int id)
        {
            return DBContext.Contacts.SingleOrDefault(c => c.Id.Equals(id));
        }

        public List<Contact> ListContact()
        {
            return DBContext.Contacts.ToList();
        }


        public Contact AddContact(Contact _contact)
        {
            _contact= DBContext.Contacts.Add(_contact);
            DBContext.SaveChanges();
            return _contact;

        }

        public Contact UpdateContact(Contact _contact)
        {            
            DBContext.Entry(_contact).State = System.Data.EntityState.Modified;
            DBContext.SaveChanges();
            return _contact;
        }

        public bool DeleteContact(int id)
        {
            Contact _contact = GetContact(id);
            if (_contact == null) throw new Exception("Item not found.");
            DBContext.Contacts.Remove(_contact);
            DBContext.SaveChanges();
            return true;
        }

       
    }
}