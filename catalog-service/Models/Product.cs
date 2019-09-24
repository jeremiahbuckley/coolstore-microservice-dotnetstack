using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogService.Models
{
    public class Product
    {
        [BsonId]
        [BsonElement("itemId")]
        public string ItemId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("desc")]
        public string Desc { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }

        public Product() {

        }

        public Product(string itemId, string name, string desc, double price) {
            this.ItemId = itemId;
            this.Name = name;
            this.Desc = desc;
            this.Price = price;
        }
    }
}