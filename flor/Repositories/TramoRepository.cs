using flor.Db;
using flor.Entities;
using flor.Interfaces;
using flor.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace flor.Repositories
{
    public class TramoRepository : ITramoRepository
    {
        private readonly ApplicationDbContext _context;

        public TramoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool InsertarBd()
        {
            StreamReader r = new StreamReader("Data/geoSimplify.json");
            string jsonString = r.ReadToEnd();
            List<JsonTramo> Objetos = Helper.TransformaJson(jsonString);

            foreach (var obj in Objetos)
            {
                Tramo tramo = new() {Id = obj.IdTramo };

                _context.Tramos.Add(tramo);
            }

            _context.SaveChanges();

            return true; 
        }


        public async Task<Tramo> GetTramoById(int id)//async
        {
            return _context.Tramos.Include(p => p.Geometrias).FirstOrDefault(b => b.Id == id);
        }
    }
}
