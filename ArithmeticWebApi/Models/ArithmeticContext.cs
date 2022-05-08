using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticWebApi.Models
{
    public class ArithmeticContext: DbContext
    {
        public ArithmeticContext(DbContextOptions<ArithmeticContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Arithmetic> Arithmetics { get; set; }
    }
}
