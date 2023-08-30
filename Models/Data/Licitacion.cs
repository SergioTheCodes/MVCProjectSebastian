using System;
using System.Collections.Generic;

namespace TestMVC.Models.Data
{
    public partial class Licitacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int IdCategoria { get; set; }
        public int IdResponsable { get; set; }
        public bool Planificado { get; set; }

        public virtual Catergorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ResponsableLicitacion IdResponsableNavigation { get; set; } = null!;
    }
}
