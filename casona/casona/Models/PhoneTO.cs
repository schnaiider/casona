using System;

namespace casona.Models
{
    public class PhoneTO
    {
        public int IdPhone { get; set; }
        public int IdUser { get; set; }
        public int IdStatus { get; set; }
        public long Phone { get; set; }
        public int Area { get; set; }


    }
    public class PhoneStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}