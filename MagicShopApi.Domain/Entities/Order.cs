﻿using MagicShop.Common.Entities.Interfaces;
using System;

namespace MagicShop.Common.Entities
{
    public class Order : IBase
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
    }
}
