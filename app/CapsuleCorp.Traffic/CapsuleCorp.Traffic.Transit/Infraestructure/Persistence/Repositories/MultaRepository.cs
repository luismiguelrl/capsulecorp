namespace CapsuleCorp.Traffic.Transit.Infraestructure.Persistence.Repositories
{
    using CapsuleCorp.Traffic.Transit.Application.Dto;
    using CapsuleCorp.Traffic.Transit.Domain.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class MultaRepository : IMultaRepository
    {
        private readonly CapsuleCorpContext dbContext;
        public MultaRepository(CapsuleCorpContext capsuleCorpContext)
        {
            this.dbContext = capsuleCorpContext;
        }

        public CityResult GetCity(int latitud, int longitud)
        {
            CityResult result = new();

            City city = (from c in dbContext.City
                         where c.Latitude == latitud &&
                         c.Longitude == longitud
                         select c).FirstOrDefault();

            if (city != null)
            {
                result.CiudadId = city.CityId;
                result.Ciudad = city.Name;
                result.Latitud = city.Latitude;
                result.Longitud = city.Longitude;
            }
            return result;
        }

        public List<CityResult> GetAllCities()
        {
            return dbContext.City.Select(c =>
            new CityResult
            {
                Ciudad = c.Name,
                CiudadId = c.CityId
            }).ToList();
        }

        public void AddTrafficFine(TrafficFineResult trafficFine)
        {
            dbContext.TrafficFine.Add(new TrafficFine
            {
                AssignedCityId = trafficFine.CiudadAsignadaId,
                Distance = trafficFine.Distancia,
                LicensePlate = trafficFine.Matricula,
                Valid = trafficFine.Valida,
                FlightAltitude = trafficFine.Altura,
                Image = trafficFine.Imagen,
                Speed = trafficFine.Velocidad
            });
            dbContext.SaveChanges();
        }

        public List<TrafficFineResult> GetTrafficFineList()
        {
            return dbContext.TrafficFine.Select(t =>
            new TrafficFineResult
            {
                CiudadAsignadaId = t.AssignedCityId,
                Distancia = t.Distance,
                Matricula = t.LicensePlate,
                Valida = t.Valid
            }).ToList();
        }
    }
}
