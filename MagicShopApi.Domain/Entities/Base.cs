using MagicShop.Common.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicShop.Common.Entities
{
    public abstract class Base : IBase
    {
        public int Id { get; set; }
    }
}
