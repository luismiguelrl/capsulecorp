namespace CapsuleCorp.Traffic.Transit.Application.Request
{
    public class InformacionSensorRequest
    {
        public int Longitud { get; set; }
        public int Latitud { get; set; }
        public string ImagenUrl { get; set; }
        public int AlturaVuelo { get; set; }
        public int Velocidad { get; set; }
        //public string Matricula { get; set; }
        public int CiudadId { get; set; }
    }
}
