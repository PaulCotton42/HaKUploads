using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCRHAK.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}