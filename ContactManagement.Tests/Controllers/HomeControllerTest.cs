using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManagemet;
using ContactManagemet.Controllers;
using ContactManagemet.Models.Entities;
using ContactManagemet.Models.Repository;
using ContactManagemet.Controllers.api;


namespace ContactManagemet.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IContactRepository Repo;
        private static int lastContactId;

        public HomeControllerTest()
        {
            Repo = new ContactRepository();
        }

        [TestMethod]
        public void ShouldAddContacts()
        {
            Contact contact = new Contact();
            contact.FirstName = "Pritam";
            contact.LastName = "Ajmire";
            contact.Email = "pritam.ajmire@gmail.com";
            contact.PhoneNumber = "8446100120";
            contact.Status = "Active";
            Contact dbContact = Repo.AddContact(contact);
            Assert.AreEqual(dbContact, contact);
            lastContactId = dbContact.Id;
        }

        [TestMethod]
        public void ShouldListContacts()
        {
            ContactsController contactApi = new ContactsController();
            List<Contact> contacts = contactApi.GetContacts().ToList();
            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count > 0);
        }
        [TestMethod]
        public void ShouldUpdateContacts()
        {
            Contact contact = Repo.GetContact(lastContactId);
            contact.FirstName = "John";
            contact.LastName = "England";
            contact.Email = "John.England@gmail.com";
            contact.PhoneNumber = "5446100120";
            contact.Status = "Inactive";

            Contact dbContact = Repo.UpdateContact(contact);
            Assert.AreEqual(dbContact.FirstName, contact.FirstName);
            Assert.AreEqual(dbContact.LastName, contact.LastName);
            Assert.AreEqual(dbContact.Email, contact.Email);
            Assert.AreEqual(dbContact.PhoneNumber, contact.PhoneNumber);
            Assert.AreEqual(dbContact.Status, contact.Status);
        }

        [TestMethod]
        public void ShouldDeleteContacts()
        {
            Assert.IsTrue(Repo.DeleteContact(lastContactId));
            Contact contact = Repo.GetContact(lastContactId);
            Assert.IsNull(contact);
        }


        public void ValidateFirstName()
        {
            Contact contact = new Contact();
            contact.FirstName = "";
            contact.LastName = "Ajmire";
            contact.Email = "pritam.ajmire@gmail.com";
            contact.PhoneNumber = "8446100120";
            contact.Status = "Active";
            Contact dbContact = Repo.AddContact(contact);
            Assert.AreEqual(dbContact, contact);
            lastContactId = dbContact.Id;
        }



    }
}
