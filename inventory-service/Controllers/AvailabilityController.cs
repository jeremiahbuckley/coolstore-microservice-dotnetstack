using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using InventoryService;
using InventoryService.Models;

namespace InventoryService.Controllers {

    [Route("/api/availability")]
    public class AvailabilityController : Controller {
        
        // private static final Logger LOGGER = LoggerFactory.getLogger(AvailabilityEndpoint.class);
        private readonly IInventorySvc iinventorySvc;

        public AvailabilityController(IInventorySvc iinventorySvc) {
            this.iinventorySvc = iinventorySvc;
        }

        [HttpGet("{itemId}")]
        // @Produces(MediaType.APPLICATION_JSON)
        public Inventory GetAvailability(string itemId) {
            // LOGGER.debug("Calling the inventory service");
            return iinventorySvc.GetInventory(itemId);
        }

    }

}