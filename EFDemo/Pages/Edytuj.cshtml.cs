using EFDemo.Data;
using EFDemo.Interfaces;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace EFDemo.Pages
{
    [Authorize]
    public class EdytujModel : PageModel
    {
        private readonly InterfejsZadañ _serwis;
        [BindProperty]
        public Zadanie Nowa { get; set; }
        public Waluta Wal { get; set; }
        public int ID { get; set; }
        public string Id { get; set; }

        public EdytujModel(ILogger<IndexModel> logger, InterfejsZadañ yearService)
        {
            _serwis = yearService;

        }
        public void OnGet()
        {
            Id = Request.Query["id"];
            ID = Convert.ToInt32(Id);
            Nowa =_serwis.Zwroc(ID);
        }
        public void set()
        {
            HttpClient client = new HttpClient();
            string http = "https://api.nbp.pl/api/exchangerates/rates/a/";
            http += Nowa.opis;
            http += "/?format=json";
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
            set();
            Nowa.wartoœæ = Nowa.iloœæ * Wal.Rates[0].war;
            Nowa.wartoœæ = Math.Round(Nowa.wartoœæ, 2);
            Nowa.opis = Wal.Info;
            Id = Request.Query["id"];
            ID = Convert.ToInt32(Id);
            _serwis.Usuñ(ID);
            _serwis.Dodaj(Nowa);
            return Redirect("Index");
        }
    }
}