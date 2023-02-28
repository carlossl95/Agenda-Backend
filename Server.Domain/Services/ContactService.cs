using Server.Domain.Class;
using Server.Domain.IRepository;

namespace Server.Domain.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        public bool? AddNewContact(Contact newContact)
        {
            ValidInput(newContact);

            var listContact = _contactRepository.ListContact();

            foreach (var contact in listContact)
            {
                if (newContact.Name == contact.Name)
                    throw new Exception("Already registered contact name");

                if (newContact.Email != "")
                {
                    if (newContact.Email == contact.Email)
                        throw new Exception("Email already registered");
                }

                if (newContact.PersonalPhone != "")
                {
                    if (newContact.PersonalPhone == contact.PersonalPhone)
                        throw new Exception("Number already registered");
                }
            }

            _contactRepository.AddNewContact(newContact);

            return true;
        }

        public bool DeleteContact(int id)
        {
            var check = _contactRepository.DeleteContact(id);

            if (check != true)
                throw new Exception("Error deleting contact");

            return check;
        }

        public List<Contact> SearchAllContact()
        {
            var listContact = _contactRepository.ListContact();

            if (listContact == null)
                throw new Exception("No contact registered");

            return listContact;
        }

        public List<Contact> SearchFilterContact(string filter)
        {
            var searchContact = _contactRepository.ListContact();

            var listContact = new List<Contact>();

            foreach (var c in searchContact)
            {
                if (c.Name.Contains(filter) || c.Company.Contains(filter) || c.Email.Contains(filter) || c.PersonalPhone.Contains(filter) || c.BusinessPhone.Contains(filter))
                {
                    listContact.Add(c);
                }
                
            }
            if (listContact == null)
                throw new Exception("contact not found");

            return listContact;
        }



        public bool UpdateContact(Contact upContact)
        {
            ValidInput(upContact);

            var listContact = _contactRepository.ListContact();

            foreach (var contact in listContact)
            {
                if (upContact.Name == contact.Name && upContact.Id != contact.Id)
                    throw new Exception("Already registered contact name");

                if (upContact.Email != "")
                {
                    if (upContact.Email == contact.Email && upContact.Id != contact.Id)
                        throw new Exception("Email already registered");
                }

                if (upContact.PersonalPhone != "")
                {
                    if (upContact.PersonalPhone == contact.PersonalPhone && upContact.Id != contact.Id)
                        throw new Exception("Number already registered");
                }

            }

            var check = _contactRepository.UpdateContact(upContact);

            if (check != true)
                throw new Exception("Error updating contact");

            return check;
        }


        private void ValidInput(Contact contact)
        {
            if (contact.Name == null)
                throw new Exception("Name is required!!!");

            if (contact.Name.Length == null)
                throw new Exception("NAME or maximum size 100 characters!!!");

            if (contact.Company == null)
                contact.Company = "";

            if (contact.Company.Length > 50)
                throw new Exception("Company or maximum size 50 characters!!!");

            if (contact.Email == null)
                contact.Email = "";

            if (contact.Email.Length > 50)
                throw new Exception("Email or maximum size 120 characters!!!");

            if (contact.PersonalPhone == null)
                contact.PersonalPhone = "";

            if (contact.PersonalPhone.Length > 11)
                throw new Exception("Personal Phone or maximum size 11 characters!!!");

            if (contact.BusinessPhone == null)
                contact.BusinessPhone = "";

            if (contact.BusinessPhone.Length > 11)
                throw new Exception("Business Phone or maximum size 11 characters!!!");
        }
    }
}