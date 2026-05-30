using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraInscripcion;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraParticipante;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class participanteController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarParticipante")]
        public IHttpActionResult insertarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().insertarParticipante(model.nombres, model.apellidos, model.documento, model.fechaNacimiento, model.email, model.idDeporte));
        }

        [HttpPost]
        [Route("rest/api/actualizarParticipante")]
        public IHttpActionResult actualizarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().actualizarParticipante(model.idParticipante, model.nombres, model.apellidos, model.documento, model.fechaNacimiento, model.email, model.idDeporte));
        }

        [HttpPost]
        [Route("rest/api/eliminarParticipante")]
        public IHttpActionResult eliminarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().eliminarParticipante(model.idParticipante));
        }

        [HttpGet]
        [Route("rest/api/listarParticipantes")]
        public IHttpActionResult listarParticipantes()
        {
            return Ok(new csParticipante().listarParticipante());
        }

        [HttpGet]
        [Route("rest/api/listarParticipantesXid")]
        public IHttpActionResult listarParticipantesXid(string idParticipante)
        {
            return Ok(new csParticipante().listarParticipanteXid(idParticipante));
        }
    }
}