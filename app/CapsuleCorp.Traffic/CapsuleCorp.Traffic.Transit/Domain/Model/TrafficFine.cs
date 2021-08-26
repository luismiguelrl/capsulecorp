namespace CapsuleCorp.Traffic.Transit.Domain.Model
{
    public class TrafficFine
    {
        public int TrafficFineId { get; set; }
        public string LicensePlate { get; set; }
        public int Distance { get; set; }
        public bool Valid { get; set; }
        public int AssignedCityId { get; set; }
        public string Image { get; set; }
        public int FlightAltitude { get; set; }
        public int Speed { get; set; }
    }
}
