using flor.Db;
using flor.Entities;
using flor.Interfaces;
using flor.Utilities;

namespace flor.Repositories
{
    public class GeometriaRepository : IGeometriaRepository
    {

        private readonly ApplicationDbContext _context;

        public GeometriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool insertarGeometria()
        {
            StreamReader r = new StreamReader("Data/geoSimplify.json");
            string jsonString = r.ReadToEnd();
            List<JsonTramo> Objetos = Helper.TransformaJson(jsonString);

            foreach (var obj in Objetos)
            {
                foreach (var geo in obj.Geometria)
                {
                    Geometria geometria = new() { TramoId = obj.IdTramo, Latitude = geo[0], Longitude = geo[1] };


                    _context.Geometrias.Add(geometria);
                }
            }

            _context.SaveChanges();

            return true;
        }
    }
}
