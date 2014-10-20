using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Models
{
    public class TTasks
    {
        public int Id { get; set; }
        [Required, Display(Name="Заголовок")]
        public string TTasksTitle { get; set; }
        [Required, AllowHtml, Display(Name = "Описание")]
        public string TTaskDesc { get; set; }
        [Required, Display(Name = "Приступить с "), DataType(dataType: DataType.Date)]
        public DateTime TTaskStart { get; set; }
        [Display(Name = "Закрыть к "), DataType(dataType: DataType.Date)]
        public DateTime TTaskEnd { get; set; }

        [Required, Display(Name = "Исполнитель")]
        public string TTasksTUsersId { get; set; }

        public virtual TProjectsVersions TProjectsVersions { get; set; }
        public virtual TStatus TStatus { get; set; }

        [ForeignKey("TTasksTUsersId")]
        public virtual ApplicationUser TUser { get; set; }
    }
}