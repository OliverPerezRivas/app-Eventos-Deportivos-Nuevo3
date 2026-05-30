using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraDeporte
    {
        public class requestDeporte
        {
            public int idDeporte { get; set; }
            public string nombre { get; set; }
            public string categoria { get; set; }
        }
        public class responseDeporte
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarDeporte
        {
            public string idDeporte { get; set; }
        }
    }
}