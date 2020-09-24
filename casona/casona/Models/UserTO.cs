using System;

namespace casona.Models
{
    public class UserTO
    {
        public int IdUser { get; set; }
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public long IdSocial { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class UserStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}