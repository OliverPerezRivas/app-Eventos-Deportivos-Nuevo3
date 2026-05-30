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

namespace app_Eventos_Deportivos_Nuevo3.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Evento(string idEventon)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idEventon))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarEventos";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarEventosXid?idEvento=" + idEventon;

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

        public ActionResult newEvento()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestEvento insertar = new requestEvento();
            insertar.nombre = formCollection["nombre"];
            insertar.fecha = DateTime.Parse(formCollection["fecha"]);
            insertar.lugar = formCollection["lugar"];
            insertar.idDeporte = int.Parse(formCollection["idDeporte"]);
            insertar.costo = int.Parse(formCollection["costo"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarEvento";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseEvento result = new responseEvento();
            result = JsonConvert.DeserializeObject<responseEvento>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Evento", "Evento");
            return RedirectToAction("newEvento", "Evento");
        }

        public ActionResult ActualizarEvento(string idEvento)
        {
            DataSet dsi = new DataSet();
            var url = "http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarEventosXid?idEvento=" + idEvento;


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
            catch (WebException ex)
            {

            }

            return View(dsi);
        }

        public ActionResult actualizar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestEvento insertar = new requestEvento();
            insertar.idEvento = int.Parse(formCollection["idEvento"]);
            insertar.nombre = formCollection["nombre"];
            insertar.fecha = DateTime.Parse(formCollection["fecha"]);
            insertar.lugar = formCollection["lugar"];
            insertar.idDeporte = int.Parse(formCollection["idDeporte"]);
            insertar.costo = int.Parse(formCollection["costo"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarEvento";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseEvento result = new responseEvento();
            result = JsonConvert.DeserializeObject<responseEvento>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Evento", "Evento");
            return RedirectToAction("ActualizarEvento", "Evento");
        }

        
        public ActionResult eliminar(string idEvento)
        {
            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarEvento";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarEvento eliminar = new requestEliminarEvento();
            eliminar.idEvento = idEvento;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responseEvento result = new responseEvento();

            result = JsonConvert.DeserializeObject<responseEvento>(resultJson);
            webClient.Dispose();

            return RedirectToAction("Evento", "Evento");
        }



    }
}