using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PizzaStoreManagement.Repository.Context
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(
            DbContextOptions<PizzaDbContext> dbContextOptions
        ) :
            base(dbContextOptions)
        {
        }
    }
}
