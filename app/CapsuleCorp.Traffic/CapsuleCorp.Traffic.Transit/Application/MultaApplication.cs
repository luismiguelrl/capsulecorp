namespace CapsuleCorp.Traffic.Transit.Application
{
    using CapsuleCorp.Traffic.Transit.Application.Dto;
    using CapsuleCorp.Traffic.Transit.Application.Request;
    using CapsuleCorp.Traffic.Transit.Infraestructure.Persistence.Repositories;
    using CapsuleCorp.Traffic.Transit.Infraestructure.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class MultaApplication : IMultaApplication
    {
        private readonly IMultaRepository multaRepository;
        public MultaApplication(IMultaRepository multaRepository)
        {
            this.multaRepository = multaRepository;
        }

        public LevantarMultaResult LevantarMulta(string matricula, InformacionSensorRequest request)
        {            
            CityResult city = this.multaRepository.GetCity(request.Latitud, request.Longitud);
         
            TrafficFineResult AddTrafictFine = new()
            {
                CiudadAsignadaId = city.CiudadId,
                Distancia = request.AlturaVuelo,
                Matricula = matricula,
                Valida = (request.Velocidad > 120 || request.AlturaVuelo > 50),
                Altura = request.AlturaVuelo,
                Imagen = request.ImagenUrl,
                Velocidad = request.Velocidad
            };

            this.multaRepository.AddTrafficFine(AddTrafictFine);

            return new LevantarMultaResult()
            {
                Distancia = $"{AddTrafictFine.Distancia}mts",
                CiudadAsignada = city.Ciudad,
                Multa = (AddTrafictFine.Valida) ? Multa.Valida : Multa.Invalida,
                Retornar404 = (matricula.Length != 7 || city.CiudadId == 0)
            };
        }


        public LevantarMultaBatchResult LevantarMultaBatch()
        {
            List<TrafficFineResult> trafficFineResults = this.multaRepository.GetTrafficFineList();
            List<CityResult> cities = this.multaRepository.GetAllCities();

            List<TrafficFineResult> trafficFinesValid = trafficFineResults.Where(t => t.Valida).ToList();
            List<TrafficFineResult> trafficFinesInvalid = trafficFineResults.Where(t => !t.Valida).ToList();

            List<LevantarMultaInfoBatch> infoValidas = this.GetListLevantarMultaInfo(trafficFinesValid, cities);
            List<LevantarMultaInfoBatch> infoInvalidas = this.GetListLevantarMultaInfo(trafficFinesInvalid, cities);

            return new LevantarMultaBatchResult
            {
                multasValidas = infoValidas,
                multasInvalidas = infoInvalidas
            };
        }

        private List<LevantarMultaInfoBatch> GetListLevantarMultaInfo(List<TrafficFineResult> trafficFineResults, List<CityResult> cities)
        {
            List<LevantarMultaInfoBatch> infoValidas = new();

            foreach (TrafficFineResult trafficFine in trafficFineResults)
            {
                CityResult city = cities.FirstOrDefault(c => c.CiudadId == trafficFine.CiudadAsignadaId);
                if (city != null)
                {
                    infoValidas.Add(new LevantarMultaInfoBatch
                    {
                        Matricula = trafficFine.Matricula,
                        Info = new LevantarMultaResult
                        {
                            CiudadAsignada = city.Ciudad,
                            Distancia = $"{trafficFine.Distancia}mts",
                            Multa = trafficFine.Valida ? Multa.Valida : Multa.Invalida
                        }
                    });
                }
            }

            return infoValidas;
        }
    }
}