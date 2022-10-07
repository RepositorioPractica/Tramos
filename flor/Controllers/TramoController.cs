using flor.Entities;
using flor.Interfaces;
using flor.Repositories;
using flor.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace flor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramoController : ControllerBase
    {
        private readonly ITramoRepository _tramoRepository;

        public TramoController(ITramoRepository tramoRepository)
        {
            _tramoRepository = tramoRepository;
        }

        [HttpPost]
        public ActionResult<Boolean> InsertarDatosEnBd()
        {
            Boolean ingresado = _tramoRepository.InsertarBd();

            return ingresado ? Ok("Ingresado") : BadRequest("Exploto");
        }


        [HttpGet("{id}")]
        [ActionName(nameof(GetTramoById))]
        public ActionResult<Task<Tramo>> GetTramoById(int id)
        {
            var productByID = _tramoRepository.GetTramoById(id);
            if (productByID == null)
            {
                return NotFound();
            }
            // return Ok("Oki");
            return productByID;

            //ViewData["Nombre"] = productByID;
            return View();
        }
    }
}
