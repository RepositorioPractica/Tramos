using flor.Interfaces;
using flor.Repositories;
using flor.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class GeometriaController  : ControllerBase
    {

        private readonly IGeometriaRepository _geometriaRepository;

        public GeometriaController(IGeometriaRepository geometriaRepository)
        {
            _geometriaRepository = geometriaRepository;
        }

        [HttpPost]
        public ActionResult<Boolean> InsertarDatosEnBd()
        {
            Boolean ingresado = _geometriaRepository.insertarGeometria();

            return ingresado ? Ok("Ingresado") : BadRequest("Exploto");
        }
    }
}
