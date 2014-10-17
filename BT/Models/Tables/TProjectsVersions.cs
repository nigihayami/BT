using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT.Models
{
    public class TProjectsVersions
    {
        public int Id { get; set; }
        [Required, Display(Name = "Код")]
        public string TProjectsVersionsCode { get; set; }
        [Display(Name = "Комментарий")]
        public string TProjectsVersionsComment { get; set; }
        [Required, Display(Name = "Дата создания"), DataType(dataType:DataType.Date, ErrorMessage="Формат даты не верен")]
        public DateTime TProjectsVersionsStart { get; set; }
        [Required, Display(Name = "Дата окончания"), DataType(dataType:DataType.Date, ErrorMessage="Формат даты не верен"), DateGreaterThanAttribute("TProjectsVersionsStart",ErrorMessage="Дата закрытия не может быть меньше даты открытия")]
        public DateTime TProjectsVersionsEnd { get; set; }
        [Display(Name = "Дата утверждения")]
        public DateTime? TProjectsVersionsApprove { get; set; }
        [Display(Name = "Дата закрытия")]
        public DateTime? TProjectsVersionsClose { get; set; }

        public virtual TProjects TProjects { get; set; }
        public virtual TStatus TStatus { get; set; }
    }
}