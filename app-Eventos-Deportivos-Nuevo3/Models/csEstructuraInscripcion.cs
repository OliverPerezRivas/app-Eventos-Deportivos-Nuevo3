using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraInscripcion
    {
        public class requestInscripcion
        {
            public int idInscripcion { get; set; }
            public int idParticipante { get; set; }
            public int idEvento { get; set; }
            public int idFormaPago { get; set; }
            public DateTime fechaInscripcion { get; set; }
            public int montoPagado { get; set; }
        }
        public class responseInscripcion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarInscripcion
        {
            public string idInscripcion { get; set; }
        }
    }
}