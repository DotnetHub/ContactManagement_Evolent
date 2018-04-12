using ContactManagemet.Models.Entities;
using ContactManagemet.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManagemet.Controllers
{
    public class HomeController : Controller
    {
        private IContactRepository Repo;

        public HomeController()
            : this(new ContactRepository())
        {

        }
        public HomeController(IContactRepository repo)
        {
            Repo = repo;
        }
        public ActionResult Contacts()
        {
            return View(Repo.ListContact());
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            Repo.AddContact(contact);
            return RedirectToAction("Contacts");
        }

        public ActionResult UpdateContact(int id)
        {
            return View(Repo.GetContact(id));
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            Repo.UpdateContact(contact);
            return RedirectToAction("Contacts");
        }



        [Route("DeleteContact")]
        public ActionResult DeleteContactConfirm(int id)
        {
            return View("DeleteContact",Repo.GetContact(id));
        }

        [Route("DeleteContact")]
        [HttpPost]
        public ActionResult DeleteContact(int id)
        {
            Repo.DeleteContact(id);
            return RedirectToAction("Contacts");
        }
    }
}