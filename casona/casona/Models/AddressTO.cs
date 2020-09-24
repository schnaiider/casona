using System;

namespace casona.Models
{
    public class AddressTO
    {
        public int IdAddress { get; set; }
        public int IdUser { get; set; }
        public int IdStatus { get; set; }
        public int IdCommune { get; set; }
        public string Commune { get; set; }
        public long CEP { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class AddressStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class CommuneTO
    {
        public int IdCommune { get; set; }
        public int IdStatus { get; set; }
        public string Commune { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class CommuneStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}