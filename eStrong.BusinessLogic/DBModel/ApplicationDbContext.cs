using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Entities;

namespace eStrong.BusinessLogic.DBModel
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
            base("name = eStrong")
        {
        }
        public DbSet<UDbTable> UDbTable { get; set; }

    }


}


