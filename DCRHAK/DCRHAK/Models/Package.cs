using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCRHAK.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set;}
        [Required]
        [Display(Name = "Episode")]
        public string PackageName { get; set; }
        [Required]
        [Display(Name = "Episode Description")]
        public string PackageDescription { get; set; }
        [Display(Name = "Contents")]
        public virtual ICollection<Item> Items { get; set; }
        [Display(Name = "Discussion")]
        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}