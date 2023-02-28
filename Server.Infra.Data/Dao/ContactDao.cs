using Server.Domain.Class;
using System.Data.SqlClient;

namespace Server.Infra.Data.Dao
{
    public class ContactDao
    {
        private readonly string _connectionString = @"server=.\SQLEXPRESS;initial catalog=QUALI_DB;integrated security=true;";

        public void AddContact(Contact newContact)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"INSERT CONTACT
                                VALUES(@NAME_,
                                    @COMPANY,
                                    @EMAIL,
                                    @PERSONAL_PHONE,
                                    @BUSINESS_PHONE)";

                    command.Parameters.AddWithValue("@NAME_", newContact.Name);
                    command.Parameters.AddWithValue("@COMPANY", newContact.Company);
                    command.Parameters.AddWithValue("@EMAIL", newContact.Email);
                    command.Parameters.AddWithValue("@PERSONAL_PHONE", newContact.PersonalPhone);
                    command.Parameters.AddWithValue("@BUSINESS_PHONE", newContact.BusinessPhone);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateContact(Contact UpContact)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"UPDATE CONTACT
                                SET NAME_ = @NAME_,
                                    COMPANY = @COMPANY,
                                    EMAIL = @EMAIL,
                                    PERSONAL_PHONE = @PERSONAL_PHONE,
                                    BUSINESS_PHONE = @BUSINESS_PHONE
                                    WHERE ID = @ID";

                    command.Parameters.AddWithValue("@NAME_", UpContact.Name);
                    command.Parameters.AddWithValue("@COMPANY", UpContact.Company);
                    command.Parameters.AddWithValue("@EMAIL", UpContact.Email);
                    command.Parameters.AddWithValue("@PERSONAL_PHONE", UpContact.PersonalPhone);
                    command.Parameters.AddWithValue("@BUSINESS_PHONE", UpContact.BusinessPhone);
                    command.Parameters.AddWithValue("@ID", UpContact.Id);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public List<Contact> ListContact()
        {
            var listContact = new List<Contact>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"SELECT * FROM CONTACT";

                    command.CommandText = sql;

                    var leader = command.ExecuteReader();

                    while (leader.Read())
                    {
                        var contact = new Contact
                        {
                            Id = int.Parse(leader["ID"].ToString()),
                            Name = (leader["NAME_"].ToString()),
                            Company = (leader["COMPANY"].ToString()),
                            Email = (leader["EMAIL"].ToString()),
                            PersonalPhone = (leader["PERSONAL_PHONE"].ToString()),
                            BusinessPhone = (leader["BUSINESS_PHONE"].ToString()),
                        };

                        listContact.Add(contact);
                    }
                }
            }
            return listContact;
        }

        public bool DeleteContact(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM CONTACT WHERE ID =@ID";

                    command.Parameters.AddWithValue("ID", id);

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}