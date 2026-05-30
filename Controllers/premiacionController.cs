using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraEvento;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraPremiacion;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class premiacionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarPremiacion")]
        public IHttpActionResult insertarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().insertarPremiacion(model.idEvento, model.idParticipante, model.puesto, model.premio));
        }

        [HttpPost]
        [Route("rest/api/actualizarPremiacion")]
        public IHttpActionResult actualizarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().actualizarPremiacion(model.idPremiacion, model.idEvento, model.idParticipante, model.puesto, model.premio));
        }

        [HttpPost]
        [Route("rest/api/eliminarPremiacion")]
        public IHttpActionResult eliminarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().eliminarPremiacion(model.idPremiacion));
        }

        [HttpGet]
        [Route("rest/api/listarPremiacion")]
        public IHttpActionResult listarPremiacion()
        {
            return Ok(new csPremiacion().listarPremiacion());
        }

        [HttpGet]
        [Route("rest/api/listarPremiacionXid")]
        public IHttpActionResult listarPremiacionXid(string idPremiacion)
        {
            return Ok(new csPremiacion().listarPremiacionXid(idPremiacion));
        }
    }
}