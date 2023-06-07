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
    public class UsuńModel : PageModel
    {
        private readonly InterfejsZadań _serwis;
        public UsuńModel(ILogger<IndexModel> logger, InterfejsZadań yearService)
        {
            _serwis = yearService;

        }
        public void OnGet()
        {
            string id = Request.Query["id"];
            _serwis.Usuń(Convert.ToInt32(id));
            Response.Redirect("Index");
        }
    }
}
