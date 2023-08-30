using System;
using System.Collections.Generic;

namespace TestMVC.Models.Data
{
    public partial class Catergorium
    {
        public Catergorium()
        {
            Licitacions = new HashSet<Licitacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Licitacion> Licitacions { get; set; }
    }
}
