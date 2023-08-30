namespace TestMVC.Models
{
    public class DTOPosts
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? Autor { get; set; }
        public int? Archivos { get; set; }
    }
}
