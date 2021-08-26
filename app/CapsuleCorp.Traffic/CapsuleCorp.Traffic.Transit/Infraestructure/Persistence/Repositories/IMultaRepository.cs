namespace CapsuleCorp.Traffic.Transit.Infraestructure.Persistence.Repositories
{
    using CapsuleCorp.Traffic.Transit.Application.Dto;
    using CapsuleCorp.Traffic.Transit.Domain.Model;
    using System.Collections.Generic;

    public interface IMultaRepository
    {
        List<CityResult> GetAllCities();
        CityResult GetCity(int latitud, int longitud);
        void AddTrafficFine(TrafficFineResult trafficFine);
        List<TrafficFineResult> GetTrafficFineList();
    }
}
