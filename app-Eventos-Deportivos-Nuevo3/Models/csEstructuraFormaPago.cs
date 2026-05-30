

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraFormaPago
    {
        public class requestFormaPago
        {
            public int idFormaPago { get; set; }
            public string descripcion { get; set; }
        }
        public class responseFormaPago
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarFormaPago
        {
            public string idFormaPago { get; set; }
        }
    }
}