using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogin.Database.Entity;

namespace UserLogin.Database
{
    public class DatabaseContext:DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<UserModel> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    UserName = "gopal",
                    Password = "gopal"
                }

                );
        }

    }
}
