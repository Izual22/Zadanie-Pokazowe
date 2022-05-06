using EFDemo.Data;
using EFDemo.Interfaces;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IYearService _yearService;
        [BindProperty]
        public Result Test { get; set; }
        [BindProperty]
        public String FirstName { get; set; }
        [BindProperty]
        public String LastName { get; set; }

        public IndexModel(ILogger<IndexModel> logger,IYearService yearService)
        {
            _logger = logger;
            _yearService = yearService;
        }
        public void OnGet()
        {
            FirstName = "";
            LastName = "";
        }
        public IActionResult OnPost()
        {
            Test.FullName = FirstName + " " + LastName;
            if (Test.Year % 400 == 0)
            {
                Test.IsTrue = "Przestępny";
            }
            else if (Test.Year % 100 == 0)
            {
                Test.IsTrue = "Nieprzestępny";
            }
            else if(Test.Year % 4 == 0)
            {
                Test.IsTrue = "Przestępny";
            }
            else
            {
                Test.IsTrue = "Nieprzestępny";
            }
            _yearService.AddNewEntry(Test);
            return Page();
        }
    }
}