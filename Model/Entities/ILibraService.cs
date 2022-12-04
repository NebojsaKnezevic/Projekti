
namespace AspNetCoreWithReact.Model.Entities
{
    public interface ILibraService
    {
        void Delete(int id);
        List<Libra> GetAll();
        List<Libra> GetByName(string name);
        Libra Save(Libra libra);
        Libra Update(Libra libra);
        List<Libra> SaveAll(List<Libra> LibraList);
    }
}