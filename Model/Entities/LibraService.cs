using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithReact.Model.Entities
{
    public class LibraService : ILibraService
    {
        private AppDataContext _context;
        public LibraService(AppDataContext appDataContext)
        {
            _context = appDataContext;
        }

        public List<Libra> GetAll()
        {

            return _context.Libras.ToList();
        }

        public List<Libra> GetByName(string name)
        {
            var linq = from x in _context.Libras select x;

            if (!string.IsNullOrWhiteSpace(name))
            {
                linq = linq.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                //linq = linq.Where(x => x.Name == name);
            }
            return linq.ToList();
        }

        public Libra Save(Libra libra)
        {
            _context.Libras.Add(libra);
            _context.SaveChanges();
            return libra;
        }

        public Libra Update(Libra libra)
        {

            var libraUpdate = _context.Libras.Find(libra.Id);
            libraUpdate.Name = libra.Name;
            libraUpdate.Address = libra.Address;
            libraUpdate.Telephone = libra.Telephone;
            _context.Libras.Update(libraUpdate);

            _context.Entry(libraUpdate).State = EntityState.Modified;
            //_context.Libras.Update(libra);
            _context.SaveChanges();
            return libra;
        }

        public void Delete(int id)
        {
            var x = _context.Libras.Find(id);
            _context.Libras.Remove(x);
            _context.SaveChanges();
        }

        public List<Libra> SaveAll(List<Libra> LibraList)
        {
            _context.Libras.AddRange(LibraList);
            _context.SaveChanges();
            return LibraList;
        }
    }
}
