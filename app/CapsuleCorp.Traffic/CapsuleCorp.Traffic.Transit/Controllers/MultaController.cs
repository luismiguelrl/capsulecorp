using CapsuleCorp.Traffic.Transit.Application;
using CapsuleCorp.Traffic.Transit.Application.Dto;
using CapsuleCorp.Traffic.Transit.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace CapsuleCorp.Traffic.Transit.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MultaController : Controller
    {
        private readonly IMultaApplication multaApplication;

        public MultaController(IMultaApplication multaApplication)
        {
            this.multaApplication = multaApplication;
        }

        [HttpPost]
        public ActionResult<LevantarMultaResult> LevantarMulta(string matricula, [FromBody] InformacionSensorRequest request)
        {
            if (matricula == null) return NotFound();

            LevantarMultaResult result = multaApplication.LevantarMulta(matricula, request);
            if (result.Retornar404)
                return NotFound();

            return result;
        }

        [HttpGet]
        public LevantarMultaBatchResult LevantarMultaBatch()
        {
            return multaApplication.LevantarMultaBatch();
        }

        [HttpGet]
        public LevantarMultaBatchResult Batch()
        {
            return new LevantarMultaBatchResult();
            
        }

    }
}
