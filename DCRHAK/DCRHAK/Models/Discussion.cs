using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCRHAK.Models
{
    public class Discussion
    {
        [Key]
        public int DicussionId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Post")]
        [DataType(DataType.MultilineText)]
        public string DiscussionPost { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

    }
}