using MagicShop.Common.Entities.Interfaces;
using System.Collections.Generic;

namespace MagicShop.Common.Entities
{
    public class User: IBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
