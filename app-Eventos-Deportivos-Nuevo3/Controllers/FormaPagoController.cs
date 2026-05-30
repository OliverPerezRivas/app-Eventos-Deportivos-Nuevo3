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
using static app_Eventos_Deportivos_Nuevo3.Models.csEstructuraFormaPago;

namespace app_Eventos_Deportivos_Nuevo3.Controllers
{
    public class FormaPagoController : Controller
    {
        // GET: FormaPago
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormaPago(string idFormaPago)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (string.IsNullOrEmpty(idFormaPago))
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarFormaPago";
            else
                url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarFormaPagoXid?idFormaPago=" + idFormaPago;

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

        public ActionResult newFormaPago()
        {
            return View();
        }

        public ActionResult guardar(FormCollection formCollection)
        {
            string json, resultJson;
            byte[] reqString, resbyte;
            requestFormaPago insertar = new requestFormaPago();
            insertar.descripcion= formCollection["descripcion"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/insertarFormaPago";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseFormaPago result = new responseFormaPago();
            result = JsonConvert.DeserializeObject<responseFormaPago>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("FormaPago", "FormaPago");
            return RedirectToAction("newFormaPago", "FormaPago");
        }

        public ActionResult ActualizarFormaPago(string idFormaPago)
        {
            DataSet dsi = new DataSet();

            var url = "http://localhost/WebApplication1api-eventosDeportivos/rest/api/listarFormaPagoXid?idFormaPago=" + idFormaPago;


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
            requestFormaPago insertar = new requestFormaPago();
            insertar.idFormaPago = int.Parse(formCollection["idFormaPago"]);
            insertar.descripcion = formCollection["descripcion"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/actualizarFormaPago";
            var request = (HttpWebRequest)WebRequest.Create(url);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resbyte = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resbyte);

            responseFormaPago result = new responseFormaPago();
            result = JsonConvert.DeserializeObject<responseFormaPago>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("FormaPago", "FormaPago");
            return RedirectToAction("ActualizarFormaPago", "FormaPago");
        }

        public ActionResult eliminar(string idFormaPago)
        {

            string json, resultJson;
            Byte[] resBytes, reqString;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/WebApplication1api-eventosDeportivos/rest/api/eliminarFormaPago";
            var request = (HttpWebRequest)WebRequest.Create(url);

            requestEliminarFormaPago eliminar = new requestEliminarFormaPago();
            eliminar.idFormaPago = idFormaPago;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";


            reqString = Encoding.UTF8.GetBytes(json);
            resBytes = webClient.UploadData(request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resBytes);

            responseFormaPago result = new responseFormaPago();

            result = JsonConvert.DeserializeObject<responseFormaPago>(resultJson);
            webClient.Dispose();

            return RedirectToAction("FormaPago", "FormaPago");
        }
    }
}