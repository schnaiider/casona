using System;

namespace casona.Models
{
    public class OrderTO
    {
        public long IdOrder { get; set; }
        public int IdUser { get; set; }
        public int IdDelivery { get; set; }
        public int IdProductType { get; set; }

    }

    public class OrderDetailTO
    {
        public int IdOrder { get; set; }
        public int IdStatus { get; set; }
        public string Delivery { get; set; }
        public int IdOrderDetail { get; set; }
        public int IdEdge { get; set; }
        public string Edge { get; set; }
        public int IdComposition { get; set; }
        public string Composition { get; set; }
        public int IdCheese { get; set; }
        public string Cheese { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Commentary { get; set; }
    }

    public class OrderItemTO
    {
        public int IdOrderItem { get; set; }
        public int IdOrderDetail { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
    }

    public class OrderHistoryTO
    {
        public int IdHistory { get; set; }
        public int IdOrder { get; set; }
        public int IdStatus { get; set; }


    }

    public class OrderDetailStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class OrderHistoryStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class OrderStatusTO
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class OrderListTO
    {
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public int IdDelivery { get; set; }
        public int IdStatus { get; set; }
        public string Delivery { get; set; }
        public int IdOrderDetail { get; set; }
        public int IdEdge { get; set; }
        public string Edge { get; set; }
        public int IdComposition { get; set; }
        public string Composition { get; set; }
        public int IdCheese { get; set; }
        public string Cheese { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Commentary { get; set; }
    }
}