namespace CapsuleCorp.Traffic.Transit.Application.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LevantarMultaResult
    {
        public string Distancia { get; set; }
        public string Multa { get; set; }
        public string CiudadAsignada { get; set; }
        public bool Retornar404 { get; set; }
    }
}
