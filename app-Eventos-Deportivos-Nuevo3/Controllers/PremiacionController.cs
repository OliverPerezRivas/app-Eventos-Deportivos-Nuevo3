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
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraPremiacion;

namespace app_Eventos_Deportivos_Nuevo3.Controllers
{
    public class PremiacionController : Controller
    {
        // GET: Premiacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Premiacion(string idPremiacion)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idPremiacion))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarPremiacion";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarPremiacionXid?idPremiacion=" + idPremiacion;

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

        public ActionResult newPremiacion()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestPremiacion insertar = new requestPremiacion();
            insertar.idEvento = int.Parse(formCollection["idEvento"]);
            insertar.idParticipante = int.Parse(formCollection["idParticipante"]);
            insertar.puesto = int.Parse(formCollection["puesto"]);
            insertar.premio = formCollection["premio"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarPremiacion";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responsePremiacion result = new responsePremiacion();
            result = JsonConvert.DeserializeObject<responsePremiacion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Premiacion", "Premiacion");
            return RedirectToAction("newPremiacion", "Premiacion");
        }

        public ActionResult ActualizarPremiacion(string idPremiacion)
        {
            DataSet dsi = new DataSet();
            var url = "http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarPremiacionXid?idPremiacion=" + idPremiacion;


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
            requestPremiacion insertar = new requestPremiacion();
            insertar.idPremiacion = int.Parse(formCollection["idPremiacion"]);
            insertar.idEvento = int.Parse(formCollection["idEvento"]);
            insertar.idParticipante = int.Parse(formCollection["idParticipante"]);
            insertar.puesto = int.Parse(formCollection["puesto"]);
            insertar.premio = formCollection["premio"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarPremiacion";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responsePremiacion result = new responsePremiacion();
            result = JsonConvert.DeserializeObject<responsePremiacion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Premiacion", "Premiacion");
            return RedirectToAction("ActualizarPremiacion", "Premiacion");
        }

        public ActionResult eliminar(string idPremiacion)
        {

            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarPremiacion";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarPremiacion eliminar = new requestEliminarPremiacion();
            eliminar.idPremiacion = idPremiacion;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responsePremiacion result = new responsePremiacion();

            result = JsonConvert.DeserializeObject<responsePremiacion>(resultJson);
            webClient.Dispose();

            return RedirectToAction("Premiacion", "Premiacion");
        }
    }
}