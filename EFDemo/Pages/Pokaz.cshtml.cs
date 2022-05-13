using EFDemo.Interfaces;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
namespace EFDemo.Pages
{
    [Authorize]
    public class PokazModel : PageModel
    {
        private readonly IYearService _yearService;
        public List<Result> Results { get; set; }
        public PokazModel(IYearService yearService)
        {
            _yearService = yearService;
        }
        public void OnGet()
        {
            Results = _yearService.GetAllEntries();
        }
    }
}
