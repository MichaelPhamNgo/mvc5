using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Entity_Framework.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_Entity_Framework.Models.EmpRegistration> EmpRegistration { get; set; }
    }
}
