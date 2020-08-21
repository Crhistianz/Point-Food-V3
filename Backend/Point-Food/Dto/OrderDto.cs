using PointFood.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Dto
{
    public class OrderCreateDto
    {
        public string ClientId { get; set; }
        public List<OrderDetailCreateDto> Products { get; set; }
        public int RestaurantId { get; set; }
        public bool Delivery { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }

    public class OrderUpdateDto
    {
        public int StateId { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public ClientDto Client { get; set; }
        public List<OrderDetailDto> Products { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public RestaurantOrderDto Restaurant { get; set; }
        public bool Delivery { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
        public string StateName { get; set; }
    }

    public class OrderDetailDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }

    public class RestaurantOrderDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
