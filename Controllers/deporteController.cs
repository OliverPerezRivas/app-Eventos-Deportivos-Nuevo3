using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraDeporte;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraEvento;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class deporteController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarDeporte")]
        public IHttpActionResult insertarDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().insertarDeporte(model.nombre, model.categoria));
        }

        [HttpPost]
        [Route("rest/api/actualizarDeporte")]
        public IHttpActionResult actualizaDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().actualizarDeporte(model.idDeporte, model.nombre, model.categoria));
        }

        [HttpPost]
        [Route("rest/api/eliminarDeporte")]
        public IHttpActionResult eliminarDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().eliminarDeporte(model.idDeporte));
        }

        [HttpGet]
        [Route("rest/api/listarDeportes")]
        public IHttpActionResult listarDeportes()
        {
            return Ok(new csDeporte().listarDeporte());
        }

        [HttpGet]
        [Route("rest/api/listarDeportesXid")]
        public IHttpActionResult listarDeportesXid(string idDeporte)
        {
            return Ok(new csDeporte().listarDeporteXid(idDeporte));
        }
    }
}