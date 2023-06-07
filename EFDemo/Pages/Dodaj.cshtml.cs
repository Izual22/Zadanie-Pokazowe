using EFDemo.Data;
using EFDemo.Interfaces;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;
using Kendo.Mvc.UI;
namespace EFDemo.Pages
{
    [Authorize]
    public class DodajModel : PageModel
    {
        private readonly InterfejsZadań _serwis;
        [BindProperty]
        public Zadanie Nowa { get; set; }
        public Waluta Wal { get; set; }

        public DodajModel(ILogger<IndexModel> logger,InterfejsZadań yearService)
        {
            _serwis = yearService;
            Nowa = new Zadanie();
            Nowa.opis = "";
            Nowa.wartość = 0;
            Nowa.ilość = 0;
        }
        public void OnGet()
        {
            if (Nowa == null)
            {
               Nowa = new Zadanie();
            }
        }
        public void set()
        {
            HttpClient client = new HttpClient();
            string http = "https://api.nbp.pl/api/exchangerates/rates/a/";
            http +=Nowa.opis;
            http +="/?format=json";
            var responce = client.GetStringAsync(http).Result;
            if (responce == null)
            {
                Wal.Rates[0].war = 2.2;
            }
            else
            {
                Wal = JsonSerializer.Deserialize<Waluta>(responce.ToString());
            }
        }

        public IActionResult OnPost()
        {
            var spr = Request.Form;
            set();
            Nowa.wartość = Nowa.ilość*Wal.Rates[0].war;
            Nowa.wartość = Math.Round(Nowa.wartość, 2);
            Nowa.opis = Wal.Info;
            _serwis.Dodaj(Nowa);
            return Redirect("Index");
        }
    }
}