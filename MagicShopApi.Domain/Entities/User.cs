using MagicShop.Common.Entities.Interfaces;
using System.Collections.Generic;

namespace MagicShop.Common.Entities
{
    public class User: Base
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
