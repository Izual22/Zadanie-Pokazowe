using EFDemo.Models;

namespace EFDemo.Interfaces
{
    public interface InterfejsZadań
    {
        public List<Models.Zadanie> Wszystkie();
        public void Dodaj(Models.Zadanie result);
        public void Usuń(int id);
        public void Edit(Models.Zadanie result, int id);
        public Zadanie Zwroc(int id);
    }
}
