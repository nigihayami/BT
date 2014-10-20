using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public class dbContext : IdentityDbContext<ApplicationUser>
    {
        public dbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static dbContext Create()
        {
            return new dbContext();
        }
        public DbSet<TProjects> TProjects { get; set; }
        public DbSet<TProjectsVersions> TProjectsVersions { get; set; }
        public DbSet<TStatus> TStatus { get; set; }

        public DbSet<BT.Models.TTasks> TTasks { get; set; }
    }
}