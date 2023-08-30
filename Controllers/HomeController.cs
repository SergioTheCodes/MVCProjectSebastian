using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVC.Models;
using TestMVC.Models.Data;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, BlogDatabaseContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertPost(DTOPosts post)
        {
            var obj = new Post
            {
                Archivos = post.Archivos,
                Autor = post.Autor,
                Descripcion = post.Descripcion,
                Fecha = post.Fecha,
                Titulo = post.Titulo
            };
            try
            {
                _context.Posts.Add(obj);
                int row = _context.SaveChanges();
                if(row > 0) {
                    throw new Exception("No inserto ningun Registro");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}