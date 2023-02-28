using Server.Domain.Class;

namespace Server.Domain.IRepository
{
    public interface IContactRepository
    {
        void AddNewContact(Contact newContact);
        bool DeleteContact(int id);
        public List<Contact> ListContact();
        bool UpdateContact(Contact upContact);
    }
}