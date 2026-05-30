using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraEvento;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class eventoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarEvento")]
        public IHttpActionResult insertarEvento(requestEvento model)
        {
            return Ok(new csEvento().insertarEvento(model.nombre, model.fecha, model.lugar, model.idDeporte, model.costo));
        }

        [HttpPost]
        [Route("rest/api/actualizarEvento")]
        public IHttpActionResult actualizarEvento(requestEvento model)
        {
            return Ok(new csEvento().actualizarEvento(model.idEvento, model.nombre, model.fecha, model.lugar, model.idDeporte, model.costo));
        }

        [HttpPost]
        [Route("rest/api/eliminarEvento")]
        public IHttpActionResult eliminarEvento(requestEvento model)
        {
            return Ok(new csEvento().eliminarEvento(model.idEvento));
        }

        [HttpGet]
        [Route("rest/api/listarEventos")]
        public IHttpActionResult listarEventos()
        {
            return Ok(new csEvento().listarEvento());
        }

        [HttpGet]
        [Route("rest/api/listarEventosXid")]
        public IHttpActionResult listarEventosXid(string idEvento)
        {
            return Ok(new csEvento().listarEventoXid(idEvento));
        }
    }
}
