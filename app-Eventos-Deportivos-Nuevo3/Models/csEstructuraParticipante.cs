using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraParticipante
    {
        public class requestParticipante
        {
            public int idParticipante { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string documento { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public string email { get; set; }
            public int idDeporte { get; set; }
        }
        public class responseParticipante
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarParticipante
        {
            public string idParticipante { get; set; }
        }
    }
}