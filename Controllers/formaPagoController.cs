using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1api_eventosDeportivos.Models;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraDeporte;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraEvento;
using static WebApplication1api_eventosDeportivos.Models.EventosDeportivos.csEstructuraFormaPago;

namespace WebApplication1api_eventosDeportivos.Controllers
{
    public class formaPagoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarFormaPago")]
        public IHttpActionResult insertarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().insertarFormaPago(model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/actualizarFormaPago")]
        public IHttpActionResult actualizarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().actualizarFormaPago(model.idFormaPago, model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/eliminarFormaPago")]
        public IHttpActionResult eliminarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().eliminarFormaPago(model.idFormaPago));
        }

        [HttpGet]
        [Route("rest/api/listarFormaPago")]
        public IHttpActionResult listarFormaPago()
        {
            return Ok(new csFormaPago().listarFormaPago());
        }

        [HttpGet]
        [Route("rest/api/listarFormaPagoXid")]
        public IHttpActionResult listarFormaPagoXid(string idFormaPago)
        {
            return Ok(new csFormaPago().listarFormaPagoXid(idFormaPago));
        }
    }
}