using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDeskDTO
{
    public class SdsDTO
    {
        public int IdSds { get; set; }
        public ESTADOS Estado { get; set; }
        public string Asunto { get; set; }
        public String Detalle { get; set; }
        public DateTime? Fec_Crea { get; set; }
        public DateTime? Fec_Cierre { get; set; }
        public DateTime? Fec_Comp { get; set; }
        public String Nom_Usu_Crea { get; set; }
        public String Nom_Usu_Resp { get; set; }

        public SdsDTO() {

            Fec_Crea = DateTime.Now;
            Estado = ESTADOS.abierta;
        }

        public override string ToString()
        {
            return String.Format("id_sds: {0}, estado: {1}, asunto: {2}, detalle: {3}, fec_crea: {4}, fec_cierre: {5}, fec_comp: {6}, nom_usu_crea: {7}, nom_usu_resp: {8}",
                IdSds, Estado, Asunto, Detalle, Fec_Crea, Fec_Cierre, Fec_Comp, Nom_Usu_Crea, Nom_Usu_Resp);
        }

    }
}
