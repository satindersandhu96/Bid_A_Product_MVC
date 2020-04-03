using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product_MVC.Models;

namespace Bid_A_Product_MVC.Data
{
    public class Bid_A_Product_DbContext : DbContext
    {
        public Bid_A_Product_DbContext (DbContextOptions<Bid_A_Product_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Bid_A_Product_MVC.Models.Bid> Bid { get; set; }

        public DbSet<Bid_A_Product_MVC.Models.Buyer> Buyer { get; set; }

        public DbSet<Bid_A_Product_MVC.Models.Product> Product { get; set; }

        public DbSet<Bid_A_Product_MVC.Models.Seller> Seller { get; set; }
    }
}
