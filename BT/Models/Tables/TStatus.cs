using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public class TStatus
    {
        public int Id { get; set; }
        [Required, Display(Name = "Статус")]
        public string TStatusName { get; set; }
    }
}