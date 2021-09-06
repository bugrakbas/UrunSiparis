using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrunSiparis.Models;

namespace UrunSiparis.Data
{
    public class UrunSiparisContext : DbContext
    {
        public UrunSiparisContext (DbContextOptions<UrunSiparisContext> options)
            : base(options)
        {
        }

        public DbSet<UrunSiparis.Models.UrunSiparisModel> UrunSiparisModel { get; set; }
    }
}
