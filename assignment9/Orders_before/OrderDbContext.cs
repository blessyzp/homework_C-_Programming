using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrderApp
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(): base("BlogDataBase")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BloggingContext>());
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderService> OrderService { get; set; }

    }
}
