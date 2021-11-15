using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClima.Data;
using WebClima.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebClima.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebClimaContext _context;
        private readonly Random _gerador;
        public HomeController(WebClimaContext context)
        {
            _gerador = new Random();
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Maiores =  await _context.Previsoes.Include(t => t.Cidade).OrderByDescending(p => p.TemperaturaMaxima).Take(3).ToListAsync();
            ViewBag.Menores = await _context.Previsoes.Include(t => t.Cidade).OrderBy(p => p.TemperaturaMinima).Take(3).ToListAsync();
            ViewBag.Cidades = await _context.Cidades.Select(i => i.Nome).ToListAsync();
            return View();
        }
        [HttpGet]
        public async Task<string> BuscarPrevisoes(string cidade)
        {
            var data = await _context.Previsoes.Where(p => p.Cidade.Nome == cidade).OrderByDescending(p => p.DataPrevisao).Take(7).ToListAsync();
            return JsonConvert.SerializeObject(data.OrderBy(i => i.DataPrevisao));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}