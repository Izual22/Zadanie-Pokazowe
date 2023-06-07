using EFDemo.Interfaces;
using EFDemo.Models;
using EFDemo.Data;
namespace EFDemo.Services
{
    public class SerwisZadań : InterfejsZadań
    {
        private readonly ResultsContext _contest;
        public SerwisZadań(ResultsContext contest)
        {
            _contest = contest;
        }
        public List<Zadanie> Wszystkie()
        {
            return _contest.Results.ToList();
        }
        public void Dodaj(Models.Zadanie result)
        {
            _contest.Results.Add(result);
            _contest.SaveChanges();
        }
        public void Usuń(int id)
        {
            Models.Zadanie ten = _contest.Results.Find(id);
            if (ten != null)
            {
                _contest.Results.Remove(ten);
                _contest.SaveChanges();
            }
        }
        public void Edit(Models.Zadanie result, int id)
        {
            if (result != null)
            {
                Models.Zadanie ten = _contest.Results.Find(id);
                _contest.Results.Add(result);
                _contest.Results.Remove(ten);
                _contest.SaveChanges();
            }
        }
        public Zadanie Zwroc(int id)
        {
            Models.Zadanie ten = _contest.Results.Find(id);
            return ten;
        }
    }
}
