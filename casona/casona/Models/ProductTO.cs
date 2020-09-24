using System;

namespace casona.Models
{
    public class ProductTO
    {
        public int IdProduct { get; set; }
        public int IdProductType { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string UrlImage { get; set; }

    }
    public class ProductTypeTO
    {
        public int IdProductType { get; set; }
        public string ProductType { get; set; }
        public int IdStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ProductTypeStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}