using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjMVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username required")]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }
        [Display(Name = "Date of Creation")]
        [DataType(DataType.Date)]
        public DateTime? DOC { get; set; }
        [Required(ErrorMessage = "Author required")]
        public string Author { get; set; }
        [StringLength(200, MinimumLength = 2)]
        public string Link { get; set; }
        [Range(1.00, 20.00)]
        public float Duration { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string Genre { get; set; }

        public int PlayListId { get; set; }
    //    public virtual PlayList PlayList { get; set; }
    }
}