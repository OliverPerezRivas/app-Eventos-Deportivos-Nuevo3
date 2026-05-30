using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraEvento;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraInscripcion;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class inscripcionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarInscripcion")]
        public IHttpActionResult insertarInscripcion(requestInscripcion model)
        {
            return Ok(new csInscripcion().insertarInscripcion(model.idParticipante, model.idEvento, model.idFormaPago, model.fechaInscripcion, model.montoPagado));
        }

        [HttpPost]
        [Route("rest/api/actualizarInscripcion")]
        public IHttpActionResult actualizarInscripcion(requestInscripcion model)
        {
            return Ok(new csInscripcion().actualizarInscripcion(model.idInscripcion, model.idParticipante, model.idEvento, model.idFormaPago, model.fechaInscripcion, model.montoPagado));
        }

        [HttpPost]
        [Route("rest/api/eliminarInscripcion")]
        public IHttpActionResult eliminarInscripcion(requestInscripcion model)
        {
            return Ok(new csInscripcion().eliminarInscripcion(model.idInscripcion));
        }

        [HttpGet]
        [Route("rest/api/listarInscripciones")]
        public IHttpActionResult listarInscripciones()
        {
            return Ok(new csInscripcion().listarInscripcion());
        }

        [HttpGet]
        [Route("rest/api/listarInscripcionesXid")]
        public IHttpActionResult listarInscripcionesXid(string idInscripcion)
        {
            return Ok(new csInscripcion().listarInscripcionXid(idInscripcion));
        }
    }
}