using MagicShop.Common.Entities;
using MagicShop.Common.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicShop.Common.Utility
{
    public static class AddBaseBuilder
    {
        public static void AddBase<T>(this ModelBuilder modelBuilder) where T : Base
        {
            var builder = modelBuilder.Entity<T>();
            builder.HasKey(x => x.Id);
        }
    }
}
