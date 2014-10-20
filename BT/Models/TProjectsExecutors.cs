using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public class TProjectsExecutors
    {
        public int Id { get; set; }
        public virtual ApplicationUser TUsers { get; set; }
        public virtual TProjectsVersions TProjectsVersions { get; set; }
    }
}