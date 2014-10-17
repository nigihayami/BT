using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public class TProjects
    {
        public int Id { get; set; }
        [Required, Display(Name = "Название проекта")]
        public string TProjectsName { get; set; }
    }
}