using Homepage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homepage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book>Books { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<StoreOwner> StoreOwners { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
