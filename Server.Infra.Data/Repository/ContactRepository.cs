using Server.Domain.Class;
using Server.Domain.IRepository;
using Server.Infra.Data.Dao;

namespace Server.Infra.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDao _contactDao;
        public ContactRepository()
        {
            _contactDao = new ContactDao();
        }

        public void AddNewContact(Contact newContact)
        {
            _contactDao.AddContact(newContact);
        }

        public bool DeleteContact(int id)
        {
            return _contactDao.DeleteContact(id);
        }

        public List<Contact> ListContact()
        {
            return _contactDao.ListContact();
        }

        public bool UpdateContact(Contact upContact)
        {
            return _contactDao.UpdateContact(upContact);
        }
    }
}