using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapsuleCorp.Traffic.Transit.Application.Dto
{
    public class TrafficFineResult
    {
        
        public string Matricula { get; set; }
        public int Distancia { get; set; }
        public bool Valida { get; set; }
        public int CiudadAsignadaId { get; set; }
        public string Imagen { get; set; }
        public int Altura { get; set; }
        public int Velocidad { get; set; }
    }
}
