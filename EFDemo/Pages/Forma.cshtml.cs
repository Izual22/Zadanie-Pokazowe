using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFDemo.Models;
using EFDemo.Middleware;
using EFDemo.Services;
using EFDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EFDemo.Pages
{
    public class FormaModel : PageModel
    {
        public IActionResult onPost()
        {
            return Redirect("Dodaj");
        }
    }
}
