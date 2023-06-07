using EFDemo.Interfaces;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
namespace EFDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly InterfejsZadañ _serwis;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string kategoria { get; set; }
        public List<Zadanie> Results { get; set; }
        public IndexModel(ILogger<IndexModel> logger, InterfejsZadañ yearService)
        {
            _logger = logger;
            _serwis = yearService;
        }
        public void OnGet()
        {
            Results = _serwis.Wszystkie();
            var wartosc = HttpContext.Session.GetString("Data");
            kategoria = ""; 
            if (wartosc != null)
            {
                kategoria = wartosc;
            }
        }
        public IActionResult OnPost()          
        {
            if (kategoria == null)
            {
                kategoria = "";
            }
            HttpContext.Session.SetString("Data", kategoria);
            return RedirectToPage("./Index");
        }
    }
}
