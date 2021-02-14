using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creating_MVC_Form.Models;

namespace Creating_MVC_Form.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _service.AddInventoryItems(items);

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }
    }
}
