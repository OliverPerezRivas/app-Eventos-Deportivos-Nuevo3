using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_Eventos_Deportivos_Nuevo3.Models
{
    public class csEstructuraPremiacion
    {
        public class requestPremiacion
        {
            public int idPremiacion { get; set; }
            public int idEvento { get; set; }
            public int idParticipante { get; set; }
            public int puesto { get; set; }
            public string premio { get; set; }
        }
        public class responsePremiacion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarPremiacion
        {
            public string idPremiacion { get; set; }
        }
    }
}