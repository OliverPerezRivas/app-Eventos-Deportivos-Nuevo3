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
    public class DeporteController : Controller
    {
        // GET: Deporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deporte(string idDeporte)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idDeporte))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarDeportes";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarDeportesXid?idDeporte=" + idDeporte;

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

        public ActionResult newDeporte()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestDeporte insertar = new requestDeporte();
            insertar.nombre = formCollection["nombre"];
            insertar.categoria = formCollection["categoria"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarDeporte";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseDeporte result = new responseDeporte();
            result = JsonConvert.DeserializeObject<responseDeporte>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Deporte", "Deporte");
            return RedirectToAction("newDeporte", "Deporte");
        }

        public ActionResult ActualizarDeporte(string idDeporte)
        {
            DataSet dsi = new DataSet();
            var url = "http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarDeportesXid?idDeporte=" +idDeporte;


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
            requestDeporte insertar = new requestDeporte();
            insertar.idDeporte = int.Parse(formCollection["idDeporte"]);
            insertar.nombre = formCollection["nombre"];
            insertar.categoria = formCollection["categoria"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarDeporte";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseDeporte result = new responseDeporte();
            result = JsonConvert.DeserializeObject<responseDeporte>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Deporte", "Deporte");
            return RedirectToAction("ActualizarDeporte", "Deporte");
        }

        public ActionResult eliminar(string idDeporte)
        {

            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarDeporte";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarDeporte eliminar = new requestEliminarDeporte();
            eliminar.idDeporte = idDeporte;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responseDeporte result = new responseDeporte();

            result = JsonConvert.DeserializeObject<responseDeporte>(resultJson);
            webClient.Dispose();

            return RedirectToAction("Deporte", "Deporte");
        }


    }
}