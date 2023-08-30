using System;
using System.Collections.Generic;

namespace TestMVC.Models.Data
{
    public partial class File
    {
        public File()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? FPath { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
