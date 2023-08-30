using System;
using System.Collections.Generic;

namespace TestMVC.Models.Data
{
    public partial class ResponsableLicitacion
    {
        public ResponsableLicitacion()
        {
            Licitacions = new HashSet<Licitacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Licitacion> Licitacions { get; set; }
    }
}
