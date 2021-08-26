using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapsuleCorp.Traffic.Transit.Application.Dto
{
    public class CityResult
    {
        public int CiudadId { get; set; }
        public string Ciudad { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
    }
}
