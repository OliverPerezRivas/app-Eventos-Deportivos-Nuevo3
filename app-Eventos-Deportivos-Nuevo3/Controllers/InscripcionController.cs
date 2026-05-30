using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraDeporte;
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraEvento;
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraInscripcion;

namespace app_Eventos_Deportivos_Nuevo3.Controllers
{
    public class InscripcionController : Controller
    {
        // GET: Inscripcion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inscripcion(string idInscripcion)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idInscripcion))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarInscripciones";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarInscripcionesXid?idInscripcion=" + idInscripcion;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string responseBody;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                    dsi = JsonConvert.DeserializeObject<DataSet>(responseBody);
                }
            }
            catch (Exception ex)
            {

            }

            return View(dsi);
        }

        public ActionResult newInscripcion()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestInscripcion insertar = new requestInscripcion();
            insertar.idParticipante = int.Parse(formCollection["idParticipante"]);
            insertar.idEvento = int.Parse(formCollection["idEvento"]);
            insertar.idFormaPago = int.Parse(formCollection["idFormaPago"]);
            insertar.fechaInscripcion = DateTime.Parse(formCollection["fechaInscripcion"]);
            insertar.montoPagado = int.Parse(formCollection["montoPagado"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarInscripcion";
            var request = (HttpWebRequest)WebRequest.Create(url);

            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseInscripcion result = new responseInscripcion();
            result = JsonConvert.DeserializeObject<responseInscripcion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Inscripcion", "Inscripcion");
            return RedirectToAction("newInscripcion", "Inscripcion");
        }

        public ActionResult ActualizarInscripcion(string idInscripcion)
        {
            DataSet dsi = new DataSet();

            var url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarInscripcionesXid?idInscripcion=" + idInscripcion;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string responseBody;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                    dsi = JsonConvert.DeserializeObject<DataSet>(responseBody);
                }
            }
            catch (Exception ex)
            {

            }

            return View(dsi);
        }

        public ActionResult actualizar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestInscripcion insertar = new requestInscripcion();
            insertar.idInscripcion = int.Parse(formCollection["idInscripcion"]);
            insertar.idParticipante = int.Parse(formCollection["idParticipante"]);
            insertar.idEvento = int.Parse(formCollection["idEvento"]);
            insertar.idFormaPago = int.Parse(formCollection["idFormaPago"]);
            insertar.fechaInscripcion = DateTime.Parse(formCollection["fechaInscripcion"]);
            insertar.montoPagado = int.Parse(formCollection["montoPagado"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarInscripcion";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseInscripcion result = new responseInscripcion();
            result = JsonConvert.DeserializeObject<responseInscripcion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Inscripcion", "Inscripcion");
            return RedirectToAction("ActualizarInscripcion", "Inscripcion");
        }

        public ActionResult eliminar(string idInscripcion)
        {
            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarInscripcion";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarInscripcion eliminar = new requestEliminarInscripcion();
            eliminar.idInscripcion = idInscripcion;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responseInscripcion result = new responseInscripcion();

            result = JsonConvert.DeserializeObject<responseInscripcion>(resultJson);
            webClient.Dispose();

            return RedirectToAction("Inscripcion", "Inscripcion");
        }
    }
}