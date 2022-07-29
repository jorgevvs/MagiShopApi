using System;
using System.Collections.Generic;
using System.Text;

namespace MagicShop.Common.Models.Request
{
    public class PutOrderCompletedBodyRequest
    {
        public int InventoryItemId { get; set; }
        public int CardOwnerId { get; set; }
        public int OrderId { get; set; }
    }
}
