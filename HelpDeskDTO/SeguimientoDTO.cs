using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDeskDTO
{
    public class SeguimientoDTO
    {
        public int IdSeg { get; set; }
        public SdsDTO SDS { get; set; }
        public DateTime? Fec_Seg { get; set; }
        public String Detalle { get; set; }
        public String Nom_Usu_Seg { get; set; }

        public override string ToString()
        {
            return String.Format("IdSeg: {0}, fec_seg: {1}, detalle: {2}, nom_usu_seg: {3}, sds => [{4}]",
                IdSeg, Fec_Seg, Detalle, Nom_Usu_Seg, SDS.ToString());
        }
    }
}
