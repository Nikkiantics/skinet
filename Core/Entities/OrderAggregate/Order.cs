using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        private List<OrderItem> items;
        private string buyerEmail;
        private Core.OrderAggregate.Address shippingAddress;
        private DeliveryMethod deliveryMethod;

        public Order()
        {
            
        }

        public Order(List<OrderItem> items, string buyerEmail, Core.OrderAggregate.Address shippingAddress, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            this.items = items;
            this.buyerEmail = buyerEmail;
            this.shippingAddress = shippingAddress;
            this.deliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEamil, DateTime orderDate, Address shipToAddress, 
        DeliveryMethod deliveryMethod, decimal subtotal)
        {
            BuyerEamil = buyerEamil;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public string BuyerEamil {get; set;}
        public DateTime OrderDate {get; set;} = DateTime.UtcNow;
        public Address ShipToAddress {get; set;}
        public DeliveryMethod DeliveryMethod {get; set;}
        public IReadOnlyList<OrderItem> OrderItems {get; set;}
        public decimal Subtotal {get; set;}
        public OrderStatus Status {get; set;} = OrderStatus.Pending;
        public string PaymentIntenstId {get; set;}
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }



    }
}