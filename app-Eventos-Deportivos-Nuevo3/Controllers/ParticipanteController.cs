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
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraParticipante;

namespace app_Eventos_Deportivos_Nuevo3.Controllers
{
    public class ParticipanteController : Controller
    {
        // GET: p
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Participante(string idParticipante)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idParticipante))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarParticipantes";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarParticipantesXid?idParticipante=" + idParticipante;

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

        public ActionResult newParticipante()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestParticipante insertar = new requestParticipante();
            insertar.nombres = formCollection["nombres"];
            insertar.apellidos = formCollection["fecha"];
            insertar.documento = formCollection["documento"];
            insertar.fechaNacimiento = DateTime.Parse(formCollection["fechaNacimiento"]);
            insertar.email = formCollection["email"];
            insertar.idDeporte = int.Parse(formCollection["idDeporte"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarParticipante";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseParticipante result = new responseParticipante();
            result = JsonConvert.DeserializeObject<responseParticipante>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Participante", "Participante");
            return RedirectToAction("newParticipante", "Participante");
        }

        public ActionResult ActualizarParticipante(string idParticipante)
        {
            DataSet dsi = new DataSet();
            var url = "http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarParticipantesXid?idParticipante=" + idParticipante;


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
            requestParticipante insertar = new requestParticipante();
            insertar.idParticipante = int.Parse(formCollection["idParticipante"]);
            insertar.nombres = formCollection["nombres"];
            insertar.apellidos = formCollection["apellidos"];
            insertar.documento = formCollection["documento"];
            insertar.fechaNacimiento = DateTime.Parse(formCollection["fechaNacimiento"]);
            insertar.email = formCollection["email"];
            insertar.idDeporte = int.Parse(formCollection["idDeporte"]);
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarParticipante";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseParticipante result = new responseParticipante();
            result = JsonConvert.DeserializeObject<responseParticipante>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("Participante", "Participante");
            return RedirectToAction("ActualizarParticipante", "Participante");
        }

        public ActionResult eliminar(string idParticipante)
        {

            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarParticipante";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarParticipante eliminar = new requestEliminarParticipante();
            eliminar.idParticipante = idParticipante;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responseParticipante result = new responseParticipante();

            result = JsonConvert.DeserializeObject<responseParticipante>(resultJson);
            webClient.Dispose();

            return RedirectToAction("Participante", "Participante");
        }
    }
}