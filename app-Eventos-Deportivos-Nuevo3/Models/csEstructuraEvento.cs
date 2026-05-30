using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraEvento
    {
        public class requestEvento
        {
            public int idEvento { get; set; }
            public string nombre { get; set; }
            public DateTime fecha { get; set; }
            public string lugar { get; set; }
            public int idDeporte { get; set; }
            public int costo { get; set; }
        }
        public class responseEvento
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarEvento
        {
            public string idEvento { get; set; }
        }
    }
}