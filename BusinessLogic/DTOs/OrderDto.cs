﻿using DataAccess.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using PersonRegistrationASPNet.BusinessLogic.Attributes;

namespace BusinessLogic.DTOs
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDto
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? OrderId { get; set; }
        [Required]
        [CheckForWhiteSpaces]
        [NotLessThanNumber(1)]
        [BsonElement("customer_id"), BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }
        [BsonElement("ordered_on"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderedOn { get; set; }
        [BsonElement("order_details")]
        public List<OrderDetail>? OrderDetails { get; set; }

        public static implicit operator Order(OrderDto order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                OrderedOn = DateTime.UtcNow,
                OrderDetails = order.OrderDetails
            };
        }
    }
}
