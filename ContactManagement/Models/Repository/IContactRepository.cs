using ContactManagemet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagemet.Models.Repository
{
    public interface IContactRepository
    {
        Contact AddContact(Contact _contact);
        Contact UpdateContact(Contact _contact);
        bool DeleteContact(int id);

        Contact GetContact(int id);
        List<Contact> ListContact();
        
    }
}