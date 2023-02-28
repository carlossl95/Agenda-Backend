namespace Server.Domain.Class
{
    public class Contact
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Company { get; set; }
        public string? Email { get; set; }
        public string? PersonalPhone { get; set; }
        public string? BusinessPhone { get; set; }

        public Contact() { }
    }
}