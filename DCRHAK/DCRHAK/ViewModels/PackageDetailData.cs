using DCRHAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCRHAK.ViewModels
{
    public class PackageDetailData
    {
        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<File> Files { get; set; }
        public IEnumerable<Discussion> Discussions { get; set; }
    }
}