using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCRHAK.Models
{
    public class File
    {
        [Key]
        public int FileId { get; set; }
        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [Display(Name = "File Type")]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}