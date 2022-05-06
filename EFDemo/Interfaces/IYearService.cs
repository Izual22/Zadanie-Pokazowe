using EFDemo.Models;

namespace EFDemo.Interfaces
{
    public interface IYearService
    {
        public List<Result> GetAllEntries();
        public void AddNewEntry(Result result);
    }
}
