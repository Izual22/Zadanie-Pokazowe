using EFDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Data
{
    public class ResultsContext:DbContext
    {
        public ResultsContext(DbContextOptions options) : base(options) { }
        public DbSet<Models.Zadanie> Results { get; set; }
    }
}
