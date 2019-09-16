using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using InventoryService.Models;

namespace InventoryService {
    public class InventorySvc : IInventorySvc {

        private readonly InventoryContext context;

        public InventorySvc(InventoryContext context) {
            this.context = context;
        }
        
        public Inventory GetInventory(string itemId) {
            Inventory inventory = context.Inventory
                .FirstOrDefault(c => c.ItemId == itemId);

            return inventory;

        }
    }

    public interface IInventorySvc {
        Inventory GetInventory(string itemId);
    }
    
}