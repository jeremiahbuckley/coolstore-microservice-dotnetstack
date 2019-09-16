using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryService.Models {
    [Table("product_inventory")]
    public class Inventory {
        [Key]
        [Column("itemid")]
        public string ItemId { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("link")]
        public string Link { get; set; }

        public Inventory() {

        }

        public Inventory(string itemId, int quantity, string location, string link) {
            this.ItemId = itemId;
            this.Quantity = quantity;
            this.Location = location;
            this.Link = link;
        }
    }
}
