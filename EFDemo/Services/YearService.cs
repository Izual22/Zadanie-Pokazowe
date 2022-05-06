using EFDemo.Interfaces;
using EFDemo.Models;
using EFDemo.Data;
namespace EFDemo.Services
{
    public class YearService : IYearService
    {
        private readonly ResultsContext _context;
        public YearService(ResultsContext contest)
        {
            _context = contest;
        }
        public List<Result> GetAllEntries()
        {
            return _context.Results.ToList();
        }
        public void AddNewEntry(Result result)
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }
    }
}
